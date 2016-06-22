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
    public class TurmasController : ApiController
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: api/Turmas
        public IQueryable<Turma> GetTurmas()
        {
            return db.Turmas;
        }

        // GET: api/Turmas/5
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> GetTurma(int id)
        {
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/Turmas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTurma(int id, Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.Id)
            {
                return BadRequest();
            }

            db.Entry(turma).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turmas
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> PostTurma(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turmas.Add(turma);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = turma.Id }, turma);
        }

        // DELETE: api/Turmas/5
        [ResponseType(typeof(Turma))]
        public async Task<IHttpActionResult> DeleteTurma(int id)
        {
            Turma turma = await db.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            db.Turmas.Remove(turma);
            await db.SaveChangesAsync();

            return Ok(turma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurmaExists(int id)
        {
            return db.Turmas.Count(e => e.Id == id) > 0;
        }
    }
}