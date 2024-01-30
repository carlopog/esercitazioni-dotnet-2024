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
    int[] d = new int[3];
    int somma = 0;
    int input;
    int input2;
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
        d[i] = n;
        somma += n;
      }

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
      ValoreSingolo:
        Console.WriteLine("inserisci il valore singolo che credi uscirà: ");
        {
          try
          {
            input = int.Parse(Console.ReadLine()!); 
          
            if (input < 1 || input > 6)
            {
              throw new ArgumentOutOfRangeException();
            }
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido: dev'essere un intero tra 1 e 6  ");
            Console.ResetColor();
            Console.WriteLine("");
            goto ValoreSingolo;
          }
        }
        Results(d);
        List<int> uguali = new();
        foreach (int dado in d)
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
              quota = 1;
              Console.WriteLine($"Hai indovinato il valore di un dado");
              Console.WriteLine($"QUOTA: {quota}x la tua scommessa {scommessa}");
              bottino += quota * scommessa;
              break;
            }
          case 2:
            {
              quota = 2;
              Console.WriteLine($"Hai indovinato il valore di due dadi");
              Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
              bottino += quota * scommessa;
              break;
            }
          case 3:
            {
              quota = 3;
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
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Hai selezionato Doppia");
        Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
        Console.ResetColor();
        Doppia:
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
            goto Doppia;
          }
        }
        Results(d);
        bool dos = (d[0] == d[1] && d[0] == input) || (d[2] == d[1] && d[2] == input) || (d[0] == d[2] && d[0] == input);
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
        Triple:
        Console.WriteLine("Vuoi scommettere su una tripla generica o specifica? g / s");
        string gs = Console.ReadLine()!;
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
            Console.Write($"{d[i]}      ");
            Thread.Sleep(500);
          }
          bool tris = (d[0] == d[1]) && (d[1] == d[2]);

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
          Console.WriteLine("Hai selezionato Tripla Specifica, se i 3 dadi hanno il valore inserito da te, vinci");
          Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
          Console.WriteLine("inserisci il valore singolo che credi uscirà tre volte");
          try
          {
            input = int.Parse(Console.ReadLine()!);
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido");
            Console.ResetColor();
            Console.WriteLine("");
            goto Scommessa;
          }
          bool tripla = (d[0] == d[1]) && (d[1] == d[2]) && (d[1] == input);

          Results(d);
          if (tripla)
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
        else
        {
          Console.WriteLine("input non valido");
          goto Triple;
        }

      }
      else if (type == "4")
      {
        quota = 5;
        Console.WriteLine($"Hai selezionato Combinazione, per vincere devi azzeccare 2 dei 3 numeri usciti");
        Console.WriteLine($"QUOTA: {quota}x la tua scommessa");
           ValoreUno:
             Console.WriteLine("inserisci il primo dei due valori singoli che credi usciranno");
        {
          try
          {
            input = int.Parse(Console.ReadLine()!); 
          
            if (input < 1 || input > 6)
            {
              throw new ArgumentOutOfRangeException();
            }
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido: dev'essere un intero tra 1 e 6  ");
            Console.ResetColor();
            Console.WriteLine("");
            goto ValoreUno;
          }
        }
         ValoreDue:
        Console.WriteLine($"inserisci anche il secondo valore");
        {
          try
          {
            input2 = int.Parse(Console.ReadLine()!); 
          
            if (input2 < 1 || input2 > 6)
            {
              throw new ArgumentOutOfRangeException();
            }
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido: dev'essere un intero tra 1 e 6  ");
            Console.ResetColor();
            Console.WriteLine("");
            goto ValoreDue;
          }
        }


        bool uguale = false;
        bool combo = false;
        Results(d);
        foreach (int dado in d)
        {
            if (dado == input)
            {
                uguale = true;
            }
        }
        if (uguale)
        {
            foreach (int dado in d)
            {
                if (dado == input2)
                {
                    combo = true;
                }
            }
            if (combo)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Hai indovinato, è uscita la combinazione indicata da te!");
                Console.ResetColor();
                bottino += quota * scommessa;
            }
            else
            {
                Console.WriteLine($"Non hai indovinato, Hai perso {scommessa} euro");
                bottino -= scommessa;
            }
        }
        else
        {
            Console.WriteLine($"Non hai indovinato, Hai perso {scommessa} euro");
            bottino -= scommessa;
        }
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
