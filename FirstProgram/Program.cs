using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography;

class Program
{
  static void Main(string[] args)
  {
    string pathGiocatori = @"giocatori.csv";
    if (!File.Exists(pathGiocatori))
    {
      File.Create(pathGiocatori).Close();
    }
    int counter = 0;
    string[] linee = File.ReadAllLines(pathGiocatori);
    string[] righe = new string[linee.Length];
    for (int i = 0; i < linee.Length; i++)
    {
      if (!linee[i].EndsWith(","))
      {
        righe[counter] = linee[i];
        counter++;
      }
    }
    File.WriteAllLines(pathGiocatori, righe);


    Console.WriteLine("Ciao, per giocare a Super Sic Bo devi essere maggiorenne, hai almeno 18 anni? (s/n)");
    string siNo = Console.ReadLine()!; // legge il tipo di operazione scelta
    if (siNo == "s")
    {
      Console.WriteLine("Come ti chiami?");
      string nomeGiocatore = Console.ReadLine()!;
      if (File.ReadAllLines(pathGiocatori).Any(line => line.StartsWith(nomeGiocatore)))
      {
        for (int i = 0; i < righe.Length; i++)
        {
          string[] giocatoreNoto = righe[i].Split(',');
          if (giocatoreNoto[0] == nomeGiocatore)
          {
            Console.WriteLine($"Ah bentornato {giocatoreNoto[0]}, mi ricordo di te, tu hai {giocatoreNoto[1]} anni");
            int etaNota = int.Parse(giocatoreNoto[1]);
            if (etaNota > 17)
            {
              Console.WriteLine("Sei maggiorenne, puoi giocare a Super Sic Bo");
            }
            else
            {
              Console.WriteLine("Non sei maggiorenne brutto bugiardo! Tornatene a casa!!");
              
            }
          }
        }
      }
      else
      {
        File.AppendAllText(pathGiocatori, "\n" + nomeGiocatore + ",");
        Age:
        Console.WriteLine($"Quanti anni hai {nomeGiocatore}?");
        try 
        {
          string eta = Console.ReadLine()!;
          int age = int.Parse(eta);
          File.AppendAllText(pathGiocatori, eta);
           if (age >= 18)
           {
              Console.WriteLine($"Bene {nomeGiocatore}, se hai {eta} anni allora puoi giocare");
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
      }
    }
    else
    {
      Console.WriteLine($"allora non puoi giocare");
      return;
    }
  }
}
