using portasTestes;
using System;

public class Personagem {
    private int IdPersonagem { get; set; }
    private string Name { get; set; }
    private double VidaPersonagem { get; set; } = 3;
    private double DanoPersonagem { get; set; } = 5;
    private Equipamento Arma { get; set; }
    private Portas Progresso { get; set; }
    private Fase Dificuldade { get; set; }

    public Personagem() { }

    public Personagem(string nome, Fase dificuldade) {
        this.Name = nome;
        this.Dificuldade = dificuldade;
    }

    public string GetNomePersonagem() {
        return this.Name;
    }

    public void SetNomePersonagem(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("Nome não pode ser vazio");
        }
        this.Name = name;
    }

    public void PerderVida() {
        if (this.VidaPersonagem > 0)
            VidaPersonagem -= 0.5;
    }

    public void GanharVida() {
        if (this.VidaPersonagem < 3)
            VidaPersonagem++;
    }

    public void EquiparArma(Equipamento novaArma, double bonusDano) {
        Arma = novaArma;
        DanoPersonagem = 5 + bonusDano;
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

    public Portas getProgresso()
    {
        return this.Progresso;
    }

    public void setProgresso(Portas progresso)
    {
        this.Progresso = progresso;
    }

    public Fase getDificuldade()
    {
        return this.Dificuldade;
    }

    public void setDificuldade(Fase dificuldade)
    {
        this.Dificuldade = dificuldade;
    }

}