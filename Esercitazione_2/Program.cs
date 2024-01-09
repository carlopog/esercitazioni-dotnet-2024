  class Program
  {
    static void Main(string[] args)
    {
      string nome =  "Christian";
      string cognome =  "Conti";
      Console.WriteLine($"Hello {nome} {cognome}!"); // interpolazione di stringhe
      Console.WriteLine("Ciao " + nome + " " + cognome); // concatenazione con operatore +
    }
  }