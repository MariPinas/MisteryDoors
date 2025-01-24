using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Equipamento
    {
        private int IdEquipamento { get; set; }
        private string Nome { get; set; }
        private double Dano { get; set; }
        private string Raridade { get; set; }

        public Equipamento() { }

        public Equipamento(string nome, int dano, string raridade)
        {
            this.Nome = nome;
            this.Dano = dano;
            this.Raridade = raridade;
        }

        public int getIdEquipamento()
        {
            return this.IdEquipamento;
        }

        public void setIdEquipamento(int idEquipamento)
        {
            this.IdEquipamento = idEquipamento;
        }

        public string getNome()
        {
            return this.Nome;
        }

        public void setNome(string nome)
        {
            this.Nome = nome;
        }

        public double getDano()
        {
            return this.Dano;
        }

        public void setDano(double dano)
        {
            this.Dano = dano;
        }

        public string getRaridade()
        {
            return this.Raridade;
        }

        public void setRaridade(string raridade)
        {
            this.Raridade = raridade;
        }


        //static pra nao depender de uma instancia de um equipamento, so vai servir pra gerar um equip aleatorio sem precisar da instancia
        public static Equipamento GerarEquipamento()
        {
            Random r = new Random();
            string raridade = DeterminarRaridade(r);
            string[] nomes = { "Espada ", "Machado ", "Lanca ", "Arco " };
            string[] nomesComplete = { "de Fogo", "de Agua", "de Terra", "de Ar" };

            
            string nome = nomes[r.Next(nomes.Length)] + nomesComplete[r.Next(nomesComplete.Length)];

            int dano = r.Next(3, 11);

            switch (raridade)
            {
                case "Raro":
                    dano += 3;
                    break;
                case "Epico":
                    dano += 5;
                    break;
                case "Lendario":
                    dano += 8;
                    break;
            }

            return new Equipamento(nome, dano, raridade);
        }

        private static string DeterminarRaridade(Random r)
        {
            int chance = r.Next(1, 101);

            if (chance <= 50)
                return "Comum";
            else if (chance <= 80)
                return "Raro";
            else if (chance <= 95)
                return "Épico";
            else
                return "Lendário";
        }
    }
}
