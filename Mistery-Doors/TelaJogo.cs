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

namespace portasTestes
{
    public partial class TelaJogo : Form
    {
        private string NomeJogador; //
        private string DificuldadeId;
        private Jogador _jogador;
        private Personagem _personagem;

        private ProgressoRepository _progressoRepo;
       
        private int portasPassadasCount = 0;
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

        public TelaJogo(Jogador jogador, Personagem personagem) {
            InitializeComponent();
            ResetarPersonagem();
            _jogador = jogador;
            _personagem = personagem;
            EntrarPortas();
            unit.Visible = true;
            ResetarPersonagem();
            InstanciarPortas();
            _progressoRepo = new ProgressoRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            lblNickname.Text = personagem.getNomePersonagem();
            CarregarProgresso();

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


        private void SalvarProgresso() // ue nao ta snedo usado pra nada depois exclui entao
        {
            try
            {
                int idJogador = _jogador.getIdJogador();
                int faseAtual = _personagem.getFaseId();
                

                _progressoRepo.ObterOuCriarProgresso(idJogador, faseAtual, portasPassadasCount);

                MessageBox.Show("Progresso salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar progresso: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            // atualiza a vida do personagem -> caso ele já existisse
            trocarVisualVida(_personagem);

            lblNickname.Text = $"Jogador: {_jogador.getUsername()}";
            int dificuldade = _personagem.getFaseId();

            if (dificuldade == 1)
                lblDificuldade.Text = "Dificuldade\n Fácil! 😄🌱";
            else if (dificuldade == 2)
                lblDificuldade.Text = "Dificuldade\n Média! 🤔⚖️";
            else if (dificuldade == 3)
                lblDificuldade.Text = "Dificuldade\n Difícil! 😬🔥";
            else if (dificuldade == 4)
                lblDificuldade.Text = "Dificuldade\n Extremo! 😱💥";
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

        public void trocarVisualVida(Personagem personagem) {
            // Atualizando vida visual
            if (personagem.getVidaPersonagem() == 3)
                pctHeart3.Image = vidaCheia;
            if (personagem.getVidaPersonagem() == 2.5)
                pctHeart3.Image = vidaMeia;
            if (personagem.getVidaPersonagem() == 2) {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaCheia;
            }
            if (personagem.getVidaPersonagem() == 1.5) {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaMeia;
            }
            if (personagem.getVidaPersonagem() == 1) {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaCheia;
            }
            if (personagem.getVidaPersonagem() == 0.5) {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaMeia;
            }
            if (personagem.getVidaPersonagem() == 0) {
                pctHeart3.Image = vidaVazia;
                pctHeart2.Image = vidaVazia;
                pctHeart1.Image = vidaVazia;
            }

            PersonagemRepository personagemRepo = new PersonagemRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
            personagemRepo.AtualizarVida(personagem.getIdPersonagem(), personagem.getVidaPersonagem());
        }
        private void CarregarProgresso()
        {
            int totalPortas = _progressoRepo.ObterPortasPassadas(_jogador.getIdJogador());
            portasPassadasCount = totalPortas;

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
            if (unit.Visible == true)
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
                    unit.BringToFront();
                    unit.BackColor = Color.Transparent;
                }
            }
        }
        private void MoverPersonagemParaPorta(PictureBox porta)
        {

            int novaPosX = porta.Location.X + porta.Width / 2 - unit.Width / 2;
            int novaPosY = porta.Location.Y + porta.Height - unit.Height / 2 - 10;
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

            string resultado = porta.SorteadorDaPorta(_personagem);
            if (resultado.Contains("🔹 Você encontrou um tesouro!\n"))
                trocarVisualVida(_personagem);
            //if (resultado.Contains("🎉 Você venceu o combate!"))   //ESTA EM FINALIZAR FASE
            //    _jogador.AtualizarVitorias(1);
            if (resultado.Contains("💀 Você foi derrotado!")){
                    //_jogador.AtualizarDerrotas(1);                 // ESTA EM BTN ENTRAR CLICK logo abaixo
                    trocarVisualVida(_personagem);
                }

                unit.Visible = false;
                btnConfirmar.Visible = true;
                lblRes.Visible = true;
                lblRes.Text = $"🚪Porta selecionada: {portaSelecionada.Name}\n{resultado}";
                msgRes.Visible = true;

                btnEntrar.Visible = false;
            
                portasPassadasCount++;
                _progressoRepo.IncrementarPortasPassadas(_jogador.getIdJogador());
                SalvarOuAtualizarProgresso();

                int portasNecessarias = ObterPortasNecessarias(_personagem.getFaseId());
                if (portasPassadasCount >= portasNecessarias)
                {
                    FinalizarFase();
                }
            if (_personagem.getVidaPersonagem() <= 0) {
                var progressoRepository = new ProgressoRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
                int progressoId = _personagem.getProgressoId();
                progressoRepository.Deletar(progressoId);
                _jogador.AtualizarDerrotas(1); // COLOQUEI AQUI NA MINHA CABECA FAZ MAIS SENTIDO
                MessageBox.Show("Seu personagem morreu! Redirecionando para a tela de personagem.");
                this.Hide();
                GerenciadorForms.AbrirTelaPersonagem(_jogador);
            }

        }
        private void SalvarOuAtualizarProgresso()
        {
            try
            {
                int idJogador = _jogador.getIdJogador();
                int faseAtual = _personagem.getFaseId();

                var progressoExistente = _progressoRepo.ObterTodos().FirstOrDefault(p => p.IdJogador == idJogador);

                if (progressoExistente != default)
                {
                    _progressoRepo.Atualizar(progressoExistente.IdProgresso, faseAtual, portasPassadasCount);

                    var personagemRepo = new PersonagemRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
                    personagemRepo.AtualizarFasePersonagem(_personagem.getIdPersonagem(), faseAtual);

                    _personagem.setProgresso(progressoExistente.IdProgresso);
                }
                else
                {
                    int idProgresso = _progressoRepo.ObterOuCriarProgresso(idJogador, faseAtual, portasPassadasCount);

                    var personagemRepo = new PersonagemRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
                    personagemRepo.AtualizarProgressoNoPersonagem(_personagem.getIdPersonagem(), idProgresso);

                    _personagem.setProgresso(idProgresso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar progresso: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetarPersonagem()
        {
            unit.Parent = pictureBox3;
            Porta1.Parent = pictureBox3;
            Porta2.Parent = pictureBox3;
            Porta3.Parent = pictureBox3;
            Porta1.Location = new Point(13, 88);
            Porta2.Location = new Point(179, 100);
            Porta3.Location = new Point(367, 95);
            unit.Location = new Point(220, 320);
            unit.BringToFront();
            unit.BackColor = Color.Transparent;
    }


    private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            this.Hide();
            GerenciadorForms.AbrirTelaPersonagem(_jogador);
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

        // LOGICA DA FINALIZAÇÃO DAS FASES

        private int ObterPortasNecessarias(int dificuldadeId)
        {
            switch (dificuldadeId)
            {
                case 1: return 8; // Fácil
                case 2: return 10; // Médio
                case 3: return 12; // Difícil
                case 4: return 15; // Extremo
                default: throw new ArgumentException("Dificuldade inválida.");
            }
        }

        private void FinalizarFase()
        {
            try
            {
                int jogadorId = _jogador.getIdJogador();
                var progresso = _progressoRepo.ObterProgressoPorJogador(jogadorId);

                if (progresso.FaseAtual > 0)
                {
                    int proximaFase = progresso.FaseAtual + 1;
                    if (proximaFase == 5)
                    {
                        MessageBox.Show("PARABÉNS! Você completou todas as fases e zerou o jogo!");
                        this.Hide();
                        GerenciadorForms.AbrirTelaPersonagem(_jogador);
                        return;
                    }
                    _progressoRepo.AtualizarProgressoFase(jogadorId, proximaFase, 0);
                    _personagem.setFaseId(proximaFase);
                    var personagemRepo = new PersonagemRepository("server=localhost;uid=root;pwd=1234;database=mistery_doors");
                    personagemRepo.AtualizarFasePersonagem(_personagem.getIdPersonagem(), proximaFase);

                    MessageBox.Show($"Fase {progresso.FaseAtual} concluída! Próxima fase: {proximaFase}.",
                        "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _jogador.AtualizarVitorias(1); //COLOQUEI AQUI TB PQ NA MINHA CABECA FAZ MAS SENTIDO
                    this.Hide();
                    GerenciadorForms.AbrirTelaPersonagem(_jogador);
                }
                else
                {
                    MessageBox.Show("Erro ao determinar o progresso do jogador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar a fase: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
