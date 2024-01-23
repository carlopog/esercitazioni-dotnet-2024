class Program
{
    static void Main(string[] args)
    {
      try 
      {
        string contenuto = File.ReadAllText("file.txt");
        // il file deve essere nella stessa cartella del programma
        Console.WriteLine(contenuto);
      }
      catch (Exception e)
      {
        Console.WriteLine("il file non esiste");
        return;
      }
      finally // questo in ogni caso lo fa alla fine 
      {
        Console.WriteLine("il file e' stato chiuso");
      }
    }
}