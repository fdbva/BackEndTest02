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
using BackEndTest02.Models;

namespace BackEndTest02.Controllers
{
    public class ProfessoresController : ApiController
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: api/Professores
        public IQueryable<Professor> GetProfessores()
        {
            return db.Professores;
        }

        // GET: api/Professores/5
        [ResponseType(typeof(Professor))]
        public IHttpActionResult GetProfessor(int id)
        {
            Professor professor = db.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfessor(int id, Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.ProfessorId)
            {
                return BadRequest();
            }

            db.Entry(professor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professores
        [ResponseType(typeof(Professor))]
        public IHttpActionResult PostProfessor(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Professores.Add(professor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = professor.ProfessorId }, professor);
        }

        // DELETE: api/Professores/5
        [ResponseType(typeof(Professor))]
        public IHttpActionResult DeleteProfessor(int id)
        {
            Professor professor = db.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            db.Professores.Remove(professor);
            db.SaveChanges();

            return Ok(professor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfessorExists(int id)
        {
            return db.Professores.Count(e => e.ProfessorId == id) > 0;
        }
    }
}