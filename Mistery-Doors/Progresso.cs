using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Progresso
    {
        private int IdProgresso { get; set; }
        private int IdJogador { get; set; }
        private int FaseAtual {  get; set; }
        private int PortasPassadas { get; set; }

        public void SalvarProgresso(int jogadorId, int faseAtual, int portasPassadas)
        {
            IdJogador = jogadorId;
            FaseAtual = faseAtual;
            PortasPassadas = portasPassadas;
        }
    }
}
