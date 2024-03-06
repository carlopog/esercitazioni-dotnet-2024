class ValidaInput
{
  public string ReadString(string dato)
  {
  Start:
    Console.WriteLine($"Inserisci {dato}:");
    try
    {
      string str = Console.ReadLine()!;
      return str;
    }
    catch
    {
      Console.WriteLine("devi inserire un numero");
      goto Start;
    }
  }
   public static int ReadInt(string dato, int? min = -1000, int? max = 1000)
  {
  Start:
    Console.WriteLine($"Inserisci {dato}:");
    try
    {
      int num = int.Parse(Console.ReadLine()!);
      if (min != -1000 || max != 1000)
      {
        if (num < min || num > max)
        {
          throw new ArgumentOutOfRangeException();
        }
      }
      return num;
    }
    catch
    {
      Console.WriteLine("devi inserire un numero");
      goto Start;
    }
  }
}