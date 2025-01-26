using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using portasTestes.Repository;

namespace portasTestes {
    public partial class TelaPerfil : Form {

        private string Username { get; set; }

       
        public TelaPerfil(string nomeUsuario) {
            InitializeComponent();
            this.Username = nomeUsuario; 
            lblNomeUsu.Visible = true;
            lblNovaSenha.Visible = false;
            lblNovoNome.Visible = false;
            txtNovoNome.Visible = false;
            txtNovaSenha.Visible = false;
            btnSalvar.Visible = false;
            btnDeletarConta.Visible = false;
        }

        private void TelaPerfil_Load(object sender, EventArgs e) {
            lblNomeUsu.Text = $"Bem-vindo(a) ao seu perfil, {Username}!";
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            string novoUsername = txtNovoNome.Text;
            string novaSenha = txtNovaSenha.Text;

            if (string.IsNullOrEmpty(novoUsername) || string.IsNullOrEmpty(novaSenha)) {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AtualizarPerfil(novoUsername, novaSenha);
            MessageBox.Show("Perfil atualizado com sucesso!");
            btnEditarPerfil.Visible = true;

           
            lblNovaSenha.Visible = false;
            lblNovoNome.Visible = false;
            txtNovoNome.Visible = false;
            txtNovaSenha.Visible = false;
            btnSalvar.Visible = false;
            btnDeletarConta.Visible = false;
        }
       
        private void AtualizarPerfil(string novoUsername, string novaSenha) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            int idJogador = jogadorRepository.getIdJogador(Username);

            if (idJogador == -1) {
                MessageBox.Show("Jogador não encontrado!");
                return;
            }
            
            jogadorRepository.Atualizar(idJogador, novoUsername, novaSenha);
            GerenciadorForms.TelaPersonagem.Show();
            this.Hide();
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e) {
            btnEditarPerfil.Visible = false;

            lblNovoNome.Visible = true;
            lblNovaSenha.Visible = true;
            txtNovoNome.Visible = true;
            txtNovaSenha.Visible = true;

            btnSalvar.Visible = true;
            btnDeletarConta.Visible = true;
        }

        private void btnDeletarConta_Click(object sender, EventArgs e) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            var resposta = MessageBox.Show("Tem certeza de que deseja excluir sua conta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resposta == DialogResult.Yes) {
                int idJogador = jogadorRepository.getIdJogador(Username);

                jogadorRepository.Deletar(idJogador);

                MessageBox.Show("Conta deletada com sucesso!");
                this.Hide();
                GerenciadorForms.TelaLogin.Show();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.TelaPersonagem.Show();
        }
    }
}
