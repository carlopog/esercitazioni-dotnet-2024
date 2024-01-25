## FILE DI TESTO .txt

### 1 - prendo le righe di un file .txt a un determinato path

```c#

class Program
{
  static void Main(string[] args)
  {
    // string path = @"C:\Users\Utente\Desktop\test.txt"
    string path = @"test.txt"; // il file deve essere nella stessa cartella del programma 
    string[] lines = File.ReadAllLines(path); // legge tutte le righe del file che si trova a quel path
    Array.ForEach(lines, Console.WriteLine); // stampa ogni riga
  }
}

/* OUTPUT:
ciao
mamma 
come 
stai
?
*/
```
### 2 - prendo le righe di un file .txt in modo casuale e le stampo

```c#

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
      Random random = new();
      int to = lines.Length;
			int x = random.Next(0, to);
      nomi[x] = lines[i]; 
    }
    Array.ForEach(nomi, Console.WriteLine); // stampa ogni riga
  }
}
/* OUTPUT:

stai

come
?
*/

```
### 3 - prendo le righe di un file .txt e le inserisco nello stesso ordine specificandolo

```c#

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
      nomi[i] = lines[i]; 
    }
    Array.ForEach(nomi, Console.WriteLine);
  }
}

/* OUTPUT:
ciao
mamma 
come 
stai
?
*/
```
### 4 - prendo le righe di un file .txt che iniziano con la lettera "c"

```c#

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    int a = 0; // introduco una variabile per avere un secondo counter
    for (int i = 0; i < lines.Length; i++)
    {
      if ( lines[i].StartsWith("c") )
      {
        nomi[a] = lines[i]; 
        a++; // a ogni parola che inizia con la c inserita aggiorno il counter
      }
    }
    if (a < 1) // se il counter e' zero
    {
      Console.WriteLine("Non ci sono righe con la c");
    }
    Array.Resize(ref nomi, a); // diminuisco la dimensione del secondo array per non avere stringhe vuote
    Array.ForEach(nomi, Console.WriteLine);
  }
}

/* OUTPUT:
ciao
come 

oppure

Non ci sono righe con la c
*/
```