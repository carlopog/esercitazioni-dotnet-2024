class Program
{
    static void Main(string[] args)
    {
      try 
      {
      int[] numeri = new int[int.MaxValue];
      // int.MaxValue e' il valore massimo che puo' contenere un int (2.147.483.647) percio' il programma si blocca
      }
      catch (Exception e)
      {
        Console.WriteLine("memoria insufficiente");
        return;
      }
    }
}