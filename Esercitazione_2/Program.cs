using System.Net.Mail;

class Program
{
  static void Main(string[] args)
  {
        List<string> nomi = ["Mario", "Luigi", "Giovanni"];
        int i = 0;
        while (i < nomi.Count) 
        {
          Console.WriteLine($"Ciao {nomi[i]}");
          i++;
        }
  }
}