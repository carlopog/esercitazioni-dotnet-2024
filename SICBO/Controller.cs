using System.Data.SQLite;
using System.Linq;

class Controller
{
  private Database _db; // Riferimento al modello
  private View _view; // Riferimento alla vista

  public Controller(Database db, View view)
  {
    _db = db; // Inizializzazione del riferimento al modello
    _view = view; // Inizializzazione del riferimento alla vista
  }
  public void MainMenu()
  {
    while (true)
    {
      _view.ShowMainMenu(); // Visualizzazione del Menu principale
      string input = Console.ReadLine()!; // Lettura dell'input dell'utente

      if (input == "1")
      {
        AggiungiGiocarore();
      }
      if (input == "2")
      {
        AggiungiScommessa();
      }
      if (input == "3")
      {
        ModificaVincita();
      }
      if (input == "4")
      {
        ModificaPrestito();
        // coi due casi (se e' uguale a 0 o se e' minore del bottino)
      }
      if (input == "5")
      {
        ModificaBottino();
      }
      if (input == "6")
      {
        EliminaGiocatore();
      }
      if (input == "e")
      {
        break;
      }
    }
  }

  private void AggiungiGiocarore()
  {
    Console.WriteLine("Inserisci nome Giocatore:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    int eta = _view.ReadInt("eta");
    var player = new Giocatore { Nome = name, Eta = eta, Bottino = 100, Lastbet = 0, Prestito = 0 };
    _db.Giocatori.Add(player);
    _db.SaveChanges();
  }
  private void AggiungiScommessa()
  {
    Console.WriteLine("Inserisci il nome del Giocatore che fa la scommessa:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    int prezzo = _view.ReadInt("prezzo della scommessa");
    var bet = new Scommessa { Nome = name, Prezzo = prezzo, Vincita = 0 };
    if (selezionato != null)
    {
      _db.Scommesse.Add(bet);
      selezionato.Lastbet = prezzo;
      _db.SaveChanges();
    }
  }
  private void ModificaVincita()
  {
    Console.WriteLine("Inserisci il nome del Giocatore che ha fatto la scommessa:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    var result = _db.Scommesse.Where(s => s.Nome == name);
    var last = result.OrderBy(f => f.Id).Last();
    if (last != null && selezionato != null)
    {
      int vincita = _view.ReadInt("il risultato della scommessa");
      last.Vincita = vincita;
      selezionato.Bottino += vincita;
      _db.SaveChanges();
    }
  }
  private void ModificaPrestito()
  {
    Console.WriteLine("Inserisci il nome del Giocatore che ha preso un prestito:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    if (selezionato != null)
    {
      int prestito = _view.ReadInt("la cifra del prestito");
      if (prestito == 0)
      {
        selezionato.Bottino -= selezionato.Prestito;
        Thread.Sleep(300);
        selezionato.Prestito = 0;
      }
      else
      {
        selezionato.Prestito = prestito;
        selezionato.Bottino += prestito;
      }
      _db.SaveChanges();
    }
  }
  private void ModificaBottino()
  {
    Console.WriteLine("Inserisci il nome del Giocatore di cui vuoi modificare il bottino:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    if (selezionato != null)
    {
      int bottino = _view.ReadInt("la cifra del nuovo bottino");
      selezionato.Bottino = bottino;
      _db.SaveChanges();
    }
  }

  private void EliminaGiocatore()
  {
    Console.WriteLine("Inserisci il nome del Giocatore da eliminare:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    if (selezionato != null)
    {
      _db.Giocatori.Remove(selezionato);
      _db.SaveChanges();
    }
  }

}