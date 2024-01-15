using System;

class Example
{
  public static void Main()
  {
    var nome = "Giammarco";
    while (true)
    {
      string input = Console.ReadLine();

      if (input.StartsWith("cmd:"))
      {
        string comando = input.Substring(4);
        switch (comando.ToLower())
        {
          case "info":
            Console.WriteLine("Comando info riconosciuto. Mostro le informazioni");
            break;
          case "name":
            Console.WriteLine($"Ciao {nome}");
            break;
          case "exit":
            Console.WriteLine("Comando exit riconosciuto. Uscita in corso...");
            return; // esce dal programma
          default:
            Console.WriteLine($"Comando {comando} non riconosciuto.");
            break;
        }
      }
      else
      {
        Console.WriteLine("Input non valido. Inserisci un comando");
      }
      Console.WriteLine("\n Inserisci un altro comando:");
    }
  }
}