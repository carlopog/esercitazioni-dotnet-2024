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