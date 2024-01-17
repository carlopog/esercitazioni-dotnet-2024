using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    List<string> nomi = ["Alex", "Simone", "Giada", "Fabio", "Carlo", "Dylan", "Natalya", "Alessandro"];
    Random random = new(); // oggetto per generare numeri casuali
    int indice = random.Next(0, nomi.Count); // in questo caso tra 0 e 2
    Console.WriteLine($"Il nome sorteggiato e' {nomi[indice]}"); // stampa il nome sorteggiato
  }
}