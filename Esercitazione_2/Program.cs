using System;

class Example
{
  public static void Main()
  {
    Console.Title = "La mia applicazione web";
    Console.CursorVisible = false; 

    Console.WriteLine("come stai?");
    string? input = Console.ReadLine();
    if (input == "bene")
    {
      Console.WriteLine("Bravo.");
      Console.Beep(750, 300);
    }
    else if (input == "male")
    {
      Console.WriteLine("cattivo");
      Console.Beep(800, 1000); 
    }
    else 
    {
      Console.WriteLine("ci sta");
      Console.Beep(38, 200); 
      Console.Beep(300, 600); 
      Console.Beep(500, 500); 
    }
    // Console.Clear();
  }
}