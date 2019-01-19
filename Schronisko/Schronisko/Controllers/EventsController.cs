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


        [HttpGet]
        public ActionResult Create()
        {

            EventsModel e = new EventsModel();
            pszczupakEntities ent = new pszczupakEntities();
            ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            ViewData["D"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            return View(e);

        }


        [HttpPost]
        public ActionResult Create(EventsModel e)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                ent.Events.Add(e.ToEventsWithoutID());
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
        public ActionResult Edit(int Id)
        {
            EventsModel e = new EventsModel();
            pszczupakEntities ent = new pszczupakEntities();
            ViewData["U"] = ent.Users.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            ViewData["D"] = ent.Dogs.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
            return View(e);
        }


        [HttpPost]
        public ActionResult Edit(EventsModel e)
        {

            if (ModelState.IsValid)
            {
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
            pszczupakEntities ent = new pszczupakEntities();
            Events events = ent.Events.Where(x => x.id == id).First();
            ent.Events.Remove(events);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
