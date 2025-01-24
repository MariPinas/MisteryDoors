using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Portas
    {
        private string Nome { get; set; }
        private double ProbabilidadeInimigo { get; set; } = 0.7;
        private double ProbabilidadeBoss { get; set; } = 0.2;
        private double ProbabilidadeLoot { get; set; } = 0.1;
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
                            $"✨ Equipamento: {loot.getNome()}\n" +
                            $"⚔️ Dano: {loot.getDano()} | 🌟 Raridade: {loot.getRaridade()}";
                if (loot.getDano() >= personagem.getArmaId().getDano())
                {
                    personagem.EquiparArma(loot, loot.getDano());
                    resultado += $"\n✔️ Você equipou a nova arma, pois ela tem um dano maior!";
                }
                else
                    resultado += $"\n❌ Você decidiu não equipar o novo item, pois ele é inferior à sua arma atual.";
            }
            return resultado;
        }

        public string RealizarAcao(Personagem personagem, Inimigo inimigo)
        {
            if (personagem.getArmaId() == null)
                personagem.EquiparArma(Equipamento.GerarEquipamento(), 1);

            personagem.EquiparArma(personagem.getArmaId(), personagem.getArmaId().getDano()); 
            string log =$"🔹 {GerenciadorForms.Personagem.getNomePersonagem()} está enfrentando {inimigo.getNome()}!\n\n" +
                        $"⚔️ Seu dano: {personagem.getDanoPersonagem()} | ArmaId: {personagem.getArmaId().getNome()} (Dano: {personagem.getArmaId().getDano()})\n" +
                        $"👾 Dano do inimigo: {inimigo.getDano()}";
            if (personagem.getDanoPersonagem() > inimigo.getDano())
            {
                log += "\n\n🎉 Você venceu o combate!\n";
                if (r.Next(0, 100) < 50)
                {
                    Equipamento loot = Equipamento.GerarEquipamento();
                    log += $"\n✨ Você encontrou um tesouro:\n" +
                           $"⚔️ {loot.getNome()} | Dano: {loot.getDano()} | 🌟 Raridade: {loot.getRaridade()}";

                    if (loot.getDano() >= personagem.getArmaId().getDano())
                    {
                        personagem.EquiparArma(loot, loot.getDano());
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
