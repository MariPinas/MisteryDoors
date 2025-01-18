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
        private PictureBox portaSelecionada;
        Dictionary<PictureBox, Portas> portas = new Dictionary<PictureBox, Portas>();
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
            if(portaSelecionada == null)
            {
                MessageBox.Show("Nenhuma porta selecionada");
                return;
            }

            Portas porta = new Portas(portaSelecionada.Name);

            string resultado = porta.SorteadorDaPorta();

            MessageBox.Show(resultado, $"Porta {porta.Nome}");
            ResetarPersonagem();
            btnEntrar.Visible = false;
        }
        private void ResetarPersonagem()
        {
            unit.Location = new Point(469, 473); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
