class Program
{
  static void Main(string[] args)
  {
    string[] nomi = ["Franco", "Ciccio", "Mario"];
    List<string> lista = ["Merio"];

    foreach (string nome in nomi)
    {
      if (nome == "Mario")
      {
        lista.Add(nome);
      }
    }
    foreach (string mario in lista)
    {
      Console.WriteLine("scrivi il cognome");
      string? cognome = Console.ReadLine();
      Console.WriteLine($"ciao {mario} {cognome}");
    }
      Console.WriteLine("premi un tasto per terminare...");
      Console.ReadKey();
  }
}

//  Esercizio: un array di stringhe con 3 nomi, cicliamo con un foreach, se il nome e' Mario, aggiungere a una lista 
//  aggiungeremo un ReafKey e un ReadLine