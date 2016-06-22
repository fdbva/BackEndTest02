using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndTest02.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public int? ProfessorId { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}