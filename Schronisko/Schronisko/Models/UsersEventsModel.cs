using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class UsersEventsModel
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Użytkownik")]
        public int id_user { get; set; }

        [Required]
        [DisplayName("Praca")]
        public int id_event { get; set; }

        public UsersEventsModel()
        {
            //default constructor
        }

        public UsersEventsModel(UsersEvents u)
        {
            Helpers.PropertyCopier<UsersEvents, UsersEventsModel>.Copy(u, this);
        }

        public UsersEvents ToUsersEventsModel()
        {
            UsersEvents u = new UsersEvents();
            Helpers.PropertyCopier<UsersEventsModel, UsersEvents>.Copy(this, u);
            return u;
        }


        public Events Event
        {
            get
            {
                pszczupakEntities ent = new pszczupakEntities();
                return ent.Events.Where(x => x.id == id_event).FirstOrDefault();
            }
            set { }
        }

        public Users Users {
            get
            {
                pszczupakEntities ent = new pszczupakEntities();
                return ent.Users.Where(x => x.id == id_user).FirstOrDefault();

            }
            set { }
        }
    }
}