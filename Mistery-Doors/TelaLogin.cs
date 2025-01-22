using System;
using System.Windows.Forms;
using portasTestes.Repository;

namespace portasTestes {
    public partial class TelaLogin : Form {
        public TelaLogin() {
            InitializeComponent();
            refresh();
            ConfigurarTelaInicial();
        }

        private bool isCad;

        private void ConfigurarTelaInicial() {
            btnVoltar.Visible = true;
            btnVoltar.Click += btnVoltar_Click;
            
            txtUsername.Visible = false;
            txtSenha.Visible = false;
            btnContinuar.Visible = false;
            lblMsg.Visible = false;
            lblUsu.Visible = false;
            lblSenha.Visible = false;
            
            btnEntrar.Click += (s, e) => MostrarCampos(false);
            btnCadastrar.Click += (s, e) => MostrarCampos(true); 
            btnContinuar.Click += BtnContinuar_Click; 
        }

        private void MostrarCampos(bool cadastro) {
            isCad = cadastro;

            
            btnEntrar.Visible = false;
            btnCadastrar.Visible = false;

            
            txtUsername.Visible = true;
            txtSenha.Visible = true;
            btnContinuar.Visible = true;
            lblUsu.Visible = true;
            lblSenha.Visible = true;

            
            btnContinuar.Text = cadastro ? "CADASTRAR" : "ENTRAR";
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            if (txtUsername.Visible || txtSenha.Visible) // se os txt estiverem visiveis
            {
                refresh(); //entao retorna para o estado inical
            } else {
                //mas se ele ja esta no estado inicial entao volta para tela inicio
                this.Hide();
                GerenciadorForms.TelaInicio.Show();
            }
        }

        private void BtnContinuar_Click(object sender, EventArgs e) {
            string username = txtUsername.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(senha)) {
                lblMsg.Text = "Por favor, preencha todos os campos.";
                lblMsg.Visible = true;
                return;
            }

            if (isCad) {
                CadastrarUsuario(username, senha);
            } else {
                EntrarUsuario(username, senha);
            }
        }

        private void CadastrarUsuario(string username, string senha) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            //verificar username
            if (jogadorRepository.VerificarUsuarioExistente(username, senha)) {
                lblMsg.Text = "Este username já existe. Escolha outro.";
                lblMsg.Visible = true;
                return;
            }

            jogadorRepository.Adicionar(username, senha);
            lblMsg.Text = "Conta criada com sucesso!";
            lblMsg.Visible = true;

            refresh();
        }

        private void EntrarUsuario(string username, string senha) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            //verificar login
            if (jogadorRepository.VerificarUsuarioExistente(username, senha)) {
                MessageBox.Show("Login realizado com sucesso!");
                this.Hide();
                GerenciadorForms.TelaPersonagem.Show();
            } else {
                lblMsg.Text = "Username ou senha incorretos.";
                lblMsg.Visible = true;
            }
        }

        private void refresh() {
            // refresh na tela
            txtUsername.Clear();
            txtSenha.Clear();
            txtUsername.Visible = false;
            txtSenha.Visible = false;
            btnContinuar.Visible = false;
            lblMsg.Visible = false;
            lblUsu.Visible = false;
            lblSenha.Visible = false;

            btnEntrar.Visible = true;
            btnCadastrar.Visible = true;
        }
    }
}
