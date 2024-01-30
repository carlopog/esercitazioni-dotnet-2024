## FUNZIONE UGUALE A CONTENUTO DI UN ARRAY 
```c#

class Program
{
   static void Uguale(int n, int[] array)
  {
    bool uguale = false;
    foreach (int d in array)
    {
      if (d == n)
      {
        uguale = true;
      }
    }
    if (uguale)
    {
        Console.WriteLine($"ie");
        
    }
  }

  static void Main(string[] args)
  {
    int[] dadi = new int[3];
    Random random = new();
    for (int i = 0; i < 3; i++)
      {
        int n = random.Next(1, 7);
        dadi[i] = n;
        Console.WriteLine(dadi[i]);
      }
    Uguale(4, dadi);
  }
}

```

## FUNZIONE COMBINAZIONE DI DUE NUMERI UGUALE A VALORI CONTENUTI IN UN ARRAY

```C#

class Program
{
    static void Combo(int n, int m, int[] array)
    {
        bool uguale = false;
        bool combo = false;
        foreach (int d in array)
        {
            if (d == n)
            {
                uguale = true;
            }
        }
        if (uguale)
        {
            foreach (int d in array)
            {
                if (d == m)
                {
                    combo = true;
                }
            }
            if (combo)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Hai indovinato, è uscita la combinazione indicata da te!");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Non hai indovinato");
            }
        }
        else
        {
            Console.Write("Non hai indovinato");

        }
    }

    static void Main(string[] args)
    {
        int[] dadi = new int[3];
        Random random = new();
        for (int i = 0; i < 3; i++)
        {
            int n = random.Next(1, 7);
            dadi[i] = n;
            Console.WriteLine(dadi[i]);
        }
        Combo(6, 4, dadi);
    }
}

```