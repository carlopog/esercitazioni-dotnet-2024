class Program
{
  static void Main(string[] args)
  {
    Dictionary<string, int> eta = new()
        {
            { "Mario", 25 },
            { "Luigi", 44 },
            { "Giuseppe", 60 }
        };
    Console.WriteLine($"Voi avete {eta["Mario"]}, {eta["Luigi"]} e {eta["Giuseppe"]} anni?");
  }
}