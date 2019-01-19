using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schronisko.Helpers;
using Schronisko.Models;


namespace Schronisko.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult UsersList()
        {
            pszczupakEntities ent = new pszczupakEntities();

            List<UsersModel> users = new List<UsersModel>();

            foreach (Users u in ent.Users.ToList())
            {
                UsersModel p = new UsersModel(u);

                users.Add(p);

            }

            return View(users);
        }

        [HttpGet]
        public ActionResult UsersRole()
        {
            pszczupakEntities ent = new pszczupakEntities();

            List<UsersModel> users = new List<UsersModel>();

            foreach (Users u in ent.Users.ToList())
            {
                UsersModel p = new UsersModel(u);


                if (User.Identity.Name != p.login) { users.Add(p); }
                //  users.Add(p);

            }

            return View(users);

        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {

            pszczupakEntities ent = new pszczupakEntities();

            ViewBag.UserId = id;
      


            var b = new List<SelectListItem>
            {
                new SelectListItem { Text = "admin", Value = "admin"},
                new SelectListItem { Text = "manager", Value = "manager"},
                new SelectListItem { Text = "worker", Value = "worker"},
                new SelectListItem { Text = "user", Value = "user"}
            };

            ViewData["Roles"] = b;




            UsersModel user = new UsersModel(ent.Users.Where(x => x.id == id).FirstOrDefault());



            return View(user);

        }


        [HttpPost]

        public ActionResult EditRole(UsersModel user)
        {
            if (ModelState.IsValid) // jezeli spelnia atrybuty, walidatory np. Required
            {
                pszczupakEntities ent = new pszczupakEntities();
                Users u = ent.Users.Where(x => x.id == user.id).FirstOrDefault();
                u.role = user.role;


                ent.Entry(ent.Users.Where(x => x.id == u.id).First()).CurrentValues.SetValues(u);
                ent.SaveChanges();
                return RedirectToAction("UsersRole");
            }
            else
            {
                return View(user);
            }




        }


        [HttpGet]
       public ActionResult DeleteUser(int id) {

            pszczupakEntities ent = new pszczupakEntities();
            Users user = ent.Users.Where(x => x.id == id).First();
            ent.Users.Remove(user);
            ent.SaveChanges();


            return RedirectToAction("UsersRole");
        }


    }
}