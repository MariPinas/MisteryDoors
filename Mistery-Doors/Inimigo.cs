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
        public double Vida { get; set; }
        public int Dano { get; set; }

        public Inimigo (string nome, double vida, int dano)
        {
            Nome = nome;
            Vida = vida;
            Dano = dano;
        }

        public void PerderVida(int dano)
        {
            if(Vida >0) 
                 Vida -= dano;
            else if(Vida == 0 && Vida < 0) 
               Vida = 0;
        }
    }
}
