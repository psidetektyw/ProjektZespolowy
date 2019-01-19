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
    public class EditEmailModel
    {
        public int id { get; set; }

        [Required]
        [EMAIL]
        [EmailAddress]
        [DisplayName(displayName: "Email")]
        public string email { get; set; }
    }
}