## uno

```c#

class ContoBancario
{
  private string? nome;
  private double saldo;

  public ContoBancario(string nome, double saldo)
  {
    this.Nome = nome;
    this.Saldo = saldo;
  }

  public string? Nome { get => nome; set => nome = value; } // get {return nome; } set { nome = value; }
  public double Saldo { get => saldo; set => saldo = value; } // get {return saldo; } set { saldo = value; }

  public void Deposita(double importo)
  {
    Saldo += importo;
  }

  public void Preleva(double importo)
  {
    Saldo -= importo;
  }

  public void Stampa()
  {
    Console.WriteLine("Nome: " + Nome);
    Console.WriteLine("Saldo: " + Saldo);
  }
}

class ContoCorrente : ContoBancario
{
  private double tasso;

  public ContoCorrente(string nome, double saldo, double tasso) : base(nome,saldo)
  {
    this.tasso = tasso;
  }

  public void CalcolaInteressi()
  {
    double interessi = Saldo * tasso / 100;
    Saldo += interessi;
  }

}

class Program 
{
  static void Main(string[] args)
  {
    ContoCorrente cc = new ContoCorrente("Mario Rossi", 1000, 2);
    cc.Deposita(500);
    cc.Preleva(200);
    cc.CalcolaInteressi();
    cc.Stampa();
  }
}

```

## due 

```c#
class Libro
{
  public string titolo;
  public string autore;

  public Libro(string titolo, string autore)
  {
    this.titolo = titolo;
    this.autore = autore;
  }
}
class Biblioteca
{
  private List<Libro> libri = new List<Libro>();
  public void Aggiungi(Libro libro)
  {
    libri.Add(libro);
  }
  public void Stampa()
  {
    int counter = 0;
    foreach (Libro libro in libri)
    {
      counter++;
      Console.WriteLine($"Libro {counter}");
      Console.WriteLine($"Titolo: {libro.titolo} \nAutore: {libro.autore}");
    }
  }
  
}
class Program
{
  static void Main(string[] args)
  {
    Biblioteca biblioteca = new Biblioteca();
    Libro l1 = new Libro("Il signore degli anelli", "J.R.R. Tolkien");
    Libro l2 = new Libro("Il nome della rosa", "Umberto Eco");
    Libro l3 = new Libro("La Repubblica", "Platone");
    biblioteca.Aggiungi(l1);
    biblioteca.Aggiungi(l2);
    biblioteca.Aggiungi(l3);
    biblioteca.Stampa();
  }
}

```

## tre 

```c#
using Newtonsoft.Json;

public class Persona 
{
  public string Nome {get; set;}
  public int Eta {get; set;}
  public bool Impiegato {get; set;}
}
public class GestioneJson 
{
  public static void Main(string[] args)
  {
    Persona persona = new Persona()
    {
      Nome = "Mario Rossi",
      Eta = 30,
      Impiegato = true
    };

    // serializzazione dell'oggetto in una stringa JSON
    string json = JsonConvert.SerializeObject(persona, Formatting.Indented);
    File.WriteAllText(@"persona.json", json);

    // Deserializzazione della stringa JSON in un oggetto Persona
    string jsonDaLeggere = File.ReadAllText(@"persona.json");
    Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona>(jsonDaLeggere);

    System.Console.WriteLine(personaDeserializzata.Nome);
  }
}

```
## quattro 

```c#

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

```