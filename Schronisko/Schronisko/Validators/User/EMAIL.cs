using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Schronisko.Validators
{


    public class EMAIL : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var emaill = value.ToString();

            pszczupakEntities ent = new pszczupakEntities();
            if (ent.Users.Where(x => x.email == emaill).Count() > 0)
            {
                return new ValidationResult("Taki adres email już istnieje");
            }
            return ValidationResult.Success;
        }



    }
}