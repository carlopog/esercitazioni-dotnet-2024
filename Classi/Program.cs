class Animale
{
  public string nome;
  public int eta;
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
class Cane : Animale
{
  public string razza;
  public Cane(string nome, int eta, string razza) : base(nome, eta)
  {
    this.razza = razza;
  }
  public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Razza: {razza}");
  }
}

class Gatto : Animale
{
  public string colore;
  public Gatto(string nome, int eta, string colore) : base(nome, eta)
  {
    this.colore = colore;
  }
    public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Colore: {colore}");
  }
}
 class Program
{
  public static void Main(string[] args)
  {
    Animale a1 = new Cane("Fido", 5, "Labrador");
    Animale a2 = new Gatto("Felix", 5, "Nero");

    a1.Stampa();
    a2.Stampa();
  }
}