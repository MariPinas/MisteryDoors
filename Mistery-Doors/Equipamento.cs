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

        public Equipamento(int id, string nome, int dano) {
            IdEquipamento = id;
            Nome = nome;
            Dano = dano;
        }
    }
}
