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
        [StringLength(50, ErrorMessage = "Max 50 znaków.")]
        public string name { get; set; }


        [DisplayName("Wielkość")]
        [Required(ErrorMessage = "Wprowadż wielkość rasy lub wpisz 'Brak Informacji'")]
        [StringLength(50, ErrorMessage = "Max 50 znaków.")]
        public string size { get; set; }


        [DisplayName("Pochodzenie")]
        [Required(ErrorMessage = "Wprowadż pochodzenie rasy lub wpisz 'Brak Informacji'")]
        [StringLength(50, ErrorMessage = "Max 50 znaków.")]
        public string origin { get; set; }

        

        [DisplayName("Nastawienie do dzieci")]
        [Required(ErrorMessage = "Wprowadż nastawienie do dzieci lub wpisz 'Brak Informacji'")]
        [StringLength(50, ErrorMessage = "Max 50 znaków.")]
        public string for_child { get; set; }


        [DisplayName("Nastawienie do innych zwierząt")]
        [Required(ErrorMessage = "Wprowadż nastawienie do innych zwierząt lub wpisz 'Brak Informacji'")]
        [StringLength(50, ErrorMessage = "Max 50 znaków.")]
        public string for_animal { get; set; }



        [DisplayName("Opis rasy")]
        [Required(ErrorMessage = "Proszę wprowadź opis rasy.")]
        public string description { get; set; }
}
}