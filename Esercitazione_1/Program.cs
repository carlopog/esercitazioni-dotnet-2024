class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un numero tra 1 e 10");
        int numero = int.Parse(Console.ReadLine()!); // il ? serve per dire che potrebbe essere null e si puo' fare anche con il !
        if (numero < 1 || numero > 10)
        {
          Console.WriteLine("il numero non e' valido");
          return;
        }
        Console.WriteLine($"il numero inserito e' il numero {numero}");
    }
}