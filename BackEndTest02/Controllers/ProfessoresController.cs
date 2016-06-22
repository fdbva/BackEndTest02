using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> GetProfessor(int id)
        {
            Professor professor = await db.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfessor(int id, Professor professor)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostProfessor(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Professores.Add(professor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = professor.ProfessorId }, professor);
        }

        // DELETE: api/Professores/5
        [ResponseType(typeof(Professor))]
        public async Task<IHttpActionResult> DeleteProfessor(int id)
        {
            Professor professor = await db.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            db.Professores.Remove(professor);
            await db.SaveChangesAsync();

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