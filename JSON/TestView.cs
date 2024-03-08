using System.Data.SQLite;

class TestView
{
  private Database _db; // Riferimento al modello
  public TestView(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }
    
  public string ScegliProdotto()
  {
    Console.WriteLine($"1. Portata");
    Console.WriteLine($"2. Piatto");
    Console.WriteLine($"3. Tavolo");
    Console.WriteLine($"4. Turno");
    Console.WriteLine($"5. Ordinazione");
    Console.WriteLine($"6. Esci");
    int scelta = ValidaInput.ReadInt("il numero del prodotto su cui vuoi operare", 1, 6)
    switch (scelta)
    {
      case 1: {return "Portata";}
      case 2: {return "Piatto";}
      case 3: {return "Tavolo";}
      case 4: {return "Turno";}
      case 5: {return "Ordinazione"}
      case 6: {return;}
      default: {Console.WriteLine("Qualcosa è andato storto"); return;}
    }
  }
    public void ScegliAzione(string prodotto)
  {
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
        AggiungiProdotto(prodotto);
        break;
      }
      case 2: 
      {
        VisualizzaProdotto(prodotto);
        break;
      }
      case 3: 
      {
        ModificaProdotto(prodotto);
        break;
      }
      case 4: 
      {
        RimuoviProdotto(prodotto);
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