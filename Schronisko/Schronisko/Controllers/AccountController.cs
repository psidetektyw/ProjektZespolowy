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

        public ActionResult Register()
        {
            UsersModel model = new UsersModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UsersModel model)
        {
            if (ModelState.IsValid)
            {
                model.password = MD5Helper.MD5Hash(model.password); // hashowanie hasła
                pszczupakEntities ent = new pszczupakEntities();
                Users u = model.ToUsers();
                u.role = "user";
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
        public ActionResult EditUser()
        {
            pszczupakEntities ent = new pszczupakEntities();
            UsersModel model = new UsersModel(ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault());



            return View(model);
        }


        [HttpPost]
        public ActionResult EditUser(UsersModel user)
        {
            if (ModelState.IsValid) // jezeli spelnia atrybuty, walidatory np. Required
            {
                pszczupakEntities ent = new pszczupakEntities();
                Users u = user.ToUsers();
                
                ent.Entry(ent.Users.Where(x => x.id == u.id).First()).CurrentValues.SetValues(u);
                ent.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(user);
            }

        }



        [HttpGet]
        public ActionResult UserDetails()
        {

            pszczupakEntities ent = new pszczupakEntities();
            UsersModel model = new UsersModel(ent.Users.Where(x => x.login == User.Identity.Name).FirstOrDefault());

            return View(model);

        }




    }
}