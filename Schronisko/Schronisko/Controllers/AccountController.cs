using Schronisko.Helpers;
using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Schronisko.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                model.password = MD5Helper.MD5Hash(model.password); // hashowanie hasła
                pszczupakEntities ent = new pszczupakEntities();
                Users u = new Users();

                u.login = model.login;
                u.password = model.password;
                u.email = model.email;
                u.role = "user";
                u.name = model.login;

                ent.Users.Add(u);
                ent.SaveChanges();

                return RedirectToAction("Login", "Account");
            }

            else {
                return View(model);
            }
            
        }

        public ActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            model.password = MD5Helper.MD5Hash(model.password); // hashowanie hasła
            bool flaga = logowanie(model.login,model.password);
            if (flaga == false) {   return View();  }
            return RedirectToAction("Index", "Home");
    
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            // usuwam cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);
            Response.Redirect("../Home");
            return View();
        }



        public bool logowanie(string username, string password)
        {


            pszczupakEntities ent = new pszczupakEntities();

            var Usr = ent.Users.Where(x => x.password == password && x.login == username).FirstOrDefault();
            
            if (Usr != null)
            {

                //autentykacja metoda forms
                if (Usr.role == null) Usr.role = "";
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,

                            Usr.login,

                            DateTime.Now,

                            DateTime.Now.AddDays(1),

                            true,

                            Usr.role,

                            FormsAuthentication.FormsCookiePath);



                // Kodowanie biletu

                string encTicket = FormsAuthentication.Encrypt(ticket);



                // Tworze ciasteczko
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                return true;

            }

            return false;

        }


        [Authorize]
        [HttpGet]
        public ActionResult EditUser()
        {
            pszczupakEntities ent = new pszczupakEntities();
            EditUserModel model = new EditUserModel();
            Users u = ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault();

            model.id = u.id;
            model.name = u.name;
            model.surname = u.surname;
            model.pesel = u.pesel;
            model.city = u.city;
            model.street = u.street;
            model.house = u.house;
            model.phone = u.phone;


            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditUser(EditUserModel user)
        {
            if (ModelState.IsValid) 
            {
                pszczupakEntities ent = new pszczupakEntities();
                Users u = ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault();

                u.name = user.name;
                u.surname = user.surname;
                u.pesel = user.pesel;
                u.city = user.city;
                u.street = user.street;
                u.house = user.house;
                u.phone = user.phone;

                ent.Entry(ent.Users.Where(x => x.id == u.id).First()).CurrentValues.SetValues(u);
                ent.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(user);
            }

        }


        [Authorize]
        [HttpGet]
        public ActionResult UserDetails()
        {

            pszczupakEntities ent = new pszczupakEntities();
            UserViewModel model = new UserViewModel(ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault());

            return View(model);

        }



        [Authorize]
        [HttpGet]
        public ActionResult EditEmail()
        {
            pszczupakEntities ent = new pszczupakEntities();
            EditEmailModel model = new EditEmailModel();
            Users u = ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault();

            model.id = u.id;
            model.email = u.email;
          



            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditEmail(EditEmailModel model)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                Users u = ent.Users.Where(x => x.id == model.id).FirstOrDefault();
                u.email = model.email;
                ent.SaveChanges();
                return RedirectToAction("UserDetails", "Account");
            }
            else
            {
                return View(model);
            }

        }



/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
     
        [HttpGet]
        public ActionResult ResetPassword()
        {
            EditEmailModel model = new EditEmailModel();
            return View(model);
        }
/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
/// 

      
        [HttpPost]
        public ActionResult ResetPassword(EditEmailModel model)  //View BAG 
        {
            Guid g = Guid.NewGuid();
            pszczupakEntities ent = new pszczupakEntities();
            Users u = ent.Users.Where(x => x.email == model.email).FirstOrDefault();
            if (u != null)
            {
                u.reset_hash = g.ToString();
                ent.SaveChanges();
                MailHelper.SendMessage(model.email, "Twój kod to resetowania hasła: " + g.ToString(), "Reset hasła na portalu schronisko");
                return View("ResetPasswordAfter");
            }

            else {
                ViewBag.reset = "Nie ma takiego Email w bazie spróbuj ponownie";
                return View(model); }


        }


/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>

   
        [HttpGet]
        public ActionResult ResetPasswordCheckGuid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPasswordCheckGuid(string guid, string email, string password)
        {
            pszczupakEntities ent = new pszczupakEntities();
            Users u = ent.Users.Where(x => x.email == email && x.reset_hash == guid).FirstOrDefault();
            if (u != null)
            {
                u.password = MD5Helper.MD5Hash(password);
                u.reset_hash = null;
                ent.SaveChanges();
                return RedirectToAction("Login");
            }

            else {

                return View(guid, email, password);

            }


            }

    }
}