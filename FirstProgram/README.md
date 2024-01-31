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
      nomi[i] = lines[x]; 
    }
    Array.ForEach(nomi, Console.WriteLine);
  }
}
/* OUTPUT:
mamma
mamma
come 
come 
mamma
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

### 5 - prendo le righe di un file .txt e creo un altro file .txt solo con le sue righe che iniziano per "c"

```c#

class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string path2 = @"test2.txt"; 
    File.Create(path2).Close(); // importante chiuderlo se no non ci scrive niente dentro
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    int a = 0;
    for (int i = 0; i < lines.Length; i++)
    {
      if ( lines[i].StartsWith("c") )
      {
        nomi[a] = lines[i]; 
        a++;
      }
    }
    if (a < 1) 
    {
      Console.WriteLine("Non ci sono righe con la c");
    }
    else
    {
      Array.Resize(ref nomi, a);
      Array.ForEach(nomi, nome => File.AppendAllText(path2, nome + "\n"));
      Console.WriteLine("File creato");
    } 
  }
}

/* OUTPUT:
ciao
come 
*/
```
### 6 - prende dei nomi da un file .txt e fa un sorteggio tra quei nomi

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
    Random random = new Random(); // crea un oggetto random
    int index = random.Next(nomi.Length); // genera un numero random tra 0 e la lunghezza dell'array
    Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
  }
}

/* OUTPUT:
Dylan
*/
```
### 7 - prende dei nomi da un file .txt e fa un sorteggio tra quei nomi, il risultato viene scritto in un nuovo file .txt

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
    Random random = new Random(); // crea un oggetto random
    int index = random.Next(nomi.Length); // genera un numero random tra 0 e la lunghezza dell'array
    Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
  }
}

/* OUTPUT:
Alessandro
*/
```
### 8 - prende dei nomi da un file .txt fa un sorteggio tra quei nomi e scrive il sorteggiato in un altro file .txt solo se non è già presente

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
    Random random = new Random(); // crea un oggetto random
    int index = random.Next(nomi.Length); // genera un numero random tra 0 e la lunghezza dell'array
    Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
    string path2 = @"test2.txt";
    if (!File.Exists(path2)) // controlla se il file esiste
    {
      File.Create(path2).Close();
    }
    if (!File.ReadAllLines(path2).Contains(nomi[index])) // controlla se il nome sorteggiato è già presente nel file
    {
      File.AppendAllText(path2, $"{nomi[index]}\n");
    }
    else
    {
      Console.WriteLine("il nome è già presente nel file");
    }
  }
}

/* OUTPUT:
Giada
Dylan
Alessandro
Carlo 

Carlo il nome è giò presente
*/
```

### 9 - write all lines

```c#
class Program
{
    static void Main(string[] args)
    {
      string path = @"test.txt";
      string[] lines = File.ReadAllLines(path);
      lines[lines.Length - 1] = "Ciao cane";
      lines[lines.Length - 1] += "Bau";
      File.WriteAllLines(path, lines);
    }
}

/*
OUTPUT

Alex
Alessandro
ChristianBau Bau
Ciao cane Bau
Ciao caneBau

*/

```

### 10 - Programma che legge un file .csv

```c#
class Program
{
      static void Main(string[] args)
    {
      string path = @"test.csv";
      string[] lines = File.ReadAllLines(path);
      foreach (string line in lines)
      {
        Console.WriteLine(line);
      }
    }
}

/*
OUTPUT

nome,cognome,eta
antonio,rossi,20
mario,verdi,30  
luigi,neri,40   

*/

```
### 11 - Programma che legge un file .csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di stringhe utilizzando la virgola come separatore

