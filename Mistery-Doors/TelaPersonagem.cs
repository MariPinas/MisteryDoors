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

namespace portasTestes {
    public partial class TelaPersonagem : Form {

        private string levelSelec;

        public TelaPersonagem() {
            InitializeComponent();

            this.Text = "Tela personagem";
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
            levelSelec = dificuldade;
            btnFacil.Font = new Font(btnFacil.Font, FontStyle.Regular);
            btnMedio.Font = new Font(btnMedio.Font, FontStyle.Regular);
            btnDificil.Font = new Font(btnDificil.Font, FontStyle.Regular);
            btnExtremo.Font = new Font(btnExtremo.Font, FontStyle.Regular);

            botaoSelecionado.Font = new Font(botaoSelecionado.Font, FontStyle.Underline);

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

        private void botaoJogar_Click(object sender, EventArgs e) {
            string nomeJogador = txtNickname.Text;

            if (string.IsNullOrWhiteSpace(nomeJogador)) {
                MessageBox.Show("Por favor, insira o nome do jogador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define o nome e a dificuldade na tela de jogo
            GerenciadorForms.TelaJogo.NomeJogador = nomeJogador;
            GerenciadorForms.TelaJogo.Dificuldade = levelSelec;

            this.Hide();
            GerenciadorForms.TelaJogo.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.TelaInicio.Show();
    }
    }

        //private void textBox1_Enter(object sender, EventArgs e) {
        //    if (textBox1.Text == "NICKNAME HERE") {
        //        textBox1.Text = ""; 
        //        textBox1.ForeColor = Color.Black; 
        //    }
        //}

        //private void textBox1_Leave(object sender, EventArgs e) {
        //    if (string.IsNullOrEmpty(textBox1.Text)) {
        //        textBox1.Text = "NICKNAME HERE";
        //        textBox1.ForeColor = Color.Gray; 
        //    }
        //}
    }


