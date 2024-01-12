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
        foreach (string nome in eta.Keys) {
          Console.WriteLine($"il signor {nome} ha {eta[$"{nome}"]} anni");
        }
  }
}