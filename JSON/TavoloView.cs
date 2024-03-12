using System.Data.SQLite;

class TavoloView
{
  private Database _db; // Riferimento al modello
  public TavoloView(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }
  public void ShowMainMenu()
  {
   Console.WriteLine("Che comando vuoi eseguire?");
    Console.WriteLine("1. Aggiungi tavolo");
    Console.WriteLine("2. Visualizza tavolo");
    Console.WriteLine("3. Modifica tavolo");
    Console.WriteLine("4. Rimuovi tavolo");
    Console.WriteLine("5. Esci");
  }

  public void ShowMenu()
  {
   Console.WriteLine("Cosa vuoi visualizzare?");
    Console.WriteLine("1. Visualizza lista completa dei tavoli");
    Console.WriteLine("2. Visualizza le ordinazioni di un tavolo singolo");
    Console.WriteLine("3. Esci");
  }

public void VisualizzaListaTavoli() // visualizza tutti i tavoli del database
{
  Console.WriteLine("Che lista di tavoli vuoi visualizzare?");
  Console.WriteLine("1. Tutti i tavoli");
  Console.WriteLine("2. Tutti i tavoli disponibili");
}

}
