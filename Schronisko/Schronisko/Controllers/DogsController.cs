using Schronisko.Helpers;
using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class DogsController : Controller
    {
        public ActionResult Index()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<DogsModel> dog = new List<DogsModel>();

            foreach (Dogs d in ent.Dogs.ToList())
                dog.Add(d.ToDogsModelWithID());

            return View(dog);
        }

        [HttpGet]
        public ActionResult Create()
        {

            DogsModel d = new DogsModel();
            pszczupakEntities ent = new pszczupakEntities();
            ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

            return View(d);

        }


        [HttpPost]
        public ActionResult Create(DogsModel d)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                ent.Dogs.Add(d.ToDogsWithoutID());
                ent.SaveChanges();


                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

                return View(d);
            }


        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            DogsModel dog = ent.Dogs.Where(x => x.id == Id).FirstOrDefault().ToDogsModelWithID();
            ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

            return View(dog);
        }


        [HttpPost]
        public ActionResult Edit(DogsModel dog)
        {
            if (ModelState.IsValid)
            {
                pszczupakEntities ent = new pszczupakEntities();
                Dogs d = new Dogs();
                d = ConverterHelper.ToDogsWithID(dog);
                ent.Entry(ent.Dogs.Where(x => x.id == d.id).First()).CurrentValues.SetValues(d);
                ent.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

                return View(dog);
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            DogsModel model = ent.Dogs.Where(x => x.id == id).FirstOrDefault().ToDogsModelWithID();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            pszczupakEntities ent = new pszczupakEntities();
            Dogs dog = ent.Dogs.Where(x => x.id == id).First();
            ent.Dogs.Remove(dog);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}