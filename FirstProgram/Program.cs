using System.Linq.Expressions;
using System.Reflection.Metadata;

class Program
{
  static void Main(string[] args)
  {
    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
    foreach (string file in files)
    {
      Console.WriteLine(Path.GetFileName(file)); // stampa solo il nome del file
    }
    Quale:
    Console.WriteLine("quale file vuoi leggere?");
    string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
    if (File.Exists(fileScelto)) // se il file esiste
    {
      string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
      foreach (string line in lines)
      {
        Console.WriteLine(line); // scrive tutte le righe del file 
      }
    }
    else
    {
      Console.WriteLine("il file non esiste");
      goto Quale;
    }
  }
}
