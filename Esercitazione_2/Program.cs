using Microsoft.VisualBasic;

class Program2
{
  static void Main(string[] args)
  {
    for (int i = 0; i < 4; i++)
    {
      Console.WriteLine("dormi un secondo");
      Thread.Sleep(1000); // piccola pausa per ridurre il carico sulla CPU (serve per non far spammare o se vuoi vedere un messaggio per un po' di tempo)
    }
    Console.WriteLine("Tempo scaduto!");
  }
}
