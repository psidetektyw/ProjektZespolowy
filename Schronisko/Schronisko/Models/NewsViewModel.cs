using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
            //default constructor
        }

        public NewsViewModel(News u)
        {
            Helpers.PropertyCopier<News, NewsViewModel>.Copy(u, this);
        }

        public News ToNews()
        {
            News u = new News();
            Helpers.PropertyCopier<NewsViewModel, News>.Copy(this, u);
            return u;
        }
        public int id { get; set; }

        [DisplayName(displayName: "News")]
        public string news1 { get; set; }

        [DataType(DataType.Date)]
        [DisplayName(displayName: "Dodano")]
        public DateTime? add_date { get; set; }
        public int user_id { get; set; }

        [DisplayName(displayName: "Przez")]
        public string user { get { pszczupakEntities ent = new pszczupakEntities();
                Users u = ent.Users.Where(x => x.id == user_id).FirstOrDefault();
                return u.role + " " + u.login; } set { } }

       
    }
}