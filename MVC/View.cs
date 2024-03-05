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
    Console.WriteLine($"1. Aggiungi user");
    Console.WriteLine($"2. Visualizza users");
    Console.WriteLine($"3. Modifica user");
    Console.WriteLine($"4. Rimuovi user");
    Console.WriteLine($"e. Esci");
  }
  public void ShowUsers(List<string> users)
  {
    foreach (var user in users)
    {
     Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
     Thread.Sleep(500);
    }
  }
  public string GetInput()
  {
    return Console.ReadLine()!; // Lettura dell'input dell'utente
  }
}