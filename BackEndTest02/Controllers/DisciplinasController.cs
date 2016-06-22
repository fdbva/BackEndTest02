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
    public class DisciplinasController : ApiController
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: api/Disciplinas
        public IQueryable<Disciplina> GetDisciplinas()
        {
            return db.Disciplinas;
        }

        // GET: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public async Task<IHttpActionResult> GetDisciplina(int id)
        {
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return Ok(disciplina);
        }

        // PUT: api/Disciplinas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDisciplina(int id, Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplina.DisciplinaId)
            {
                return BadRequest();
            }

            db.Entry(disciplina).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
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

        // POST: api/Disciplinas
        [ResponseType(typeof(Disciplina))]
        public async Task<IHttpActionResult> PostDisciplina(Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disciplinas.Add(disciplina);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = disciplina.DisciplinaId }, disciplina);
        }

        // DELETE: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public async Task<IHttpActionResult> DeleteDisciplina(int id)
        {
            Disciplina disciplina = await db.Disciplinas.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            db.Disciplinas.Remove(disciplina);
            await db.SaveChangesAsync();

            return Ok(disciplina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisciplinaExists(int id)
        {
            return db.Disciplinas.Count(e => e.DisciplinaId == id) > 0;
        }
    }
}