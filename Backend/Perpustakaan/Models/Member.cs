using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Perpustakaan.Models
{
    public class Member
    {
        public int ID { get; set; }
        public char IdAnggota { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
    }
}