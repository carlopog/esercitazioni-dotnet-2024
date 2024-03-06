using System.Data.SQLite;

class TestView
{
  private Database _db; // Riferimento al modello
  public TestView(Database db)
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
}