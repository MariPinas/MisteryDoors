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
        private  Jogador _jogador {  get; set; }
        private string levelSelec;

        PersonagemRepository personagemRepository = new PersonagemRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
        JogadorRepository jogadorRepository = new JogadorRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
        public TelaPersonagem(Jogador jogador) {
            InitializeComponent();
            this._jogador = jogador;
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += (s, e) => this.Invalidate();

            botaoJogar.Visible = false;

            jogadorRepository.Atualizar(jogador.getIdJogador(),jogador.getUsername(),null, jogador.getVitorias(), jogador.getDerrotas());
            label1.Text = jogador.getVitorias().ToString() + " VITORIAS!";
            label2.Text = jogador.getDerrotas().ToString() + " DERROTAS!";
        }

        public Jogador getJogador() {
            return this._jogador;
        }
        public void setJogador(Jogador jogador) {
            this._jogador = jogador;
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
            FaseRepository faseRepository = new FaseRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
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
            SelecionarDificuldade(btnFacil, "facil");
        }

        private void btnMedio_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnMedio, "medio");
        }

        private void btnDificil_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnDificil, "dificil");
        }

        private void btnExtremo_Click(object sender, EventArgs e) {
            SelecionarDificuldade(btnExtremo, "extremo");
        }

        private int ObterIdFase(string dificuldade) {
            FaseRepository faseRepository = new FaseRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
            return faseRepository.ObterIdDificuldade(dificuldade); //return idFase correspondente a dificuldade selecionada
        }

        public Personagem CriarPersonagem(int faseId, int jogadorId)
        {
            // Verificar se o jogador já possui um personagem
            Personagem personagemExistente = personagemRepository.ObterPersonagemPorJogador(jogadorId);

            if (personagemExistente != null)
            {
                return personagemExistente; // Retorna o personagem existente, caso já exista
            }

            ProgressoRepository progressoRepo = new ProgressoRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
            int idProgresso = progressoRepo.ObterOuCriarProgresso(jogadorId, faseId, 0); 

            Personagem novoPersonagem = new Personagem("Linke", faseId, jogadorId);
            novoPersonagem.setProgresso(idProgresso); 

            var personagemCriado = personagemRepository.AdicionarPersonagem(novoPersonagem);

            return personagemCriado;
        }


        private void botaoJogar_Click(object sender, EventArgs e) {
            Personagem personagem = _jogador.Personagens.FirstOrDefault();

            if (personagem != null) {
                GerenciadorForms.AbrirTelaJogo(_jogador, personagem);
                this.Hide();
            } else {
                Jogador jogador1 = getJogador();
                int jogadorId = jogadorRepository.getIdJogador(TelaLogin.getUsername());
                int faseId = ObterIdFase(levelSelec);
                personagem = CriarPersonagem(faseId, jogadorId);
                personagemRepository.AssociarPersonagemAoJogador(personagem.getIdPersonagem(), jogadorId);

                this.Hide();
                GerenciadorForms.AbrirTelaJogo(jogador1, personagem);
            }
            
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.InicializarTelaLogin();
    }

        private void btnPerfil_Click(object sender, EventArgs e) {
            string username = TelaLogin.getUsername();
            TelaPerfil telaPerfil = new TelaPerfil(username);  
            this.Hide();
            telaPerfil.Show();
        }


        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void TelaPersonagem_Load(object sender, EventArgs e)
        {
            JogadorRepository jogadorRepo = new JogadorRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
            List<int> fasesDesbloqueadas = jogadorRepo.ObterFasesDesbloqueadas(_jogador.getIdJogador());

            btnMedio.Visible = false;
            btnDificil.Visible = false;
            btnExtremo.Visible = false;

            btnFacil.Visible = true;

            if (fasesDesbloqueadas.Contains(2))
            {
                btnMedio.Visible = true;
            }
            if (fasesDesbloqueadas.Contains(3))
            {
                btnDificil.Visible = true;
            }
            if (fasesDesbloqueadas.Contains(4))
            {
                btnExtremo.Visible = true;
            }
        }


        private void lblNomePersonagem_Click(object sender, EventArgs e)
        {

        }
    }
    }


