using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schronisko.Models
{
    public class UsersEventsModel
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_event { get; set; }

        public Events Events { get; set; }
        public Users Users { get; set; }
    }
}