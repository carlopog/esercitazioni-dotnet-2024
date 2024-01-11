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
     //da errore se inseriamo un quarto oggetto in questo array da 3 elementi [3] ==> index out of range
     //non da errore se inserisco meno elementi tipo 2 su [3] ==> come terzo valore prende zero
     //da errore se chiedo di disegnare nel WriteLine un elemento che non esiste num[5] ==> index out of range
    }
  }
```
### 12 - Dichiarare una lista
```c#
  class Program12
  {
    static void Main(string[] args)
    {
     int[] num = new int[3];
     num[0] = 2; 
     num[1] = 4;
     num[2] = 6;
     Console.WriteLine($"Ciao lo sapevi che {num[0]} + {num[1]} fa {num[2]} ?");
    }
  }
```