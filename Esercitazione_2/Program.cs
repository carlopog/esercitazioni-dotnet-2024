class Program
{
  static void Main(string[] args)
  {
    List<string> nomi = ["Toad", "Luigi", "Yoshi"];
    foreach (string nome in nomi)
    {
      Console.WriteLine($"Ciao {nome}");
    }
  }
}