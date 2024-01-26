class Program
{
  static void Main(string[] args)
  {
      string path = @"test.txt";
      string[] lines = File.ReadAllLines(path);
      lines[^2] = "Ciao cane";
      lines[^2] += " Bau";
      lines[^3] += " Bau";
      File.WriteAllLines(path, lines);
  }
}
