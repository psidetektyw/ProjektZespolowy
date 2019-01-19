using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Schronisko.Validators
{


    public class LOGIN : ValidationAttribute
    {
  

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var login = value.ToString();

            pszczupakEntities ent = new pszczupakEntities();
            List < String > logins = new List<String>();
            logins = ent.Users.Select(x => x.login).ToList();


            foreach (String s in logins) {

                if (s == login) {
                    return new ValidationResult("Taki Login juz istnieje");
                }

            }





            return ValidationResult.Success;
        }



    }
}