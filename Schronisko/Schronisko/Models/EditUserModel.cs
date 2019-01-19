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
        public string street { get; set; }


        [DisplayName(displayName: "Numer")]
        public string house { get; set; }


        [DisplayName(displayName: "Numer telefonu")]
        public string phone { get; set; }
    }
}