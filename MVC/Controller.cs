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
        EditUser(); // Modifica di un utente
      }
      else if (input == "4")
      {
        RemoveUser(); // Rimozione di un utente
      }
      else if (input == "e")
      {
        break; // Uscita dal programma
      }
    }
  }

  private void AddUser()
  {
    Console.WriteLine("Enter user name:"); // Richiesta nome dell'utente
    var name = _view.GetInput(); // Lettura del nome dell'utente
    var user = new User { Nome = name };
    _db.Users.Add(user);
    _db.SaveChanges();
  }
  private void EditUser()
  {
    EnterId:
    Console.WriteLine("Enter user id:"); // Richiesta id dell'utente
    {
      try
      {
        var userId = int.Parse(Console.ReadLine()!); 
        var result = _db.Users.SingleOrDefault(u => u.Id == userId);
        if (result != null)
        {
          Console.WriteLine("Enter user new name:"); // Richiesta nuovo nome dell'utente
          var newName = Console.ReadLine()!; 
          result.Nome = newName;
          _db.SaveChanges();
        }
      }
      catch (Exception)
      {
        Console.WriteLine("inserisci un numero valido");
        goto EnterId;
      }
    }
  }
  private void RemoveUser()
 {
    EnterId:
    Console.WriteLine("Enter user id:"); // Richiesta id dell'utente
    {
      try
      {
        var userId = int.Parse(Console.ReadLine()!); 
        var result = _db.Users.SingleOrDefault(u => u.Id == userId);
        if (result != null)
        {
          _db.Remove(result);
          _db.SaveChanges();
        }
      }
      catch (Exception)
      {
        Console.WriteLine("inserisci un numero valido");
        goto EnterId;
      }
    }
  }
  private void ShowUsers()
  {
    var users = _db.Users.ToList(); 
      foreach (var u in users)
      {
        Console.WriteLine($"{u.Id} - {u.Nome}");
      }
  }
}