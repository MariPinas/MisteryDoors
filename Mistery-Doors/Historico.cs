using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Historico
    {
        public int IdHistorico { get; set; }
        public int IdJogador { get; set; }
        public string Resultado { get; set; } // vitoria ou derrota
        public DateTime Data {  get; set; }

        public void RegistrarHistorico(int jogadorId, string resultado) {
            IdJogador = jogadorId;
            Resultado = resultado;
            Data = DateTime.Now;
        }
    }
}
