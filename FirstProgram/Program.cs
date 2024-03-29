﻿using Newtonsoft.Json;

class Program
{
  static void Aggiorna(string path, string nome, int prestito, int bottino)
  {
      string[] righe = File.ReadAllLines(path);
      string[][] players = new string[righe.Length][];
      for (int i = 0; i < righe.Length; i++)
      {
        players[i] = righe[i].Split(',');
      }
      for (int i = 0; i < players.Length; i++)
      {
        if (players[i][0] == nome) // se il nome e' gia' presente nel file
        {
          players[i][2] = prestito.ToString();
          players[i][3] = bottino.ToString();
        }
        string path3 = @"giocatori2.csv";
        if (!File.Exists(path3))
        {
          File.Create(path3).Close();
        }
        foreach (string[] player in players)
        {
          File.AppendAllText(path3, player[0] + "," + int.Parse(player[1]) + "," + int.Parse(player[2]) + "," + int.Parse(player[3]) + "\n");
        }
        string[] nuoviDati = File.ReadAllLines(path3);
        File.Delete(path);
        File.Create(path).Close();
        File.AppendAllLines(path, nuoviDati);
        File.Delete(path3);
      }
    }
    static bool Exit(string[] giocatore)
    {
      string nome = giocatore[0];
      string path = @"giocatori.csv";
      int prestito = int.Parse(giocatore[2]);
      int bottino = int.Parse(giocatore[3]);
      if (prestito > 0 && bottino >= prestito)
      {
        Console.WriteLine($"Ci riprendiamo i nostri {prestito} euro");
        Thread.Sleep(400);
        bottino -= prestito;
        Console.WriteLine($"il tuo credito e' di {bottino} euro");
        Aggiorna(path, nome, 0, bottino);
      }
      Console.WriteLine("Vuoi continuare a giocare o uscire? c/u");
      string scelta = Console.ReadLine()!;
      if (scelta == "u")
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    static void Results(int[] a)
    {
      Console.WriteLine("Sono usciti i numeri:");

      for (int i = 0; i < 3; i++)
      {
        Console.Write($"{a[i]} ");
        Thread.Sleep(300);
      }
    }

    static void CreateFile(string path)
    {
      if (!File.Exists(path))
      {
        File.Create(path).Close();
      }
    }

    static string[] CreatePlayer(string nomeGiocatore, int[] ePB)
    {
      string pathJson = "giocatoreAttuale.json";
      if (!File.Exists(pathJson))
      {
        File.Delete(pathJson);
      }
      File.Create(pathJson).Close();
      File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { nome = nomeGiocatore, eta = ePB[0].ToString(), prestito = ePB[1].ToString(), bottino = ePB[2].ToString() }));
      string json = File.ReadAllText(pathJson);
      dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file
      Thread.Sleep(1000);
      string nomeAttuale = obj.nome;
      string etaAttuale = obj.eta;
      string prestitoAttuale = obj.prestito;
      string bottinoAttuale = obj.bottino;
      string[] player = [nomeAttuale, etaAttuale, prestitoAttuale, bottinoAttuale];
      return player;
    }

    static void Main(string[] args)
    {
      string pathJson = "giocatoreAttuale.json";
      int prestitone = 0;
      string csv = "";
      string pathGiocatori = @"giocatori.csv";
      string pathGiocatoreAttuale = @"giocatoreAttuale.csv";
      CreateFile(pathGiocatori);
      CreateFile(pathGiocatoreAttuale);
      string[] player = new string[4];
      int counter = 0;
      string[] li = File.ReadAllLines(pathGiocatori);
      string[] righe = new string[li.Length];
      for (int i = 0; i < li.Length; i++)
      {
        if (!li[i].EndsWith(",")) // controlla che i dati dei giocatori siano completi altrimenti li cancella
        {
          righe[counter] = li[i];
          counter++;
        }
      }
      File.WriteAllLines(pathGiocatori, righe);
      Console.WriteLine("Ciao, per giocare a Super Sic Bo devi essere maggiorenne, hai almeno 18 anni? (s/n)");
      string siNo = Console.ReadLine()!; // legge il tipo di operazione scelta
      if (siNo == "s")
      {
        Console.WriteLine("Come ti chiami?");
        string nomeGiocatore = Console.ReadLine()!; // ti fa inserire il nome del giocatore attuale
        int[] ePB = new int[3];


        File.WriteAllText(pathGiocatoreAttuale, nomeGiocatore);

        if (File.ReadAllLines(pathGiocatori).Any(line => line.StartsWith(nomeGiocatore)))
        {
          for (int i = 0; i < righe.Length; i++)
          {
            string[] giocatoreNoto = righe[i].Split(',');
            if (giocatoreNoto[0] == nomeGiocatore)
            {
              Console.WriteLine($"Ah bentornato {giocatoreNoto[0]}, mi ricordo di te, tu hai {giocatoreNoto[1]} anni");
              ePB[0] = int.Parse(giocatoreNoto[1]);
              if (int.Parse(giocatoreNoto[2]) > 0)
              {
                Console.WriteLine($" e ci devi ancora {giocatoreNoto[2]} euro dall'ultima volta");
                if (int.Parse(giocatoreNoto[2]) < 100 + int.Parse(giocatoreNoto[3]))
                {
                  ePB[1] = 0;
                  Thread.Sleep(500);
              
                  Thread.Sleep(500);
                }
                else
                {
                  Console.WriteLine("Quindi vattene via prima che ti togliamo anche le scarpe!");
                  return;
                }
              }
              if (int.Parse(giocatoreNoto[3]) > 0)
              {
                Console.WriteLine($" e hai ancora {giocatoreNoto[3]} euro dall'ultima volta");
                ePB[2] = 100 - int.Parse(giocatoreNoto[2]) + int.Parse(giocatoreNoto[3]);
              }
              else if (int.Parse(giocatoreNoto[3]) <= 0)
              {
                ePB[2] = 100 + int.Parse(giocatoreNoto[3]);
                Console.WriteLine($"ci vuoi riprovare vedo, anche oggi hai {ePB[2]} euro a disposizione.");
              }
                  Aggiorna(pathGiocatori, giocatoreNoto[0], ePB[1], ePB[2]);

              int etaNota = int.Parse(giocatoreNoto[1]);
              if (etaNota > 17)
              {
                Console.WriteLine("Sei maggiorenne, puoi giocare a Super Sic Bo");
              }
              else
              {
                Console.WriteLine("Non sei maggiorenne brutto bugiardo! Tornatene a casa!!");
              }
              foreach (int e in ePB)
              {
                File.AppendAllText(pathGiocatoreAttuale, e.ToString() + ",");
              }

              player = CreatePlayer(nomeGiocatore, ePB);
            }
          }
        }
        else
        {
          File.AppendAllText(pathGiocatori, nomeGiocatore + ",");
        Age:
          Console.WriteLine($"Quanti anni hai {nomeGiocatore}?");
          try
          {
            string eta = Console.ReadLine()!;
            int age = int.Parse(eta);
            ePB[0] = age;
            ePB[1] = 0;
            ePB[2] = 100;
            player[2] = "0";
            player[3] = "100";
            File.AppendAllText(pathGiocatori, eta + "," + 0 + "," + 100);

            if (age >= 18)
            {
              Console.WriteLine($"Beh se hai {eta} anni allora puoi giocare");
            }
            else if (age < 13)
            {
              Console.WriteLine("Allora cosa dici di essere maggiorenne?? Vattene via bambinetto!");
              return;
            }
            else if (age == 17)
            {
              Console.WriteLine($"17 anni non sono abbastanza. Torna l'anno prossimo ragazzo.");
              return;
            }
            else
            {
              Console.WriteLine("Allora non sei maggiorenne! Tornatene a casa pischello!");
              return;
            }

          }
          catch (Exception)
          {
            Console.WriteLine($"Non è un'età valida, inserisci un numero.");
            goto Age;
          }

          player = CreatePlayer(nomeGiocatore, ePB);
        }
      }
      else
      {
        Console.WriteLine($"allora non puoi giocare");
        return;
      }

      Random random = new();
      int[] d = new int[3];
      int input;
      int input2;
      int quota = 1;
      int scommessa = 0;
      int lastScommessa = 0;
      int lastPrestito = 0;
      bool guess;
      int giro = 1;

      string pathScommesse = @"scommesse.txt";
      if (File.Exists(pathScommesse))
      {
        File.Delete(pathScommesse);
      }
        File.Create(pathScommesse).Close();
        File.AppendAllText(pathScommesse, "0" + "\n");

      string pathPrestito = @"prestito.txt";
      if (!File.Exists(pathPrestito))
      {
        File.Create(pathPrestito).Close();
        File.AppendAllText(pathPrestito, "0" + "\n");
      }

      Console.ForegroundColor = ConsoleColor.Magenta;
      
      int prestito = int.Parse(player[2]);
      int bottino = int.Parse(player[3]);
      Console.WriteLine($"Ciao {player[0]} il tuo budget di partenza è {bottino}");
      Console.ResetColor();

      int round = 0;
      while (bottino > 0)
      {
        Aggiorna(pathGiocatori, player[0], prestito, bottino);
        round++;
        guess = false;
        string[] lineee = File.ReadAllLines(pathScommesse);
        string[] scommesse = new string[lineee.Length];
        for (int i = 0; i < lineee.Length; i++)
        {
          scommesse[i] = lineee[i];
        }
        lastScommessa = int.Parse(scommesse[^1]);
        Console.WriteLine($"ultima scommessa {lastScommessa}");
        if (lastScommessa > bottino)
        {
          prestitone = lastScommessa - bottino + 50;
        }

        if (round > 2)
        {
          if (Exit(player))
          {
            return;
          }
        }

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
            if (scommessa <= lastScommessa)
            {
              throw new ArgumentOutOfRangeException();
            }
            else if (scommessa > bottino)
              if (giro < 2)
              {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vuoi un prestito di {prestito} euro? s / n");
                Console.ResetColor();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.S)
                {
                  prestito = prestitone;
                  if (!File.Exists(pathJson))
                  {
                    File.Delete(pathJson);
                  }
                  File.Create(pathJson).Close();
                  bottino += prestito;
                  Console.WriteLine($"\n Ora hai {bottino} euro");
                  File.AppendAllText(pathPrestito, prestito.ToString());
                  player[2] = prestito.ToString();
                  player[3] = bottino.ToString();
                  File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { nome = player[0], eta = player[1], prestito = player[2], bottino = player[3] }));
                  foreach (string dato in player)
                  {
                    csv += "," + dato;
                  }
                  File.WriteAllText(pathGiocatoreAttuale, csv);
                  Aggiorna(pathGiocatori, player[0], prestito, bottino);
                  giro++;
                  goto Scommessa;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                  Console.WriteLine("\nAllora scappa con i tuoi due spiccioli, vigliacco!");
                  Aggiorna(pathGiocatori, player[0], prestito, bottino);
                  return;
                }
                else
                {
                  Console.WriteLine($"input non valido");
                  goto Scommessa;
                }
              }
              else
              {
                string[] linee = File.ReadAllLines(pathPrestito);
                string[] prestiti = new string[linee.Length];
                for (int i = 0; i < linee.Length; i++)
                {
                  prestiti[i] = linee[i];
                }
                lastPrestito = int.Parse(prestiti[^1]);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vattene finchè hai ancora dei soldi in tasca,\ne vedi di riportarci i nostri {lastPrestito} euro al più presto!!");
                Aggiorna(pathGiocatori, player[0], prestito, bottino);
                Console.ResetColor();
                return;
              }
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido, devi scommettere sempre più della puntata precedente");
            Console.ResetColor();
            Console.WriteLine("");
            goto Scommessa;
          }
        }

        File.AppendAllText(pathScommesse, $"{scommessa}\n");


      Scrivi:
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tipi di scommessa:");
        Console.WriteLine("1. Valore Singolo");
        Console.WriteLine("2. Doppia");
        Console.WriteLine("3. Tripla");
        Console.WriteLine("4. Combinazione");
        Console.WriteLine("5. Totale");
        Console.ResetColor();
        string type = Console.ReadLine()!;
        if (type == "1")
        {
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.WriteLine("QUOTA:");
          Console.WriteLine("se esce una volta 1x,");
          Console.WriteLine("se esce due volte 2x,");
          Console.WriteLine("se esce tre volte 3x,");
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
              quota = 1;
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
          File.AppendAllText(pathGiocatori, "," + 0 + "\n");
          Console.BackgroundColor = ConsoleColor.Red;
          Console.WriteLine($"Vattene via pezzente!");
          Console.ResetColor();
          Aggiorna(pathGiocatori, player[0], prestito, bottino);
        }
      }
    }
  }

