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

    public class UserViewModel
    {
        public UserViewModel()
        {
            //default constructor
        }

        public UserViewModel(Users u)
        {
            Helpers.PropertyCopier<Users, UserViewModel>.Copy(u, this);
        }

        public Users ToUsers()
        {
            Users u = new Users();
            Helpers.PropertyCopier<UserViewModel, Users>.Copy(this, u);
            return u;
        }


        public int id { get; set; }


        [NAZWY]
        [DisplayName(displayName: "Imię")]
        public string name { get; set; }


        [NAZWY]
        [DisplayName(displayName: "Nazwisko")]
        public string surname { get; set; }


        [PESEL]
        [DisplayName(displayName: "Pesel")]
        public string pesel { get; set; }



        [DisplayName(displayName: "Miasto")]
        public string city { get; set; }


        [DisplayName(displayName: "Ulica")]
        public string street { get; set; }


        [DisplayName(displayName: "Numer")]
        public string house { get; set; }


        [DisplayName(displayName: "Login")]
        public string login { get; set; }


        [DisplayName(displayName: "Email")]
        public string email { get; set; }


        [DisplayName(displayName: "Hasło")]
        public string password { get; set; }


        [DisplayName(displayName: "Rola")]
        public string role { get; set; }

        [DisplayName(displayName: "Numer telefonu")]
        public string phone { get; set; }


        public string adres { get { return city + " " + street + " " + house; } set { } }

    }
}