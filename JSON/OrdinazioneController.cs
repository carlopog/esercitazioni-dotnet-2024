using System.Data.SQLite;
using System.Linq;

class OrdinazioneController
{
  private Database _db; // Riferimento al modello
  private OrdinazioneView _ordinazioneview; // Riferimento alla vista

  public OrdinazioneController(Database db, OrdinazioneView ordinazioneview) // View view,
  {
    _db = db; // Inizializzazione del riferimento al modello
    _ordinazioneview = ordinazioneview; // Inizializzazione del riferimento alla vista
  }

  public void ShowMainMenu()
  {
    _ordinazioneview.ShowMainMenu();
    int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
    switch (scelta)
    {
      case 1:
        {
          InserisciOrdinazione();
          break;
        }
      case 2:
        {
          Show();
          break;
        }
      case 3:
        {
          ModificaOrdinazione();
          break;
        }
      case 4:
        {
          RimuoviOrdinazione();
          break;
        }
      case 5:
        {
          return;
        }
      default: { Console.WriteLine("Qualcosa è andato storto"); return; }
    }
  }

  public void Show()
  {
    _ordinazioneview.ShowMenu();
    int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
    switch (scelta)
    {
      case 1:
        {
            // visualizza tutte le ordinazioni
            var ordinazioni = _db.Ordinazioni.ToList();
            foreach (var o in ordinazioni)
            {
              Console.WriteLine($"{o.OrdinazioneId}. - {o.TavoloId} - {o.Disponibile}");
            }

          break;
        }

      case 2:
        {
            int counter = 0;
            // visualizza tutte le ordinazioni con disponibile = false
            var ordinazioni = _db.Ordinazioni.Where(s => s.Disponibile == false);
            foreach (var o in ordinazioni)
            {
              Console.WriteLine($"{o.OrdinazioneId}. - {o.Tavolo.Nome}");
              foreach (var p in o.Piatti)
              {
                counter++;
                Console.WriteLine($"{counter}. - {p.Nome} - {p.Prezzo}");
              }
            }

            break;
          }
      case 3:
            {
              _ordinazioneview.VisualizzaOrdinazioniTavolo();
              break;
            }
          case 4:
            {
              return;
            }
          }
        }
        public void InserisciOrdinazione() // inserisci ordinazione nel database
        {
          int id = ValidaInput.ReadInt("l'id del tavolo dell'ordinazione");
          var tavolo = _db.Tavoli.SingleOrDefault(s => s.TavoloId == id);

          List<Piatto> piatti = new List<Piatto>();
          for (int i = 0; i < tavolo.Capacita; i++)
          {
            int piattoId = ValidaInput.ReadInt("l'id del piatto da ordinare");
            var piatto = _db.Piatti.SingleOrDefault(s => s.PiattoId == piattoId);
            piatti.Add(piatto);
          }

          var ordinazione = new Ordinazione { Piatti = piatti, TavoloId = id, Tavolo = tavolo, Disponibile = false };
          _db.Ordinazioni.Add(ordinazione);
          _db.SaveChanges();
        }

        public void ModificaOrdinazione() // modifica ordinazione nel database
        {
          int id = ValidaInput.ReadInt("l'id dell'ordinazione che vuoi modificare");
          var ordinazione = _db.Ordinazioni.SingleOrDefault(s => s.OrdinazioneId == id);
          Console.WriteLine("Cosa vuoi modificare?");
          Console.WriteLine("1. i Piatti ordinati");
          Console.WriteLine("2. il Tavolo a cui portare l'ordinazione");
          Console.WriteLine("3. Pronta");
          Console.WriteLine("4. Non Pronta");
          Console.WriteLine("5. Niente");
          int choice = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 7);
          if (choice == 1)
          {
            List<Piatto> piatti = new List<Piatto>();
            for (int i = 0; i < ordinazione.Tavolo.Capacita; i++)
            {
              int piattoId = ValidaInput.ReadInt("l'id del nuovo piatto da ordinare");
              var piatto = _db.Piatti.SingleOrDefault(s => s.PiattoId == piattoId);
              piatti.Add(piatto);
            }
          }
          else if (choice == 2)
          {
            int nuovoT = ValidaInput.ReadInt("l'id del nuovo tavolo dell'ordinazione");
            ordinazione.TavoloId = nuovoT;
            var nuovoTavolo = _db.Tavoli.SingleOrDefault(s => s.TavoloId == id);
            ordinazione.Tavolo = nuovoTavolo;
          }
          else if (choice == 3)
          {
            ordinazione.Disponibile = true;
          }
          else if (choice == 4)
          {
            ordinazione.Disponibile = false;
          }
          else if (choice == 5)
          {
            return;
          }
          _db.SaveChanges();

        }

        public void RimuoviOrdinazione() // cancella ordinazione dal database
        {
          int id = ValidaInput.ReadInt("l'id dell'ordinazione che vuoi eliminare");
          var ordinazione = _db.Ordinazioni.SingleOrDefault(s => s.OrdinazioneId == id);
          _db.Ordinazioni.Remove(ordinazione);
          _db.SaveChanges();
        }

    }
