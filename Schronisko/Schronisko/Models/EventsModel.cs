using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class EventsModel
    {
      

        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Data rozpoczęcia")]
        [Required(ErrorMessage = "Podaj datę wydarzenia")]
        public System.DateTime date { get; set; }

        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        [DisplayName("Czas rozpoczęcia")]
        [Required(ErrorMessage = "Podaj czas rozpoczęcia")]
        public System.TimeSpan time { get; set; }


        [DisplayName("Opis wydarzenia")]
        [Required(ErrorMessage = "Krótki opis wydarzenia")]
        public string description { get; set; }


        [DisplayName("Status")]
        public int approved { get; set; }


        [DisplayName("Utworzony przez")]
        public int id_user { get; set; }

        [DisplayName("Pies")]
        [Required(ErrorMessage = "Wybierz psa")]
        public int? id_dog { get; set; }

        public Dogs dogs
        {
            get
            {
                pszczupakEntities ent = new pszczupakEntities();
                return ent.Dogs.Where(x => x.id == id_dog).FirstOrDefault();
            }
        }

        public Users users
        {
            get
            {
                pszczupakEntities ent = new pszczupakEntities();
                return ent.Users.Where(x => x.id == id_user).FirstOrDefault();
            }
        }

    }
}