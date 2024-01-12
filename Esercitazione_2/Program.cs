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
        var nomi = eta.Keys;
        foreach (string nome in nomi) {
          Console.WriteLine($"il signor {nome} ha {eta[$"{nome}"]} anni");
        }
  }
}