```c#
class Program
{ 
  
  static void Main(string[] args)
  {
      string path = @"test.csv";
      string[] lines = File.ReadAllLines(path);
      string[][] nomi = new string[lines.Length][]; // array di array sarebbe una matrice righe e colonne
      for (int i = 0; i < lines.Length; i++)
      {
        nomi[i] = lines[i].Split(',');
      }
      foreach (string[] nome in nomi)
      {
        foreach (string n in nome)
        {
          Console.Write(n + " "); // stampa la riga
        }
        Console.WriteLine();
      }
  }
}

/*
OUTPUT

nome,cognome,eta
antonio,rossi,20
mario,verdi,30  
luigi,neri,40   

*/

```
### 12 - stessa cosa dell'esercizio 11 e poi crea un file .csv per ogni riga con il nome del file che corrisponde al nome della prima colonna ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

```c#
class Program
{ 
  
  static void Main(string[] args)
  {
      string path = @"test.csv";
      string[] lines = File.ReadAllLines(path);
      string[][] nomi = new string[lines.Length][]; // array di array sarebbe una matrice righe e colonne
      for (int i = 0; i < lines.Length; i++)
      {
        nomi[i] = lines[i].Split(',');
      }
      foreach (string[] nome in nomi)
      {
          string path2 = nome[0] + ".csv"; // il file deve essere nella stessa cartella del programma
          File.Create(path2).Close(); // crea il file e lo chiude per poterlo modificare
          for (int i = 1; i < nome.Length; i++)
          {
            File.AppendAllText(path2, nome[i] + "\n"); // scrive la riga nel file
          }
        // elimino il primo file che contiene le intestazioni delle colonne 
      }
        File.Delete("nome.csv");
  } 
}


/*
OUTPUT

nome,cognome,eta
antonio,rossi,20
mario,verdi,30  
luigi,neri,40   

*/

```

### 13 - Programma che chiede all'utente dui inserire una serie di nomi e cognomi ed eta (andando a capo ongi volta) e li salva in un file .csv

```c#
class Program
{
  static void Main(string[] args)
  {
      string path = @"test.csv";
      File.Create(path).Close(); // crea il file e lo chiude per poterlo modificare
      while (true)
      {
        Console.WriteLine($"inserisci nome, cognome ed eta");
        string nome = Console.ReadLine()!; // legge il nome
        string cognome = Console.ReadLine()!; // legge il nome
        string eta = Console.ReadLine()!; // legge il nome
        File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
        Console.WriteLine("vuoi inserire un altro nome? (s/n)");
        string risposta = Console.ReadLine()!;
        if (risposta == "n")
        {
          break;
        }
      }
  }
}


```
 
### 14 - Programma che chiede all'utente dui inserire una serie di nomi e cognomi ed eta (andando a capo ongi volta) e li salva in un file .csv solo se non c'e' gia' lo stesso nome nel file .csv

```c#
class Program
{
  static void Main(string[] args)
  {
      string path = @"test.csv";
      File.Create(path).Close(); // crea il file e lo chiude per poterlo modificare
      while (true)
      {
        Console.WriteLine($"inserisci nome, cognome ed eta");
        string nome = Console.ReadLine()!; // legge il nome
        string cognome = Console.ReadLine()!; // legge il nome
        string eta = Console.ReadLine()!; // legge il nome
        string[] lines = File.ReadAllLines(path);
        bool found = false;
        foreach (string line in lines)
        {
          if (line.StartsWith(nome)) // controlla se il nome è gia' presente nel file
          {
            found = true;
            break;
          }
        }
        if (!found)
        {
          File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
        }
        else
        {
          Console.WriteLine("il nome e' gia' presente nel file");
        }
        Console.WriteLine("vuoi inserire un altro nome? (s/n)");
        string risposta = Console.ReadLine()!;
        if (risposta == "n")
        {
          break;
        }
      }
  }
}


```
### 15 - Programma che chiede all'utente dui inserire una serie di nomi e cognomi ed eta (andando a capo ongi volta) e li salva in un file .csv solo se non c'e' gia' lo stesso nome nel file .csv

