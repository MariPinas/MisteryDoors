using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Historico
    {
        private int IdHistorico { get; set; }
        private int IdJogador { get; set; }
        private string Resultado { get; set; } // vitoria ou derrota
        private DateTime Data {  get; set; }

        public void RegistrarHistorico(int jogadorId, string resultado) {
            IdJogador = jogadorId;
            Resultado = resultado;
            Data = DateTime.Now;
        }
    }
}
