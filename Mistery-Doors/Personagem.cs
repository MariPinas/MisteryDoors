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
        public Equipamento ArmaId { get; set; }
        public Portas ProgressoId { get; set; }
        public Fase DificuldadeId { get; set; }


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
            ArmaId = NovaArma;
            DanoPersonagem = 5 + bonusDano;
        }
    }
}
