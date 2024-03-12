using System.Data.SQLite;

class PiattoView
{
  private Database _db; // Riferimento al modello
  public PiattoView(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }
  public void ShowMainMenu()
  {
   Console.WriteLine("Che comando vuoi eseguire?");
    Console.WriteLine("1. Aggiungi piatto");
    Console.WriteLine("2. Visualizza piatto");
    Console.WriteLine("3. Modifica piatto");
    Console.WriteLine("4. Rimuovi piatto");
    Console.WriteLine("5. Esci");
  }

  public void ShowMenu()
  {
   Console.WriteLine("Cosa vuoi visualizzare?");
    Console.WriteLine("1. Visualizza lista completa dei piatti");
    Console.WriteLine("2. Visualizza categoria di piatti");
    Console.WriteLine("3. Visualizza piatto singolo");
    Console.WriteLine("4. Esci");
  }

public void VisualizzaListaPiatti() // visualizza tutti i piatti del database
{
  Console.WriteLine("Che lista di piatti vuoi visualizzare?");
  Console.WriteLine("1. Tutti i piatti");
  Console.WriteLine("2. Tutti i piatti disponibili oggi");
}
public void VisualizzaCategoria() // visualizza tutti i piatti della categoria
{
  Console.WriteLine("Che categoria vuoi visualizzare?");
  Console.WriteLine("1. Antipasti");
  Console.WriteLine("2. Primi");
  Console.WriteLine("3. Secondi");
  Console.WriteLine("4. Vini");
  Console.WriteLine("5. Dolci");
}
public void VisualizzaPiatto() // visualizza un piatto singolo
{
  Console.WriteLine("Che piatto vuoi visualizzare?");
}

}
