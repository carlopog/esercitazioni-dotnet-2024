using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
  string pathPiatti = @"piatti.json"; // menu con piatto e costo
  string piattiJson = File.ReadAllText(pathPiatti);
  dynamic menu = JsonConvert.DeserializeObject(piattiJson)!;

  string[] piatti = new string[25]; // array del menu 
  string[] prezzi = new string[25]; // array dei costi

  Ordine("antipasti", piatti, prezzi, menu, 1);
  Ordine("primi", piatti, prezzi, menu, 2);
  Ordine("vini", piatti, prezzi, menu, 2);
  Ordine("secondi", piatti, prezzi, menu, 2);
  Ordine("vini", piatti, prezzi, menu, 2);
  Ordine("dolci", piatti, prezzi, menu, 2);

  Console.WriteLine($"buon appetito");

  //  string[] conti = File.ReadAllLines(pathCassa);do
  //  string[] piatti = File.ReadAllLines(pathOrdine);

// cassa: cosa hai comprato e quanto hai speso?

  }


static void Ordine(string tipi, string[] piatti, string[] costi, dynamic menu, int tavolo)
{
  Inizio:
  Console.Write("Buonasera signori, ");
  Console.WriteLine($"cosa gradite come {tipi}?");

  string a; 

  for (int i = 0; i < 25; i++)
  {
    piatti[i] = menu[i].piatto;
    costi[i] = menu[i].prezzo;
    a = menu[i].tipo;
    if (tipi == a)
    {
      Console.WriteLine($"{piatti[i]} a {costi[i]} euro");
    }
  }

  string pathOrdine = tavolo + "ordine.txt";
  string pathCassa = tavolo + "cassa.txt";
  string piatto; // piatto singolo
  int costo; // costo del singolo

  string scelta = Console.ReadLine()!;
  for (int i = 0; i < 25; i++)
  {
    piatto = piatti[i];
    costo = int.Parse(costi[i]);
    if (scelta == piatto)
    {
      File.AppendAllText(pathOrdine, piatto + "\n");
      File.AppendAllText(pathCassa, costo + "\n");
    }
  }
  Console.WriteLine($"Volete ordinare altri {tipi}? s/n");
  string siNo = Console.ReadLine()!;
    if (siNo == "s")
    {
      goto Inizio;
    }
}


}
