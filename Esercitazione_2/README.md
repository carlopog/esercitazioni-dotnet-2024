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
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
      }
  }
```
