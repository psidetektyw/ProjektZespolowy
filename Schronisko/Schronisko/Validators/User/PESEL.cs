using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;



namespace Schronisko.Validators.User
{
    public class PESEL : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var pesel = value.ToString();
            if (Regex.IsMatch(pesel, "^[0-9]{11}$"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid length PESEL (must be 11 characters).");
        }
    }
}