class Program
{
  static void Main(string[] args)
  {
    string[] personaggi = new string[3];
        personaggi[0] = "Toad";
        personaggi[1] = "Luigi";
        personaggi[2] = "Yoshi";
        foreach (string personaggio in personaggi)
       {
          Console.WriteLine($"Ciao {personaggio}");
       };

    Dictionary<string, int> eta = new()
        {
            { "Mario", 25 },
            { "Luigi", 44 },
            { "Giuseppe", 60 }
        };
    var nomi = eta.Keys;
    foreach (string nome in nomi) {
    Console.WriteLine($"un nome e' {nome}");
    }
  }
}