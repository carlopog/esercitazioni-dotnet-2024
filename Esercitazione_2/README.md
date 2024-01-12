#ESERCITAZIONI BASE SU C# .NET CORE

**Utilizzare dotnet new console crea un nuovo progetto console**
**Utilizzare dotnet run esegue il progetto console**

- 01 - Tipi di dato e variabili
- 02 - Operatori 
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli

## 01 - Esercitazioni su tipi di dato e variabili

### 01 - Dichiarare una variabile di tipo stringa


```c#

{
  class Program
  {
    static void Main(string[] args)
    {
      string nome =  "Christian";
      console.WriteLine($"Hello {nome}!");
    }
  }
}
```

### 02 - Dichiarare una variabile di tipo intero (numero)
```c#
  class Program2
  {
    static void Main(string[] args)
    {
      int eta = 20; //gli interi non hanno bisogno di apici doppi
      Console.WriteLine($"Hai {eta} anni");
    }
  }
```


### 03 - Dichiarare una variabile di tipo booleano
```c#
  class Program3
  {
    static void Main(string[] args)
    {
      bool maggiorenne = true; //i booleani non hanno bisogno di apici doppi
      Console.WriteLine($"Sei maggiorenne? {maggiorenne}");
    }
  }
```



### 04 - Dichiarare una variabile di tipo decimale
```c#
  class Program4
  {
    static void Main(string[] args)
      {
        decimal altezza = 1.80m; //importante mettere m o M dopo il numero
        Console.WriteLine($"Sei alto {altezza} metri");
      }
  }
```
### 05 - Dichiarare una variabile di tipo data
```c#
  class Program5
  {
    static void Main(string[] args)
      {
        DateTime dataDiNascita = new DateTime(1980, 1, 1);
        Console.WriteLine($"Sei nato il {dataDiNascita}");
      }
  }
```
### 06 - Dichiarare una variabile di tipo data formattata
```c#
  class Program6
  {
    static void Main(string[] args)
      {
        DateTime dataDiNascita = new DateTime(1980, 1, 1);
        DateTime d = new DateTime(2038, 4, 27);
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
        Console.WriteLine($"Morirai {d.ToLongDateString()}");
      }
  }
```
### 07 - Utilizzare l'operatore + per sommare due interi
```c#
  class Program7
  {
    static void Main(string[] args)
      {
       int a = 10;
       int b = 20;
       int c = a + b;
       Console.WriteLine($"La somma di {a} e {b} e' {c}");
      }
  }
```
### 08 - Utilizzare l'operatore + per sommare due interi e un decimale
```c#
  class Program8
  {
    static void Main(string[] args)
      {
       int a = 10;
       int b = 20;
       decimal c = 1.5m;
       decimal d = a + b + c;
       Console.WriteLine($"La somma di {a} e {b} e {c} e' {d}");
      }
  }
```
### 09 - Utilizzare l'operatore == e != per confrontare due stringhe
```c#
  class Program9
  {
    static void Main(string[] args)
    {
      string nome = "Pino";
      string cognome = "Paoli";
      bool uguali = nome == cognome;
      bool diversi = nome != cognome;
      Console.WriteLine($"i due nomi sono uguali? {uguali}");
      Console.WriteLine($"i due nomi sono diversi? {diversi}");
    }
  }
```
### 10 - Utilizzare l'operatore > o < per confrontare due stringhe
```c#
  class Program9
  {
    static void Main(string[] args)
    {
      int a = 9;
      int b = 5;
      int c = 5;
      bool maggiore = a > b;
      bool maggioreUguale = c >= b;
      bool minoreUguale = c <= b;
      bool minore = a < b;
      Console.WriteLine($"a e' maggiore di b? {maggiore}");
      Console.WriteLine($"a e' minore di b? {minore}");
      Console.WriteLine($"c e' maggiore uguale di b? {maggioreUguale}");
      Console.WriteLine($"c e' minore uguale di b? {minoreUguale}");
    }
  }
```

### 10 -  Dichiarare un array di stringhe
```c#
  class Program10
  {
    static void Main(string[] args)
    {
     string[] nomi = new string[3]; //array ha un num di elementi predeterminato
     nomi[0] = "Mario"; // puoi inserire un elemento in una posizione specifica
     nomi[1] = "Luigi"; // array deve contenere dati dello stesso tipo
     nomi[2] = "Giovanni";
     Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
    }
  }
```

### 11 - Dichiarare un array di interi
```c#
  class Program11
  {
    static void Main(string[] args)
    {
     int[] num = new int[3];
     num[0] = 2; 
     num[1] = 4;
     num[2] = 6;
     Console.WriteLine($"Ciao lo sapevi che {num[0]} + {num[1]} fa {num[2]} ?");

     //da errore se inseriamo una stringa in un array di interi ==> non fa conversioni implicite 
     //da errore se chiedo di disegnare nel WriteLine un elemento che non esiste num[5] ==> index out of range
     //da errore se inseriamo un quarto oggetto in questo array da 3 elementi [3] ==> index out of range
     //non da errore se inserisco meno elementi tipo 2 su [3] ==> come terzo valore prende zero
     //questa cosa potrebbe causare confusione, ci starebbe mettere un metodo che restituisce "dato mancante"
    }
  }
```
### 12 - Dichiarare un array di stringhe e utilizzare il metodo Length
```c#
  class Program12
  {
    static void Main(string[] args)
    {
     string[] nomi = new string[3]; 
     nomi[0] = "Mario"; 
     nomi[1] = "Luigi"; 
     nomi[2] = "Giovanni";
     Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");
     Console.WriteLine($"il numero di elementi e' {nomi.Length}")
    }
  }
```
### 13 - Dichiarare una lista
```c#
  class Program13
  {
    static void Main(string[] args)
    {
      List<string> nomi = new List<string>(); // utilizziamo il diamond <>
      nomi.Add("Luigi"); // aggiunta di un elemento tramite il metodo Add
      nomi.Add("Giovanni"); // ogni elemento deve essere tra parentesi () perche' uso il metodo
      nomi.Add("Mario"); // gli elementi vengono inseriti nell'ordine in cui li mettiamo
      Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}");

      // da piu' liberta' di un array e meno errori
      // ma e' meno preciso
    }
  }
```

