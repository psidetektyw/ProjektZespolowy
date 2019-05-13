using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schronisko.Helpers;
using Schronisko.Models;


namespace Schronisko.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
  
        //OK
        [HttpGet]
        public ActionResult UsersList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin")) { return RedirectToAction("Index", "Home"); }

            pszczupakEntities ent = new pszczupakEntities();

            List<UserViewModel> users = new List<UserViewModel>();

            foreach (Users u in ent.Users.ToList())
            {
                UserViewModel p = new UserViewModel(u);

                users.Add(p);

            }

            return View(users);
        }

        //OK
        [HttpGet]
        public ActionResult UsersRole()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin")) { return RedirectToAction("Index", "Home"); }




            pszczupakEntities ent = new pszczupakEntities();

            List<UserViewModel> users = new List<UserViewModel>();

            foreach (Users u in ent.Users.ToList())
            {
                UserViewModel p = new UserViewModel(u);


                if (User.Identity.Name != p.login) { users.Add(p); }
                //  users.Add(p);

            }

            return View(users);

        }

        //OK
        [HttpGet]
        public ActionResult EditRole(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin")) { return RedirectToAction("Index", "Home"); }




            pszczupakEntities ent = new pszczupakEntities();

            var b = new List<SelectListItem>
            {
                new SelectListItem { Text = "admin", Value = "admin"},
                new SelectListItem { Text = "manager", Value = "manager"},
                new SelectListItem { Text = "worker", Value = "worker"},
                new SelectListItem { Text = "user", Value = "user"}
            };

            ViewData["Roles"] = b;

            

            Users u = ent.Users.Where(x => x.id == id).FirstOrDefault();
            EditRoleModel user = new EditRoleModel();

            ViewBag.login  = u.login;

            user.id = id;
            user.role = u.role;
      

            return View(user);

        }


        //OK
        [HttpPost]
        public ActionResult EditRole(EditRoleModel user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin")) { return RedirectToAction("Index", "Home"); }

            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                Users u = new Users();
                u = ent.Users.Where(x => x.id == user.id).FirstOrDefault();

  
                u.role = user.role;
         


                ent.Entry(ent.Users.Where(x => x.id == u.id).First()).CurrentValues.SetValues(u);
                ent.SaveChanges();
                return RedirectToAction("UsersRole");
            }
            else
            {


                pszczupakEntities ent = new pszczupakEntities();
          
                Users u = ent.Users.Where(x => x.id == user.id).FirstOrDefault();

                var b = new List<SelectListItem>
            {
                new SelectListItem { Text = "admin", Value = "admin"},
                new SelectListItem { Text = "manager", Value = "manager"},
                new SelectListItem { Text = "worker", Value = "worker"},
                new SelectListItem { Text = "user", Value = "user"}
            };

                ViewData["Roles"] = b;
                ViewBag.login = u.login;

                return View(user);
            }




        }

        //OK
        [HttpGet]
       public ActionResult DeleteUser(int id) {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin")) { return RedirectToAction("Index", "Home"); }

            pszczupakEntities ent = new pszczupakEntities();
            Users user = ent.Users.Where(x => x.id == id).First();
            ent.Users.Remove(user);
            ent.SaveChanges();


            return RedirectToAction("UsersRole");
        }


    }
}