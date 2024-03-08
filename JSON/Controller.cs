using System.Data.SQLite;

class Controller
{
  private Database _db; // Riferimento al modello
  private TestView _testview; // Riferimento alla vista

  public Controller(Database db, TestView testview)
  {
    _db = db; // Inizializzazione del riferimento al modello
    _testview = testview; // Inizializzazione del riferimento alla vista
  }
  public void MainMenu()
  {
    while(true)
    {
      string prodotto = _testview.ScegliProdotto();
      _testview.ScegliAzione(prodotto);
    }
  }
  public void AggiungiProdotto(string prodotto)
  {
    if (prodotto == "Portata")
    {
      
    }
    else if (prodotto == "Piatto")
    {

    }
    else if (prodotto == "Turno")
    {

    }
    else if (prodotto == "Tavolo")
    {

    }
    else if (prodotto == "Ordinazione")
    {

    }
    else 
    {
      Console.WriteLine("Qualcosa è andato storto");
      return;
    }
  };
  public void VisualizzaProdotto(string prodotto)
  {
    if (prodotto == "Portata")
    {
      
    }
    else if (prodotto == "Piatto")
    {

    }
    else if (prodotto == "Turno")
    {

    }
    else if (prodotto == "Tavolo")
    {

    }
    else if (prodotto == "Ordinazione")
    {

    }
    else 
    {
      Console.WriteLine("Qualcosa è andato storto");
      return;
    }
  };
  public void ModificaProdotto(string prodotto)
  {
    if (prodotto == "Portata")
    {
      
    }
    else if (prodotto == "Piatto")
    {

    }
    else if (prodotto == "Turno")
    {

    }
    else if (prodotto == "Tavolo")
    {

    }
    else if (prodotto == "Ordinazione")
    {

    }
    else 
    {
      Console.WriteLine("Qualcosa è andato storto");
      return;
    }
  };
  public void RimuoviProdotto(string prodotto)
  {
    if (prodotto == "Portata")
    {
      
    }
    else if (prodotto == "Piatto")
    {

    }
    else if (prodotto == "Turno")
    {

    }
    else if (prodotto == "Tavolo")
    {

    }
    else if (prodotto == "Ordinazione")
    {

    }
    else 
    {
      Console.WriteLine("Qualcosa è andato storto");
      return;
    }
  };
}