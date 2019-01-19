using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class RacesModel
    {

        public int id { get; set; }

        [DisplayName("Nazwa rasy")]
        [Required(ErrorMessage = "Proszę wprowadź nazwę rasy.")]
        public string name { get; set; }


        [DisplayName("Opis rasy")]
        [Required(ErrorMessage = "Proszę wprowadź opis rasy.")]
        public string description { get; set; }
}
}