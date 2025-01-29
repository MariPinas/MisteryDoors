using portasTestes;
using portasTestes.Repository;
using System;

public class Personagem {
    private int IdPersonagem { get; set; }
    private string Name { get; set; }
    private double VidaPersonagem { get; set; } = 3;
    private double DanoPersonagem { get; set; } = 5;
    private Equipamento Arma { get; set; }
    private int ProgressoId { get; set; }
    private int FaseId { get; set; }
    private int IdJogador {  get; set; }

    public int getIdJogador() {
        return IdJogador;
    }

    public void setIdJogador(int idJogador) {
        this.IdJogador = idJogador;
    }

    public Personagem() { }
    public Personagem(Equipamento i) { this.Arma = i;}

    public Personagem(string nome, int dificuldadeid, int jogadorId) {
        this.Name = nome;
        this.FaseId = dificuldadeid;
        this.IdJogador = jogadorId;
    }

    public int getIdPersonagem() {  return IdPersonagem; }
    public void setIdPersonagem(int id) {  IdPersonagem = id; }

    public string getNomePersonagem() {
        return this.Name;
    }

    public void setNomePersonagem(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("Nome não pode ser vazio");
        }
        this.Name = name;
    }

    public void PerderVida() {
        if (this.VidaPersonagem > 0)
            VidaPersonagem -= 0.5;
        VerificarMortePersonagem();
    }
    private void VerificarMortePersonagem() {
        if (this.VidaPersonagem <= 0) {
            Console.WriteLine($"{Name} morreu!");
            var repository = new PersonagemRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
            repository.Deletar(IdPersonagem);
        }
    }
    public void GanharVida() {
        if (this.VidaPersonagem < 3)
            VidaPersonagem += 0.5;
    }

    public void EquiparArma(Equipamento novaArma, double bonusDano) {
        Arma = novaArma;
        DanoPersonagem = 5 + bonusDano;
        Console.WriteLine("atualizar Dano");
        Console.WriteLine($"{IdPersonagem} e {DanoPersonagem} e {Name}");
        var repository = new PersonagemRepository("server=localhost;uid=root;pwd=admin;database=mistery_doors");
        repository.AtualizarDano(IdPersonagem, DanoPersonagem);
        Console.WriteLine("Dano atualizado");
    }

    public double getVidaPersonagem()
    {
        return this.VidaPersonagem;
    }

    public void setVidaPersonagem(double vida)
    {
        this.VidaPersonagem = vida;
    }

    public double getDanoPersonagem()
    {
        return this.DanoPersonagem;
    }

    public void setDanoPersonagem(double dano)
    {
        this.DanoPersonagem = dano;
    }

    public Equipamento getArma()
    {
        return this.Arma;
    }

    public void setArma(Equipamento arma)
    {
        this.Arma = arma;
    }

    public int getProgressoId()
    {
        return this.ProgressoId;
    }

    public void setProgresso(int progresso)
    {
        this.ProgressoId = progresso;
    }

    public int getFaseId()
    {
        return this.FaseId;
    }

    public void setFaseId(int dificuldadeid)
    {
        this.FaseId = dificuldadeid;
    }

}