```c#
class Program
{
  static void Main(string[] args)
  {
      string path = @"test.csv";
      File.Create(path).Close(); // crea il file e lo chiude per poterlo modificare
      while (true)
      {
        Console.WriteLine($"inserisci nome, cognome ed eta");
        string nome = Console.ReadLine()!; // legge il nome
        string cognome = Console.ReadLine()!; // legge il nome
        string eta = Console.ReadLine()!; // legge il nome
        if (!File.ReadAllLines(path).Any(line => line.StartsWith(nome))) // controlla che nessuna linea inizi col nome
        {
          File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
        }
        else
        {
          string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
          string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza dell'array lines (numero di righe del file)
          for (int i = 0; i < lines.Length; i++)
          {
            nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzando la virgola come separatore
          }
          for (int i = 0; i < nomi.Length; i++)
          {
            if (nomi[i][0] == nome) // se il nome e' gia' presente nel file
            {
              nomi[i][1] = cognome; // aggiorno il cognome
              nomi[i][2] = eta; // aggiorno l'eta'
            }
          }
          File.Delete(path);
          File.Create(path).Close();
          foreach (string[] n in nomi)
          {
            File.AppendAllText(path, n[0] + "," + n[1] + "," + n[2] + "\n");
          }
        }
        Console.WriteLine("vuoi inserire un altro nome? (s/n)");
        string risposta = Console.ReadLine()!;
        if (risposta == "n")
        {
          break;
        }
      }
  }
}

/* OUTPUT

gino,pino,55
pino,pancio,3
pinco,pallo,3
franco,stanco,pancio
gesu,cristo,33

*/

```
 
### 15 - Vedi tutti i file .csv nella tua cartella, scegli quale vuoi leggere e ti scrive tutte le sue righe in console

```c#
class Program
{
  static void Main(string[] args)
  {
    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
    foreach (string file in files)
    {
      Console.WriteLine(file); // stampa il nome del file
    }
    Console.WriteLine("quale file vuoi leggere?");
    string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
    string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
    foreach (string line in lines)
    {
      Console.WriteLine(line); // scrive tutte le righe del file 
    }
  }
}

/* OUTPUT

quale file vuoi leggere?
test.csv
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
luigi,neri,40

*/

```
### 16 - Vedi tutti i file .csv nella tua cartella, scegli quale vuoi eliminare e lo cancella

```c#
class Program
{
  static void Main(string[] args)
  {
    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
    foreach (string file in files)
    {
      Console.WriteLine(Path.GetFileName(file)); // stampa il nome del file
    }
    Console.WriteLine("quale file vuoi eliminare?");
    string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
    if (File.Exists(fileScelto)) // controlla se il file esiste
    {
      File.Delete(fileScelto); // elimina il file
    }
    else
    {
      Console.WriteLine("il file non esiste"); 
    }
  }
}

/* OUTPUT

quale file vuoi eliminare?
test.csv

*/

```
### 17 - Vedi tutti i nomi dei file .csv nella tua cartella, scegli quale vuoi eliminare e lo cancella

```c#
class Program
{
  static void Main(string[] args)
  {
    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
    foreach (string file in files)
    {
      Console.WriteLine(Path.GetFileName(file)); // stampa solo il nome del file
    }
    Quale:
    Console.WriteLine("quale file vuoi leggere?");
    string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
    if (File.Exists(fileScelto)) // se il file esiste
    {
      string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
      foreach (string line in lines)
      {
        Console.WriteLine(line); // scrive tutte le righe del file 
      }
    }
    else
    {
      Console.WriteLine("il file non esiste");
      goto Quale;
    }
  }
}

/* OUTPUT

antonio.csv
luigi.csv
mario.csv
test.csv
quale file vuoi leggere?
3
il file non esiste
quale file vuoi leggere?
antonio.csv
rossi
20

*/

```
### 18 - Vuoi leggere un file o eliminarlo?

