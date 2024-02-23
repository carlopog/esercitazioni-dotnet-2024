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
                   CREATE TABLE giocatori (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, eta REAL(id));
                   INSERT INTO giocatori (nome, eta) VALUES ('Gianni',41); 
                   INSERT INTO giocatori (nome, eta) VALUES ('Marco',33);
                   INSERT INTO giocatori (nome, eta) VALUES ('Francisco',23);

                   CREATE TABLE scommesse (id INTEGER PRIMARY KEY AUTOINCREMENT, nome_giocatore TEXT, prezzo INTEGER CHECK (prezzo >= 0) FOREIGN KEY (nome_giocatore) REFERENCES giocatore(nome))
                   INSERT INTO scommesse (nome_giocatore, prezzo) VALUES ('Gianni', 50)
                   INSERT INTO scommesse (nome_giocatore, prezzo) VALUES ('Gianni', 50)

                   CREATE TABLE vincite (id INTEGER PRIMARY KEY AUTOINCREMENT, nome_giocatore TEXT, risultato INTEGER FOREIGN KEY (nome_giocatore) REFERENCES giocatore(nome))
                   INSERT INTO vincite (nome_giocatore, risultato) VALUES ('Gianni', -50)
                   INSERT INTO vincite (nome_giocatore, risultato) VALUES ('Gianni', 50)
                   
                   CREATE TABLE prestiti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome_giocatore TEXT UNIQUE, valore INTEGER CHECK (prestito >= 0), FOREIGN KEY (nome_giocatore) REFERENCES giocatore(nome) )
                   INSERT INTO prestiti (nome_giocatore, valore) VALUES ('Gianni', 100)

                   CREATE TABLE bottini (id INTEGER PRIMARY KEY AUTOINCREMENT, nome_giocatore TEXT UNIQUE, ammontare INTEGER CHECK (bottino >= 0) FOREIGN KEY (nome_giocatore) REFERENCES giocatore(nome))
                   INSERT INTO bottini (nome_giocatore, ammontare) VALUES ('Gianni', 100)
                   ";

      SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
      command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database
      connection.Close(); // chiude la connessione al database
    }
    while (true)
    {
      Console.WriteLine("scegli un'opzione");
      Console.WriteLine("1 - inserisci prodotto");
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
    string prodotto;
    string numero;
    while (true)
    {
      Console.WriteLine("scegli un'opzione");
      Console.WriteLine("1 - inserisci giocatore");
      Console.WriteLine("2 - inserisci scommessa");
      Console.WriteLine("3 - inserisci bottino");
      Console.WriteLine("4 - inserisci prestito");
      Console.WriteLine("5 - inserisci vincita");
      Console.WriteLine("6 - esci");
      string scelta = Console.ReadLine()!;
      switch (scelta)
      {
        case "1":
          {
            prodotto = "del giocatore";
            numero = "l'età";
            break;
          }
        case "2":
          {
            prodotto = "della scommessa";
            numero = "il prezzo";
            break;
          }
        case "3":
          {
            prodotto = "del bottino";
            numero = "l' ammontare";
            break;
          }
        case "4":
          {
            prodotto = "del prestito";
            numero = "valore";
            break;
          }
        case "5":
          {
            prodotto = "della vincita";
            numero = "il risultato";
            break;
          }
        case "6":
          {
            return;
          }
        default:
        {
            Console.WriteLine("Devi inserire un numero da 1 a 5, riprova");
            break;
          }
      }

      Console.WriteLine($"Inserisci nome del giocatore:");
      string nome = Console.ReadLine()!;
      Console.WriteLine($"Inserisci {numero} {prodotto}:");
      string prezzo = Console.ReadLine()!;
      SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
      connection.Open();
    string sql = @$"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo})";
      SQLiteCommand command = new SQLiteCommand(sql, connection);
      command.ExecuteNonQuery();
      connection.Close();
    }
  }
  // static void VisualizzaProdotti()
  // { 
  //   SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
  //   connection.Open()
  //   string sql = @$"SELECT * FROM prodotti";
  //   SQLiteCommand command = new SQLiteCommand(sql, connection);
  //   SQLiteDataReader reader = command.ExecuteReader();
  //   while (reader.Read()) // finche' il metodo Read legge qualcosa in reader va avanti, ce li fa leggere tutti
  //   {
  //     Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
  //   }
  //   connection.Close();
  // }

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