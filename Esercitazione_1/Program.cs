class Program
{
    static void Main(string[] args)
    {
      try 
      {
        int zero = 0;
        int numero = 1 / zero; // il programma si blocca perche genera un eccezione dividere per zero
      }
      catch (Exception e)
      {
        Console.WriteLine("Il numero non e' valido");
        Console.WriteLine("ERRORE NON TRATTATO:");
        Console.WriteLine($"messaggio {e.Message}");
        Console.WriteLine($"codice errore {e.HResult}");
        return;
      }
    }
}