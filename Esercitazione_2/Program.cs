using System.Net.Mail;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine($"Premi 'Ctrl' + 'C' per terminare");
    Console.TreatControlCAsInput = true;

    while (true)
    {
      ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
      {
        if (keyInfo.Key == ConsoleKey.C)
        {
          Console.WriteLine("Combinazione 'Ctrl' + 'C' rilevata, uscita in corso...");
          break;
        }
      }
    }
  }
}