```c#
class Program
{
  static void Main(string[] args)
  {
    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
    foreach (string file in files)
    {
      Console.WriteLine(Path.GetFileName(file)); // stampa solo il nome del file
    }
    Tipo:
    Console.WriteLine("Vuoi leggere un file o eliminarlo? (l/e)");
    string tipoScelto = Console.ReadLine()!; // legge il tipo di operazione scelta
    if(tipoScelto == "l")
    {
      Leggi:
      Console.WriteLine("Quale file vuoi leggere?");
      string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
      if (File.Exists(fileScelto)) // se il file esiste
      {
        string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
        foreach (string line in lines)
        {
          Console.WriteLine(line); // scrive tutte le righe del file 
        }
      }
      else
      {
        Console.WriteLine("il file non esiste");
        goto Leggi;
      }
    }
    else if (tipoScelto == "e")
    {
      Elimina:
      Console.WriteLine("quale file vuoi eliminare?");
      string fileScelto = Console.ReadLine()!; // legge il nome del file scelto
      if (File.Exists(fileScelto)) // controlla se il file esiste
      {
        File.Delete(fileScelto); // elimina il file
        Console.WriteLine($"il file {fileScelto} è stato eliminato"); 
      }
      else
      {
        Console.WriteLine("il file non esiste"); 
        goto Elimina;
      }
    }
    else
    {
      Console.WriteLine("Tipo non valido.");
      goto Tipo;
    }
  }
}

/* OUTPUT

antonio.csv
mario.csv
test.csv
Vuoi leggere un file o eliminarlo? (l/e)
e
quale file vuoi eliminare?

il file non esiste
quale file vuoi eliminare?
test.csv

*/

```
 
### 19 - versione con il try and catch del programma precedente + .csv per scrivere direttamente il nome del file .csv

```c#
class Program
{
    static void Main(string[] args)
    {
      string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); // legge tutti i file .csv nella cartella del programma
      foreach (string file in files)
      {
        Console.WriteLine(Path.GetFileName(file)); // stampa solo il nome del file
      }
      Tipo:
      Console.WriteLine("Vuoi leggere un file o eliminarlo? (l/e)");
      string tipoScelto = Console.ReadLine()!; // legge il tipo di operazione scelta
      if (tipoScelto == "l")
      {
        Leggi:
        Console.WriteLine("Quale file vuoi leggere?");
        string fileScelto = Console.ReadLine() + ".csv" !; // legge il nome del file scelto
        try
        {
          string[] lines = File.ReadAllLines(fileScelto); // legge tutte le righe del file
          foreach (string line in lines)
          {
            Console.WriteLine(line); // scrive tutte le righe del file 
          }
        }
        catch (Exception)
        {
          Console.WriteLine("il file non esiste");
          goto Leggi;
        }
      }
      else if (tipoScelto == "e")
      {
        Elimina:
        Console.WriteLine("quale file vuoi eliminare?");
        string fileScelto = Console.ReadLine() + ".csv"!; // legge il nome del file scelto
        try
        {
          File.Delete(fileScelto); // elimina il file
          Console.WriteLine($"il file {fileScelto} è stato eliminato"); 
        }
        catch (Exception)
        {
          Console.WriteLine("il file non esiste"); 
          goto Elimina;
        }
      }
      else
      {
        Console.WriteLine("Tipo non valido.");
        goto Tipo;
      }

    }
}

/*
OUTPUT
Vuoi leggere un file o eliminarlo? (l/e)
l
Quale file vuoi leggere?
test 
nome,cognome,eta
antonio,rossi,20
mario,verdi,30
*/

```

###  20 - 

```c#
class Program
{
    static void Main(string[] args)
    {
      string headerLine = File.ReadLines(path).First();
      string lastLine = File.ReadLines(path).Last();
      Console.WriteLine(headerLine);
      Console.WriteLine(lastLine);
    }
}

/*
OUTPUT

*/

```