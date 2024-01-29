   ValoreSingolo:
        Console.WriteLine("inserisci il valore singolo che credi uscirà: ");
        {
          try
          {
            input = int.Parse(Console.ReadLine()!); 
          
            if (input < 1 || input > 6)
            {
              throw new ArgumentOutOfRangeException();
            }
          }
          catch (Exception)
          {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Non è un numero valido: dev'essere un intero tra 1 e 6  ");
            Console.ResetColor();
            Console.WriteLine("");
            goto ValoreSingolo;
          }
        }