class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt";
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    int a = 0;
    for (int i = 0; i < lines.Length; i++)
    {
      if (lines[i].StartsWith("c"))
      {
        nomi[a] = lines[i];
        a++;
      }
    }
    if (a < 1)
    {
      Console.WriteLine("Non ci sono righe con la c");
    }
    Array.Resize(ref nomi, a);
    Array.ForEach(nomi, Console.WriteLine);
  }
}
