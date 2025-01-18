using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Name { get; set; }
        public double VidaPersonagem { get; set; } = 3;
        public double DanoPersonagem { get; set; } = 5;
        public Equipamento Arma { get; set; }
        public Portas Progresso { get; set; }
        public Fase Dificuldade { get; set; }


        public void PerderVida()
        {
            if (this.VidaPersonagem > 0)
                VidaPersonagem -= 0.5;
        }

        public void GanharVida()
        {
            if (this.VidaPersonagem < 3)
                VidaPersonagem++;
        }

        public void EquiparArma(Equipamento NovaArma, double bonusDano)
        {
            Arma = NovaArma;
            DanoPersonagem = 5 + bonusDano;
        }
    }
}
