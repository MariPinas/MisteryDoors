using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using portasTestes.Repository;

namespace portasTestes {
    public partial class TelaLogin : Form {
        private static string username;
        private static string senha;
        private static int jogadorId;

        public static int getJogadorId() {
            return jogadorId;
        }
        public static string getUsername() {
            return username;
        }

        public static string getSenha() {
            return senha;
        }
        public TelaLogin() {
            InitializeComponent();
            refresh();
            ConfigurarTelaInicial();
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            // cores do figma
            Color[] cores = {
            ColorTranslator.FromHtml("#EFC981"),
            ColorTranslator.FromHtml("#EE9E69"),
            ColorTranslator.FromHtml("#AE6245")
        };


            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle, cores[0], cores[2], LinearGradientMode.Vertical)) {

                ColorBlend blend = new ColorBlend {
                    Colors = cores,
                    Positions = new float[] { 0.0f, 0.5f, 1.0f } // proporcoes d cores
                };

                brush.InterpolationColors = blend;

                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

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
                GerenciadorForms.AbrirTelaInicial();
            }
        }

        private void BtnContinuar_Click(object sender, EventArgs e) {
            username = txtUsername.Text.Trim();
            senha = txtSenha.Text.Trim();

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

        private void CadastrarUsuario(string nomeUser, string senhaUser) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            //verificar username
            if (jogadorRepository.VerificarUsernameExistente(nomeUser)) {
                lblMsg.Text = "Este username já existe. Escolha outro.";
                lblMsg.Visible = true;
                return;
            }

            jogadorRepository.Adicionar(nomeUser, senhaUser);
            lblMsg.Text = "Conta criada com sucesso!";
            lblMsg.Visible = true;

            refresh();
        }

        private void EntrarUsuario(string nomeUser, string senhaUser) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            // Verificar login
            if (jogadorRepository.VerificarUsuarioExistente(nomeUser, senhaUser)) {
                // Pega o jogador completo
                Jogador jogador = jogadorRepository.GetJogadorPorUsername(nomeUser);

                MessageBox.Show("Login realizado com sucesso!");
                this.Hide();
                GerenciadorForms.AbrirTelaPersonagem(jogador);
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
