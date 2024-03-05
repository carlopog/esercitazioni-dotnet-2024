using System.Data.SQLite;

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

  public void RemoveUser(string name)
  {
    string remove = $"DELETE FROM users WHERE (name) = '{name}'";
    var command = new SQLiteCommand(remove, _connection);
    command.ExecuteNonQuery();
  }
  public void EditUser(string name, string newName)
  {
    string edit = $"UPDATE users SET (name) = '{newName}' WHERE (name) = '{name}'";
    var command = new SQLiteCommand(edit, _connection);
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