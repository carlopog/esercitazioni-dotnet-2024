using System.Net.Mail;

class Program
{
  static void Main(string[] args)
  {
    string[] nomi = ["Mario", "Luigi", "Giovanni"];
    int i = 0;
    while (i < nomi.Length) 
    {
      Console.WriteLine($"Ciao {nomi[i]}");
      i++;
    }
  }
}