using System.Data.SQLite;
using System.Linq;

class Controller
{
  private Database _db; // Riferimento al modello
  // private View _view; // Riferimento alla vista
  private TestView _testview; // Riferimento alla vista

  public Controller(Database db, TestView testview) // View view,
  {
    _db = db; // Inizializzazione del riferimento al modello
    // _view = view; // Inizializzazione del riferimento alla vista
    _testview = testview; // Inizializzazione del riferimento alla vista
  }

public void Start()
{
  _view.Start();
  Console.WriteLine("Inserisci nome Giocatore:"); // Richiesta nome dell'utente
  string name = Console.ReadLine()!; // Lettura del nome dell'utente
  AggiungiGiocatore(name);
  int quota = 1;
  int lastbet = 0;
  int vincita = 0;
  bool continua = true;
  while (continua)
  {
    Scommessa(); // ritorna un nuovo valore per quota e una condizione per vinto()

    ScriviColorato("blu", $"La quota della tua scommessa è {quota}x")
    int prezzo = ValidaInput.ReadInt("quanti euro vuoi scommettere");
    AggiungiScommessa(name, prezzo); // aggiorna lastbet

    bool win = Vinto(); // condizioni che cambiano
    if (win)
    {
      vincita = quota * prezzo;
    }
    else
    {
      vincita = -prezzo; 
    }
    ModificaVincita(name, vincita); // aggiorna anche il bottino
    continua = Continua(); // funzione che restituisce un bool true o false
  }
}
  public void MainMenu()
  {
    while (true)
    {
      _testview.ShowMainMenu(); // Visualizzazione del Menu principale
      string input = Console.ReadLine()!; // Lettura dell'input dell'utente

      if (input == "1")
      {
        AggiungiGiocatore();
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

  //   static void CreateFile(string path)
  // {
  //   if (!File.Exists(path))
  //   {
  //     File.Create(path).Close();
  //   }
  // }
  public void ScriviColorato(string colore, string testo)
  {
    if (colore == "rosso")
    {
      Console.ForegroundColor = ConsoleColor.Red;
    }
    else if (colore == "verde")
    {
      Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (colore == "magenta")
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
    }
    else if (colore == "blu")
    {
      Console.ForegroundColor = ConsoleColor.Blue;
    }
    else 
    {
      Console.BackgroundColor = ConsoleColor.Green;
    }
    Console.WriteLine(testo);
    Console.ResetColor();
  }
  private void AggiungiGiocatore(string name) // controlla se il giocatore non e' gia' registrato e la sua eta'
  {
    int eta = 10;
    // Console.WriteLine("Inserisci nome Giocatore:"); // Richiesta nome dell'utente
    // string name = Console.ReadLine()!; // Lettura del nome dell'utente
    bool result = _db.Giocatori.Any(g => g.Nome == name);
    if (result)
    {
      var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
      Console.WriteLine($"Bentornato {name}, mi ricordo di te, hai {selezionato.Eta} anni");
      eta = selezionato.Eta;
      if (selezionato.Bottino < 100)
      {
        Console.WriteLine($"Hai ancora {selezionato.Bottino} dall'ultima partita");
        Console.WriteLine($"Ma noi te ne aggiungiamo 100 per farti divertire di più");
        selezionato.Bottino += 100;
        ScriviColorato("verde", $"Quindi il tuo bottino attuale è {selezionato.Bottino}");
      }
      if (selezionato.Prestito > 0)
      {
        Console.WriteLine($"Ma tu ci devi ancora {selezionato.Prestito} euro");
        selezionato.Bottino -= selezionato.Prestito;
        selezionato.Prestito = 0;
        ScriviColorato("rosso", $"Quindi il tuo bottino attuale è {selezionato.Bottino}");
      }
    }
    else
    {
      eta = ValidaInput.ReadInt("eta");
      var player = new Giocatore { Nome = name, Eta = eta, Bottino = 100, Lastbet = 0, Prestito = 0 };
      _db.Giocatori.Add(player);
      _db.SaveChanges();
    }
    if (eta > 17)
    {
      Console.WriteLine($"Beh se hai {eta} anni allora puoi giocare");
    }
    else
    {
      Console.WriteLine("Allora non sei maggiorenne! Tornatene a casa pischello!");
      return;
    }
  }
  private void AggiungiScommessa(string name, int prezzo)
  {
    // Console.WriteLine("Inserisci il nome del Giocatore che fa la scommessa:"); // Richiesta nome dell'utente
    // var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    // int prezzo = ValidaInput.ReadInt("quanti euro vuoi scommettere");
    var bet = new Scommessa { Nome = name, Prezzo = prezzo, Vincita = 0 };
    if (selezionato != null)
    {
      _db.Scommesse.Add(bet);
      selezionato.Lastbet = prezzo;
      _db.SaveChanges();
    }
  }
  /// <summary>
  ///  Questo metodo aggiorna il valore Vincita dell'ultima scommessa effettuata da un dato giocatore
  ///  deve essere chiamato dopo il risultato di ogni scommessa
  ///  aggiorna anche il valore del Bottino del giocatore sommandogli la Vincita
  /// </summary>
  private void ModificaVincita(string name, int vincita)
  {
    // Console.WriteLine("Inserisci il nome del Giocatore che ha fatto la scommessa:"); // Richiesta nome dell'utente
    // var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    var result = _db.Scommesse.Where(s => s.Nome == name);
    var last = result.OrderBy(f => f.Id).Last();
    if (last != null && selezionato != null)
    {
      // int vincita = ValidaInput.ReadInt("il risultato della scommessa");
      last.Vincita = vincita;
      selezionato.Bottino += vincita;
      _db.SaveChanges();
    }
  }

  /// <summary>
  ///  Questo metodo aggiorna il valore Prestito di un dato giocatore deve essere chiamato:
  ///  - se il giocatore accetta di ricevere un prestito dal banco
  ///    aggiorna anche il valore del Bottino del giocatore sommandogli il Prestito
  ///  - o se ha abbastanza soldi da ripagare i suoi debiti, in questo caso
  ///    aggiorna anche il valore del Bottino del giocatore sottraendogli il Prestito
  /// </summary>
  private void ModificaPrestito(string name, int prestito)
  {
    // Console.WriteLine("Inserisci il nome del Giocatore che ha preso un prestito:"); // Richiesta nome dell'utente
    // var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    if (selezionato != null)
    {
      // int prestito = ValidaInput.ReadInt("la cifra del prestito");
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
      int bottino = ValidaInput.ReadInt("la cifra del nuovo bottino");
      selezionato.Bottino = bottino;
      _db.SaveChanges();
    }
  }

  private void EliminaGiocatore()
  {
    Console.WriteLine("Inserisci il nome del Giocatore da eliminare:"); // Richiesta nome dell'utente
    var name = Console.ReadLine()!; // Lettura del nome dell'utente
    var selezionato = _db.Giocatori.SingleOrDefault(g => g.Nome == name);
    var result = _db.Scommesse.Where(s => s.Nome == name);
    if (selezionato != null)
    {
      _db.Giocatori.Remove(selezionato);
      foreach (var r in result)
      {
        _db.Scommesse.Remove(r);
      }
      _db.SaveChanges();
    }
  }

}