using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mistery_Maze
{
    public class Core
    {
        public readonly static Keys KeyUp = Keys.W;
        public readonly static Keys KeyDown = Keys.S;
        public readonly static Keys KeyLeft = Keys.A;
        public readonly static Keys KeyRight = Keys.D;

        public static bool IsUp = false;
        public static bool IsDown = false;
        public static bool IsLeft = false;
        public static bool IsRight = false;

        private static Random random = new Random();

        // Equipamentos possíveis do baú
        private static readonly List<string> Equipamentos = new List<string>
    {
        "Espada Lendária",
        "Escudo de Ferro",
        "Poção de Cura",
        "Armadura de Ouro",
        "Arco Longo"
    };

        // Tipos de conteúdo possíveis para as portas
        private static readonly List<string> TiposPorta = new List<string>
    {
        "Boss",
        "Baú",
        "Goblins Fracos",
        "Goblins Fortes"
    };

        // Sorteia um equipamento do baú
        public static string SorteiaEquipamento()
        {
            int index = random.Next(Equipamentos.Count);
            return Equipamentos[index];
        }

        // Sorteia o tipo de uma porta
        public static string SorteiaPorta()
        {
            int index = random.Next(TiposPorta.Count);
            return TiposPorta[index];
        }
    }
}
