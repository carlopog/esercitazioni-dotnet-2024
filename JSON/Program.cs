﻿using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
    string pathPiatti = @"piatti.json"; // menu con piatto e costo
    string piattiJson = File.ReadAllText(pathPiatti);
    dynamic menu = JsonConvert.DeserializeObject(piattiJson)!;

    int tavoloNumero = Tavolo();

    string[] piatti = new string[25]; // array del menu 
    string[] prezzi = new string[25]; // array dei costi
    string[] tipi = ["antipasti","primi","vini","secondi","vini","dolci"];


    foreach (string t in tipi)
    {
      Ordine(t, piatti, prezzi, menu, tavoloNumero);
    };

    Console.WriteLine("Buon appetito");
    Thread.Sleep(500);
    Cassa(tavoloNumero);
    Console.WriteLine("Grazie e Arrivederci!");
  }

  static int Tavolo()
  {
    int tavolo = 0;
    Console.WriteLine("Tavolo numero?");
  Res:
    string res = Console.ReadLine()!;
    try
    {
      tavolo = int.Parse(res);
    }
    catch (Exception)
    {
      Console.WriteLine("devi inserire un numero");
      goto Res;
    }
    return tavolo;
  }

  static void Cassa(int tavolo)
  {
    Console.WriteLine("Signori, stasera avete mangiato:");
    int total = 0;
    string pathCassa = @$"{tavolo}cassa.txt";
    string pathOrdine = @$"{tavolo}ordine.txt";
    string[] piattiTavolo = File.ReadAllLines(pathOrdine);
    foreach (string piatto in piattiTavolo)
    {
      Console.WriteLine(piatto);
      Thread.Sleep(300);
    }
    string[] contoTavolo = File.ReadAllLines(pathCassa);
    foreach (string conto in contoTavolo)
    {
      int price = int.Parse(conto);
      total += price;
    }
    Console.WriteLine($"Per un totale di {total} euro");
    File.Delete(pathCassa);
    File.Delete(pathOrdine);
  }

  static void Ordine(string tipi, string[] piatti, string[] costi, dynamic menu, int tavolo)
  {
  Inizio:
    Console.Write("Buonasera signori, ");
    Console.WriteLine($"cosa gradite come {tipi}?");
    string a;
    int c = 0;

    for (int i = 0; i < 25; i++)
    {
      piatti[i] = menu[i].piatto;
      costi[i] = menu[i].prezzo;
      a = menu[i].tipo;
      if (tipi == a)
      {
        c = i + 1;
        Console.WriteLine($"{c}. {piatti[i]} a {costi[i]} euro");
      }
    }

    string pathOrdine = tavolo + "ordine.txt";
    string pathCassa = tavolo + "cassa.txt";
    string piatto; // piatto singolo
    int costo; // costo del singolo

    Scelta:
    string scelta = Console.ReadLine()!;
    try
    {
      int numScelto = int.Parse(scelta) - 1;
      for (int i = 0; i < 25; i++)
      {
        piatto = piatti[i];
        costo = int.Parse(costi[i]);
        if (piatti[numScelto] == piatto)
        {
          if (!File.Exists(pathOrdine))
          {
            File.Create(pathOrdine).Close();
          }
          File.AppendAllText(pathOrdine, piatto + "\n");
          if (!File.Exists(pathOrdine))
          {
            File.Create(pathCassa).Close();
          }
          File.AppendAllText(pathCassa, costo + "\n");
        }
      }
      if (tipi != "vini")
      {
        Console.WriteLine($"Volete ordinare altri {tipi}? s/n");
        string siNo = Console.ReadLine()!;
        if (siNo == "s")
        {
          goto Inizio;
        }
    }
    Thread.Sleep(500);
    }
    catch (Exception)
    {
      Console.WriteLine("devi inserire un numero");
      goto Scelta;
    }

  }


}
