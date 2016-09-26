using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Perpustakaan.Models
{
    public class AksesAnggota
    {
        public int ID { get; set; }
        public char IdAnggota { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}