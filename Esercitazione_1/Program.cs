class Program
{
    static void Main(string[] args)
    {
      string nome = null;
      try 
      {
        Console.WriteLine(nome.Length);
      }
      catch (Exception e)
      {
        Console.WriteLine("il nome non e' valido");
        return;
      }
    }
}