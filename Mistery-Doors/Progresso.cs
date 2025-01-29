using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class ProgressoId
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

        public int getIdProgresso()
        {
            return this.IdProgresso;
        }

        public void setIdProgresso(int idProgresso)
        {
            this.IdProgresso = idProgresso;
        }

        public int getIdJogador()
        {
            return this.IdJogador;
        }

        public void setIdJogador(int idJogador)
        {
            this.IdJogador = idJogador;
        }

        public int getFaseAtual()
        {
            return this.FaseAtual;
        }

        public void setFaseAtual(int faseAtual)
        {
            this.FaseAtual = faseAtual;
        }

        public int getPortasPassadas()
        {
            return this.PortasPassadas;
        }
        public void setPortasPassadas(int portasPassadas)
        {
            this.PortasPassadas = portasPassadas;
        }
    }

}
