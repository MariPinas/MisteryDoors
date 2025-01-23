using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Jogador
    {
        private int IdJogador {  get; set; }
        private string Username { get; set; }
        private string Senha { get; set; }
        private int Vitorias { get; set; }
        private int Derrotas { get; set; }
        private Personagem PersonagemId { get; set; }

        public void Reiniciar()
        {
            this.PersonagemId = new Personagem(); 
        }
    }
}
