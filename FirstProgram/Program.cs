
using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.json";
    string json = File.ReadAllText(path);
    dynamic obj = JsonConvert.DeserializeObject(json)!; // deserializza il file
    Console.WriteLine($"nome: {obj.nome} \ncognome: {obj.cognome} \neta: {obj.eta}");
  }
}
