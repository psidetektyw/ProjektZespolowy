using Schronisko.Helpers;
using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager" || UserHelper.GetUserRole(User.Identity.Name) != "worker" || UserHelper.GetUserRole(User.Identity.Name) != "user") return RedirectToAction("Login", "Account");
            else if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }
            else
            {



                DogsModel d = new DogsModel();
                pszczupakEntities ent = new pszczupakEntities();
                ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();

                return View(d);
            }
        }


        [HttpPost]
        public ActionResult Create(DogsModel d, HttpPostedFileBase file)
        {

            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager" || UserHelper.GetUserRole(User.Identity.Name) != "worker" || UserHelper.GetUserRole(User.Identity.Name) != "user") return RedirectToAction("Login", "Account");
            else if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }
            else { 

            if (ModelState.IsValid)
            {
     
                pszczupakEntities ent = new pszczupakEntities();
                Dogs dog = d.ToDogsWithoutID();
                ent.Dogs.Add(dog);
                ent.SaveChanges();

                if (file != null)
                {
                    var path = Path.Combine(Server.MapPath($"~/Images/Dogs/Index/{dog.id}"), file.FileName);
                    System.IO.Directory.CreateDirectory(Server.MapPath($"~/Images/Dogs/Index/{dog.id}"));
                    file.SaveAs(path);
                    dog.photo_path = $"/Images/Dogs/Index/{dog.id}/{file.FileName}";
                }

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

        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager" || UserHelper.GetUserRole(User.Identity.Name) != "worker" || UserHelper.GetUserRole(User.Identity.Name) != "user") return RedirectToAction("Login", "Account");
            else if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }


            pszczupakEntities ent = new pszczupakEntities();
            DogsModel dog = ent.Dogs.Where(x => x.id == Id).FirstOrDefault().ToDogsModelWithID();
            ViewData["Race"] = ent.Races.Select(x => new SelectListItem() { Value = x.id.ToString(), Text = x.name }).ToList();
           
            return View(dog);
        }


        [HttpPost]
        public ActionResult Edit(DogsModel dog, HttpPostedFileBase file)
        {
            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager" || UserHelper.GetUserRole(User.Identity.Name) != "worker" || UserHelper.GetUserRole(User.Identity.Name) != "user") return RedirectToAction("Login", "Account");
            else if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }


            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Server.MapPath($"~/Images/Dogs/Index/{dog.id}"), file.FileName);
                    System.IO.Directory.CreateDirectory(Server.MapPath($"~/Images/Dogs/Index/{dog.id}"));
                    file.SaveAs(path);
                }
                    pszczupakEntities ent = new pszczupakEntities();
                    Dogs d = new Dogs();
                    d = ConverterHelper.ToDogsWithID(dog);

                if (file != null)
                d.photo_path = $"/Images/Dogs/Index/{dog.id}/{file.FileName}";


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
            if (UserHelper.GetUserRole(User.Identity.Name) != "admin" || UserHelper.GetUserRole(User.Identity.Name) != "manager" || UserHelper.GetUserRole(User.Identity.Name) != "worker" || UserHelper.GetUserRole(User.Identity.Name) != "user") return RedirectToAction("Login", "Account");
            else if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }


            pszczupakEntities ent = new pszczupakEntities();
            Dogs dog = ent.Dogs.Where(x => x.id == id).First();
            ent.Dogs.Remove(dog);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}