### 13 - Dichiarare una lista
```c#
  class Program13
  {
    static void Main(string[] args)
    {
      List<int> num = new List<int>();
      num.Add(3); // ovviamente gli interi non hanno bisogno delle virgolette ""
      num.Add(5);
      num.Add(7);
      Console.WriteLine($"Lista di numeri: {num[0]}, {num[1]} e {num[2]}");
    } 
  }
```
### 14 - Dichiarare una lista e contare i suoi elementi col metodo Count
```c#
  class Program14
  {
    static void Main(string[] args)
    {
         List<int> numeri = new List<int>();
         numeri.Add(3);
         numeri.Add(5); // ho aggiunto un po' di numeri per vedere se funziona il count
         numeri.Add(5);
         numeri.Add(5);
         numeri.Add(5);
         numeri.Add(5);
         numeri.Add(7);
         Console.WriteLine($"Lista di numeri: {numeri[0]}, {numeri[1]} e {numeri[2]}");
         Console.WriteLine($"ci sono {numeri.Count} numeri");
    } 
  }
```

### 15 - Dichiarare una pila di stringhe
```c#
  class Program15
  {
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>();
        nomi.Push("Mario");    
        nomi.Push("Kevin");    
        nomi.Push("Paolo");    
        Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()} e {nomi.Pop()}");
        // Pop() metodo delle Stack che fa uscire per primo l'ultimo elemento inserito 
    } 
  }
```
### 16 - Dichiarare una coda di stringhe

```c#
  class Program16
  {
    static void Main(string[] args)
    {
      Queue<string> nomi = new Queue<string>();
      nomi.Enqueue("Mario");    
      nomi.Enqueue("Kevin");    
      nomi.Enqueue("Paolo");    
      Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue()}");
    } 
  }
```
### 17 - inizializzare, liste, pile e code in modo semplificato

```c#
 
  // inizializzazione di un array di interi
    int[] numeri = new int[] {1, 2, 3, 4, 5};
    int[] numeriDue = [1, 2, 3, 4, 5];

    // inizializzazione di un array di stringhe
    string[] nomi = new string[] {"Mario", "Luigi", "Yoshi"};
    string[] nomiDue = ["Mario", "Luigi", "Yoshi"];

    // inizializzazione di un list di interi
    List<int> listaNumeri = new List<int> {1, 2, 3, 4, 5};
    List<int> listaNumeriDue = [1, 2, 3, 4, 5];

    // inizializzazione di un list di stringhe
    List<string> listaNomi = new List<string> {"Mario", "Luigi", "Yoshi"};
    List<string> listaNomiDue = ["Mario", "Luigi", "Yoshi"];

    // inizializzazione di uno stack (pila) di interi
    Stack<int> pilaNumeri = new Stack<int>(new int[] {1, 2, 3, 4, 5});
    Stack<int> pilaNumeriDue = new([1, 2, 3, 4, 5]);

    // inizializzazione di una queue (coda) di stringhe
    Queue<string> codaNomi = new Queue<string>(new string[] {"Mario", "Luigi", "Yoshi"});
    Queue<string> codaNomiDue = new(["Mario", "Luigi", "Yoshi"]);

    Console.WriteLine($"Array numeri: {numeri[0]}, {numeriDue[1]}");
    Console.WriteLine($"Array stringhe: {nomi[0]}, {nomiDue[1]}");
    Console.WriteLine($"Lista numeri: {listaNumeriDue[0]}, {listaNumeri[1]}");
    Console.WriteLine($"Lista stringhe: {listaNomiDue[0]}, {listaNomi[1]}");
    Console.WriteLine($"Pila numeri: {pilaNumeri.Pop()}, {pilaNumeri.Pop()}");
    Console.WriteLine($"Pila DUE numeri: {pilaNumeriDue.Pop()}, {pilaNumeriDue.Pop()}");
    Console.WriteLine($"Coda stringhe: {codaNomi.Dequeue()}, {codaNomi.Dequeue()}");
    Console.WriteLine($"Coda DUE stringhe: {codaNomiDue.Dequeue()}, {codaNomiDue.Dequeue()}");

```

### 18 - Test vari metodi delle liste (pochi in realta')

```c#

  class Program18

    {
      static void Main(string[] args)
      {
        List<int> listaNumeri = [1, 2, 3, 4, 5];

        Console.WriteLine($"Lista numeri: {listaNumeri[0]}, {listaNumeri[1]}");
      }
    }


```
### 19 - Esercitazioni sulle condizioni: usare if

```c#

  class Program19

    {
      static void Main(string[] args)
      {
        int a = 10;
        int b = 2;
        if (a > b) // la condizione da verificare sta tra parentesi ()
        {
          Console.WriteLine($"{a} e' maggiore di {b}");
          // il codice da eseguire quando la condizione e' verificata tra {}
        }
      }
    }


```

### 20 - Esercitazioni sulle condizioni: usare if

```c#

  class Program20

    {
      static void Main(string[] args)
      {
        int a = 10;
        int b = 2;
        if (a > b) // la condizione da verificare sta tra parentesi ()
        {
          Console.WriteLine($"{a} e' maggiore di {b}");
          // il codice da eseguire quando la condizione e' verificata tra {}
        }
      }
    }


```
