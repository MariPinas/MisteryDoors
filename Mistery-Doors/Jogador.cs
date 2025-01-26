using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Jogador
    {
        public int IdJogador {  get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        private int Vitorias { get; set; }
        private int Derrotas { get; set; }

        public List<Personagem> Personagens { get; set; } = new List<Personagem>();

        public int AtualizarVitorias(int soma)
        {
            return Vitorias += soma;
        }
        public int AtualizarDerrotas(int soma)
        {
            return Derrotas += soma;
        }
        public int getIdJogador()
        {
            return this.IdJogador;
        }
        public string getUsername()
        {
            return this.Username;
        }

        public int getVitorias()
        {
            return this.Vitorias;
        }
        public void setVitorias()
        {
            this.Vitorias++;
        }
        public void setVitorias(int vitorias)
        {
            this.Vitorias = vitorias;
        }
        public int getDerrotas()
        {
            return this.Derrotas;
        }
        public void setDerrotas(int derrotas)
        {
            this.Derrotas = derrotas;
        }
        public void setDerrotas()
        {
            this.Derrotas++;
        }
    }
   

}
