using System.Data.SQLite;

class View
{
  private Database _db; // Riferimento al modello
  public View(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }

  public void ShowMainMenu()
  {
    Console.WriteLine($"1. Aggiungi Giocatore");
    Console.WriteLine($"2. Aggiungi Scommessa e Modifica Lastbet");
    Console.WriteLine($"3. Modifica Vincita e Bottino");
    Console.WriteLine($"4. Modifica Prestito e Bottino");
    Console.WriteLine($"5. Modifica Bottino");
    Console.WriteLine($"6. Rimuovi Giocatore");
    Console.WriteLine($"e. Esci");
  }
  // public void VisualizzaGiocatori(List<string> giocatori)
  // {
  //   foreach (var giocatore in giocatori)
  //   {
  //    Console.WriteLine(giocatore); // Visualizzazione dei nomi degli utenti
  //    Thread.Sleep(500);
  //   }
  // }
  public int ReadInt(string dato)
  {
  Start:
    Console.WriteLine($"Inserisci {dato}:");
    try
    {
      int num = int.Parse(Console.ReadLine()!);
      return num;
    }
    catch
    {
      Console.WriteLine("devi inserire un numero");
      goto Start;
    }
  }
}