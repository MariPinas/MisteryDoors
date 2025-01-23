using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Inimigo
    {
        private string Nome {  get; set; }

        private int Dano { get; set; }

        public Inimigo (string nome, int dano)
        {
            Nome = nome;
            
            Dano = dano;
        }

       
    }
}
