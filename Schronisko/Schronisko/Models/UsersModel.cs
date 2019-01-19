using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using Schronisko.Validators;


namespace Schronisko.Models
{
    public class UsersModel
    {
        public UsersModel()
        {
            //default constructor
        }

        public UsersModel(Users u)
        {
            Helpers.PropertyCopier<Users,UsersModel>.Copy(u, this);
        }

        public Users ToUsers()
        {
            Users u = new Users();
            Helpers.PropertyCopier<UsersModel, Users>.Copy(this, u);
            return u;
        }



     
        public int id { get; set; }


        [Required]
        [DisplayName(displayName: "Imię")]
        public string name { get; set; }


        [Required]
        [DisplayName(displayName: "Nazwisko")]
        public string surname { get; set; }



        [Required]
        [DisplayName(displayName: "Pesel")]
        public string pesel { get; set; }


        [Required]
        [DisplayName(displayName: "Miasto")]
        public string city { get; set; }

        [Required]
        [DisplayName(displayName: "Ulica")]
        public string street { get; set; }


        [DisplayName(displayName: "Numer")]
        public string house { get; set; }


        [LOGIN]
        [DisplayName(displayName: "Login")]
        public string login { get; set; }


        [DisplayName(displayName: "Email")]
        public string email { get; set; }

        [DisplayName(displayName: "Hasło")]
        public string password { get; set; }

        [DisplayName(displayName: "Rola")]
        public string role { get; set; }
    }
}