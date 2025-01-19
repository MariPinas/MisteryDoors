using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portasTestes
{
    public partial class TelaJogo : Form
    {
        
        public string NomeJogador { get; set; } //
        public string Dificuldade { get; set; }

        private PictureBox portaSelecionada;
        Dictionary<PictureBox, Portas> portas = new Dictionary<PictureBox, Portas>();

        Personagem personagem = new Personagem()
        {
            Name = "teste", //coloquei o NomeJogador ali
            ArmaId = Equipamento.GerarEquipamento()
        };

        private void Form1_Load(object sender, EventArgs e) {
            lblNickname.Text = $"Jogador: {NomeJogador}";
            lblDificuldade.Text = $"Dificuldade: {Dificuldade}";
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
        public TelaJogo()
        {
            InitializeComponent();
            EntrarPortas();
            ResetarPersonagem();
            InstanciarPortas();
            btnEntrar.Visible = false;
            btnConfirmar.Visible = false;
            msgRes.Visible = false;
            lblRes.Visible = false;

            lblRes.Size = msgRes.Size;
            lblRes.TextAlign = ContentAlignment.MiddleLeft;
            lblRes.MaximumSize = new Size(msgRes.Width, msgRes.Height);
            lblRes.AutoSize = true;

        }
        public void trocarVisualVida(Personagem personagem)
        {
            if (personagem.VidaPersonagem == 3)
                pctHeart3.Image = vidaCheia;
            if (personagem.VidaPersonagem == 2.5)
                pctHeart3.Image = vidaMeia;
            if (personagem.VidaPersonagem == 2)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaCheia;
            }
            if (personagem.VidaPersonagem == 1.5)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaMeia;
            }
            if (personagem.VidaPersonagem == 1)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaCheia;
            }
            if (personagem.VidaPersonagem == 0.5)
            {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaMeia;
            }
            if (personagem.VidaPersonagem == 0)
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
            if (resultado.Contains("perdeu o combate!"))
                trocarVisualVida(personagem);
            unit.Visible = false;
            btnConfirmar.Visible = true;
            lblRes.Visible = true;
            lblRes.Text = resultado;
            msgRes.Visible = true;

            btnEntrar.Visible = false;

        }
        private void ResetarPersonagem()
        {
            unit.Location = new Point(469, 473);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            unit.Visible = true;
            btnConfirmar.Visible = false;
            lblRes.Visible = false;
            msgRes.Visible = false;


            ResetarPersonagem();
        }

        private void Porta1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
    }
}
