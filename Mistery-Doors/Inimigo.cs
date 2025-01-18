using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Inimigo
    {
        public string Nome {  get; set; }  
        public int Dano { get; set; }

        public Inimigo (string nome, int dano)
        {
            Nome = nome;
           
            Dano = dano;
        }    
    }
}
