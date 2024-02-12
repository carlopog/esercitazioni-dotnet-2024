using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
    int numeroTavoli = 1;
    Console.WriteLine("Quanti tavoli ha il tuo ristorante?");
    try 
    {
      numeroTavoli = int.Parse(Console.ReadLine()!);
    }
    catch (Exception)
    {
      Console.WriteLine("inserisci un numero valido");
    }    

    string[] tipi = ["antipasti", "vini", "primi", "secondi", "dolci"];
    string pathJson = "menu.json";
    File.Create(pathJson).Close(); // creo il menu
    File.AppendAllText(pathJson, "[\n");
    CreateFiles(tipi, pathJson); // ci scrivo dentro i vari piatti e i loro prezzi
    string file = File.ReadAllText(pathJson);
    file = file.Remove(file.Length - 2, 1); // vai nell'ultima riga e cancella la virgola
    File.WriteAllText(pathJson, file);
    File.AppendAllText(pathJson, "]");

    string piattiJson = File.ReadAllText(pathJson);

    dynamic menu = JsonConvert.DeserializeObject(piattiJson)!; // ti da una lista 
    int count = menu.Count; // fai .Count perche' e' una lista, fosse un array sarebbe .Length

    string[] piatti = new string[count]; // array del menu 
    string[] prezzi = new string[count]; // array dei costi

    int tavoloNumero = Tavolo(numeroTavoli);

    bool desideraAltro = true;
    int tipoScelto = 1;
    string testo = "antipasti";

    while (desideraAltro)

    {

      Console.WriteLine("Cosa volete ordinare?");
      Console.WriteLine("1. Antipasti");
      Console.WriteLine("2. Vini");
      Console.WriteLine("3. Primi");
      Console.WriteLine("4. Secondi");
      Console.WriteLine("5. Dolci");

      try
      {
        tipoScelto = int.Parse(Console.ReadLine()!);
           if (tipoScelto > 5 || tipoScelto < 1)
        {
          throw new ArgumentOutOfRangeException();
        }
      }
      catch (Exception)
      {
        Console.WriteLine("inserisci un numero valido");
      }

      switch (tipoScelto)
      {
        case 1:
        {
          testo = "antipasti";
          break;
        }
        case 2:
        {
          testo = "vini";
          break;
        }
        case 3:
        {
          testo = "primi";
          break;
        }
        case 4:
        {
          testo = "secondi";
          break;
        }
        case 5:
        {
          testo = "dolci";
          break;
        }
      }

      Ordine(testo, piatti, prezzi, menu, tavoloNumero);

      Console.WriteLine("Desiderate altro? s/n");
      string da = Console.ReadLine()!;
      if (da == "n")
      {
        desideraAltro = false;
      }
    }
      

    Console.WriteLine("Buon appetito");
    Thread.Sleep(500);
    Cassa(tavoloNumero);
    Console.WriteLine("Grazie e Arrivederci!");
  }

  static void CreateFiles(string[] tipi, string pathJson)
  {
    int numero = 0;
    foreach (string tipo in tipi)
    {
      string path = @$"{tipo}.csv";
      string[] lines = File.ReadAllLines(path);
      string[] piatti = new string[lines.Length];
      for (int i = 0; i < lines.Length; i++)
      {
        piatti[i] = lines[i];
      };
      foreach (string piattoPrezzo in piatti)
      {
        numero++;
        int lettere = piattoPrezzo.Length - 3;
        string piatto = piattoPrezzo.Substring(0, lettere);
        string prezzo = piattoPrezzo.Substring(lettere + 1);
        File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { numero, tipo, piatto, prezzo }) + ",\n");
      }
    }
  }

  static int Tavolo(int numeroTavoli)
  {
    int tavolo = 0;
    Console.WriteLine("Tavolo numero?");
  Res:
    string res = Console.ReadLine()!;
    try
    {
      tavolo = int.Parse(res);
      if (tavolo > numeroTavoli || tavolo < 1)
      {
        throw new ArgumentOutOfRangeException();
      }
    }
    catch (Exception)
    {
      Console.WriteLine("Devi inserire un numero valido");
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
    string[] contoTavolo = File.ReadAllLines(pathCassa);

    for (int i = 0; i < piattiTavolo.Length; i++)
    {
      Console.WriteLine($"{piattiTavolo[i]} {contoTavolo[i]} €");
      Thread.Sleep(500);
    }
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
    int qTipo = 1;

    for (int i = 0; i < menu.Count; i++)
    {
      piatti[i] = menu[i].piatto;
      costi[i] = menu[i].prezzo;
      a = menu[i].tipo;
      if (tipi == a)
      {
        c = i + 1;
        qTipo++;
        Console.WriteLine($"{c}. {piatti[i]} a {costi[i]} euro");
        Thread.Sleep(500);
      }
    }

    string pathOrdine = tavolo + "ordine.txt";
    string pathCassa = tavolo + "cassa.txt";
    string piatto; // piatto singolo
    int costo; // costo del singolo

  Scelta:
    Console.WriteLine("inserisca il numero del piatto desiderato");
    
    string scelta = Console.ReadLine()!;
    try
    {
      int numScelto = int.Parse(scelta) - 1;
      for (int i = 0; i < menu.Count; i++)
      {
        piatto = piatti[i];
        costo = int.Parse(costi[i]);
        int top = c-qTipo;
        
        if (numScelto >= c || numScelto <= top)
        {
          throw new ArgumentOutOfRangeException();
        }
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
      Console.WriteLine("Devi inserire un numero valido");
      goto Scelta;
    }
  }


}
