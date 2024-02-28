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

