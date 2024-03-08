using System.Data.SQLite;

class View
{
  private Database _db; // Riferimento al modello
  public View(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }
  public void Start()
  {
   Console.WriteLine("Che comando vuoi eseguire?");
    Console.WriteLine($"1. Aggiungi {prodotto}");
    Console.WriteLine($"2. Visualizza {prodotto}");
    Console.WriteLine($"3. Modifica {prodotto}");
    Console.WriteLine($"4. Rimuovi {prodotto}");
    Console.WriteLine($"5. Esci");
    int scelta = ValidaInput.ReadInt("il numero dell'azione che vuoi effettuare", 1, 5);
    switch (scelta)
    {
      case 1: 
      {
        AggiungiPiatto();
        break;
      }
      case 2: 
      {
        VisualizzaPiatto(prodotto);
        break;
      }
      case 3: 
      {
        ModificaPiatto(prodotto);
        break;
      }
      case 4: 
      {
        RimuoviPiatto(prodotto);
        break;
      }
      case 5: 
      {
       return;
      }
      default: {Console.WriteLine("Qualcosa è andato storto"); return;}
    }
  }
  }


public static void VisualizzaListaPiatti() // visualizza tutti i piatti del database
public static void VisualizzaCategoria() // visualizza tutti i piatti della categoria
public static void VisualizzaPiatto() // visualizza un piatto singolo

}
