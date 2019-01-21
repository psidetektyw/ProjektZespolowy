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
        [StringLength(60, ErrorMessage = "Max 60 znaków.")]
        public string name { get; set; }


        [NAZWY]
        [DisplayName(displayName: "Nazwisko")]
        [StringLength(100, ErrorMessage = "Max 100 znaków.")]
        public string surname { get; set; }


        [PESEL]
        [DisplayName(displayName: "Pesel")]
        [StringLength(11, ErrorMessage = "Musi być 11 znaków.")]
        public string pesel { get; set; }



        [DisplayName(displayName: "Miasto")]
        [StringLength(60, ErrorMessage = "Max 60 znaków.")]
        public string city { get; set; }


        [DisplayName(displayName: "Ulica")]
        [StringLength(60, ErrorMessage = "Max 60 znaków.")]
        public string street { get; set; }


        [DisplayName(displayName: "Numer")]
        [StringLength(15, ErrorMessage = "Max 15 znaków.")]
        public string house { get; set; }


        [DisplayName(displayName: "Login")]
        [StringLength(60, ErrorMessage = "Max 50 znaków.")]
        public string login { get; set; }


        [DisplayName(displayName: "Email")]
        [StringLength(60, ErrorMessage = "Max 50 znaków.")]
        public string email { get; set; }


        [DisplayName(displayName: "Hasło")]
        [StringLength(200, ErrorMessage = "Max 200 znaków.")]
        public string password { get; set; }


        [DisplayName(displayName: "Rola")]
        [StringLength(30, ErrorMessage = "Max 30 znaków.")]
        public string role { get; set; }

        [DisplayName(displayName: "Numer telefonu")]
        [StringLength(25, ErrorMessage = "Max 25 znaków.")]
        public string phone { get; set; }


        public string adres { get { return city + " " + street + " " + house; } set { } }

    }
}