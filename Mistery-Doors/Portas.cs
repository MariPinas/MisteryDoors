using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Portas
    {
        public string Nome { get; set; }
        public double ProbabilidadeInimigo { get; set; } = 0.7;
        public double ProbabilidadeBoss { get; set; } = 0.2;
        public double ProbabilidadeLoot { get; set; } = 0.1;
        public Portas(string nome)
        {
            Nome = nome;
        }
        private static Random r = new Random();

        //public string SorteadorDaPorta(Personagem personagem)
        //{
        //    string resultado;
        //    double chance = r.NextDouble();

        //    if (chance < ProbabilidadeInimigo)
        //    {
        //        Inimigo inimigo = new Inimigo("Inimigos Fracos", r.Next(3, 7));
        //        resultado = RealizarAcao(personagem, inimigo);
        //    }

        //    else if (chance < ProbabilidadeInimigo + ProbabilidadeBoss)
        //    {
        //        Inimigo boss = new Inimigo("Boss Poderoso", r.Next(10, 15));
        //        resultado = RealizarAcao(personagem, boss);
        //    }
        //    else
        //    {
        //        Equipamento loot = Equipamento.GerarEquipamento();
        //        personagem.EquiparArma(loot, loot.Dano);
        //        resultado = $"Você encontrou um loot!\nEquipamento: {loot.Nome} | Dano: {loot.Dano} | Raridade: {loot.Raridade}";
        //    }
        //    return resultado;
        //}

        //public string RealizarAcao(Personagem personagem, Inimigo inimigo)
        //{

        //}
    }
}
