using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Portas
    {
        public string Nome {  get; set; }
        public double ProbabilidadeInimigo { get; set; } = 0.7;
        public double ProbabilidadeBoss { get; set; } = 0.2;
        public double ProbabilidadeLoot { get; set; } = 0.1;
        public Portas(string nome) {
            Nome = nome;
         }
        private static Random r = new Random();

        public string SorteadorDaPorta()
        {
            
            double chance = r.NextDouble();

            if (chance < ProbabilidadeInimigo)
                return "Inimigos Fracos";
            else if (chance < ProbabilidadeInimigo + ProbabilidadeBoss)
                return "Boss";
            else
                return "Loot";
        }
    }
}
