using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Schronisko.Validators.User;
using Schronisko.Validators;

namespace Schronisko.Models
{

    [PASSWORD("password", "confirmPassword", ErrorMessage = "Hasła się nie zgadzają")]
    public class RegisterModel
    {
        [Required]
        [LOGIN]
        [DisplayName(displayName: "Login")]
        public string login { get; set; }

        [Required]
        [EMAIL]
        [EmailAddress]
        [DisplayName(displayName: "Email")]
        public string email { get; set; }


        [Required]
        [StringLength(12, ErrorMessage = "{0} musi mieć minimum {2} a maksymalnie {1}", MinimumLength = 6)]
        [DisplayName(displayName: "Hasło")]
        public string password { get; set; }


        [Required]
        [DisplayName(displayName: "Potwierdz Hasło")]
        public string confirmPassword { get; set; }


    }
}