
using Newtonsoft.Json;

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.json";
    string json = File.ReadAllText(path);
    Console.WriteLine(json);
  }
}
