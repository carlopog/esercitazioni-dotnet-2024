using System.Data.SQLite;

class OrdinazioneView
{
  private Database _db; // Riferimento al modello
  public OrdinazioneView(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }
  public void ShowMainMenu()
  {
   Console.WriteLine("Che comando vuoi eseguire?");
    Console.WriteLine("1. Aggiungi ordinazione");
    Console.WriteLine("2. Visualizza ordinazione");
    Console.WriteLine("3. Modifica ordinazione");
    Console.WriteLine("4. Rimuovi ordinazione");
    Console.WriteLine("5. Esci");
  }

  public void ShowMenu()
  {
   Console.WriteLine("Cosa vuoi visualizzare?");
    Console.WriteLine("1. Visualizza lista completa delle ordinazioni");
    Console.WriteLine("2. Visualizza tutte le ordinazioni non ancora pronte");
    Console.WriteLine("3. Visualizza tutte le ordinazioni di un tavolo specifico");
    Console.WriteLine("4. Visualizza una singola ordinazione");
    Console.WriteLine("5. Esci");
  }

public static void VisualizzaOrdinazioniTavolo() // visualizza tutti i ordinazioni del database
{
  string name = ValidaInput.ReadString("il nome del tavolo che vuoi visualizzare");
  // visualizza tutti i tavoli con nome = '{name}'
  var tavolo = _db.Tavoli.SingleOrDefault(s => s.Nome == name);
  Console.WriteLine($"{tavolo.Nome} - tavolo da {tavolo.Capacita} persone - disponibilità {tavolo.Disponibile}");
  foreach (var o in tavolo.Ordinazioni)
  {
    Console.WriteLine($"Pronto? {o.Disponibile}");
    foreach (var p in o.Piatti)
    {
      Console.WriteLine($"{p.Nome} - {p.Prezzo}");
    }
  }
}
public static void VisualizzaOrdinazione() // visualizza un ordinazione singolo
{
  Console.WriteLine("Che ordinazione vuoi visualizzare?");
}

}
