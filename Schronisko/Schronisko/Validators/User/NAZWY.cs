using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Schronisko.Validators.User
{
    public class NAZWY : ValidationAttribute
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
                    return new ValidationResult("Duża Litera jako pierwszy znak oraz bez spacji");
                }
            }

            else
            {
                return ValidationResult.Success;
            }

        }
    }
}