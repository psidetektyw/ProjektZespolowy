using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schronisko.Helpers
{
    public static class UserHelper
    {
        public static string GetUserRole(string login)
        {
            if (login == null || login == "") return "";
            pszczupakEntities ent = new pszczupakEntities();
            return ent.Users.Where(x => x.login == login).FirstOrDefault().role;
        }

        public static int GetUserId(string login)
        {
            pszczupakEntities ent = new pszczupakEntities();
            return ent.Users.Where(x => x.login == login).FirstOrDefault().id;
        }
    }
}