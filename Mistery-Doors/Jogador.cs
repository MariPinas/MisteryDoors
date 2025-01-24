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
    }
}
