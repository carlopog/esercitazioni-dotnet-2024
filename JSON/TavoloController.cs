using System.Data.SQLite;
using System.Linq;

class TavoloController
{
  private Database _db; // Riferimento al modello
  private TavoloView _tavoloview; // Riferimento alla vista
  private OrdinazioneView _ordinazioneview; // Riferimento alla vista

  public TavoloController(Database db, TavoloView tavoloview, OrdinazioneView ordinazioneview) // View view,
  {
    _db = db; // Inizializzazione del riferimento al modello
    _tavoloview = tavoloview; // Inizializzazione del riferimento alla vista
    _ordinazioneview = ordinazioneview; // Inizializzazione del riferimento alla vista
  }

public void ShowMainMenu()
{
  _tavoloview.ShowMainMenu();
  int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
  switch (scelta)
    {
      case 1: 
      {
        InserisciTavolo();
        break;
      }
      case 2: 
      {
        Show();
        break;
      }
      case 3: 
      {
        ModificaTavolo();
        break;
      }
      case 4: 
      {
        RimuoviTavolo();
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
  _tavoloview.ShowMenu();
   int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 4);
  switch (scelta)
    {
      case 1: 
      {   
        _tavoloview.VisualizzaListaTavoli();
        int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 2);
        if ( choice == 1 )
        {
          // visualizza tutti i tavoli
          var tavoli = _db.Tavoli.ToList(); 
          foreach (var p in tavoli)
          {
            Console.WriteLine($"{p.Id}. - {p.Nome} - tavolo da  {p.Capacita} persone");
          }
        }
        else if ( choice == 2 )
        {
          // visualizza tutti i tavoli con disponibile = true
          var tavoli = _db.Tavoli.Where(s => s.Disponibile == true); 
          foreach (var p in tavoli)
          {
            Console.WriteLine($"{p.Id}. - {p.Nome} - tavolo da  {p.Capacita} persone");
          }
        }
        break;
      }
      case 2: 
      {
       _ordinazioneview.VisualizzaOrdinazioniTavolo();
        break;
      }
      case 3: 
      {
        return;
      }
    }
}
public void InserisciTavolo() // inserisci tavolo nel database
{
    Console.WriteLine("Inserisci il nome del Tavolo:"); 
    string name = Console.ReadLine()!; 
    int capacita = ValidaInput.ReadInt("la capacità del tavolo");
    var tavolo = new Tavolo { Nome = name, Capacita = capacita, Disponibile = true };
    _db.Tavoli.Add(tavolo);
    _db.SaveChanges();
} 

public void ModificaTavolo() // modifica tavolo nel database
{
    Console.WriteLine("Inserisci il nome del Tavolo che vuoi modificare:"); 
    string name = Console.ReadLine()!; 
    var tavolo = _db.Tavoli.SingleOrDefault(s => s.Nome == name);
    Console.WriteLine("Cosa vuoi modificare?"); 
    Console.WriteLine("1. Nome"); 
    Console.WriteLine("2. Capacita"); 
    Console.WriteLine("3. Oggi Disponibile"); 
    Console.WriteLine("4. Non Disponibile"); 
    Console.WriteLine("5. Niente"); 
    int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 7);
      if ( choice == 1 )
      {
        Console.WriteLine("Inserisci il nuovo Nome del tavolo"); 
        string nuovoNome = Console.ReadLine()!; 
        tavolo.Nome = nuovoNome;
      }
      else if ( choice == 2 )
      {
        int nuovaCapacita = ValidaInput.ReadInt("la nuova Capacita del tavolo");
        tavolo.Capacita = nuovaCapacita;
      }
      else if ( choice == 3 )
      {
        tavolo.Disponibile = true;
      }
      else if ( choice == 4 )
      {
        tavolo.Disponibile = false;
      }
      else if ( choice == 5 )
      {
        return;
      }
    _db.SaveChanges();

} 

public void RimuoviTavolo() // cancella tavolo dal database
{
 Console.WriteLine("Inserisci il nome del Tavolo che vuoi eliminare:"); 
 string name = Console.ReadLine()!; 
 var tavolo = _db.Tavoli.SingleOrDefault(s => s.Nome == name);
 _db.Tavoli.Remove(tavolo);
_db.SaveChanges();
} 



}
