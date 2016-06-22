using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndTest02.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turno { get; set; }
        public int Ano { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}