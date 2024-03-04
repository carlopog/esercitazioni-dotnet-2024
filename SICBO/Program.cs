using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Spectre.Console;
class Program
{
  static void Main(string[] args)
  {
    string path = @"database.db"; // creo la rotta del file database
    if (!File.Exists(path)) // se il file database non esistesse
    {
      SQLiteConnection.CreateFile(path); // crea il file del database
      SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database, indicando la versione 
      connection.Open(); // apre la connessione al database
      string sql = @"CREATE TABLE giocatori (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, eta REAL, bottino INTEGER CHECK (bottino >= 0), lastbet INTEGER CHECK (lastbet >=0), prestito INTEGER CHECK (prestito >= 0));
                     CREATE TABLE scommesse (id INTEGER PRIMARY KEY AUTOINCREMENT, prezzo INTEGER CHECK (prezzo >= 0), vincita INTEGER, nome TEXT, FOREIGN KEY (nome) REFERENCES giocatori(nome));
                   ";
      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
    }
    while (true)
    {
      Console.WriteLine("scegli un'opzione");
      Console.WriteLine("1 - inserisci giocatore"); // con bottino, lastbet e prestito coi valori di default
      Console.WriteLine("2 - inserisci scommessa"); // con vincita iniziale -{prezzo} modifica lastbet
      Console.WriteLine("3 - visualizza giocatori"); // deve farmi vedere tutti i dati dei giocatori
      Console.WriteLine("4 - visualizza scommesse"); // deve farmi vedere tutte le scommesse o tutte quelle di un giocatore
      Console.WriteLine("5 - modifica giocatore"); 
      Console.WriteLine("6 - modifica vincita");  // triggera modifica bottino e dopo
      /*
        if prestito > 0 & prestito < bottino
      update bottino = bottino - prestito;
      update prestito = 0;
      */
      Console.WriteLine("7 - modifica prestito"); // update prestito = x; triggera update bottino += prestito;
      Console.WriteLine("8 - elimina giocatore");
      Console.WriteLine("e - esci");
      string input = Console.ReadLine()!;
      switch (input)
      {
        case "1":
          {
            InserisciProdotto("giocatore");
            // InserisciGiocatore();
            break;
          }
        case "2":
          {
            InserisciProdotto("scommessa");
            // InserisciScommessa();
            break;
          }
        case "3":
          {
            // VisualizzaProdotto("giocatore");
            VisualizzaGiocatori();
            break;
          }
        case "4":
          {
            // VisualizzaProdotto("scommessa");
            VisualizzaScommesse();
            break;
          }
        case "5":
          {
            ModificaProdotto("giocatore");
            // ModificaGiocatore();
            break;
          }
        case "6":
          {
            ModificaProdotto("vincita");
            // ModificaVincitaBottino();

        //  ModificaProdotto("bottino"); assegnandogli il valore bottino + vincita
         /*
              if prestito > 0 & prestito < bottino
            update bottino = bottino - prestito;
            update prestito = 0;
        */
            break;
          }
        case "7":
          {
            ModificaProdotto("prestito");
            // ModificaPrestito();

            break;
          }
        case "8":
          {
            EliminaProdotto("giocatore");
            break;
          }
        case "e":
          {
            return;
          }
        default:
          {
            Console.WriteLine("Devi inserire un numero da 1 a 8, riprova");
            break;
          }
      }
    }
  }

