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
        public string Nome { get; set; }
        public int Vidas { get; set; } = 3;
        public Personagem PersonagemId { get; set; }

        public void Reiniciar()
        {
            Vidas = 3;
            this.PersonagemId = new Personagem();
            
        }
    }
}
