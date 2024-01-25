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


```