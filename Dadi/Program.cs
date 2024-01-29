class Program
{
  static void Results(int[] a)
  {
    Console.WriteLine("Sono usciti i numeri:");

    for (int i = 0; i < 3; i++)
    {
      Console.Write($"{a[i]} ");
      Thread.Sleep(300);
    }
  }
  static void Main(string[] args)
  {
    Random random = new();
    int[] dadi = new int[3];
    int somma = 0;
    int input = 1;
    int quota = 1;
    int scommessa = 0;
    int bottino = 100;

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Ciao Bello il tuo budget di partenza è {bottino}");
    Console.ResetColor();

    while (bottino > 0)
    {
      for (int i = 0; i < 3; i++)
      {
        int n = random.Next(1, 7);
        dadi[i] = n;
        // Console.WriteLine($"è uscito il numero {n}");
        somma += n;
      }
    // Console.WriteLine($"e la somma e' {somma}");

    Scommessa:
      Console.WriteLine("Quanto Scommetti?");
      {
        try
        {
          scommessa = int.Parse(Console.ReadLine()!); // faccio inserire un nuovo valore a input all'utente, ripetendo il controllo che sia un numero valido
        }
        catch (Exception)
        {
          Console.BackgroundColor = ConsoleColor.Magenta;
          Console.WriteLine("Non è un numero valido");
          Console.ResetColor();
          Console.WriteLine("");
          goto Scommessa;
        }
      }
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Tipi di scommessa:");
      Console.WriteLine("1. Valore Singolo");
      Console.WriteLine("2. Doppia");
      Console.WriteLine("3. Tripla");
      Console.WriteLine("4. Combinazione");
      Console.WriteLine("5. Totale");
      Console.ResetColor();

    Scrivi:
      string type = Console.ReadLine()!;
      if (type == "1")
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("QUOTA:");
        Console.WriteLine("se esce una volta 2x,");
        Console.WriteLine("se esce due volte 4x,");
        Console.WriteLine("se esce tre volte 6x,");
        Console.ResetColor();
        Console.WriteLine("inserisci il valore singolo che credi uscirà: ");

        {
          try
          {
            input = int.Parse(Console.ReadLine()!); // faccio inserire un nuovo valore a input all'utente, ripetendo il controllo che sia un numero valido
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido");
            Console.ResetColor();
            Console.WriteLine("");
            goto Scommessa;
          }
        }
        Results(dadi);
        List<int> uguali = new();
        foreach (int dado in dadi)
        {
          if (dado == input)
          {
            uguali.Add(dado);
          }
        }
        switch (uguali.Count)
        {
          case 0:
            {
              quota = 0;
              Console.WriteLine($"Non hai indovinato,");
              Console.WriteLine($"Hai perso {scommessa} euro");
              bottino -= scommessa;
              break;
            }
          case 1:
            {
              quota = 2;
              Console.WriteLine($"Hai indovinato il valore di un dado");
              Console.WriteLine($"QUOTA: {quota}x la tua scommessa {scommessa}");
              bottino += quota * scommessa;
              break;
            }
          case 2:
            {
              quota = 4;
              Console.WriteLine($"Hai indovinato il valore di due dadi");
              Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
              bottino += quota * scommessa;
              break;
            }
          case 3:
            {
              quota = 6;
              Console.WriteLine($"Hai indovinato il valore di tre dadi");
              Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
              bottino += quota * scommessa;
              break;
            }
          default:
            {
              Console.WriteLine($"qualcosa è andato storto");
              return;
            }
        }


      }
      else if (type == "2")
      {
        quota = 8;
        Console.WriteLine($"Hai selezionato Doppia");
        Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
        Console.WriteLine("inserisci il valore singolo che credi uscirà due volte");
        {
          try
          {
            input = int.Parse(Console.ReadLine()!); // faccio inserire un nuovo valore a input all'utente, ripetendo il controllo che sia un numero valido
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido");
            Console.ResetColor();
            Console.WriteLine("");
            goto Scommessa;
          }
        }
        Results(dadi);
        bool dos = (dadi[0] == dadi[1] && dadi[0] == input) || (dadi[2] == dadi[1] && dadi[2] == input) || (dadi[0] == dadi[2] && dadi[0] == input);
        if (dos)
        {
          Console.WriteLine($"Hai indovinato!! due dadi hanno lo stesso valore");
          bottino += quota * scommessa;
        }
        else
        {
          Console.WriteLine($"Non hai indovinato, Hai perso {scommessa} euro");
          bottino -= scommessa;
        }

      }
      else if (type == "3")
      {
        Console.WriteLine("Vuoi scommettere su una tripla generica o specifica? g / s");
        string gs = Console.ReadLine();
        if (gs == "g")
        {
          quota = 30;
          Console.WriteLine("Hai selezionato Tripla Generica, se i 3 dadi hanno lo stesso valore vinci");
          Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
          for (int i = 0; i < 3; i++)
          {
            Console.Write("---   "); // disegno questi trattini per separare
            Thread.Sleep(500);
          }
          Console.WriteLine($"i numeri usciti sono: ");
          for (int i = 0; i < 3; i++)
          {
            Console.Write($"{dadi[i]}      ");
            Thread.Sleep(500);
          }
          bool tris = (dadi[0] == dadi[1]) && (dadi[1] == dadi[2]);
          if (tris)
          {
            Console.WriteLine($"Hai indovinato!! i tre dadi hanno lo stesso valore");
            bottino += quota * scommessa;
          }
          else
          {
            Console.WriteLine($"Non hai indovinato, Hai perso {scommessa} euro");
            bottino -= scommessa;
          }
        }
        else if (gs == "s")
        {
          quota = 200;
          Console.WriteLine("Hai selezionato Tripla Specifica, se i 3 dadi hanno il valore da te inserito vinci");
          Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
          Console.WriteLine("inserisci il valore singolo che credi uscirà tre volte");
        }
        else
        {
          Console.WriteLine("input non valido");
          goto Scrivi;
        }

      }
      else if (type == "4")
      {
        quota = 5;
        Console.WriteLine("inserisci due valori singoli che credi usciranno insieme");
        Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
      }
      else if (type == "5")
      {
        Console.WriteLine("inserisci il valore totale che credi uscirà (ovvero la somma dei 3 dadi)");
      }
      else
      {
        Console.WriteLine("input non valido");
        goto Scrivi;
      }

      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine($"il tuo bottino è di {bottino} euro");
      Console.ResetColor();
      if (bottino == 0)
      {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"Vattene via pezzente!");
        Console.ResetColor();
      }
    }
  }
}
