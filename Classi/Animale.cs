class Animale
{
  public string nome;
  public int eta;
  public Animale(string nome)
  {
    this.nome = nome;
  }
  public Animale(string nome, int eta)
  {
    this.nome = nome;
    this.eta = eta;
  }
  public virtual void Stampa()
  {
    Console.WriteLine($"Nome: " + nome);
    Console.WriteLine($"Eta: " + eta);
  }
}