class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
      Random random = new();
      int to = lines.Length;
			int x = random.Next(0, to);
      nomi[i] = lines[x]; 
    }
    Array.ForEach(nomi, Console.WriteLine);
  }
}
