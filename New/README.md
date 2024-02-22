
creo un programma che 

- [x] crea un database 
- [x] se non esiste gia'
- [x] funzione inserisci prodotto
- [x] funzione visualizza prodotto
- [x] funzione elimina prodotto
- [x] chiude la connessione al database 
- [ ] funzione modifica un prodotto
- [ ] funzione join per non selezionare solo una tabella ma due insieme
- [ ] filtra un prodotto in base al nome
- [ ] funzione ordina i prodotti dal meno costoso al piu'
- [ ] funzione filtra il prodotto piu' costoso

```c#

class Program
{
  static void Main(string[] args)
  {
    string path = @"database.db"; // creo la rotta del file database
    if (!File.Exists(path)) // se il file database non esistesse
    {
      SQLiteConnection.CreateFile(path); // crea il file del database
      SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=1;"); // crea la connessione al database, indicando la versione 
      connection.Open(); // apre la connessione al database
      string sql = @"
                   CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                   INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1',1,10); 
                   INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2',2,20);
                   INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3',3,30);
                   ";

      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
    }
    while (true)
    {
      Console.WriteLine("scegli un'opzione");
      Console.WriteLine("1 - inserisci prodotto");
      Console.WriteLine("2 - visualizza prodotto");
      Console.WriteLine("3 - elimina prodotto");
      Console.WriteLine("4 - esci");
      string input = Console.ReadLine()!;
      switch(input)
      case "1":
      {
        InserisciProdotto();
        break;
      }
      case "2":
      {
        VisualizzaProdotti();
        break;
      }
      case "3":
      {
        EliminaProdotto();
        break;
      }
      case "4":
      {
        return;
      }
      default
      {
        Console.WriteLine("Devi inserire un numero da 1 a 4, riprova");
      }
    }
  }

  static void InserisciProdotto()
  { 
    Console.WriteLine("Inserisci i dati del prodotto");
    Console.WriteLine("Inserisci nome del prodotto:");
    string nome = Console.ReadLine()!;
    Console.WriteLine("Inserisci il prezzo del prodotto:");
    string prezzo = Console.ReadLine()!;
    Console.WriteLine("Inserisci la quantita del prodotto:");
    string quantita = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=1;"); // crea la connessione al database, indicando la versione 
    connection.Open()
    string sql = @$"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
  static void VisualizzaProdotti()
  { 
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=1;"); // crea la connessione al database, indicando la versione 
    connection.Open()
    string sql = @$"SELECT * FROM prodotti";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SQLiteDataReader reader = command.ExecuteReader();
    while (reader.Read()) // finche' il metodo Read legge qualcosa in reader va avanti, ce li fa leggere tutti
    {
      Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
    }
    connection.Close();
  }

  static void EliminaProdotto()
  { 
    Console.WriteLine("Inserisci il nome del prodotto:");
    string nome = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=1;"); // crea la connessione al database, indicando la versione 
    connection.Open()
    string sql = @$"DELETE FROM prodotti WHERE nome = '{nome}";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
}


```