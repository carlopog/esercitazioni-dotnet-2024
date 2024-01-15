using System.Net.Mail;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine($"Premi 'Ctrl' + 'N' per terminare");

    while (true)
    {
      ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
      {
        if (keyInfo.Key == ConsoleKey.N)
        {
          Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata, uscita in corso...");
          break;
        }
      }
    }
  }
}