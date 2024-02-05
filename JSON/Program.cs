using Newtonsoft.Json;

class Program
{

  static void Main(string[] args)
  {
  string siNo;
  string piatto;
  string scelta;
  int costoPiatto;
  string pathPiatti = @"piatti.json";
  string piattiJson = File.ReadAllText(pathPiatti);
  dynamic p = JsonConvert.DeserializeObject(piattiJson)!;
  string[] piatti = new string[25];
  string[] costoPiatti = new string[25];
  string pathCassa = @"cassa.txt";
  string pathOrdine = @"ordine.txt";

  Antipasti:
  Console.Write("Buonasera signori, ");
  Console.WriteLine($"cosa gradite come antipasti?");

  for (int i = 0; i < 5; i++)
  {
    piatti[i] = p[i].piatto;
    costoPiatti[i] = p[i].prezzo;
    Console.WriteLine($"{piatti[i]} a {costoPiatti[i]} euro");
  }

  scelta = Console.ReadLine()!;
  for (int i = 0; i < 5; i++)
  {
    piatto = piatti[i];
    costoPiatto = int.Parse(costoPiatti[i]);
    if (scelta == piatto)
    {
      File.AppendAllText(pathOrdine, piatto + "\n");
      File.AppendAllText(pathCassa, costoPiatto + "\n");
    }
  }
  Console.WriteLine($"Volete ordinare altri antipasti? s/n");
  siNo = Console.ReadLine()!;
    if (siNo == "s")
    {
      goto Antipasti;
    }
  Primi:
  Console.Write("Buonasera signori, ");
  Console.WriteLine($"cosa gradite come primi?");

  for (int i = 5; i < 10; i++)
  {
    piatti[i] = p[i].piatto;
    costoPiatti[i] = p[i].prezzo;
    Console.WriteLine($"{piatti[i]} a {costoPiatti[i]} euro");
  }

  scelta = Console.ReadLine()!;
  for (int i = 5; i < 10; i++)
  {
    piatto = piatti[i];
    costoPiatto = int.Parse(costoPiatti[i]);
    if (scelta == piatto)
    {
      File.AppendAllText(pathOrdine, piatto + "\n");
      File.AppendAllText(pathCassa, costoPiatto + "\n");
    }
  }
  Console.WriteLine($"Volete ordinare altri primi? s/n");
  siNo = Console.ReadLine()!;
    if (siNo == "s")
    {
      goto Primi;
    }
  // Vini:
  //   Ordine(vini, 15, 20);
  //   if (siNo == "s")
  //   {
  //     goto Vini;
  //   }
  // Secondi:
  //   Ordine(secondi, 10, 15);
  //   if (siNo == "s")
  //   {
  //     goto Secondi;
  //   }
  // Dolci:
  //   Ordine(dolci, 20, 25);
  //   if (siNo == "s")
  //   {
  //     goto Dolci;
  //   }
    Console.WriteLine($"buon appetito");

  }


// static void Ordine(string primo, int da, int a)
// {
//   Console.Write("Buonasera signori, ");
//   Console.WriteLine($"cosa gradite come {primo}?");

//   for (int i = da; i < a; i++)
//   {
//     piatti[i] = p[i].piatto;
//     costoPiatti[i] = p[i].prezzo;
//     Console.WriteLine($"{piatti[i]} a {costoPiatti[i]} euro");
//   }

//   scelta = Console.ReadLine()!;
//   for (int i = da; i < a; i++)
//   {
//     piatto = piatti[i];
//     costoPiatto = int.Parse(costoPiatti[i]);
//     if (scelta == piatto)
//     {
//       File.AppendAllText(pathOrdine, piatto + "\n");
//       File.AppendAllText(pathCassa, costoPiatto + "\n");
//     }
//   }
//   Console.WriteLine($"Volete ordinare altri {primo}? s/n");
//   siNo = Console.ReadLine()!;
// }


  //  string[] conti = File.ReadAllLines(pathCassa);
  //  string[] piatti = File.ReadAllLines(pathOrdine);

}
