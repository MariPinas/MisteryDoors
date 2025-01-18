using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mistery_Maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeLabirinto();
        }
        private Dictionary<Control, string> portas; // Associa cada porta ao seu conteúdo
        private Label textoResultado;
        private Player player;
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Core.KeyUp)
                Core.IsUp = true;
            if (e.KeyCode == Core.KeyDown)
                Core.IsDown = true;
            if (e.KeyCode == Core.KeyRight)
                Core.IsRight = true;
            if (e.KeyCode == Core.KeyLeft)
                Core.IsLeft = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Core.KeyUp)
                Core.IsUp = false;
            if (e.KeyCode == Core.KeyDown)
                Core.IsDown = false;
            if (e.KeyCode == Core.KeyRight)
                Core.IsRight = false;
            if (e.KeyCode == Core.KeyLeft)
                Core.IsLeft = false;
        }

        private void a(object sender, EventArgs e)
        {

        }

        private void player1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void InitializeLabirinto()
        {
            this.Text = "Labirinto";
            this.Size = new Size(800, 600);

            // Adiciona o jogador
            player = new Player
            {
                Location = new Point(50, 50) // Posição inicial do jogador
            };
            this.Controls.Add(player);

            // Adiciona as portas
            portas = new Dictionary<Control, string>();
            AdicionarPorta("Porta 1", 600, 100);
            AdicionarPorta("Porta 2", 100, 400);
            AdicionarPorta("Porta 3", 600, 400);
            AdicionarPorta("Porta 4", 300, 300);

            // Adiciona um label para exibir os resultados
            textoResultado = new Label
            {
                Location = new Point(50, 500),
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Text = "Explore o labirinto e clique em uma porta!"
            };
            this.Controls.Add(textoResultado);

            Timer collisionTimer = new Timer
            {
                Interval = 50 // Verifica colisões a cada 50ms
            };
            collisionTimer.Tick += VerificarColisoes;
            collisionTimer.Start();

        }

        private void AdicionarPorta(string nome, int x, int y)
        {
            Label porta = new Label
            {
                Text = nome,
                Location = new Point(x, y),
                Size = new Size(100, 50),
                BackColor = Color.Brown, // Cor para visualizar as portas
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White
            };

            // Sorteia o conteúdo desta porta
            string conteudo = Core.SorteiaPorta();
            portas.Add(porta, conteudo);

            this.Controls.Add(porta);
        }
        private void VerificarColisoes(object sender, EventArgs e)
        {
            foreach (var porta in portas)
            {
                if (player.Bounds.IntersectsWith(porta.Key.Bounds))
                {
                    MostrarResultado(porta.Value); // Exibe o conteúdo da porta
                    break; // Sai do loop após a colisão
                }
            }
        }

        private void MostrarResultado(string conteudo)
        {
            if (conteudo == "Boss")
            {
                textoResultado.Text = "Você encontrou um boss! Prepare-se para a batalha!";
            }
            else if (conteudo == "Baú")
            {
                string equipamento = Core.SorteiaEquipamento();
                textoResultado.Text = $"Você encontrou um baú! Ele contém: {equipamento}";
            }
            else if (conteudo == "Goblins Fracos")
            {
                textoResultado.Text = "Você encontrou goblins fracos. Fácil de derrotar!";
            }
            else if (conteudo == "Goblins Fortes")
            {
                textoResultado.Text = "Você encontrou goblins fortes. Um desafio espera por você!";
            }
        }
    }
}
