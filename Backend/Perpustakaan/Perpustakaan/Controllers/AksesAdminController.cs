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
using Perpustakaan.Models;
using Perpustakaan.DAL;

namespace Perpustakaan.Controllers
{
    public class AksesAdminController : ApiController
    {
        private BookContext db = new BookContext();

        // GET api/AksesAdmin
        public IQueryable<AksesAdmin> GetAksesAdmins()
        {
            return db.AksesAdmins;
        }

        // GET api/AksesAdmin/5
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult GetAksesAdmin(int id)
        {
            AksesAdmin aksesadmin = db.AksesAdmins.Find(id);
            if (aksesadmin == null)
            {
                return NotFound();
            }

            return Ok(aksesadmin);
        }

        // PUT api/AksesAdmin/5
        public IHttpActionResult PutAksesAdmin(int id, AksesAdmin aksesadmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aksesadmin.ID)
            {
                return BadRequest();
            }

            db.Entry(aksesadmin).State = EntityState.Modified;

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

        // POST api/AksesAdmin
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult PostAksesAdmin(AksesAdmin aksesadmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AksesAdmins.Add(aksesadmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aksesadmin.ID }, aksesadmin);
        }

        // DELETE api/AksesAdmin/5
        [ResponseType(typeof(AksesAdmin))]
        public IHttpActionResult DeleteAksesAdmin(int id)
        {
            AksesAdmin aksesadmin = db.AksesAdmins.Find(id);
            if (aksesadmin == null)
            {
                return NotFound();
            }

            db.AksesAdmins.Remove(aksesadmin);
            db.SaveChanges();

            return Ok(aksesadmin);
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