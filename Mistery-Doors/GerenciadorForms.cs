using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portasTestes.Repository;

namespace portasTestes {
    public static class GerenciadorForms {
        public static TelaLogin TelaLogin { get; set; }
        public static TelaPersonagem TelaPersonagem { get; set; }
        public static TelaJogo TelaJogo { get; set; }
        public static TelaPerfil TelaPerfil { get; set; }

        public static TelaInicio TelaInicio { get; set; }
        public static Jogador JogadorAtual { get; set; }  //jogador logado
        public static PersonagemRepository personagemRepository { get; private set; }
        public static JogadorRepository jogadorRepository { get; private set; }

        ////proximos passos utilizar 1 repository doq ficar instanciando a cara operacao
        //static GerenciadorForms() {
        //    string connectionString = "server=localhost;uid=root;pwd=1234;database=mistery_doors";
        //    personagemRepository = new PersonagemRepository(connectionString);
        //    jogadorRepository = new JogadorRepository(connectionString);
        //}

        public static void AbrirTelaInicial() {
            TelaInicio = new TelaInicio();
            TelaInicio.Show();
        }

        public static void InicializarTelaLogin() {
            TelaLogin = new TelaLogin();
            TelaLogin.Show();
        }
        public static void AbrirTelaPerfil(string username) {
            if (TelaPerfil == null || TelaPerfil.IsDisposed) { //se a tela perfil for null ou esta disposed entao a nova vai receber o username
                TelaPerfil = new TelaPerfil(username);
            } else {
                TelaPerfil.AtualizarPerfilJogador(username); //se nao, ela vai atualizar o nome do jogador
            }

            TelaPerfil.Show();
        }

        public static void AbrirTelaPersonagem(Jogador jogador) {
            JogadorAtual = jogador;

            TelaPersonagem = new TelaPersonagem(jogador);
            TelaPersonagem.Show();
        }

        public static void AbrirTelaJogo(Jogador jogador, Personagem personagem) {
            TelaJogo = new TelaJogo(jogador, personagem);
            TelaJogo.Show();
        }

    }
}
