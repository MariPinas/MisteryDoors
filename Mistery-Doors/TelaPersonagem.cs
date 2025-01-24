using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using portasTestes.Repository;

namespace portasTestes {
    public partial class TelaPersonagem : Form {

        private string levelSelec;

        public TelaPersonagem() {
            InitializeComponent();

            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += (s, e) => this.Invalidate();

            botaoJogar.Visible = false;
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

        private void SelecionarDificuldade(Button botaoSelecionado, string dificuldade) {
            FaseRepository faseRepository = new FaseRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            levelSelec = dificuldade;
            btnFacil.Font = new Font(btnFacil.Font, FontStyle.Regular);
            btnMedio.Font = new Font(btnMedio.Font, FontStyle.Regular);
            btnDificil.Font = new Font(btnDificil.Font, FontStyle.Regular);
            btnExtremo.Font = new Font(btnExtremo.Font, FontStyle.Regular);

            botaoSelecionado.Font = new Font(botaoSelecionado.Font, FontStyle.Underline);
            int dificuldadeId = faseRepository.ObterIdDificuldade(dificuldade);

            botaoJogar.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) {
            
        }

        private void label1_Click_1(object sender, EventArgs e) {

        }

        private void btnFacil_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnFacil, "Facil");
        }

        private void btnMedio_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnMedio, "Medio");
        }

        private void btnDificil_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnDificil, "Dificil");
        }

        private void btnExtremo_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnExtremo, "Extremo");
        }

        private int InstanciarFase(string dificuldade) {
            Fase fase = new Fase(dificuldade); 
            var faseRepository = new FaseRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");

            return faseRepository.AdicionarFase(fase);
        }

        public int CriarPersonagem(int faseId)
        {
            if(GerenciadorForms.Personagem != null)
            {
                MessageBox.Show("Voce ja tem um personagem criado!");
                return -1;
            }
            if (string.IsNullOrWhiteSpace(txtNickname.Text))
            {
                MessageBox.Show("Digite um nome para o seu personagem antes de continuar.");
                return -1;
            }

            Personagem personagem = new Personagem(txtNickname.Text, faseId);
            Equipamento nova = Equipamento.GerarEquipamento();
            personagem.setArmaId(nova);

            GerenciadorForms.Personagem = personagem;

            var personagemRepository = new PersonagemRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            return personagemRepository.AdicionarPersonagem(personagem);
        }
       
        public void AssociarPersonagemAoJogador(int jogadorId, int personagemId) {
            var jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            jogadorRepository.AssociarPersonagemAoJogador(jogadorId, personagemId);
        }

        private void botaoJogar_Click(object sender, EventArgs e) {
            JogadorRepository jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            if (levelSelec == null) {
                MessageBox.Show("Selecione uma dificuldade primeiro.");
                return;
            }

            int faseId = InstanciarFase(levelSelec);
            int personagem = CriarPersonagem(faseId);

            MessageBox.Show("Personagem criado e associado com sucesso!");
            this.Hide();
            GerenciadorForms.TelaJogo.Show();  
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.TelaLogin.Show();
    }

        private void btnPerfil_Click(object sender, EventArgs e) {
            string username = TelaLogin.getUsername();
           
            GerenciadorForms.TelaPerfil.setUsername(username);
            this.Hide();
            GerenciadorForms.TelaPerfil.Show();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void TelaPersonagem_Load(object sender, EventArgs e) {
           
            txtNickname.Visible = true;
            lblNomePersonagem.Visible = false;
        }
    }
    }


