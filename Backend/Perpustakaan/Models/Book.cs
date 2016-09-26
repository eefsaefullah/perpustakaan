using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Perpustakaan.Models
{
    public class Book 
    {
        public int ID { get; set; }
        public char BukuID { get; set; }
        public string Judul { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }
        public int TahunTerbit { get; set; }

    }
}