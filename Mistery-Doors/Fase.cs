using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Fase
    {
        public int IdFase { get; set; }
        public string Dificuldade { get; set; }
        public int PortarParaVencer { get; set; }

        public Fase(string dificuldade)
        {
            Dificuldade = dificuldade;
            switch(dificuldade.ToLower())
            {
                case "facil":
                    PortarParaVencer = 5;
                    break;
                case "medio":
                    PortarParaVencer = 7;
                    break;
                case "dificil":
                    PortarParaVencer = 10;
                    break;
                case "extremo":
                    PortarParaVencer = 12;
                    break;
                 default:
                    PortarParaVencer = 5;
                    break;

            }
        }
    }
}
