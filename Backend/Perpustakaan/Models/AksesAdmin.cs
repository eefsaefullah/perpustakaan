using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Perpustakaan.Models
{
    public class AksesAdmin
    {
        public int ID { get; set; }
        public char IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}