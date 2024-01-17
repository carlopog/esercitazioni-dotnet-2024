using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
      string[] nomi = ["Mario","Luigi","Giovanni"]; 
      Random random = new Random(); // oggetto per generare numeri casuali
      int indice = random.Next(0, nomi.Length); // in questo caso tra 0 e 2
      Console.WriteLine($"Il nome sorteggiato e' {nomi[indice]}"); // stampa il nome sorteggiato
  }
}
