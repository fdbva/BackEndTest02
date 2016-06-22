using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using BackEndTest02.Models;

namespace BackEndTest02.Migrations
{
    public class SeedInit<T> : DropCreateDatabaseAlways<BackEndDbContext>
    {
        protected override void Seed(BackEndTest02.Models.BackEndDbContext context)
        {
            var turmas = new List<Turma>
            {
                new Turma {Id = 1, Nome = "Turma1", Turno = "Turno1", Ano = 2001, Alunos = new List<Aluno>(), Disciplinas = new List<Disciplina>()},
                new Turma {Id = 2, Nome = "Turma2", Turno = "Turno2", Ano = 2002, Alunos = new List<Aluno>(), Disciplinas = new List<Disciplina>()},
                new Turma {Id = 3, Nome = "Turma3", Turno = "Turno3", Ano = 2003, Alunos = new List<Aluno>(), Disciplinas = new List<Disciplina>()},
            };
            turmas.ForEach(s => context.Turmas.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();
            var professores = new List<Professor>
            {
                new Professor { ProfessorId = 1,  Nome = "Professor1", Disciplinas = new List<Disciplina>() },
                new Professor { ProfessorId = 2, Nome = "Professor2", Disciplinas = new List<Disciplina>() },
                new Professor { ProfessorId = 3, Nome = "Professor3", Disciplinas = new List<Disciplina>() }
            };
            professores.ForEach(s => context.Professores.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();
            var disciplinas = new List<Disciplina>
            {
                new Disciplina { DisciplinaId = 1, Nome = "Disciplina1", Professor = professores[0], Turmas = new List<Turma>() },
                new Disciplina { DisciplinaId = 2, Nome = "Disciplina2", Professor = professores[0], Turmas = new List<Turma>() },
                new Disciplina { DisciplinaId = 3, Nome = "Disciplina3", Professor = professores[0], Turmas = new List<Turma>() },
                new Disciplina { DisciplinaId = 4, Nome = "Disciplina4", Professor = professores[1], Turmas = new List<Turma>() },
                new Disciplina { DisciplinaId = 5, Nome = "Disciplina5", Professor = professores[2], Turmas = new List<Turma>() }
            };
            disciplinas.ForEach(s => context.Disciplinas.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();
            var alunos = new List<Aluno>
            {
                new Aluno {AlunoId = 1, Nome = "Aluno1", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 2, Nome = "Aluno2", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 3, Nome = "Aluno3", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 4, Nome = "Aluno4", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 5, Nome = "Aluno5", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 6, Nome = "Aluno6", Turma = turmas[0], TurmaId = turmas[0].Id},
                new Aluno {AlunoId = 7, Nome = "Aluno7", Turma = turmas[1], TurmaId = turmas[1].Id},
                new Aluno {AlunoId = 8, Nome = "Aluno8", Turma = turmas[1], TurmaId = turmas[1].Id},
                new Aluno {AlunoId = 9, Nome = "Aluno9", Turma = turmas[1], TurmaId = turmas[1].Id},
                new Aluno {AlunoId = 10, Nome = "Aluno10", Turma = turmas[2], TurmaId = turmas[2].Id},
                new Aluno {AlunoId = 11, Nome = "Aluno11", Turma = turmas[2], TurmaId = turmas[2].Id},
                new Aluno {AlunoId = 12, Nome = "Aluno12", Turma = turmas[2], TurmaId = turmas[2].Id},
                new Aluno {AlunoId = 13, Nome = "Aluno13", Turma = turmas[2], TurmaId = turmas[2].Id},
                new Aluno {AlunoId = 14, Nome = "Aluno14", Turma = turmas[2], TurmaId = turmas[2].Id},
                new Aluno {AlunoId = 15, Nome = "Aluno15", Turma = turmas[2], TurmaId = turmas[2].Id}
            };
            alunos.ForEach(s => context.Alunos.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();
            professores[0].Disciplinas.Add(disciplinas[0]);
            professores[0].Disciplinas.Add(disciplinas[1]);
            professores[0].Disciplinas.Add(disciplinas[2]);
            professores[1].Disciplinas.Add(disciplinas[3]);
            professores[2].Disciplinas.Add(disciplinas[4]);
            disciplinas[0].Turmas.Add(turmas[0]);
            disciplinas[1].Turmas.Add(turmas[0]);
            disciplinas[2].Turmas.Add(turmas[0]);
            disciplinas[3].Turmas.Add(turmas[1]);
            disciplinas[4].Turmas.Add(turmas[2]);
            turmas[0].Disciplinas.Add(disciplinas[0]);
            turmas[0].Disciplinas.Add(disciplinas[1]);
            turmas[0].Disciplinas.Add(disciplinas[2]);
            turmas[1].Disciplinas.Add(disciplinas[3]);
            turmas[2].Disciplinas.Add(disciplinas[4]);
            turmas[0].Alunos.Add(alunos[0]);
            turmas[0].Alunos.Add(alunos[1]);
            turmas[0].Alunos.Add(alunos[2]);
            turmas[0].Alunos.Add(alunos[3]);
            turmas[0].Alunos.Add(alunos[4]);
            turmas[0].Alunos.Add(alunos[5]);
            turmas[1].Alunos.Add(alunos[6]);
            turmas[1].Alunos.Add(alunos[7]);
            turmas[1].Alunos.Add(alunos[8]);
            turmas[2].Alunos.Add(alunos[9]);
            turmas[2].Alunos.Add(alunos[10]);
            turmas[2].Alunos.Add(alunos[11]);
            turmas[2].Alunos.Add(alunos[12]);
            turmas[2].Alunos.Add(alunos[13]);
            turmas[2].Alunos.Add(alunos[14]);
            context.SaveChanges();
        }

    }
}