using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Perpustakaan.Models;

namespace Perpustakaan.DAL
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Member> Members { get; set; }
<<<<<<< HEAD
        public DbSet<AksesAnggota> Akses { get; set;}
=======
        public DbSet<AksesAnggota> Akses { get; set; }
        public DbSet<AksesAdmin> AksesAdmins { get; set; }
>>>>>>> b5ef2dbf2c01e9402b19a2073904b785459a2457
    }
}