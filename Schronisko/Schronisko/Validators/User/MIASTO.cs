using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Schronisko.Validators.User
{
    public class MIASTO : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            if (value != null)
            {
                var tekst = value.ToString();

                if (Regex.IsMatch(tekst, "^[A-ZŻŹĆĄŚĘŁÓŃ][A-ZŻŹĆĄŚĘŁÓŃa-zzżźćńółęą]{2,}$"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Duża Litera jako pierwszy znak, bez spacji, minimum 3 znaki");
                }
            }

            else
            {
                return ValidationResult.Success;
            }

        }
    }
}