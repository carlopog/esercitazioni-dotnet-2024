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
    Tipo:
    Console.WriteLine("Vuoi leggere un file o eliminarlo? (l/e)");
    string tipoScelto = Console.ReadLine()!; // legge il tipo di operazione scelta
    if (tipoScelto == "l")
    {
      Leggi:
      Console.WriteLine("Quale file vuoi leggere?");
      string fileScelto = Console.ReadLine() + ".csv" !; // legge il nome del file scelto
      try
      {
        string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
        foreach (string line in lines)
        {
          Console.WriteLine(line); // scrive tutte le righe del file 
        }
      }
      catch (Exception)
      {
        Console.WriteLine("il file non esiste");
        goto Leggi;
      }
    }
    else if (tipoScelto == "e")
    {
      Elimina:
      Console.WriteLine("quale file vuoi eliminare?");
      string fileScelto = Console.ReadLine() + ".csv"!; // legge il nome del file scelto
      try
      {
        File.Delete(fileScelto); // elimina il file
        Console.WriteLine($"il file {fileScelto} è stato eliminato"); 
      }
      catch (Exception)
      {
        Console.WriteLine("il file non esiste"); 
        goto Elimina;
      }
    }
    else
    {
      Console.WriteLine("Tipo non valido.");
      goto Tipo;
    }
  }
}
