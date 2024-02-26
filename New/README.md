

dotnet add package Spectre.Console

dotnet add package Spectre.Console.Cli



scriptini 

 SELECT giocatori.id, bottini.nome, bottini.ammontare, giocatori.eta FROM bottini  JOIN giocatori ON bottini.nome = giocatori.nome ; 

 SELECT giocatori.id, giocatori.nome, bottini.ammontare, giocatori.eta FROM bottini  JOIN giocatori ON bottini.nome = giocatori.nome WHERE bottini.nome ='Mario';

 SELECT giocatori.id, giocatori.nome, bottini.ammontare AS bottino, prestiti.valore AS prestito FROM giocatori JOIN bottini ON giocatori.nome = bottini.nome JOIN prestiti ON giocatori.nome = prestiti.nome;

SELECT giocatori.id, giocatori.nome, bottini.ammontare, prestiti.valore FROM giocatori JOIN bottini ON giocatori.nome = bottini.nome JOIN prestiti ON giocatori.nome = prestiti.nome;

SELECT giocatori.id, giocatori.nome, scommesse.prezzo, vincite.risultato FROM giocatori JOIN scommesse ON scommesse.nome = scommesse.nome JOIN vincite ON giocatori.nome = vincite.nome;

SELECT scommesse.id, scommesse.nome, scommesse.prezzo, vincite.risultato, vincite.nome FROM scommesse JOIN vincite ON scommesse.id = vincite.id; 





```c#
public static class Program 
{
  public static void Main(string[] args)
    {
      AnsiConsole.Markup("[underline red]Hello[/] World!");

    var table = new Table();
    table.AddColumn("Column 1");
    table.AddColumn("Column 2");
    table.AddRow("Valore 1", "Valore 2");
    table.AddRow("Valore 3", "Valore 4");
    AnsiConsole.Write(table);
    AnsiConsole.Markup("Hello :globe_showing_europe_africa:!");

    AnsiConsole.Progress()
    .Start(ctx =>
    {
      var task1 = ctx.AddTask("[green]Reticulating splines[/]");
      var task2 = ctx.AddTask("[green]Folding space[/]");
    
      while(!ctx.IsFinished)
      {
        task1.Increment(1.5);
        task2.Increment(0.5);
      }
    
    });
    }
}


```


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

```sql
    CREATE TABLE giocatori (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, eta REAL, id_prestito INTEGER, id_bottino INTEGER, id_scommessa INTEGER, FOREIGN KEY (id_prestito) REFERENCES prestiti(id), FOREIGN KEY (id_scommessa) REFERENCES scommesse(id), FOREIGN KEY (id_bottino) REFERENCES bottini(id)  );
                   INSERT INTO prodotti (nome, eta, id_prestito, id_bottino, id_scommessa) VALUES ('Gianni',41,1,1,2); 
                   INSERT INTO prodotti (nome, eta, id_prestito, id_bottino, id_scommessa) VALUES ('Marco',33,1,1,2);
                   INSERT INTO prodotti (nome, eta, id_prestito, id_bottino, id_scommessa) VALUES ('Francisco',23,1,1,2);
```


```c#
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      switch (input)
      {
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
        default:
        {
            Console.WriteLine("Devi inserire un numero da 1 a 4, riprova");
            break;
          }
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
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    connection.Open();
    string sql = @$"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
  static void VisualizzaProdotti()
  {
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    connection.Open();
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
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    connection.Open();
    string sql = @$"DELETE FROM prodotti WHERE nome = '{nome}";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
}


```