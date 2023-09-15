using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lib
{
    public class Individuo
    {
        [Key]
        public int Id { get; set; }
        public string Nome;
        public string Apelido;
        public DateTime DataNasc;
    }
}
