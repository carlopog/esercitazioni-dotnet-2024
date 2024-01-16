using System;
using System.Collections;
using System.Runtime.Intrinsics.Arm;

class Example
{
  public static void Main()
  {
    Console.Clear(); // pulisce la schermata iniziale
    bool continua = true;
    do
    {
      Console.Clear(); // pulisce la schermata a ogni giro
      
      Console.WriteLine("Menu di Selezione");
      Console.WriteLine("1. Opzione uno");
      Console.WriteLine("2. Opzione due");
      Console.WriteLine("3. Opzione tre");
      Console.WriteLine("4. Esci");

      Console.WriteLine("Inserisci il numero dell'opzione desiderata");
      string? scelta = Console.ReadLine();

      switch (scelta)
      {
        case "1":
          Console.WriteLine("Hai scelto l'opzione 1");
          // inserire qui la logica per l'opzione 1
          break;
        case "2":
          Console.WriteLine("Hai scelto l'opzione 2");
          // inserire qui la logica per l'opzione 2
          break;
        case "3":
          Console.WriteLine("Hai scelto l'opzione 3");
          // inserire qui la logica per l'opzione 3
          break;
        case "4":
          Console.WriteLine("Uscita in corso...");
          return;
        default:
          Console.WriteLine("Selezione non valida. Riprova.");
          break;
      }
      if (continua)
      {
        Console.WriteLine("Premi un tasto per continuare");
        Console.ReadKey(); // aspetta che l'utente prema un tasto prima di continuare
      }
    }
    while (continua);
  }
}