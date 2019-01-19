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
    public class EventsModelsController : Controller
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

        // GET: EventsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsModel eventsModel = db.EventsModels.Find(id);
            if (eventsModel == null)
            {
                return HttpNotFound();
            }
            return View(eventsModel);
        }

        // GET: EventsModels/Create
        public ActionResult Create()
        {
            EventsModel e = new EventsModel();
            pszczupakEntities ent = new pszczupakEntities();
            ViewData["Event"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();

            return View(e);
        }

        // POST: EventsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,time,description,approved,id_user,id_dog")] EventsModel eventsModel)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                ent.Events.Add(eventsModel.ToEventsWithoutID());
                ent.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["Event"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();

                return View(eventsModel);
            }
        }

        // GET: EventsModels/Edit/5
        public ActionResult Edit(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            EventsModel ev = ent.Events.Where(x => x.id == id).FirstOrDefault().ToEventsModelWithID();
            ViewData["Event"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();

            return View(ev);
        }

        // POST: EventsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,time,description,approved,id_user,id_dog")] EventsModel eventsModel)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                Events e = new Events();
                e = ConverterHelper.ToEventsWithID(eventsModel);
                ent.Entry(ent.Events.Where(x => x.id == e.id).First()).CurrentValues.SetValues(e);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["Event"] = ent.Events.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.description }).ToList();

                return View(eventsModel);
            }
        }

        // GET: EventsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            Events ev = ent.Events.Where(x => x.id == id).First();
            ent.Events.Remove(ev);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: EventsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsModel eventsModel = db.EventsModels.Find(id);
            db.EventsModels.Remove(eventsModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
