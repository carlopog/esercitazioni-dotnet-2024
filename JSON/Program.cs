using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
    var db = new Database(); // Model

    var piattoView = new PiattoView(db); // View
    var piattoController = new PiattoController (db, piattoView); // Controller
    piattoController.ShowMainMenu(); // Menu principale dell'app

    var ordinazioneView = new OrdinazioneView(db); // View
    var ordinazioneController = new OrdinazioneController (db, ordinazioneView); // Controller
    ordinazioneController.ShowMainMenu(); // Menu principale dell'app
    
    var tavoloView = new TavoloView(db); // View
    var tavoloController = new TavoloController (db, tavoloView, ordinazioneView); // Controller
    tavoloController.ShowMainMenu(); // Menu principale dell'app
  }
}

  //   int numeroTavoli = 1;

  // T:
  //   Console.WriteLine("Quanti tavoli ha il tuo ristorante?");
  //   try
  //   {
  //     numeroTavoli = int.Parse(Console.ReadLine()!);
  //   }
  //   catch (Exception)
  //   {
  //     Console.WriteLine("inserisci un numero valido");
  //     goto T;
  //   }

  //   string[] tipi = ["antipasti", "primi", "secondi", "vini", "dolci"];
  //   string pathJson = "menu.json";
  //   File.Create(pathJson).Close(); // creo il menu
  //   File.AppendAllText(pathJson, "[\n");
  //   CreateFiles(tipi, pathJson); // ci scrivo dentro i vari piatti e i loro prezzi
  //   string file = File.ReadAllText(pathJson);
  //   file = file.Remove(file.Length - 2, 1); // vai nell'ultima riga e cancella la virgola
  //   File.WriteAllText(pathJson, file);
  //   File.AppendAllText(pathJson, "]");

  //   string piattiJson = File.ReadAllText(pathJson);

  //   dynamic menu = JsonConvert.DeserializeObject(piattiJson)!; // ti da una lista 
  //   int count = menu.Count; // fai .Count perche' e' una lista, fosse un array sarebbe .Length

  //   string[] piatti = new string[count]; // array del menu 
  //   string[] prezzi = new string[count]; // array dei costi

  // SelezionaTavolo:
  //   int tavoloNumero = Tavolo(numeroTavoli);

  //   int turno = 1;
  //   string pathTurno = "tavolo" + tavoloNumero + "-turno.txt";
  //   File.Create(pathTurno).Close();
  //   File.WriteAllText(pathTurno, turno.ToString());

  // Turno:
  //   if (File.Exists("contoTavolo" + tavoloNumero + "-" + "turno" + turno + ".txt"))
  //   {
  //     int turnoPrecedente = int.Parse(File.ReadAllText(pathTurno));
  //     turno = turnoPrecedente + 1;
  //     File.WriteAllText(pathTurno, turno.ToString());
  //     goto Turno;
  //   }

  //   bool desideraAltro = true;
  //   int tipoScelto = 1;
  //   string testo = "antipasti";

  //   while (desideraAltro)

  //   {
  //   Tipo:
  //     Console.WriteLine("Cosa volete ordinare?");
  //     Console.WriteLine("1. Antipasti");
  //     Console.WriteLine("2. Primi");
  //     Console.WriteLine("3. Secondi");
  //     Console.WriteLine("4. Vini");
  //     Console.WriteLine("5. Dolci");
  //     Console.WriteLine("6. Non sappiamo ancora");

  //     try
  //     {
  //       tipoScelto = int.Parse(Console.ReadLine()!);
  //       if (tipoScelto > 6 || tipoScelto < 1)
  //       {
  //         throw new ArgumentOutOfRangeException();
  //       }
  //     }
  //     catch (Exception)
  //     {
  //       Console.WriteLine("inserisci un numero valido");
  //       goto Tipo;
  //     }

  //     switch (tipoScelto)
  //     {
  //       case 1:
  //         {
  //           testo = "antipasti";
  //           break;
  //         }
  //       case 2:
  //         {
  //           testo = "primi";
  //           break;
  //         }
  //       case 3:
  //         {
  //           testo = "secondi";
  //           break;
  //         }
  //       case 4:
  //         {
  //           testo = "vini";
  //           break;
  //         }
  //       case 5:
  //         {
  //           testo = "dolci";
  //           break;
  //         }
  //       case 6:
  //         {
  //           Console.WriteLine("ok allora vado a un altro tavolo");
  //           goto SelezionaTavolo;
  //         }
  //     }

  //     Ordine(testo, piatti, prezzi, menu, tavoloNumero);

  //     Console.WriteLine("Desiderate altro? (se rispondete no vi porto il conto) s/n");
  //     string da = Console.ReadLine()!;
  //     if (da == "n")
  //     {
  //       desideraAltro = false;
  //     }
  //   }


  //   Console.WriteLine("Buon appetito");
  //   Thread.Sleep(500);
  //   Cassa(tavoloNumero, turno);
  //   Console.WriteLine("Grazie e Arrivederci!");

  //   Console.WriteLine("ci sono ancora ancora altri clienti che devono ordinare? s/n");
  //   string clientiSiNo = Console.ReadLine()!;
  //   if (clientiSiNo == "s")
  //   {
  //     Console.Write("Prendi l'ordinazione del ");
  //     goto SelezionaTavolo;
  //   }
  //   else
  //   {
  //     Console.WriteLine("Allora il tuo turno è finito. Ciao!");
  //   }
  // }

  // static void CreateFiles(string[] tipi, string pathJson)
  // {
  //   int numero = 0;
  //   foreach (string tipo in tipi)
  //   {
  //     string path = @$"{tipo}.csv";
  //     string[] lines = File.ReadAllLines(path);
  //     string[] piatti = new string[lines.Length];
  //     for (int i = 0; i < lines.Length; i++)
  //     {
  //       piatti[i] = lines[i];
  //     };
  //     foreach (string piattoPrezzo in piatti)
  //     {
  //       numero++;
  //       int lettere = piattoPrezzo.Length - 3;
  //       string piatto = piattoPrezzo.Substring(0, lettere);
  //       string prezzo = piattoPrezzo.Substring(lettere + 1);
  //       File.AppendAllText(pathJson, JsonConvert.SerializeObject(new { numero, tipo, piatto, prezzo }) + ",\n");
  //     }
  //   }
  // }

  // static int Tavolo(int numeroTavoli)
  // {
  //   int tavolo = 0;
  //   Console.WriteLine("Tavolo numero?");
  // Res:
  //   string res = Console.ReadLine()!;
  //   try
  //   {
  //     tavolo = int.Parse(res);
  //     if (tavolo > numeroTavoli || tavolo < 1)
  //     {
  //       throw new ArgumentOutOfRangeException();
  //     }
  //   }
  //   catch (Exception)
  //   {
  //     Console.WriteLine("Devi inserire un numero valido");
  //     goto Res;
  //   }
  //   return tavolo;
  // }

  // static void Cassa(int tavolo, int turno)
  // {
  //   Console.WriteLine("Signori, stasera avete mangiato:");
  //   int total = 0;
  //   string pathCassa = @$"{tavolo}cassa.txt";
  //   string pathOrdine = @$"{tavolo}ordine.txt";
  //   string pathConto = @$"contoTavolo{tavolo}-turno{turno}.txt";
  //   if (File.Exists(pathConto))
  //   {
  //     turno++;
  //     pathConto = @$"contoTavolo{tavolo}-turno{turno}.txt";
  //   }
  //   File.Create(pathConto).Close();
  //   string[] piattiTavolo = File.ReadAllLines(pathOrdine);
  //   string[] contoTavolo = File.ReadAllLines(pathCassa);

  //   for (int i = 0; i < piattiTavolo.Length; i++)
  //   {
  //     File.AppendAllText(pathConto, $"{piattiTavolo[i]} {contoTavolo[i]} € \n");
  //     Console.WriteLine($"{piattiTavolo[i]} {contoTavolo[i]} €");
  //     Thread.Sleep(500);
  //   }
  //   foreach (string conto in contoTavolo)
  //   {
  //     int price = int.Parse(conto);
  //     total += price;
  //   }
  //   Console.WriteLine($"Per un totale di {total} euro");

  //   Console.WriteLine("il cliente ha pagato? (cancello i file ordine e cassa?) s/n");
  //   string siNo = Console.ReadLine()!;
  //   if (siNo == "s")
  //   {
  //     File.AppendAllText(pathConto, "PAGATO");
  //   }
  //   else
  //   {
  //     File.AppendAllText(pathConto, "DEVE ANCORA PAGARE");
  //     Console.WriteLine("Non si preoccupi, se non ha contanti oggi può pagare la prossima volta");
  //   }
  //   File.Delete(pathCassa);
  //   File.Delete(pathOrdine);
  // }



  // static void Ordine(string tipi, string[] piatti, string[] costi, dynamic menu, int tavolo)
  // {
  // Inizio:
  //   Console.Write("Buonasera signori, ");
  //   Console.WriteLine($"cosa gradite come {tipi}?");
  //   string a;
  //   int c = 0;
  //   int qTipo = 1;

  //   for (int i = 0; i < menu.Count; i++)
  //   {
  //     piatti[i] = menu[i].piatto;
  //     costi[i] = menu[i].prezzo;
  //     a = menu[i].tipo;
  //     if (tipi == a)
  //     {
  //       c = i + 1;
  //       qTipo++;
  //       Console.WriteLine($"{c}. {piatti[i]} a {costi[i]} euro");
  //       Thread.Sleep(500);
  //     }
  //   }

  //   string pathOrdine = tavolo + "ordine.txt";
  //   string pathCassa = tavolo + "cassa.txt";
  //   string piatto; // piatto singolo
  //   int costo; // costo del singolo

  // Scelta:
  //   Console.WriteLine("inserisca il numero del piatto desiderato");

  //   string scelta = Console.ReadLine()!;
  //   try
  //   {
  //     int numScelto = int.Parse(scelta) - 1;
  //     for (int i = 0; i < menu.Count; i++)
  //     {
  //       piatto = piatti[i];
  //       costo = int.Parse(costi[i]);
  //       int top = c - qTipo;

  //       if (numScelto >= c || numScelto <= top)
  //       {
  //         throw new ArgumentOutOfRangeException();
  //       }
  //       if (piatti[numScelto] == piatto)
  //       {
  //         if (!File.Exists(pathOrdine))
  //         {
  //           File.Create(pathOrdine).Close();
  //         }
  //         File.AppendAllText(pathOrdine, piatto + "\n");
  //         if (!File.Exists(pathOrdine))
  //         {
  //           File.Create(pathCassa).Close();
  //         }
  //         File.AppendAllText(pathCassa, costo + "\n");
  //       }
  //     }
  //     if (tipi != "vini")
  //     {
  //       Console.WriteLine($"Volete ordinare altri {tipi}? s/n");
  //       string siNo = Console.ReadLine()!;
  //       if (siNo == "s")
  //       {
  //         goto Inizio;
  //       }
  //     }
  //     Thread.Sleep(500);
  //   }
  //   catch (Exception)
  //   {
  //     Console.WriteLine("Devi inserire un numero valido");
  //     goto Scelta;
  //   }
  // }



