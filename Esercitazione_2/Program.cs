class Program
{
  static void Main(string[] args)
  {
        int a = 22;
        switch (a)
        {
          case 10:
            Console.WriteLine($"{a} e' uguale a 10");
            break;
          case 20:
            Console.WriteLine($"{a} e' uguale a 20");
            break;
          default:
            Console.WriteLine($"{a} non e' uguale a 10 o 20");
            break;
        }
      }
  }