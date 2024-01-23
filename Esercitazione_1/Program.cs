class Program
{
    static void Main(string[] args)
    {
      try 
      {
        int numero = int.Parse("Ciao");
        // il metodo int.Parse() genera un'eccezione perche' "ciao" non e' un numero
      }
      catch (Exception e)
      {
        Console.WriteLine("Il numero non e' valido");
        return;
      }
    }
}