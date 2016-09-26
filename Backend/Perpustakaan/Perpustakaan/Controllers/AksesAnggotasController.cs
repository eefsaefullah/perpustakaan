using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Perpustakaan.DAL;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class AksesAnggotasController : ApiController
    {
        private BookContext db = new BookContext();

        // GET: api/AksesAnggotas
        public IQueryable<AksesAnggota> GetAkses()
        {
            return db.Akses;
        }

        // GET: api/AksesAnggotas/5
        [ResponseType(typeof(AksesAnggota))]
        public IHttpActionResult GetAksesAnggota(int id)
        {
            AksesAnggota aksesAnggota = db.Akses.Find(id);
            if (aksesAnggota == null)
            {
                return NotFound();
            }

            return Ok(aksesAnggota);
        }

        // PUT: api/AksesAnggotas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAksesAnggota(int id, AksesAnggota aksesAnggota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aksesAnggota.ID)
            {
                return BadRequest();
            }

            db.Entry(aksesAnggota).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AksesAnggotaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AksesAnggotas
        [ResponseType(typeof(AksesAnggota))]
        public IHttpActionResult PostAksesAnggota(AksesAnggota aksesAnggota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Akses.Add(aksesAnggota);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aksesAnggota.ID }, aksesAnggota);
        }

        // DELETE: api/AksesAnggotas/5
        [ResponseType(typeof(AksesAnggota))]
        public IHttpActionResult DeleteAksesAnggota(int id)
        {
            AksesAnggota aksesAnggota = db.Akses.Find(id);
            if (aksesAnggota == null)
            {
                return NotFound();
            }

            db.Akses.Remove(aksesAnggota);
            db.SaveChanges();

            return Ok(aksesAnggota);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AksesAnggotaExists(int id)
        {
            return db.Akses.Count(e => e.ID == id) > 0;
        }
    }
}