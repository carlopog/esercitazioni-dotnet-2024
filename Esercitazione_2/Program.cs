using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    // stampa i numeri tra 1 e 100
    // for (int i = 1; i < 101; i++ )
    // estrai a sorte 5 numeri
    Random random = new();
    for (int a = 0; a < 5; a++)
    {
      int i = random.Next(1, 101); // genera un numero tra 1 e 100

      {
        bool fizz = i % 3 == 0;
        bool buzz = i % 5 == 0;

        if (fizz & buzz)
        {
          Console.WriteLine($"{i} fizzbuzz");
        }
        else if (fizz)
        {
          Console.WriteLine($"{i} fizz");
        }
        else if (buzz)
        {
          Console.WriteLine($"{i} buzz");
        }
        else
        {
          Console.WriteLine($"{i}");
        }
      }
    }

    // estrai a sorte 
    // se e' divisibile per 3 e' fizz 
    // se e' divisibile per 5 e' buzz 
    // se e' divisibile per 3 e 5 e' fizz buzz 
  }
}