using System;
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
            ModificaProdotto();
            break;
          }
        case "3":
          {
            ModificaProdotto();
            break;
          }
        case "e":
          {
            return;
          }
        default:
          {
            Console.WriteLine("Devi inserire un numero da 1 a 3, riprova");
            break;
          }
      }
    }
  }

  static string[] SelezionaProdotto(string prodotti,string prodotto,string numero)
  {
    Console.WriteLine("scegli un'opzione");
    Console.WriteLine("1 - inserisci giocatore");
    Console.WriteLine("2 - inserisci scommessa");
    Console.WriteLine("3 - inserisci vincita");
    Console.WriteLine("4 - inserisci bottino");
    Console.WriteLine("5 - inserisci prestito");
    string scelta = Console.ReadLine()!;
    switch (scelta)
    {
      case "1":
        {
          Console.WriteLine("Hai scelto di inserire un giocatore,");
          prodotti = "giocatori";
          prodotto = "del giocatore";
          numero = "eta";
          break;
        }
      case "2":
        {
          Console.WriteLine("Hai scelto di inserire una scommessa,");
          prodotti = "scommesse";
          prodotto = "della scommessa";
          numero = "prezzo";
          break;
        }
      case "3":
        {
          Console.WriteLine("Hai scelto di inserire una vincita,");
          prodotti = "vincite";
          prodotto = "della vincita";
          numero = "risultato";
          break;
        }
      case "4":
        {
          Console.WriteLine("Hai scelto di inserire un bottino,");
          prodotti = "bottini";
          prodotto = "del bottino";
          numero = "ammontare";
          break;
        }
      case "5":
        {
          Console.WriteLine("Hai scelto di inserire un prestito,");
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

  static void VisualizzaProdotto()
  {
    Console.WriteLine($"non esiste ancora");
  }

  static void ModificaProdotto()
  {
    Console.WriteLine($"non esiste ancora");
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
    string[] array = SelezionaProdotto(prodotti,prodotto,numero);
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
