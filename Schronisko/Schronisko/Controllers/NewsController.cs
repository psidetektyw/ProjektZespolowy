using Schronisko.Helpers;
using Schronisko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    
    public class NewsController : Controller
    {
        [Authorize]
        public ActionResult Add()
        {
         
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("Login", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home");  }

            NewsViewModel model = new NewsViewModel();
          
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(NewsViewModel model)
        {
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("Login", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }
          
            model.user_id = UserHelper.GetUserId(User.Identity.Name);
                model.add_date = DateTime.Now;

                pszczupakEntities ent = new pszczupakEntities();

               News n = model.ToNews();


                ent.News.Add(n);
                ent.SaveChanges();
                return RedirectToAction("Index", "Home");

            

        
        }

        [HttpGet]
        public PartialViewResult ShowNewses()
        {
            pszczupakEntities ent = new pszczupakEntities();
            List<NewsViewModel> lista = new List<NewsViewModel>();
            foreach (News item in ent.News.OrderByDescending(x => x.add_date).Take(10)) {
                NewsViewModel model = new NewsViewModel();
                model.add_date = item.add_date;
                model.news1 = item.news1;
                model.user_id = item.user_id;
                model.id = item.id;
                lista.Add(model);
            }
            return PartialView(lista);
        }



        [HttpGet]
        public ActionResult DeleteNews(int? id)
        {
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("Login", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }

            if (id == null)
            {
                return HttpNotFound();
            }

            pszczupakEntities ent = new pszczupakEntities();
            News n = null;
            List<News> newsy= ent.News.ToList();
            foreach(News item in newsy)
            {
                if (item.id == id)
                    n = item;
            }
            NewsViewModel nvm = new NewsViewModel();
            nvm.id = n.id;
            nvm.user_id = n.user_id;
            nvm.add_date = n.add_date;
            nvm.news1 = n.news1;
            
            return View(nvm);
        }

        [HttpGet]
        public ActionResult DeleteNewsConf(int? id)
        {
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("Login", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }

            if (id == null)
            {
                return HttpNotFound();
            }

            pszczupakEntities ent = new pszczupakEntities();
            News n = null;
            List<News> newsy = ent.News.ToList();
            foreach (News item in newsy)
            {
                if (item.id == id)
                    n = item;
            }
            try
            {
                ent.News.Remove(n);
            }
            catch { }

            ent.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}