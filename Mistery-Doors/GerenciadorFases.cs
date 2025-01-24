using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes {
    internal class GerenciadorFases {
            public static int ObterPortasParaVencer(string dificuldade) {
                switch (dificuldade.ToLower()) {
                    case "facil":
                        return 5;
                    case "media":
                        return 10;
                    case "dificil":
                        return 15;
                case "extremo":
                        return 25;
                    default:
                        throw new ArgumentException("Dificuldade inválida!");
                }
            }
        
    }
}
