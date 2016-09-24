using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Perpustakaan.Models;


namespace Perpustakaan.DAL
{
    public class BookInitializer : System.Data.Entity.CreateDatabaseIfNotExists<BookContext>
    {
    }
}