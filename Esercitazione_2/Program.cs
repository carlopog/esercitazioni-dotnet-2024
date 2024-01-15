using System;

class Example
{
  public static void Main()
  {
    var nome = "Giammarco";
    Console.WriteLine("Inserisci un comando che parta con cmd:");
    while (true)
    {
      string? input = Console.ReadLine();

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
      else if (input == "secret")
      {
        Console.WriteLine("Secret informations. Password required");
        string? password = Console.ReadLine();
        if (password == "ciao")
        {
          Console.Write("Good Job: Babbo Natale non esiste!");
          return;
        }
        else {
          Console.Write("Wrong password");
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