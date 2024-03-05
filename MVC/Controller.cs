using System.Data.SQLite;

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
    while(true)
    {
      _view.ShowMainMenu(); // Visualizzazione del Menu principale
      var input = _view.GetInput(); // Lettura dell'input dell'utente
      if (input == "1")
      {
        AddUser(); // Aggiunta di un utente
      }
      else if (input == "2")
      {
        ShowUsers(); // Visualizzazione degli utenti
      }
      else if (input == "3")
      {
        break; // Uscita dal programma
      }
    }
  }

  private void AddUser()
  {
    Console.WriteLine("Enter user name:"); // Richiesta nome dell'utente
    var name = _view.GetInput(); // Lettura del nome dell'utente
    _db.AddUser(name); // Aggiunta dell'utente al database
  }
  private void ShowUsers()
  {
    var users = _db.GetUsers(); // Lettura degli utenti dal database
    _view.ShowUsers(users); // Visualizzazione degli utenti
  }
}