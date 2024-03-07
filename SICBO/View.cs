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
    // come prima cosa farei cwl "Benvenuto" e poi AggiungiGiocatore() 
   
    // capire se serve i txt/csv dei singoli dati  o un json GiocatoreAttuale
    // in ogni caso potrebbe essere utile fare l'array dei dati del giocatore
    // NOME [0], BOTTINO [1], PRESTITO [2], LASTBET [3]


  }
}

