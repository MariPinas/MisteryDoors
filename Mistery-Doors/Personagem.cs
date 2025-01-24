using portasTestes;
using System;

public class Personagem {
    private int IdPersonagem { get; set; }
    private string Name { get; set; }
    private double VidaPersonagem { get; set; } = 3;
    private double DanoPersonagem { get; set; } = 5;
    private Equipamento ArmaId { get; set; }
    private Portas ProgressoId { get; set; }
    private int FaseId { get; set; }

    public Personagem() { }

    public Personagem(string nome, int dificuldadeid) {
        this.Name = nome;
        this.FaseId = dificuldadeid;
    }

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
    }

    public void GanharVida() {
        if (this.VidaPersonagem < 3)
            VidaPersonagem++;
    }

    public void EquiparArma(Equipamento novaArma, double bonusDano) {
        ArmaId = novaArma;
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

    public Equipamento getArmaId()
    {
        return this.ArmaId;
    }

    public void setArmaId(Equipamento arma)
    {
        this.ArmaId = arma;
    }

    public Portas getProgressoId()
    {
        return this.ProgressoId;
    }

    public void setProgresso(Portas progresso)
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