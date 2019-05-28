using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSideProject.Models
{
    public class login_table
    {
        public int login_id { get; set; }
        public string username { get; set; }
        public string passwords { get; set; }
        public string roleofuser { get; set; }
        public string token { get; set; }
    }
}