  static string[] SelezionaProdotto(string scelta, string prodotti, string prodotto, string numero, string verbo)
  {
    switch (scelta)
    {
      case "1":
      case "giocatore":
        {
          Console.WriteLine($"Hai scelto di {verbo} un giocatore,");
          prodotti = "giocatori";
          prodotto = "del giocatore";
          numero = "eta";
          break;
        }
      case "2":
      case "scommessa":
        {
          Console.WriteLine($"Hai scelto di {verbo} una scommessa,");
          prodotti = "scommesse";
          prodotto = "della scommessa";
          numero = "prezzo";
          break;
        }
      case "3":
      case "vincita":
        {
          Console.WriteLine($"Hai scelto di {verbo} una vincita,");
          prodotti = "scommesse";
          prodotto = "della vincita";
          numero = "vincita";
          break;
        }
      case "4":
      case "bottino":
        {
          Console.WriteLine($"Hai scelto di {verbo} un bottino,");
          prodotti = "giocatori";
          prodotto = "del bottino";
          numero = "bottino";
          break;
        }
      case "5":
      case "prestito":
        {
          Console.WriteLine($"Hai scelto di {verbo} un prestito,");
          prodotti = "giocatori";
          prodotto = "del prestito";
          numero = "prestito";
          break;
        }
      default:
        {
          Console.WriteLine("Devi inserire un numero da 1 a 5, riprova");
          break;
        }
    }
    string[] arr = [prodotti, prodotto, numero];
    return arr;
  }
  static void SelezionaVisualizzazione(string prodotti, string numero)
  {
    int counter = 0;
  Valori:
    Console.WriteLine($"Hai scelto {prodotti}. Come vuoi visualizzare?");
    Console.WriteLine("1 - Elenco completo");
    Console.WriteLine("2 - In base a un nome");
    Console.WriteLine("3 - In base a un id");
    Console.WriteLine("4 - In base a un valore");
    string scelta = Console.ReadLine()!;
    switch (scelta)
    {
      case "1":
        {
          Console.WriteLine("Hai scelto Elenco completo:");
          SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
          connection.Open();
          string sql = $"SELECT * FROM {prodotti}"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti
          SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
          SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
          while (reader.Read())
          {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
            counter++;
            Thread.Sleep(300);
          }
          if (counter == 0)
          {
            Console.WriteLine("Non c'è nessun dato in questo elenco");
          }
          connection.Close(); // chiude la connessione al database se non è già chiusa
          break;
        }
      case "2":
        {
          Console.WriteLine("Hai scelto di visualizzare un elenco in base al nome,");
          Console.WriteLine("Inserisci nome del giocatore di cui vuoi visualizzare:");
          string nome = Console.ReadLine()!;
          SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
          connection.Open();
          string sql = $"SELECT * FROM {prodotti} WHERE nome = '{nome}'";
          SQLiteCommand command = new SQLiteCommand(sql, connection);
          SQLiteDataReader reader = command.ExecuteReader();

          while (reader.Read())
          {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
            counter++;
            Thread.Sleep(300);
          }
          connection.Close();
          if (counter == 0)
          {
            Console.WriteLine("Non c'è nessun dato corrispondente a questo nome");
          }
          break;
        }

      case "3":
        {
          Console.WriteLine("Hai scelto di visualizzare un elenco in base all'id,");
          Console.WriteLine("Inserisci l'id che vuoi visualizzare:");
          string id = Console.ReadLine()!;
          SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
          connection.Open();
          string sql = $"SELECT * FROM {prodotti} WHERE id = '{id}'";
          SQLiteCommand command = new SQLiteCommand(sql, connection);
          SQLiteDataReader reader = command.ExecuteReader();

          while (reader.Read())
          {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
            counter++;
            Thread.Sleep(300);
          }
          connection.Close();
          if (counter == 0)
          {
            Console.WriteLine("Non c'è nessun dato corrispondente a questo id");
          }
          break;
        }

      case "4":
        {
          Console.WriteLine("Hai scelto di visualizzare un elenco in base ad un valore numerico,");
          Console.WriteLine("Cosa vuoi visualizzare?");
          Console.WriteLine("1 - Elenco completo dal maggiore al minore");
          Console.WriteLine("2 - Elenco completo dal minore al maggiore");
          Console.WriteLine("3 - Valori superiori a un determinato numero");
          Console.WriteLine("4 - Valori inferiori a un determinato numero");
          Console.WriteLine("5 - Solo valori uguali a un determinato numero");
          string numScelta = Console.ReadLine()!;
          switch (numScelta)
          {
            case "1":
              {
                SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                connection.Open();
                string sql = $"SELECT * FROM {prodotti} ORDER BY {numero} DESC";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                  counter++;
                  Thread.Sleep(300);
                }
                connection.Close();
                if (counter == 0)
                {
                  Console.WriteLine("Non c'è nessun dato");
                }
                break;
              }
            case "2":
              {
                SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                connection.Open();
                string sql = $"SELECT * FROM {prodotti} ORDER BY {numero} ASC";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                  counter++;
                  Thread.Sleep(300);
                }
                connection.Close();
                if (counter == 0)
                {
                  Console.WriteLine("Non c'è nessun dato");
                }
                break;
              }
            case "3":
              {
              Superiore:
                Console.WriteLine("Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} > {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore maggiore di {paragone.ToString()}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Superiore;
                }

              }
            case "4":
              {
              Inferiore:
                Console.WriteLine($"Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} < {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore minore di {paragone}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Inferiore;
                }

              }
            case "5":
              {
              Inizio:
                Console.WriteLine($"Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} = {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore uguale a {paragone}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Inizio;
                }
              }
            default:
              {
                Console.WriteLine($"devi scegliere un numero tra 1 e 5");
                goto Valori;
              }
          }
          break;
        }
      default:
        {
          Console.WriteLine("Devi inserire un numero da 1 a 5, riprova");
          break;
        }
    }
  }

  static string OpzioniProdotto(string metodo)
  {
    Console.WriteLine("scegli un'opzione");
    Console.WriteLine($"1 - {metodo} giocatore");
    Console.WriteLine($"2 - {metodo} scommessa");
    Console.WriteLine($"3 - {metodo} vincita");
    Console.WriteLine($"4 - {metodo} bottino");
    Console.WriteLine($"5 - {metodo} prestito");
    string scelta = Console.ReadLine()!;
    return scelta;
  }
  // string scelta = OpzioniProdotto("visualizza");
  static void VisualizzaProdotto(string scelta)
  {
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string verbo = "visualizzare";
    string[] array = SelezionaProdotto(scelta, prodotti, prodotto, numero, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];
    SelezionaVisualizzazione(prodotti, numero);
  }
  static void VisualizzaGiocatori()
  {
    int counter = 0;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
    connection.Open();
    string sql = $"SELECT * FROM giocatori"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    while (reader.Read())
    {
      Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, eta: {reader["eta"]}, bottino: {reader["bottino"]}, lastbet: {reader["lastbet"]}, prestito: {reader["prestito"]} ");
      counter++;
      Thread.Sleep(500);
    }
    if (counter == 0)
    {
      Console.WriteLine("Non c'è nessun dato in questo elenco");
    }
    connection.Close(); 
  }
  static void VisualizzaScommesse()
  {
    int counter = 0;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
    connection.Open();
    string sql = $"SELECT * FROM scommesse"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti
    SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
    SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
    while (reader.Read())
    {
      Console.WriteLine($"id: {reader["id"]}, prezzo: {reader["prezzo"]}, vincita: {reader["vincita"]}, nome: {reader["nome"]}");
      counter++;
      Thread.Sleep(600);
    }
    if (counter == 0)
    {
      Console.WriteLine("Non c'è nessun dato in questo elenco");
    }
    connection.Close();
  }

