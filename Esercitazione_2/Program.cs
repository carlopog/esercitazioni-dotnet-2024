using System.Net.Mail;

class Program
{
  static void Main(string[] args)
  {
        Console.WriteLine($"Premi N per terminare");
        while (true) 
        {
          ConsoleKeyInfo keyInfo = Console.ReadKey();
          if (keyInfo.Key == ConsoleKey.N)
          {
            break;
          }
        }
  }
}