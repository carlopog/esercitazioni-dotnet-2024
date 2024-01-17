using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    // stampa i numeri tra 1 e 100
    for (int i = 1; i < 101; i++ )
    {
      {
        bool fizz = i % 3 == 0;
        bool buzz = i % 5 == 0;
        Console.Write($"{i} ");
    
         if (fizz)
        {
          Console.Write("fizz");
        }
         if (buzz)
        {
          Console.WriteLine("buzz");
        }
        else
        {
          Console.WriteLine("");
        }
      }
    }
  }
}