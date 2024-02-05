using Newtonsoft.Json;

class Program {
  static void Main(string[] args)
  {
    string path = @"test.json";
    File.Create(path).Close();
    File.AppendAllText(path, "[\n");
    while (true)
    {
      Console.WriteLine($"inserisci nome e prezzo");
      string nome = Console.ReadLine()!;
      string prezzo = Console.ReadLine()!;
      File.AppendAllText(path, JsonConvert.SerializeObject(new {nome, prezzo }) + ",\n");
      Console.WriteLine($"vuoi inserire un altro prodotto? s/n");
      string risposta = Console.ReadLine()!;
      if (risposta == "n")
      {
        break;
      }
    }
    // togli l'ultima virgola
    string file = File.ReadAllText(path);
    file = file.Remove(file.Length -2, 1); // vai nell'ultima riga
    File.WriteAllText(path, file);
    File.AppendAllText(path, "]"); // scrive la riga nel file
  }
}