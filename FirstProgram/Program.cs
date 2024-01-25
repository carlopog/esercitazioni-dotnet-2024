class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);

    string[] nomi = new string[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
      nomi[i] = lines[i]; 
    }
    
    Array.ForEach(nomi, Console.WriteLine);
  }
}
