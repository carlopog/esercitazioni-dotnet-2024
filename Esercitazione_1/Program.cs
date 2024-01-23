class Program
{
    static void Main(string[] args)
    {
      int[] numeri = [1, 2 , 3];
      try 
      {
        Console.WriteLine(numeri[3]);
      }
      catch (Exception e)
      {
        Console.WriteLine("indice non valido");
        return;
      }
    }
}