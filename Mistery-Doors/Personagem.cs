using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Personagem
    {
        private int IdPersonagem { get; set; }
        private string Name { get; set; }
        private double VidaPersonagem { get; set; } = 3;
        private double DanoPersonagem { get; set; } = 5;
        private Equipamento ArmaId { get; set; }
        private Portas ProgressoId { get; set; }
        private Fase DificuldadeId { get; set; }


        public string getNomePersonagem()
        {
            return this.Name;
        }

        public void setNomePersonagem(string name)
        {
            this.Name = name;
        }

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
