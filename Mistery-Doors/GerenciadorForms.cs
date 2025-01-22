using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portasTestes {
    internal class GerenciadorForms {
        public static TelaInicio TelaInicio { get; } = new TelaInicio();
        public static TelaPersonagem TelaPersonagem { get; } = new TelaPersonagem();
        public static TelaJogo TelaJogo { get; } = new TelaJogo();

        public static TelaLogin TelaLogin { get; } = new TelaLogin();
    }
}
