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
    public class AksesAdminsController : ApiController
    {
        private BookContext db = new BookContext();

        // GET: api/AksesAdmins
        public IQueryable<AksesAdmin> GetAksesAdmins()
        {
            return db.AksesAdmins;
        }

        // GET: api/AksesAdmins/5
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult GetAksesAdmin(int id)
        {
            AksesAdmin aksesAdmin = db.AksesAdmins.Find(id);
            if (aksesAdmin == null)
            {
                return NotFound();
            }

            return Ok(aksesAdmin);
        }

        // PUT: api/AksesAdmins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAksesAdmin(int id, AksesAdmin aksesAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aksesAdmin.ID)
            {
                return BadRequest();
            }

            db.Entry(aksesAdmin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AksesAdminExists(id))
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

        // POST: api/AksesAdmins
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult PostAksesAdmin(AksesAdmin aksesAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AksesAdmins.Add(aksesAdmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aksesAdmin.ID }, aksesAdmin);
        }

        // DELETE: api/AksesAdmins/5
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult DeleteAksesAdmin(int id)
        {
            AksesAdmin aksesAdmin = db.AksesAdmins.Find(id);
            if (aksesAdmin == null)
            {
                return NotFound();
            }

            db.AksesAdmins.Remove(aksesAdmin);
            db.SaveChanges();

            return Ok(aksesAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AksesAdminExists(int id)
        {
            return db.AksesAdmins.Count(e => e.ID == id) > 0;
        }
    }
}