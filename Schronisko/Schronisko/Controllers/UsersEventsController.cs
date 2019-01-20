using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schronisko;
using Schronisko.Models;
using Schronisko.Helpers;

namespace Schronisko.Controllers
{
    public class UsersEventsController : Controller
    {
        
        public ActionResult Index()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<UsersEventsModel> ue = new List<UsersEventsModel>();


            foreach (UsersEvents m in ent.UsersEvents.ToList())
            {
                ue.Add(new UsersEventsModel(m));
            }





            return View(ue);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {

            if (UserHelper.GetUserRole(User.Identity.Name) == "" || User == null)
            {
                return RedirectToAction("Index", "Home");
            }

            UsersEventsModel e = new UsersEventsModel();


            pszczupakEntities ent = new pszczupakEntities();
            ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            ViewData["E"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();

      
            return View(e);

        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(UsersEventsModel e)
        {
          


            pszczupakEntities ent = new pszczupakEntities();

            if (ModelState.IsValid)
            {

             UsersEvents eventt = new UsersEvents();
                eventt.id_event = e.id_event;
                eventt.id_user = e.id_user;
                ent.UsersEvents.Add(eventt);
                ent.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            else
            {
      
                ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
                ViewData["E"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();


                return View(e);
            }


        }




        
        [HttpGet]
        public ActionResult Details(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            UsersEventsModel model = ent.UsersEvents.Where(x => x.id == id).FirstOrDefault().ToUsersEventsModelWithID();
            int eve = ent.UsersEvents.Where(x => x.id == id).Select(x => x.id_event).FirstOrDefault();
            List<int> usersID = ent.UsersEvents.Where(y => y.id_event == eve ).Select(x => x.id_user).ToList();

            List<UserViewModel> users = new List<UserViewModel>();
            UserViewModel user = new UserViewModel();
            foreach (int ID in usersID)
            {
                user = ent.Users.Where(x=> x.id == ID).FirstOrDefault().ToUsersModelWithID();
                users.Add(user);
            }
            
            ViewData["U"] = users;
            return View(model);
            
        }

        




    }
}