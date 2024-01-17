using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    Random random = new();
    int somma = 0;
    for (int i = 0; i < 10; i++)
    {
      int numero = random.Next(1, 11); // genera un numero tra 1 e 10
      somma += numero; // somma uguale a se stessa piu' numero 
      Console.WriteLine($"il numero casuale e' {numero}");
      Thread.Sleep(1000);
      Console.WriteLine($"il parziale e' {somma}");
      Thread.Sleep(1000);
    }
    Console.WriteLine($"La somma e' {somma}");
  }
}
