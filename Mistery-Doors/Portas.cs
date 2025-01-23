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
                Inimigo boss = new Inimigo("Boss Poderoso", r.Next(7, 13));
                resultado = RealizarAcao(personagem, boss);
            }
            else
            {
                Equipamento loot = Equipamento.GerarEquipamento();
                resultado = $"\n🔹 Você encontrou um tesouro!\n" +
                            $"✨ Equipamento: {loot.Nome}\n" +
                            $"⚔️ Dano: {loot.Dano} | 🌟 Raridade: {loot.Raridade}";
                if (loot.Dano >= personagem.ArmaId.Dano)
                {
                    personagem.EquiparArma(loot, loot.Dano);
                    resultado += $"\n✔️ Você equipou a nova arma, pois ela tem um dano maior!";
                }
                else
                    resultado += $"\n❌ Você decidiu não equipar o novo item, pois ele é inferior à sua arma atual.";
            }
            return resultado;
        }

        public string RealizarAcao(Personagem personagem, Inimigo inimigo)
        {
            personagem.EquiparArma(personagem.ArmaId, personagem.ArmaId.Dano); //descomentar se nao fica a arma inicial bugada, o dano fica errado
            string log =$"🔹 {personagem.Name} está enfrentando {inimigo.Nome}!\n\n" +
                        $"⚔️ Seu dano: {personagem.DanoPersonagem} | Arma: {personagem.ArmaId.Nome} (Dano: {personagem.ArmaId.Dano})\n" +
                        $"👾 Dano do inimigo: {inimigo.Dano}";
            if (personagem.DanoPersonagem > inimigo.Dano)
            {
                log += "\n\n🎉 Você venceu o combate!\n";
                if (r.Next(0, 100) < 50)
                {
                    Equipamento loot = Equipamento.GerarEquipamento();
                    log += $"\n✨ Você encontrou um tesouro:\n" +
                           $"⚔️ {loot.Nome} | Dano: {loot.Dano} | 🌟 Raridade: {loot.Raridade}";

                    if (loot.Dano >= personagem.ArmaId.Dano)
                    {
                        personagem.EquiparArma(loot, loot.Dano);
                        log += "\n✔️ Você equipou a nova arma, pois ela tem um dano maior!";
                    }
                    else
                        log += "\n❌ Você decidiu não equipar o novo item, pois ele é inferior à sua arma atual.";
                }else
                    log += "\n📦 Infelizmente, o inimigo não deixou nenhum loot para trás.";
            }
            
            else
            {
                log += "\n\n💀 Você foi derrotado!\n" +
                       "⚠️ Você perdeu uma vida. Tente novamente!";
                personagem.PerderVida();
            }
            return log;
        }
    }
}
