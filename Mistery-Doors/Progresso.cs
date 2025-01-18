using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Progresso
    {
        public int IdProgresso { get; set; }
        public int IdJogador { get; set; }
        public int FaseAtual {  get; set; }
        public int PortasPassadas { get; set; }

        public void SalvarProgresso(int jogadorId, int faseAtual, int portasPassadas)
        {
            IdJogador = jogadorId;
            FaseAtual = faseAtual;
            PortasPassadas = portasPassadas;
        }
    }
}
