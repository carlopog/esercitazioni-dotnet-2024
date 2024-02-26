﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
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
      string sql = @"CREATE TABLE giocatori (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, eta REAL);
                     CREATE TABLE scommesse (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, prezzo INTEGER CHECK (prezzo >= 0), FOREIGN KEY (nome) REFERENCES giocatori(nome));
                     CREATE TABLE vincite (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, risultato INTEGER, FOREIGN KEY (nome) REFERENCES giocatori(nome));
                     CREATE TABLE prestiti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, valore INTEGER CHECK (valore >= 0), FOREIGN KEY (nome) REFERENCES giocatori(nome));
                     CREATE TABLE bottini (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, ammontare INTEGER CHECK (ammontare >= 0), FOREIGN KEY (nome) REFERENCES giocatori(nome));
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
      Console.WriteLine("3 - modifica prodotto");
      Console.WriteLine("4 - elimina prodotto");
      Console.WriteLine("e - esci");
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
            VisualizzaProdotto();
            break;
          }
        case "3":
          {
            ModificaProdotto();
            break;
          }
        case "4":
          {
            EliminaProdotto();
            break;
          }
        case "e":
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

  static string[] SelezionaProdotto(string prodotti, string prodotto, string numero, string metodo, string verbo)
  {
    Console.WriteLine("scegli un'opzione");
    Console.WriteLine($"1 - {metodo} giocatore");
    Console.WriteLine($"2 - {metodo} scommessa");
    Console.WriteLine($"3 - {metodo} vincita");
    Console.WriteLine($"4 - {metodo} bottino");
    Console.WriteLine($"5 - {metodo} prestito");
    string scelta = Console.ReadLine()!;
    switch (scelta)
    {
      case "1":
        {
          Console.WriteLine($"Hai scelto di {verbo} un giocatore,");
          prodotti = "giocatori";
          prodotto = "del giocatore";
          numero = "eta";
          break;
        }
      case "2":
        {
          Console.WriteLine($"Hai scelto di {verbo} una scommessa,");
          prodotti = "scommesse";
          prodotto = "della scommessa";
          numero = "prezzo";
          break;
        }
      case "3":
        {
          Console.WriteLine($"Hai scelto di {verbo} una vincita,");
          prodotti = "vincite";
          prodotto = "della vincita";
          numero = "risultato";
          break;
        }
      case "4":
        {
          Console.WriteLine($"Hai scelto di {verbo} un bottino,");
          prodotti = "bottini";
          prodotto = "del bottino";
          numero = "ammontare";
          break;
        }
      case "5":
        {
          Console.WriteLine($"Hai scelto di {verbo} un prestito,");
          prodotti = "prestiti";
          prodotto = "del prestito";
          numero = "valore";
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
    Console.WriteLine($"Hai scelto {prodotti}. Come vuoi visualizzare?");
    Console.WriteLine($"1 - Elenco completo");
    Console.WriteLine($"2 - In base a un nome");
    Console.WriteLine($"3 - In base a un id");
    Console.WriteLine($"4 - In base a un valore");
    Console.WriteLine($"5 - Dal valore maggiore al minore");
    Console.WriteLine($"6 - Dal valore minore al maggiore");
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
            Thread.Sleep(300);
          }
          connection.Close(); // chiude la connessione al database se non è già chiusa
          break;
        }
      case "2":
        {
          Console.WriteLine($"Hai scelto di visualizzare un elenco in base al nome,");
          Console.WriteLine($"Inserisci nome del giocatore di cui vuoi visualizzare:");
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
      // case "3":
      //   {
      //     Console.WriteLine($"Hai scelto di {verbo} una vincita,");
      //     prodotti = "vincite";
      //     prodotto = "della vincita";
      //     numero = "risultato";
      //     break;
      //   }
      // case "4":
      //   {
      //     Console.WriteLine($"Hai scelto di {verbo} un bottino,");
      //     prodotti = "bottini";
      //     prodotto = "del bottino";
      //     numero = "ammontare";
      //     break;
      //   }
      // case "5":
      //   {
      //     Console.WriteLine($"Hai scelto di {verbo} un prestito,");
      //     prodotti = "prestiti";
      //     prodotto = "del prestito";
      //     numero = "valore";
      //     break;
      //   }
      default:
        {
          Console.WriteLine("Devi inserire un numero da 1 a 5, riprova");
          break;
        }
    }
    // string[] arr = [];
    // return arr;
  }
  static void VisualizzaProdotto()
  {
    // Console.WriteLine($"non esiste ancora");
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string metodo = "visualizza";
    string verbo = "visualizzare";
    string[] array = SelezionaProdotto(prodotti, prodotto, numero, metodo, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];

    Console.WriteLine(prodotti);
    Console.WriteLine(prodotto);
    Console.WriteLine(numero);
    


    SelezionaVisualizzazione(prodotti, numero);

    // Console.WriteLine($"Inserisci {numero} {prodotto}:");
    // string prezzo = Console.ReadLine()!;
    // SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    // connection.Open();
    // string sql = @$"INSERT INTO {prodotti} (nome, {numero}) VALUES ('{nome}', {prezzo})";
    // SQLiteCommand command = new SQLiteCommand(sql, connection);
    // command.ExecuteNonQuery();
    // connection.Close();


  }

  static void ModificaProdotto()
  {
    Console.WriteLine($"non esiste ancora");
    // var bottino = SELECT bottini.
  }
  static void EliminaProdotto()
  {
    Console.WriteLine($"non esiste ancora");
  }
  static void InserisciProdotto()
  {
    string prodotti = "";
    string prodotto = "";
    string numero = "";
    string metodo = "inserisci";
    string verbo = "inserire";
    string[] array = SelezionaProdotto(prodotti, prodotto, numero, metodo, verbo);
    prodotti = array[0];
    prodotto = array[1];
    numero = array[2];

    Console.WriteLine($"Inserisci nome del giocatore:");
    string nome = Console.ReadLine()!;
    Console.WriteLine($"Inserisci {numero} {prodotto}:");
    string prezzo = Console.ReadLine()!;
    SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione al database, indicando la versione 
    connection.Open();
    string sql = @$"INSERT INTO {prodotti} (nome, {numero}) VALUES ('{nome}', {prezzo})";
    SQLiteCommand command = new SQLiteCommand(sql, connection);
    command.ExecuteNonQuery();
    connection.Close();
  }
}
