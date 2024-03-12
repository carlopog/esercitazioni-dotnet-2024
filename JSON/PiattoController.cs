using System.Data.SQLite;
using System.Linq;

class PiattoController
{
  private Database _db; // Riferimento al modello
  private PiattoView _piattoview; // Riferimento alla vista

  public PiattoController(Database db, PiattoView piattoview) // View view,
  {
    _db = db; // Inizializzazione del riferimento al modello
    _piattoview = piattoview; // Inizializzazione del riferimento alla vista
  }

public void ShowMainMenu()
{
  _piattoview.ShowMainMenu();
  int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
  switch (scelta)
    {
      case 1: 
      {
        InserisciPiatto();
        break;
      }
      case 2: 
      {
        Show();
        break;
      }
      case 3: 
      {
        ModificaPiatto();
        break;
      }
      case 4: 
      {
        RimuoviPiatto();
        break;
      }
      case 5: 
      {
       return;
      }
      default: {Console.WriteLine("Qualcosa è andato storto"); return;}
    }
}

public void Show()
{
  _piattoview.ShowMenu();
   int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 4);
  switch (scelta)
    {
      case 1: 
      {   
        _piattoview.VisualizzaListaPiatti();
        int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 2);
        if ( choice == 1 )
        {
          // visualizza tutti i piatti
          var piatti = _db.Piatti.ToList(); 
          foreach (var p in piatti)
          {
            Console.WriteLine($"{p.PiattoId}. - {p.Categoria} - {p.Nome} - {p.Prezzo}");
          }
        }
        else if ( choice == 2 )
        {
          // visualizza tutti i piatti con disponibile = true
          var piatti = _db.Piatti.Where(s => s.Disponibile == true); 
          foreach (var p in piatti)
          {
            Console.WriteLine($"{p.PiattoId}. - {p.Categoria} - {p.Nome} - {p.Prezzo}");
          }
        }
        break;
      }
      case 2: 
      {
          var piatti = _db.Piatti.Where(s => s.Disponibile == true); 
        _piattoview.VisualizzaCategoria();
        int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
        if ( choice == 1 )
        {
          // visualizza tutti i piatti con categoria = 'antipasti'
          var antipasti = piatti.Where(s => s.Categoria == "antipasti"); 
           foreach (var a in antipasti)
          {
            Console.WriteLine($"{a.PiattoId}. - {a.Categoria} - {a.Nome} - {a.Prezzo}");
          }
        }
        else if ( choice == 2 )
        {
          // visualizza tutti i piatti con categoria = 'primi'
           var primi = piatti.Where(s => s.Categoria == "primi"); 
           foreach (var p in primi)
          {
            Console.WriteLine($"{p.PiattoId}. - {p.Categoria} - {p.Nome} - {p.Prezzo}");
          }
        }
        else if ( choice == 3 )
        {
         // visualizza tutti i piatti con categoria = 'secondi'
          var secondi = piatti.Where(s => s.Categoria == "secondi"); 
           foreach (var s in secondi)
          {
            Console.WriteLine($"{s.PiattoId}. - {s.Categoria} - {s.Nome} - {s.Prezzo}");
          }
        }
        else if ( choice == 4 )
        {
          // visualizza tutti i piatti con categoria = 'vini'
           var vini = piatti.Where(s => s.Categoria == "vini"); 
           foreach (var v in vini)
          {
            Console.WriteLine($"{v.PiattoId}. - {v.Categoria} - {v.Nome} - {v.Prezzo}");
          }
        }
        else if ( choice == 5 )
        {
          // visualizza tutti i piatti con categoria = 'dolci'
           var dolci = piatti.Where(s => s.Categoria == "dolci"); 
           foreach (var d in dolci)
          {
            Console.WriteLine($"{d.PiattoId}. - {d.Categoria} - {d.Nome} - {d.Prezzo}");
          }
        }

        break;
      }
      case 3: 
      {
        _piattoview.VisualizzaPiatto();
        var vi = new ValidaInput();
        string name = vi.ReadString("il nome del piatto che vuoi visualizzare");
        // visualizza tutti i piatti con nome = '{name}'
        var piatto = _db.Piatti.SingleOrDefault(s => s.Nome == name);
        Console.WriteLine($"{piatto.PiattoId}. - {piatto.Categoria} - {piatto.Nome} - {piatto.Prezzo}");

        break;
      }
      case 4: 
      {
        return;
      }
    }
}

public void InserisciPiatto() // inserisci piatto nel database
{
    Console.WriteLine("Inserisci il nome del Piatto:"); 
    string name = Console.ReadLine()!; 
    int prezzo = ValidaInput.ReadInt("il prezzo");
    Console.WriteLine("Inserisci il nome della Categoria del Piatto:"); 
    string categoria = Console.ReadLine()!; 
    Console.WriteLine("Inserisci una Descrizione del Piatto:"); 
    string descrizione = Console.ReadLine()!; 
    List<Ordinazione> ordinazioni = new List<Ordinazione>(); 

    var piatto = new Piatto { Nome = name, Prezzo = prezzo, Categoria = categoria, Descrizione = descrizione, Ordinazioni = ordinazioni, Disponibile = true };
    _db.Piatti.Add(piatto);
    _db.SaveChanges();
} 

public void ModificaPiatto() // modifica piatto nel database
{
    Console.WriteLine("Inserisci il nome del Piatto che vuoi modificare:"); 
    string name = Console.ReadLine()!; 
    var piatto = _db.Piatti.SingleOrDefault(s => s.Nome == name);
    Console.WriteLine("Cosa vuoi modificare?"); 
    Console.WriteLine("1. Nome"); 
    Console.WriteLine("2. Descrizione"); 
    Console.WriteLine("3. Categoria"); 
    Console.WriteLine("4. Prezzo"); 
    Console.WriteLine("5. Oggi Disponibile"); 
    Console.WriteLine("6. Non Disponibile"); 
    Console.WriteLine("7. Niente"); 
    int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 7);
      if ( choice == 1 )
      {
        Console.WriteLine("Inserisci il nuovo Nome del piatto"); 
        string nuovoNome = Console.ReadLine()!; 
        piatto.Nome = nuovoNome;
      }
      else if ( choice == 2 )
      {
        Console.WriteLine("Inserisci la nuova Descrizione del piatto"); 
        string nuovaDesc = Console.ReadLine()!;
        piatto.Descrizione = nuovaDesc;
      }
      else if ( choice == 3 )
      {
        Console.WriteLine("Inserisci la nuova Categoria del piatto"); 
        string nuovaCat = Console.ReadLine()!;
        piatto.Categoria = nuovaCat;
      }
      else if ( choice == 4 )
      {
        int nuovoPrezzo = ValidaInput.ReadInt("il nuovo Prezzo del piatto");
        piatto.Prezzo = nuovoPrezzo;
      }
      else if ( choice == 5 )
      {
        piatto.Disponibile = true;
      }
      else if ( choice == 6 )
      {
        piatto.Disponibile = false;
      }
      else if ( choice == 7 )
      {
        return;
      }
    _db.SaveChanges();

} 

public void RimuoviPiatto() // cancella piatto dal database
{
 Console.WriteLine("Inserisci il nome del Piatto che vuoi eliminare:"); 
 string name = Console.ReadLine()!; 
 var piatto = _db.Piatti.SingleOrDefault(s => s.Nome == name);
 _db.Piatti.Remove(piatto);
_db.SaveChanges();
} 

}
