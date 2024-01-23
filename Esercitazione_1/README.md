# GESTIONE DELLE ECCEZIONI

in C# le eccezioni sono oggetti che rappresentano errori che si verificano durante l'esecuzione di un programma.

Si possono verificare in due modi:
- eccezioni generate dal sistema
- eccezioni generate dal programmatore

Le eccezioni generate dal sistema sono quelle che si verificano quando il sistema operativo o il runtime .Net Framework
rilevano un errore che non puo' essere gestito dal programma.

Gli esempi piu' comuni sono:
-System.IO.IOException  (si verifica quando si tenta di accedere a un file che non esiste)
-System.IndexOutOfRangeException   (si verifica quando si tenta di accedere a un elemento di un array con un indice non valido)
-System.NullReferenceException  (si verifica quando si tenta di accedere a un oggetto null)
-System.OutOfMemoryException  (si verifica quando non c'e' abbastanza memoria disponibile)
-System.StackOverflowException  (si verifica quando la pila e' piena)

Le eccezioni generate dal programmatore sono quelle che si verificano quando il programmatore genera un'eccezione per segnalare un errore

Gli esempi piu' comuni sono:
-System.ArgumentException  (si verifica quando un argomento di di un metodo non e' valido)
-System.ArgumentNullException (si verifica quando un argomento di di un metodo e' null)
-System.ArgumentOutOfRangeException (si verifica quando un argomento di di un metodo e' fuori dal range consentito)
-System.DividedByZeroException (si verifica quando si tenta di dividere per zero)
-System.InvalidCastException (si verifica quando si tenta di convertire un tipo in un altro tipo non valido)
-System.NotImplementedException (si verifica quando si tenta di usare un metodo non implementato)

Le eccezioni possono essere gestite con il costrutto try-catch-finally.

Oppure in modo piu' avanzato con il costrutto try-catch-finally-throw.

Le differenze tra i due costrutti sono:
-try-catch-finally: il blocco finally viene sempre eseguito
-try-catch-finally-throw: il blocco finally viene eseguito solo se necessario

Ecco un esempio di 

```c#

try 
{
  // codice che puo' generare un'eccezione
}

catch (Exception e)
{
  // codice che gestisce l'eccezione
  throw;
}
finally
{
  // codice che viene eseguito solo se non viene generata un'eccezione
}
```

il costrutto try-catch-finally puo' essere utilizzato 


La principale differenza tra il metodo TryParse e il costrutto try-catch-finally e' che il metodo TryParse non genera
un'eccezione ma restituisce un valore booleano che indica se la conversione e' andata a buon fine o no.
il costrutto try-catch-finally invece genera un'eccezione e 

Quando si usa il try-parse e quando invece e' meglio usare il costrutto try-catch-finally?

se si vuole gestire l'eccezione con un messaggio di errore personalizzato e' meglio usare il try-catch-finally 
se si vuole gestire l'eccezione ma si vuole solo controllare se la conversione e' andata a buon fine o no e' meglio usare il try-parse

## Esempi di gestione delle eccezioni 

### Vogliamo verificare che l'utente inserisca un numero tra 1 e 10:

```c#
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
```

### Vogliamo verificare che l'utente inserisca un numero tra 1  e 10 e gestire l'eccezione con il caso try-catch-finally:

```c#
class Program 
{
  static void Main(string[] args)
  {
    Console.WriteLine("Inserisci un numero tra 1 e 10");
    try
    {
      int numero = int.Parse(Console.ReadLine()!);
      if (numero < 1 || numero > 10)
      {
        Console.WriteLine("il numero non e' valido");
        return;
      }
        Console.WriteLine($"il numero inserito e' {numero}");
    }
    catch (Exception e)
    {
        Console.WriteLine("il numero non e' valido");
        return;
    }
  }
}
```

### Vogliamo gestire System.IO.IOException (si verifica quando si tenta di accedere a un file che non esiste)
```c#
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string contenuto = File.ReadAllText("file.txt"); // il file deve essere nella stessa cartella del programma
            Console.WriteLine(contenuto);
        }
        catch (Exception e)
        {
            Console.WriteLine("il file non esiste");
            return;
        }
    }
}
```

###  Vogliamo gestire System.IndexOutOfRangeException (si verifica quando si tenta di accedere a un elemento di un array con un indice non valido):

```c#
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
```