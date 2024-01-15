using System;

class Example
{
  public static void Main()
  {
    Console.WriteLine ("Trascina un file qui e premi invio");
    string filePath = Console.ReadLine().Trim('"'); 
    // trim rimuove le virgolette che possono apparire nel percorso
    try 
    {
      string content = File.ReadAllText(filePath);
      Console.WriteLine("Contenuto del file:");
      Console.WriteLine(content);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Si e' verificato un errore: {ex.Message}");
    }
  }
}