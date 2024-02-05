using Newtonsoft.Json;

class Program {
  static void Main(string[] args)
  {
    string pathMenu = @"menu.json";
    string json = File.ReadAllText(pathMenu);
    dynamic menu = JsonConvert.DeserializeObject(json)!; // deserializza il file
    Console.WriteLine($"Buonasera signori, cosa gradite come antipasto? {menu.antipasti}");
     
    // string path = @"test.json";
    // File.Create(path).Close();
    // File.AppendAllText(path, "[\n");
    // while (true)
    // {
    //   Console.WriteLine($"inserisci nome e prezzo");
    //   string nome = Console.ReadLine()!;
    //   string prezzo = piatti[nome];
    //   File.AppendAllText(path, JsonConvert.SerializeObject(new {nome, prezzo }) + ",\n");
    //   Console.WriteLine($"Desidera altro? s/n");
    //   string risposta = Console.ReadLine()!;
    //   if (risposta == "n")
    //   {
    //     break;
    //   }
    // }
    // // togli l'ultima virgola
    // string file = File.ReadAllText(path);
    // file = file.Remove(file.Length -2, 1); // vai nell'ultima riga
    // File.WriteAllText(path, file);
    // File.AppendAllText(path, "]"); // scrive la riga nel file
  }
}