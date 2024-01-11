class Program
{
  static void Main(string[] args)
  {
    List<string> nomi = new List<string>();
    nomi.Add("Luigi");
    nomi.Add("Giovanni");
    nomi.Add("Mario");
    Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
  }
}