static int NumerizzaInput(string stringa)
{
  Start:
  Console.WriteLine($"inserisci {stringa}");
  string input = Console.ReadLine()!;
  try
  {
    int num = int.Parse(input);
    return num;
  }
  catch (Exception)
  {
    Console.WriteLine("Devi inserire un numero");
    goto Start;
  }
}
  // string scelta = OpzioniProdotto("modifica");
  static void ModificaProdotto(string scelta)
  {
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string num = "";
    string sql = "";
    string verbo = "modificare";

    string[] array = SelezionaProdotto(scelta, prodotti, prodotto, numero, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];
  
  if (scelta == "giocatore" || scelta == "1")
    {
      Console.WriteLine($"inserisci il nome del giocatore che vuoi modificare"); // chiede il nome del prodotto da modificare
      string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
      ModGiocatore:
      Console.WriteLine("Cosa vuoi modificare?");
      Console.WriteLine("1. Eta");
      Console.WriteLine("2. Bottino");
      Console.WriteLine("3. Prestito");
      Console.WriteLine("4. Ultima scommessa");
      string campo = Console.ReadLine()!;
      switch (campo)
      {
        case "1":
        case "eta":
          {
            Console.WriteLine($"Hai scelto di modificare l'età di questo giocatore,");
            num = "eta";
            break;
          }
        case "2":
        case "bottino":
          {
            Console.WriteLine("Hai scelto di modificare il bottino di questo giocatore,");
            num = "bottino";
            break;
          }
        case "3":
        case "prestito":
          {
            Console.WriteLine("Hai scelto di modificare il prestito di questo giocatore,");
            num = "prestito";
            break;
          }
        case "4":
        case "ultima scommessa":
          {
            Console.WriteLine("Hai scelto di modificare l'ultima scommessa di questo giocatore,");
            num = "lastbet";
            break;
          }
        default:
          {
            Console.WriteLine("Devi inserire un numero da 1 a 4, riprova");
            goto ModGiocatore;
          }
      }
      Console.WriteLine($"inserisci il nuovo {num}");
      int prezzo = int.Parse(Console.ReadLine()!); // legge il nuovo prezzo del prodotto da modificare
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
      connection.Open();
      sql = $"UPDATE {prodotti} SET {num} = {prezzo} WHERE nome = '{nome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
      SQLiteCommand command = new SQLiteCommand(sql, connection);
      command.ExecuteNonQuery();
      connection.Close();
    }
    else if (scelta == "scommessa" || scelta == "2")
    {
      int id = NumerizzaInput("l'id della scommessa che vuoi modificare");
      int prezzo = NumerizzaInput($"il nuovo {numero}");
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
      connection.Open();
      sql = $"UPDATE {prodotti} SET {numero} = {prezzo} WHERE id = {id}"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
      SQLiteCommand comando = new SQLiteCommand(sql, connection);
      comando.ExecuteNonQuery();
      connection.Close();
    }  

    else if (scelta == "vincita" || scelta == "3" ) 
    {
      Console.WriteLine($"inserisci il nome del giocatore a cui vuoi modificare il campo {numero}"); // chiede il nome del prodotto da modificare
      string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
      Console.WriteLine($"inserisci il nuovo {numero}");
      int prezzo = int.Parse(Console.ReadLine()!); // legge il nuovo prezzo del prodotto da modificare
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
      connection.Open();
      string cassa = $"SELECT bottino FROM giocatori WHERE nome = '{nome}'";
      SQLiteCommand comma = new SQLiteCommand(cassa, connection);
      comma.ExecuteNonQuery();
      SQLiteDataReader reader = comma.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati
      while (reader.Read())
      {
        Console.WriteLine($"bottino: {reader["bottino"]}");
      }
      connection.Close();
      connection.Open();
      string idMax = $"(SELECT (id) FROM scommesse WHERE nome = '{nome}' ORDER BY id DESC LIMIT 1) + 1"; // selezionare scommessa con id maggiore con quel nome
      sql = $"UPDATE {prodotti} SET {numero} = {prezzo} WHERE id = {idMax}; ";
      // UPDATE giocatori SET bottino = {bottinoAggiornato} WHERE nome = '{nome}'; "; 
      
      // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
      SQLiteCommand comando = new SQLiteCommand(sql, connection);
      comando.ExecuteNonQuery();
      connection.Close();
      var prestitoAttivo =  $"SELECT prestito FROM giocatori WHERE nome = '{nome}'";
      // int prestitoAttivo =  int.Parse(prestitoA);
      int differenza = bottinoAggiornato - prestitoAttivo;
      if (prestitoAttivo > 0 && differenza >= 0)
      {
        connection.Open();
        string sql2 = $"UPDATE giocatori SET bottino = {differenza} WHERE nome = '{nome}'; UPDATE giocatori SET prestito = 0 WHERE nome = '{nome}'; "; 
        SQLiteCommand com = new SQLiteCommand(sql2, connection);
        com.ExecuteNonQuery();
        connection.Close();
      }
    }
    
    else
    {
      Console.WriteLine($"inserisci il nome del giocatore a cui vuoi modificare il campo {numero}"); // chiede il nome del prodotto da modificare
      string nome = Console.ReadLine()!; // legge il nome del prodotto da modificare
      Console.WriteLine($"inserisci il nuovo {numero}");
      int prezzo = int.Parse(Console.ReadLine()!); // legge il nuovo prezzo del prodotto da modificare
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
      connection.Open();
      sql = $"UPDATE {prodotti} SET {numero} = {prezzo} WHERE nome = '{nome}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
      SQLiteCommand command = new SQLiteCommand(sql, connection);
      command.ExecuteNonQuery();
      connection.Close();
    }



  }

  // string scelta = OpzioniProdotto("elimina");
  static void EliminaProdotto(string scelta)
  {
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string verbo = "eliminare";
    string[] array = SelezionaProdotto(scelta, prodotti, prodotto, numero, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];
  Riprova:
    Console.WriteLine("inserisci l'id del prodotto");
    try
    {
      int id = int.Parse(Console.ReadLine()!);
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
      connection.Open();
      string sql = $"DELETE FROM {prodotti} WHERE id = {id}"; // crea il comando sql che elimina il prodotto con nome uguale a quello inserito
      SQLiteCommand command = new SQLiteCommand(sql, connection);
      command.ExecuteNonQuery();
      connection.Close();
    }
    catch (Exception)
    {
      Console.WriteLine($"L'id deve essere un numero valido");
      goto Riprova;
    }
  }

  // string scelta = OpzioniProdotto("inserisci");
  static void InserisciProdotto(string scelta)
  {
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string verbo = "inserire";
    string[] array = SelezionaProdotto(scelta, prodotti, prodotto, numero, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];

    Console.WriteLine($"Inserisci nome del giocatore:");
    string nome = Console.ReadLine()!;
    Console.WriteLine($"Inserisci {numero} {prodotto}:");
    string prezzo = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    connection.Open();
    string sql;
    if (scelta == "giocatore" || scelta == "1")
    {
      sql = @$"INSERT INTO {prodotti} (nome, {numero}, bottino, lastbet, prestito) VALUES ('{nome}', {prezzo}, 100, 0, 0)";
    }
    else if (scelta == "scommessa" || scelta == "2")
    {
      sql = @$"INSERT INTO {prodotti} (nome, {numero}, vincita) VALUES ('{nome}', {prezzo}, -{prezzo});
                      UPDATE giocatori SET lastbet = {prezzo} WHERE nome = '{nome}'";
    }
    else
    {
      {
        sql = @$"INSERT INTO {prodotti} (nome, {numero}) VALUES ('{nome}', {prezzo})";
      }
    }
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
}
