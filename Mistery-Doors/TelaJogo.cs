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

namespace portasTestes
{
    public partial class TelaJogo : Form
    {
        private string NomeJogador { get; set; } //
        private string DificuldadeId { get; set; }

        private Personagem personagem;

        public string getNomeJogador() {
            return NomeJogador;
        }
        public string getDificuldade() {  
            return DificuldadeId; 
        }

        public void setNomeJogador(string nome) {
            NomeJogador = nome;
        }
        public void setDificuldade(string dificuldade) {
            DificuldadeId = dificuldade;
        }

        public TelaJogo()
        {
            InitializeComponent();
            EntrarPortas();
            unit.Visible = true;
            ResetarPersonagem();
            InstanciarPortas();

            personagem = GerenciadorForms.Personagem ?? new Personagem();
            personagem.EquiparArma(Equipamento.GerarEquipamento(), 1);

            lblNickname.Text = personagem.getNomePersonagem();

            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += (s, args) => this.Invalidate();
            btnEntrar.Visible = false;
            btnConfirmar.Visible = false;
            msgRes.Visible = false;
            lblRes.Visible = false;

            lblRes.Size = msgRes.Size;
            lblRes.TextAlign = ContentAlignment.MiddleLeft;
            lblRes.MaximumSize = new Size(msgRes.Width, msgRes.Height);
            lblRes.AutoSize = true;
        }
        private void Form1_Load(object sender, EventArgs e) {

            lblNickname.Text = $"Jogador: {NomeJogador}";
            lblDificuldade.Text = $"DificuldadeId: {DificuldadeId}";
        }

        private PictureBox portaSelecionada;
        Dictionary<PictureBox, Portas> portas = new Dictionary<PictureBox, Portas>();
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

        Image vidaCheia = Properties.Resources.heart;
        Image vidaMeia = Properties.Resources.meioHeart;
        Image vidaVazia = Properties.Resources._0heart;
        
        private void InstanciarPortas()
        {
            Portas porta1 = new Portas("Porta1");
            Portas porta2 = new Portas("Porta2");
            Portas porta3 = new Portas("Porta3");

            portas.Add(Porta1, porta1);
            portas.Add(Porta2, porta2);
            portas.Add(Porta3, porta3);
        }
        
        public void trocarVisualVida(Personagem personagem)
        {
            if (personagem.getVidaPersonagem() == 3)
                pctHeart3.Image = vidaCheia;
            if (personagem.getVidaPersonagem() == 2.5)
                pctHeart3.Image = vidaMeia;
            if (personagem.getVidaPersonagem() == 2)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaCheia;
            }
            if (personagem.getVidaPersonagem() == 1.5)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaMeia;
            }
            if (personagem.getVidaPersonagem() == 1)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaCheia;
            }
            if (personagem.getVidaPersonagem() == 0.5)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaMeia;
            }
            if (personagem.getVidaPersonagem() == 0)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaVazia;
            }
        }
        private void EntrarPortas()
        {
            Porta1.Click += Porta_Click;
            Porta2.Click += Porta_Click;
            Porta3.Click += Porta_Click;
            btnEntrar.Click += BtnEntrar_Click;
        }

        private void Porta_Click(object sender, EventArgs e)
        {
            if(unit.Visible == true)
            {
                PictureBox portaClicada = sender as PictureBox;

                if (portaSelecionada == portaClicada)
                {
                    portaSelecionada = null;
                    btnEntrar.Visible = false;
                    ResetarPersonagem();
                }
                else
                {
                    portaSelecionada = portaClicada;
                    btnEntrar.Visible = true;
                    MoverPersonagemParaPorta(portaSelecionada);
                }
            }
        }
        private void MoverPersonagemParaPorta(PictureBox porta)
        {

            int novaPosX = porta.Location.X + porta.Width / 2 - unit.Width / 2;
            int novaPosY = porta.Location.Y + porta.Height - unit.Height / 2;
            unit.Location = new Point(novaPosX, novaPosY);
        }
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (portaSelecionada == null)
            {
                MessageBox.Show("Nenhuma porta selecionada");
                return;
            }

            Portas porta = new Portas(portaSelecionada.Name);

            string resultado = porta.SorteadorDaPorta(personagem);
            
            if (resultado.Contains("💀 Você foi derrotado!"))
                trocarVisualVida(personagem);
            unit.Visible = false;
            btnConfirmar.Visible = true;
            lblRes.Visible = true;
            lblRes.Text = $"🚪Porta selecionada: {portaSelecionada.Name}\n{resultado}";
            msgRes.Visible = true;

            btnEntrar.Visible = false;


        }
        private void ResetarPersonagem()
        {
            
            unit.Location = new Point(325, 309);
        }

       
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.TelaPersonagem.Show();
        }

        private void lblDificuldade_Click(object sender, EventArgs e) {

        }

        private void lblRes_Click(object sender, EventArgs e) {

        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            unit.Visible = true;
            btnConfirmar.Visible = false;
            lblRes.Visible = false;
            msgRes.Visible = false;


            ResetarPersonagem();
        }
    }
}
