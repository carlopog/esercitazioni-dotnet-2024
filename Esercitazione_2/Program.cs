class Program
{
  static void Main(string[] args)
  {
    int a = 10;
    int b = 1;
    if (a > b)
    {
      Console.WriteLine($"{a} e' maggiore di {b}");
    }
    else if (a < b)
    {
      Console.WriteLine($"{a} e' minore di {b}");
    }
    else
    {
      Console.WriteLine($"{a} e' uguale a {b}");
    }
  }
}