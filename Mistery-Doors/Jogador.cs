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
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public Personagem PersonagemId { get; set; }

        public void Reiniciar()
        {
            this.PersonagemId = new Personagem(); 
        }
    }
}
