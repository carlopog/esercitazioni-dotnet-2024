class Program
{
  static void Main(string[] args)
  {
    Dictionary<string, string> nomi = new()
    {
        { "Mario", "Rossi" },
        { "Luigi", "Biancoli" },
        { "Giuseppe", "Verdi" }
    };
    Console.WriteLine($"Ciao {nomi["Mario"]}, {nomi["Luigi"]} e {nomi["Giuseppe"]}");
  }
}