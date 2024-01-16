using System;
using System.Collections;

class Example
{
  public static void Main()
  {
    Console.Clear();
    Console.WriteLine("Seleziona l'opzione:");
    Console.WriteLine("1 - Nascondi il cursore");
    Console.WriteLine("2 - Mostra il cursore");
    Console.WriteLine("3 - Pulisci console");
    Console.WriteLine("4 - Emetti beep");
    Console.WriteLine("5 - Emetti beep prolungato");
    Console.WriteLine("6 - Imposta il titolo");
    Console.WriteLine("e - Exit\n");

    while (true)
    {
      Console.WriteLine("Digita...");

      string? input = Console.ReadLine();
      switch (input)
      {
        case "1":
          Console.CursorVisible = false;
          break;

        case "2":
          Console.CursorVisible = true;
          break;

        case "3":
          Console.Clear();
          break;

        case "4":
          Console.Beep();
          break;

        case "5":
          Console.WriteLine("Inserisci la frequenza");
          int freq = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Inserisci i millisecondi");
          int ms = Int32.Parse(Console.ReadLine());
          Console.Beep(freq, ms);
          break;

        case "6":
          Console.Title = "La mia app";
          break;

        case "e":
          return;

        default:
          Console.WriteLine("Comando non valido riprova");
          break;

      }

      Console.Clear();
      Console.WriteLine("Seleziona l'opzione:");
      Console.WriteLine("1 - Nascondi il cursore");
      Console.WriteLine("2 - Mostra il cursore");
      Console.WriteLine("3 - Pulisci console");
      Console.WriteLine("4 - Emetti beep");
      Console.WriteLine("5 - Emetti beep prolungato");
      Console.WriteLine("6 - Imposta il titolo");
      Console.WriteLine("e - Exit\n");

    }
  }
}
