using Newtonsoft.Json;

class Program {
    
    static void CreateFiles(string[] nomi)
    {
    
    foreach (string nome in nomi)
    {
      string path = @$"{nome}test.json";
      File.ReadAllLines(path);    
      
    }
    }
    

  static void Main(string[] args)
  {
    string[] nomi = ["antipasti", "b", "c"];
    CreateFiles(nomi);

  }
}