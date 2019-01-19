using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName(displayName: "Login")]
        public string login { get; set; }

        [Required]
        [DisplayName(displayName: "Hasło")]
        public string password { get; set; }
    }
}