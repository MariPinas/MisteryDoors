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

        public string SorteadorDaPorta(Personagem personagem)
        {
            string resultado;
            double chance = r.NextDouble();

            if (chance < ProbabilidadeInimigo)
            {
                Inimigo inimigo = new Inimigo("Inimigos Fracos", r.Next(3, 7));
                resultado = RealizarAcao(personagem, inimigo);
            }

            else if (chance < ProbabilidadeInimigo + ProbabilidadeBoss)
            {
                Inimigo boss = new Inimigo("Boss Poderoso", r.Next(10, 15));
                resultado = RealizarAcao(personagem, boss);
            }
            else
            {
                Equipamento loot = Equipamento.GerarEquipamento();
                resultado = $"\nVocê encontrou um loot!\nEquipamento: {loot.Nome} | Dano: {loot.Dano} | Raridade: {loot.Raridade}";
                if (loot.Dano >= personagem.ArmaId.Dano)
                {
                    personagem.EquiparArma(loot, loot.Dano);
                    resultado += $"\nVocê equipou a Arma com o dano maior!";
                }
                else
                    resultado += $"\nVocê nao pegou o loot com dano menor!";
            }
            return resultado;
        }

        public string RealizarAcao(Personagem personagem, Inimigo inimigo)
        {
            //personagem.EquiparArma(personagem.Arma, personagem.Arma.Dano); //descomentar se nao fica a arma inicial bugada, o dano fica errado
            string log = $"Personagem Nome: {personagem.Name} | Personagem Dano: {personagem.DanoPersonagem}\nPersonagem Arma: {personagem.ArmaId.Nome} | Dano {personagem.ArmaId.Dano}\n Inimigo {inimigo.Nome} | Inimigo Dano: {inimigo.Dano}";

            if (personagem.DanoPersonagem > inimigo.Dano)
            {
                log += "\nVocê venceu o combate!\n";
                if (r.Next(0, 100) < 50)
                {
                    Equipamento loot = Equipamento.GerarEquipamento();
                    log += $"\nLoot recebido:\n {loot.Nome} | Dano: {loot.Dano} | Raridade: {loot.Raridade}\n";
                    if (loot.Dano >= personagem.ArmaId.Dano)
                    {
                        personagem.EquiparArma(loot, loot.Dano);
                        log += "\nLoot é melhor que a arma atual e voce pegou ela!";
                    }
                    else
                        log += "\nA arma era pior e voce nao pegou ela!";
                }
            }
            else
            {
                log += "\n Voce perdeu o combate!\n";
                personagem.PerderVida();
            }
            return log;
        }
    }
}
