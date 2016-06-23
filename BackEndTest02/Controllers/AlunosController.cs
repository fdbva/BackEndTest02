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
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
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
                db.SaveChanges();
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
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alunos.Add(aluno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult DeleteAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            db.Alunos.Remove(aluno);
            db.SaveChanges();

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