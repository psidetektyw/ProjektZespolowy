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
         
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("logowanie", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home");  }

            NewsViewModel model = new NewsViewModel();
          
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(NewsViewModel model)
        {
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("logowanie", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }
          
            model.user_id = UserHelper.GetUserId(User.Identity.Name);
                model.add_date = DateTime.Now;

                pszczupakEntities ent = new pszczupakEntities();

               News n = model.ToNews();
                //News n = new News();
                //n.add_date = DateTime.Now;
                //n.news1 = model.news1;
                //n.user_id = model.user_id;


                ent.News.Add(n);
                ent.SaveChanges();
                return RedirectToAction("Index", "Home");

            

        
        }

        [HttpGet]
        public PartialViewResult ShowNewses()
        {
            pszczupakEntities ent = new pszczupakEntities();
            //List<NewsViewModel> lista = new List<NewsViewModel>();

            List<NewsViewModel> lista = ent.News.OrderByDescending(x=>x.add_date).Take(10).Select(x => new NewsViewModel()
            {
                id = x.id,
                news1 = x.news1,
                user_id = x.user_id,
                add_date = x.add_date
           
            }).ToList();

            //foreach (News n in ent.News.ToList()) {
            //    NewsViewModel b = new NewsViewModel();

            //    b.id = n.id;
            //    b.news1 = n.news1;
            //    b.user_id = n.user_id;
            //    b.add_date = n.add_date;

            //    lista.Add(b);
           
            //}


            return PartialView(lista);
        }



        [HttpGet]
        public ActionResult DeleteNews(int id)
        {
            if ((UserHelper.GetUserRole(User.Identity.Name) != "admin") && (UserHelper.GetUserRole(User.Identity.Name) != "manager") && (UserHelper.GetUserRole(User.Identity.Name) != "worker") && (UserHelper.GetUserRole(User.Identity.Name) != "user")) { return RedirectToAction("logowanie", "Account"); }
            if (UserHelper.GetUserRole(User.Identity.Name) == "user") { return RedirectToAction("Index", "Home"); }

            pszczupakEntities ent = new pszczupakEntities();

            News n = ent.News.Where(x => x.id == id).FirstOrDefault();

            ent.News.Remove(n);
            ent.SaveChanges();
           
            return RedirectToAction("Index","Home");
        }


    }
}