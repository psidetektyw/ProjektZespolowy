using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Schronisko.Validators.User
{
    public class PASSWORD : ValidationAttribute
    {

        public string haslo1 { get; set; }
        public string haslo2 { get; set; }



        public PASSWORD(string h1, string h2)
        {
            haslo1 = h1;
            haslo2 = h2;
        }


        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection wlasciwosci = TypeDescriptor.GetProperties(value);
            string pass1 = wlasciwosci.Find(haslo1, true).GetValue(value) as string;
            string pass2 = wlasciwosci.Find(haslo2, true).GetValue(value) as string;

            if (pass1 == pass2) { return true; }
            else { return false; }


        }








    }
}