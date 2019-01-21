using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using Schronisko.Validators.User;


namespace Schronisko.Models
{
    public class EditUserModel
    {
        public int id { get; set; }


        [NAZWY]
        [StringLength(20, ErrorMessage = "{0} musi mieć minimum {2} a maksymalnie {1}", MinimumLength = 2)]
        [DisplayName(displayName: "Imię")]
        public string name { get; set; }


        [NAZWY]
        [StringLength(25, ErrorMessage = "{0} musi mieć minimum {2} a maksymalnie {1}", MinimumLength = 2)]
        [DisplayName(displayName: "Nazwisko")]
        public string surname { get; set; }


        [PESEL]
        [DisplayName(displayName: "Pesel")]
        public string pesel { get; set; }


        [NAZWY]
        [StringLength(30, ErrorMessage = "{0} musi mieć minimum {2} a maksymalnie {1}", MinimumLength = 3)]
        [DisplayName(displayName: "Miasto")]
        public string city { get; set; }


        [DisplayName(displayName: "Ulica")]
        [StringLength(60, ErrorMessage = "Max 60 znaków.")]
        public string street { get; set; }


        [DisplayName(displayName: "Numer")]
        [StringLength(15, ErrorMessage = "Max 15 znaków.")]
        public string house { get; set; }


        [DisplayName(displayName: "Numer telefonu")]
        [StringLength(25, ErrorMessage = "Max 25 znaków.")]
        public string phone { get; set; }
    }
}