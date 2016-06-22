using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BackEndTest02.Migrations;

namespace BackEndTest02.Models
{
    public class BackEndDbContext : DbContext
    {
        public BackEndDbContext() : base()
        {
            Database.SetInitializer(new SeedInit<BackEndDbContext>());
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        
    }
}