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
    int input;
    int input2;
    int quota = 1;
    int scommessa = 0;
    int bottino = 100;
    bool guess = false;

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Ciao Bello il tuo budget di partenza è {bottino}");
    Console.ResetColor();

    while (bottino > 0)
    {
      int somma = 0;
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
      Totale:
        Console.WriteLine("Vuoi scommettere su un totale specifico o un gruppo? s / g");
        string sg = Console.ReadLine()!;
        if (sg == "s")
        {
        TotaleS:
          Console.WriteLine("inserisci il valore totale che credi uscirà (ovvero la somma dei 3 dadi)");
          {
            try
            {
              input = int.Parse(Console.ReadLine()!);
              if (input < 3 || input > 18)
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
              goto TotaleS;
            }
          }
          switch (input)
          {
            case 4:
            case 17:
              {
                quota = 50;
                break;
              }
            case 5:
            case 16:
              {
                quota = 25;
                break;
              }
            case 6:
            case 15:
              {
                quota = 20;
                break;
              }
            case 7:
            case 14:
              {
                quota = 10;
                break;
              }
            case 8:
            case 13:
              {
                quota = 8;
                break;
              }
            default:
              {
                quota = 6;
                break;
              }
          }
          Results(d);
          Console.WriteLine($"\nLa loro somma fa {somma}");
          if (input == somma)
          {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Quindi hai indovinato, è uscita la combinazione indicata da te!");
            Console.ResetColor();
            bottino += quota * scommessa;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Quindi non hai indovinato, Hai perso {scommessa} euro");
            bottino -= scommessa;
            Console.ResetColor();
          }
        }
        else if (sg == "g")
        {
        TotaleG:
          Console.WriteLine("In quale gruppo pensi che rientrerà la somma totale?");
          Console.WriteLine("1. Big: la somma totale dei dadi è compresa tra 11 e 17");
          Console.WriteLine("2. Small: la somma totale dei dadi è compresa tra 4 e 10");
          Console.WriteLine("3. Pari: la somma totale dei dadi è un numero pari");
          Console.WriteLine("4. Dispari: la somma totale dei dadi è un numero dispari");
          Console.WriteLine("5. Estremi: la somma totale dei dadi è 3 o 18");
          {
            try
            {
              input = int.Parse(Console.ReadLine()!);
              if (input < 1 || input > 5)
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
              goto TotaleG;
            }
          }
          switch (input)
          {
            case 1:
              {
                if (somma > 10 && somma < 18)
                {
                  guess = true;
                }
                break;
              }
            case 2:
              {
                if (somma > 3 && somma < 11)
                {
                  guess = true;
                }
                break;
              }
            case 3:
              {
                if (somma % 2 == 0)
                {
                  guess = true;
                }
                break;
              }
            case 4:
              {
                if (somma % 2 == 0)
                {
                  guess = false;
                }
                else
                {
                  guess = true;
                }
                break;
              }
            case 5:
              {
                if (somma == 3 || somma == 18)
                {
                  guess = true;
                }
                break;
              }
          }
          Results(d);
          Console.WriteLine($"\nIl totale è {somma}");
          if (guess)
          {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Quindi hai indovinato, è nel gruppo indicato da te!");
            Console.ResetColor();
            bottino += quota * scommessa;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Quindi non hai indovinato, Hai perso {scommessa} euro");
            bottino -= scommessa;
            Console.ResetColor();
          }
        }
        else
          {
            Console.WriteLine("input non valido");
            goto Totale;
          }
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
