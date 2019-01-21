using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schronisko.Helpers;

namespace Schronisko.Controllers
{
    public class RacesController : Controller
    {
        // GET: Races
        public ActionResult Index()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<RacesModel> race = new List<RacesModel>();


            foreach (Races r in ent.Races.ToList())    
                race.Add(r.ToRacesModelWithID());
            
            return View(race);
        }

        public PartialViewResult RacePartial(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            RacesModel model = ent.Races.Where(x => x.id == id).FirstOrDefault().ToRacesModelWithID();
            return PartialView("Details",model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            RacesModel r = new RacesModel();
            return View(r);

        }
        

        [HttpPost]
        public ActionResult Create(RacesModel r)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                ent.Races.Add(r.ToRacesWithoutID());
                ent.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                return View(r);
            }


        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            RacesModel race = ent.Races.Where(x => x.id == Id).FirstOrDefault().ToRacesModelWithID();
            return View(race);
        }


        [HttpPost]
        public ActionResult Edit(RacesModel race)
        {
            if (ModelState.IsValid) 
            {
                pszczupakEntities ent = new pszczupakEntities();
                Races r = ent.Races.Where(x => x.id == race.id).FirstOrDefault();
                r = ConverterHelper.RacesSameValuesWithoutID(r, race);
                ent.Entry(ent.Races.Where(x => x.id == r.id).First()).CurrentValues.SetValues(r);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(race);
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            RacesModel model = ent.Races.Where(x => x.id == id).FirstOrDefault().ToRacesModelWithID();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            Races race = ent.Races.Where(x => x.id == id).First();

            List<Dogs> dogs = ent.Dogs.Where(x => x.id_race == id).ToList();

            foreach(Dogs d in dogs)
            {
                d.id_race = null;
                ent.Entry(ent.Dogs.Where(x => x.id == d.id).First()).CurrentValues.SetValues(d);
            }

            ent.Races.Remove(race);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}