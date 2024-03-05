# MVC 

MVC è un pattern architetturale che separa i dati, la logica di business e l'interfaccia utente in 3 componenti distinti.

- Model: classe che rappresenta il database
- View: interfaccia grafica
- Controller: classe che gestisce le interazioni tra l'utente e il modello

comando dotnet per creare l'app


## per usare entity framework

fare i dotnet add package a seconda di inmemory o sqlite

class user con id e nome

database crei la connessione estendendo la classe database

classe view resta uguale

classe controller bisogna modificarlo

```bash
dotnet new console -n MvcConsole
```

comando dotnet per installare il pacchetto System.Data.SQLite

```bash
dotnet add package System.Data.SQLite
```

```csharp
using System.Data.SQLite;

class Program
{
  static void Main(string[] args)
  {
    var db = new Database(); // Model
    var view = new View(db); // View
    var controller = new Controller (db, view); // Controller
    controller.MainMenu(); // Menu principale dell'app
  }
}

class Database
{
  private SQLiteConnection _connection; // SQLiteConnection e' una classe  che rappresenta una connessione a un database SQLite
   // si utilizza l'underscore davanti al nome della variabile per indicare che e' privata e non accessibile dall'esterno
  public Database()
  {
    _connection = new SQLiteConnection("Data Source=database.db"); // creazione di una connessione al database
    _connection.Open(); // Apertura della connessione
    string sql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)"; // Stringa creazione della tabella users
    var command = new SQLiteCommand(sql, _connection); // Creazione del comando
    command.ExecuteNonQuery(); // Esecuzione del comando
  }

  public void AddUser(string name)
  {
    string add = $"INSERT INTO users (name) VALUES ('{name}')";
    var command = new SQLiteCommand(add, _connection);
    command.ExecuteNonQuery();
  }

  public List<string> GetUsers()
  {
    string getUsers = "SELECT name FROM users";
    var command = new SQLiteCommand(getUsers, _connection);
    var reader = command.ExecuteReader();
    var users = new List<string>(); // Creare una lista per memorizzare i nomi degli utenti
    while (reader.Read()) // questo restituisce un array con tutti i dati
    {
      users.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista, levandoli uno alla volta dall'array
    }
    return users; // Restituzione della lista

  }
}

class View 
{
  private Database _db; // Riferimento al modello

  public View(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }

  public void ShowMainMenu()
  {
    Console.WriteLine($"1. Aggiungi user");
    Console.WriteLine($"2. Leggi users");
    Console.WriteLine($"3. Esci");
  }
  public void ShowUsers(List<string> users)
  {
    foreach (var user in users)
    {
     Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
    }
  }
  public string GetInput()
  {
    return Console.ReadLine(); // Lettura dell'input dell'utente
  }
}

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

```


```c#

// se vuoi selezionare il primo della tabella

      // Read
      Console.WriteLine("Prendo il primo user");
      var first = db.Users
          .OrderBy(f => f.Id)
          .First();

      Console.WriteLine(first.Nome);

// se vuoi chiamare Pinodaniele il primo della tabella
      // Update
      first.Nome = "Pinodaniele";
      db.SaveChanges();
      Console.WriteLine(first.Nome);

```