class Program
{
    static void Main(string[] args)

    {
      {
        string c = "5";
      try 
      {
        Console.WriteLine(int.Parse(c));
        
      }
      catch (Exception e)
      {
        Console.WriteLine($" non e' un numero");
        return;
      }
      finally // questo in ogni caso lo fa alla fine 
      {
        Console.WriteLine("il file e' stato chiuso");
      }
    }
    }
}