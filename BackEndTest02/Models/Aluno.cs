using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndTest02.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public int? TurmaId { get; set; }

        public virtual Turma Turma { get; set; }
    }
}