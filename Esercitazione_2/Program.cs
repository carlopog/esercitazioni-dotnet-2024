using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    Random random = new();
    int somma = 0;
    for (int i = 0; i < 5; i++)
    {
      int numero = random.Next(1, 11); // genera un numero tra 1 e 10
      somma += numero; // somma uguale a se stessa piu' numero 
      Console.Write("il numero casuale e' ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"{numero}");
      Console.ResetColor(); 

      Thread.Sleep(500);
      Console.WriteLine($"il parziale e' {somma}");
      Thread.Sleep(500);
    }
    Console.Write($"La somma e' ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{somma}");
    Console.ResetColor(); 
  }
}
