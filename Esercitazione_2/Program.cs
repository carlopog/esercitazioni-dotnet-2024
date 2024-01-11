class Program
{
  static void Main(string[] args)
  {
     string[] nomi = new string[3]; 
     nomi[0] = "Mario"; 
     nomi[1] = "Luigi"; 
     nomi[2] = "Giovanni";
     Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
     Console.WriteLine($"il numero di elementi e' {nomi.Length}");
  }
}