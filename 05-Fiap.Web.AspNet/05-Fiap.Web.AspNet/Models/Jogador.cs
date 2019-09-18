using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Fiap.Web.AspNet.Models
{
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public int DataNascimento { get; set; }
        public float Altura { get; set; }

        //Relacionamento

        public int TimeId { get; set; }


    }
}
