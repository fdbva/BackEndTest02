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
    public class AlunosController : ApiController
    {
        private BackEndDbContext db = new BackEndDbContext();

        // GET: api/Alunos
        public IQueryable<Aluno> GetAlunos()
        {
            return db.Alunos;
        }

        // GET: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> GetAluno(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Alunos
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alunos.Add(aluno);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        public async Task<IHttpActionResult> DeleteAluno(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlunoExists(int id)
        {
            return db.Alunos.Count(e => e.AlunoId == id) > 0;
        }
    }
}