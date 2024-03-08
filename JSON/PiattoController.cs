using System.Data.SQLite;
using System.Linq;

class Controller
{
  private Database _db; // Riferimento al modello
  private PiattoView _testview; // Riferimento alla vista

  public Controller(Database db, PiattoView piattoview) // View view,
  {
    _db = db; // Inizializzazione del riferimento al modello
    _piattoview = piattoview; // Inizializzazione del riferimento alla vista
  }

public void Start()
{
  _piattoview.Start();
}
public void InserisciPiatto()
{

} // inserisci piatto nel database
public void ModificaPiatto()
{

} // modifica piatto nel database
public void CancellaPiatto()
{

} // cancella piatto dal database




}













/*
CreaMenu(); // crea un file json con i piatti che selezioni
ModificaMenu(); // modifica il json
EliminaMenu(); // elimina il json
*/