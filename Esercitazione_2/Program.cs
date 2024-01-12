class Program
{
  static void Main(string[] args)
  {
    Dictionary<string, string> nomi = new Dictionary<string, string>();
    nomi.Add("Mario", "Rossi");
    nomi.Add("Luigi", "Biancoli");
    nomi.Add("Giuseppe", "Verdi");
    Console.WriteLine($"Ciao {nomi["Mario"]}, {nomi["Luigi"]} e {nomi["Giuseppe"]}");
  }
}