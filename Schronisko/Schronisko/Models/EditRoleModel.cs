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
    public class EditRoleModel
    {
        public int id { get; set; }

        [DisplayName(displayName: "Rola")]
        [StringLength(30, ErrorMessage = "Max 30 znaków.")]
        public string role { get; set; }

    }
}