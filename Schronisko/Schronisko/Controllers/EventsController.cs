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
    public class EventsController : Controller
    {
        private pszczupakEntities db = new pszczupakEntities();

        // GET: EventsModels
        public ActionResult Index()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<EventsModel> events = new List<EventsModel>();

            foreach (Events e in ent.Events.ToList())
                events.Add(e.ToEventsModelWithID());

            return View(events);
        }

        public ActionResult Schedule()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<EventsModel> events = new List<EventsModel>();
            IEnumerable<Events> query = ent.Events.ToList().OrderBy(e => e.date);
            
            foreach (Events e in query)
            {
                if (e.date.CompareTo(DateTime.Now) < 0) {   //jesli starsze niz dzisiaj to usun
                    if(!e.time.Equals("00:00:00.0000000"))                  //jesli czas 0 to trwa caly dzien
                        ent.Events.Remove(e);
                }
                    string eUserLogin = ent.Users.Find(e.id_user).login;
                if (e.id_user == UserHelper.GetUserId(User.Identity.Name))
                    events.Add(e.ToEventsModelWithID());
                //pracownik widzi eventy userow:
                if (UserHelper.GetUserRole(User.Identity.Name) == "worker" && UserHelper.GetUserRole(eUserLogin) == "user")
                    events.Add(e.ToEventsModelWithID());
                if(UserHelper.GetUserRole(User.Identity.Name) == "admin" || UserHelper.GetUserRole(User.Identity.Name) == "manager")
                    events.Add(e.ToEventsModelWithID());
            }
            ent.SaveChanges();
            return View(events);
            //posortowac!!!
        }


        [HttpGet]
        public ActionResult Create()
        {
            //if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") 
            //    && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) {
            //    return RedirectToAction("logowanie", "Account"); }

            //if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home");  }
            if (UserHelper.GetUserRole(User.Identity.Name)=="" || User==null)
            {
                return RedirectToAction("Index", "Home");
            }

            EventsModel e = new EventsModel();
            e.id_user = UserHelper.GetUserId(User.Identity.Name);

            pszczupakEntities ent = new pszczupakEntities();
            ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            ViewData["D"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            e.id_user = UserHelper.GetUserId(User.Identity.Name);
            return View(e);

        }


        [HttpPost]
        public ActionResult Create(EventsModel e)
        {
            if (UserHelper.GetUserRole(User.Identity.Name) == "" || User == null) { return RedirectToAction("Index", "Home");  }
           
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();

                if (UserHelper.GetUserRole(User.Identity.Name) == "user")
                {
                    e.approved = 0;
                }
                else e.approved = 1;

                e.id_user = UserHelper.GetUserId(User.Identity.Name);

                ent.Events.Add(e.ToEventsWithoutID());
                ent.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["User"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
                ViewData["Dog"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

                e.id_user = UserHelper.GetUserId(User.Identity.Name);
                return View(e);
            }


        }



        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (UserHelper.GetUserRole(User.Identity.Name) == "" || User == null) { return RedirectToAction("Index", "Home"); }
            
            pszczupakEntities ent = new pszczupakEntities();
            Events found = ent.Events.Find(Id);
            EventsModel e = found.ToEventsModelWithID();

            //USER moze edytowac tylko swoje eventy
            if (UserHelper.GetUserRole(User.Identity.Name) == "user" && UserHelper.GetUserId(User.Identity.Name) != e.id_user)
            { return RedirectToAction("Index", "Home"); }

            ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            ViewData["D"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            //return Json("lololo"+e.id_user+"uu", JsonRequestBehavior.AllowGet);
            return View(e);
        }


        [HttpPost]
        public ActionResult Edit(EventsModel e)
        {
            e.id_user = UserHelper.GetUserId(User.Identity.Name);   // DLACZEGO GUBI SIE ID_USER????????????
            //USER moze edytowac tylko swoje eventy
            if ((UserHelper.GetUserRole(User.Identity.Name) == "user" && (UserHelper.GetUserId(User.Identity.Name) != e.id_user))
                || UserHelper.GetUserRole(User.Identity.Name) == "")
            //    return Json("lololo"+ UserHelper.GetUserId(User.Identity.Name)+"    "+ e.id_user+" id idusera");
            { return RedirectToAction("Index", "Home"); }

            if (ModelState.IsValid)
            {
                if (UserHelper.GetUserRole(User.Identity.Name) == "user")
                    e.approved = 0;

                pszczupakEntities ent = new pszczupakEntities();
                Events events = ConverterHelper.ToEventsWithID(e);
                ent.Entry(ent.Events.Where(x => x.id == events.id).First()).CurrentValues.SetValues(events);
                ent.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["User"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
                ViewData["Dog"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
                return View(e);
            }


        }

        

        [HttpGet]
        public ActionResult Details(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            EventsModel model = ent.Events.Where(x => x.id == id).FirstOrDefault().ToEventsModelWithID();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager")
            { return RedirectToAction("Index", "Home"); }

            pszczupakEntities ent = new pszczupakEntities();
            Events events = ent.Events.Where(x => x.id == id).First();
            ent.Events.Remove(events);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
