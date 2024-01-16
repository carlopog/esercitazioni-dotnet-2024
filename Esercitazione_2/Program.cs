class Program2
{
  static void Main(string[] args)
  {
    Dictionary<string, int> famiglia = new()
    {
      {"Carlo", 25},
      {"Elvis", 30},
      {"Simone", 40},
      {"Giovanna", 60},
      {"Maurizio", 65},
    };

    Console.WriteLine("nella mia famiglia ci sono:");

    foreach (string key in famiglia.Keys) 
    {
      Console.WriteLine($"{key}");
    }
      
      bool uscita = true;
      while (uscita)
      { 
 
      Console.WriteLine("Di chi vuoi sapere l'eta?");
      string? scelta = Console.ReadLine();
      switch (scelta)
        {
          case "Giovanna":
            Console.WriteLine("Non si chiede l'eta' di una signora");
            break;
          case "Carlo":
            Console.WriteLine($"io ho {famiglia[scelta]} anni");
            break;
          case "Elvis": case "Simone": case "Maurizio":
            Console.WriteLine($"{scelta} ha {famiglia[scelta]} anni");
            break;
          case "x": 
            Console.WriteLine($"{scelta} uscita in corso");
          return;
          default: 
            Console.WriteLine($"{scelta} scelta non valida");
          return;
        }
      }
  }
}


      // int i = 0;
      // while (i < parenti.Length - 1)
      // {
      //   Console.WriteLine($" {parenti[i]},");
      //   i++;
      // }
