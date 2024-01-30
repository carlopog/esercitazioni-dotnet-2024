class Program
{
  static void Main(string[] args)
  {
    string path = @"test.csv";
    string[] lines = File.ReadAllLines(path);
    string[][] nomi = new string[lines.Length][]; // array di array sarebbe una matrice righe e colonne
    for (int i = 0; i < lines.Length; i++)
    {
      nomi[i] = lines[i].Split(',');
    }
    foreach (string[] nome in nomi)
    {
      foreach (string n in nome)
      {
        Console.Write(n + " "); // stampa la riga
      }
      Console.WriteLine();
    }
  }
}
