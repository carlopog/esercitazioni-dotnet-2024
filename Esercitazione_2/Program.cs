using System.ComponentModel;
using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
      List<int> fizzibuzzi= [15];
      List<int> fizzi= [3];
      List<int> buzzi= [5];
      Random random = new();
      for (int a = 0; a < 15; a++)
      {
        int i = random.Next(1, 101); // genera un numero tra 1 e 100
        
          bool fizz = i % 3 == 0;
          bool buzz = i % 5 == 0;
  
          if (fizz && buzz)
          {
            fizzibuzzi.Add(i);
          }
          else if (fizz)
          {
            fizzi.Add(i);

          }
          else if (buzz)
          {
            buzzi.Add(i);
          }
          else
          {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{i} fuori lista");
            Console.ResetColor();
          }
      }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"FizziBuzzi ha {fizzibuzzi.Count} elementi");
        fizzibuzzi.ForEach(fb => Console.Write($"{fb}  "));
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nFizzi  ha {fizzi.Count} elementi");
        fizzi.ForEach(f => Console.Write($"{f}  "));
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nBuzzi  ha {buzzi.Count} elementi");
        buzzi.ForEach(b => Console.Write($"{b}  "));
        Console.ResetColor();
  }
}