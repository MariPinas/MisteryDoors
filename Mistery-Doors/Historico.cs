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


        public int getIdHistorico()
        {
            return this.IdHistorico;
        }

        public void setIdHistorico(int idHistorico)
        {
            this.IdHistorico = idHistorico;
        }

        public int getIdJogador()
        {
            return this.IdJogador;
        }

        public void setIdJogador(int idJogador)
        {
            this.IdJogador = idJogador;
        }

        public string getResultado()
        {
            return this.Resultado;
        }

        public void setResultado(string resultado)
        {
            if (resultado.ToLower() == "vitoria" || resultado.ToLower() == "derrota")
            {
                this.Resultado = resultado;
            }
            else
            {
                throw new ArgumentException("O resultado deve ser 'vitoria' ou 'derrota'.");
            }
        }

        public DateTime getData()
        {
            return this.Data;
        }

        public void setData(DateTime data)
        {
            this.Data = data;
        }

    }
}
