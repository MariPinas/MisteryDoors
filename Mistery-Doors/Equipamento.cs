using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string Nome {  get; set; }
        public int Dano { get; set; }
        public string Raridade { get; set; }

        public Equipamento(string nome, int dano, string raridade) {
            Nome = nome;
            Dano = dano;
            Raridade = raridade;
        }

        //static pra nao depender de uma instancia de um equipamento, so vai servir pra gerar um equip aleatorio sem precisar da instancia
        public static Equipamento GerarEquipamento()
        {
            Random r = new Random();
            string[] raridades = { "Comum", "Raro", "Epico", "Lendario" };
            string[] nomes = { "Espada ", "Machado ", "Lanca ", "Arco " };
            string[] nomesComplete = { "de Fogo", "de Agua", "de Terra", "de Ar" };

            string raridade = raridades[r.Next(raridades.Length)];
            string nome = nomes[r.Next(nomes.Length)] + nomesComplete[r.Next(nomesComplete.Length)];

            int dano = r.Next(5, 21);

            switch (raridade)
            {
                case "Raro": 
                    dano += 5;
                    break;
                case "Epico":
                    dano += 10;
                    break;
                case "Lendario":
                    dano += 15;
                    break;
            }

            return new Equipamento(nome, dano, raridade);
        }
    }
}
