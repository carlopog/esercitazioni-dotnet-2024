class Program
{
  static void Main(string[] args)
  {
    DateTime dataDiNascita = new DateTime(1998, 4, 27);
    DateTime d = new DateTime(2038, 4, 27);
    Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
    Console.WriteLine($"Morirai {d.ToLongDateString()}");
  }
}