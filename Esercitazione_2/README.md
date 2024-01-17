#ESERCITAZIONI BASE SU C# .NET CORE

**Utilizzare dotnet new console crea un nuovo progetto console**
**Utilizzare dotnet run esegue il progetto console**

- 01 - Tipi di dato e variabili
- 02 - Operatori 
- 03 - Strutture di dati
- 04 - Condizioni
- 05 - Cicli

## - Esercitazioni su tipi di dato e variabili

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

### 20 - Esercitazioni sulle condizioni: usare else if

```c#

  class Program20

    {
      static void Main(string[] args)
      { 
        int a = 10;
        int b = 1;
        if (a > b)
        {
          Console.WriteLine($"{a} e' maggiore di {b}");
        }
        else if (a < b)
        {
          Console.WriteLine($"{a} e' minore di {b}");
        }
        else
        {
          Console.WriteLine($"{a} e' uguale a {b}");
        }
      }
    }

```
### 21 - Esercitazioni sulle condizioni: usare switch case

```c#

  class Program21

    {
      static void Main(string[] args)
      { 
        int a = 10;
        switch (a)
        {
          case 10:
            Console.WriteLine($"{a} e' uguale a 10");
            break;
          case 20:
            Console.WriteLine($"{a} e' uguale a 20");
            break;
          default:
            Console.WriteLine($"{a} non e' uguale a 10 o 20");
            break;
        }
      }
    }

```

### 22 - Dichiarare un dizionario di stringhe

```c#

  class Program22

    {
      static void Main(string[] args)
      { 
        Dictionary<string, string> nomi = new Dictionary<string, string>();
        nomi.Add("Mario", "Rossi");
        nomi.Add("Luigi", "Biancoli");
        nomi.Add("Giuseppe", "Verdi");
        Console.WriteLine($"Ciao {nomi["Mario"]}, {nomi["Luigi"]} e {nomi["Giuseppe"]}");
      }
    }

```

### 23 - Dichiarare un dizionario di stringhe-interi velocemente

```c#

  class Program23

    {
      static void Main(string[] args)
      {
        Dictionary<string, int> eta = new()
        {
            { "Mario", 25 },
            { "Luigi", 44 },
            { "Giuseppe", 60 }
        };
        Console.WriteLine($"Ciao {eta["Mario"]}, {eta["Luigi"]} e {eta["Giuseppe"]}");
      }
    }

```

### 24 - Utilizzare il ciclo for

```c#

  class Program24

    {
      static void Main(string[] args)
      { 
       for(int i = 0; i < 10; i++)
       {
          Console.WriteLine($"il valore di i e' {i}");
       }
      }
    }

```

### 25 - Utilizzare il ciclo foreach

```c#

  class Program25

    {
      static void Main(string[] args)
      { 
        string[] nomi = new string[3];
        nomi[0] = "Toad";
        nomi[1] = "Luigi";
        nomi[2] = "Yoshi";
        foreach (string nome in nomi)
       {
          Console.WriteLine($"Ciao {nome}");
       }
      }
    }

```
### 26 - Utilizzare il ciclo foreach in una lista di stringhe

```c#

  class Program26

    {
      static void Main(string[] args)
      { 
        List<string> nomi = new List<string>{"Toad", "Luigi", "Yoshi"};
        foreach (string nome in nomi)
       {
          Console.WriteLine($"Ciao {nome}");
       }
      }
    }

```

### 27 - ciclo foreach per leggere il valore delle chiavi di un dictionary 

```c#

  class Program27

    {
      static void Main(string[] args)
      { 
        Dictionary<string, int> eta = new()
        {
          { "Mario", 25 },
          { "Luigi", 44 },
          { "Giuseppe", 60 }
        };
        var nomi = eta.Keys;
        foreach (string nome in nomi) {
          Console.WriteLine($"il signor {nome} ha {eta[$"{nome}"]} anni");
        }
      }
    }

```

### 28 - Esercizio: un array di stringhe con 3 nomi, cicliamo con un foreach, se il nome e' Mario, aggiungere a una lista 

```c#

  class Program28

    {
      static void Main(string[] args)
      { 
        string[] nomi = ["Franco", "Ciccio", "Mario"];
        List<string> lista = ["Merola"];
        foreach (string nome in nomi) {
          if(nome == "Mario") {
            lista.Add(nome);
          }
        } 
        foreach (string mario in lista) {
          Console.WriteLine($"{mario}");
        }
      }
    }

```
### 29 - Utilizzare il Console.ReadLine() per leggere input dalla console

```c#

  class Program29

    {
      static void Main(string[] args)
      { 
        string? nome = Console.ReadLine();
        Console.WriteLine($"Ciao {nome}");
      }
    }

```
### 30 - Utilizzare il Console.ReadKey() per leggere input dalla console

```c#

  class Program30

    {
      static void Main(string[] args)
      { 
        Console.WriteLine($"premi un tasto per terminare...");
        Console.ReadKey();
      }
    }

```
### 31 - Utilizzare il ciclo while con un array di stringhe

```c#

  class Program31

    {
      static void Main(string[] args)
      { 
        string[] nomi = ["Mario", "Luigi", "Giovanni"];
        // creo un array di stringhe
        int i = 0;
        // creo una variabile indice
        while (i < nomi.Length) 
        // il ciclo continua finche' indice e' minore del numero degli elementi dell'array
        {
          Console.WriteLine($"Ciao {nomi[i]}");
        // scrive in console il nome nella posizione corrispondente al numero dell'indice
          i++;
        // aumenta di uno l'indice
        }
      }
    }

```

### 32- Utilizzare il ciclo while con una Lista di stringhe

```c#

  class Program32
    {
      static void Main(string[] args)
      {
        List<string> nomi = ["Mario", "Luigi", "Giovanni"];
        // creo una lista di stringhe
        int i = 0;
        // creo una variabile indice
        while (i < nomi.Count) 
        // il ciclo continua finche' indice e' minore del numero degli elementi dell'array
        {
          Console.WriteLine($"Ciao {nomi[i]}");
        // scrive in console il nome nella posizione corrispondente al numero dell'indice
          i++;
        // aumenta di uno l'indice
        }
      }
    }

```

### 33- Utilizzare il ciclo while con il ReadKey per farlo funzionare con un tasto specifico

```c#

  class Program33
    {
      static void Main(string[] args)
      {
        Console.WriteLine($"Premi N per terminare");

        while (true) 
        // il ciclo continua finche' e' settata come vera la condizione
        {
          ConsoleKeyInfo keyInfo = Console.ReadKey();
          if (keyInfo.Key == ConsoleKey.N)
          {
            break; // Esce dal ciclo se viene premuto N 
          }
        }
      }
    }

```
### 34- Utilizzare il ciclo while con il ReadKey per farlo funzionare con due tasti specifici

```c#

  class Program34
    {
      static void Main(string[] args)
      {
        Console.WriteLine($"Premi 'Ctrl' + 'N' per terminare");

        while (true) 
        {
        // Aspetta fino a che non viene premuto un tasto
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        // Verifica se il tasto CTRL e' tenuto premuto
          if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
          {
        // Controlla se viene premuto il tasto N
            if (keyInfo.Key == ConsoleKey.N)
        // se vuoi usare ctrl + c devi prima aggiungere Console.TreatControlCAsInput = true
            {
              Console.WriteLine("Combinazione 'Ctrl' + 'N' rilevata, uscita in corso...");
              break; // messaggio di uscita e termina la sessione
            }
          }
        }
      }
    }

```
### 35- comandi di write per scrivere in modi diversi

```c#
 class Program35
    {
      static void Main(string[] args)
      {
        Console.Write("ooo\n"); // con slash n vado a capo
        Console.Write("gino");
        Console.ReadKey();  // aspetto un comando per andare avanti
        Console.Write('\r'); // cancello la riga precedente
        Console.Write("ginopaoli"); // sovrascrivo quella stessa riga 
      }
    }
```

### 36 - Creare un menu con lo switch case

```c#

class Program36
  {
    static void Main(string[] args)
    {
      while (true)
    {
      Console.Clear();
      Console.WriteLine("Menu di Selezione");
      Console.WriteLine("1. Opzione uno");
      Console.WriteLine("2. Opzione due");
      Console.WriteLine("3. Opzione tre");
      Console.WriteLine("4. Esci");

      Console.Write("Inserisci il numero dell'opzione desiderata");
      string input = Console.ReadLine();
      
      switch(input)
      {
        case "1":
          Console.WriteLine("Hai scelto l'opzione 1");
          // inserire qui la logica per l'opzione 1
          break;        
        case "2":
          Console.WriteLine("Hai scelto l'opzione 2");
          // inserire qui la logica per l'opzione 2
          break;        
        case "3":
          Console.WriteLine("Hai scelto l'opzione 3");
          // inserire qui la logica per l'opzione 3
          break;        
        case "4":
          Console.WriteLine("Uscita in corso...");
          return;        
        default: 
          Console.WriteLine("Selezione non valida. Riprova.");
          break;
      }
      Console.WriteLine("Premi un tasto per continuare");
      Console.ReadKey(); // aspetta che l'utente prema un tasto prima di continuare
    }
    }
  }
```

### 37 - Creo un programma che legge i comandi con cmd: 

```c#

class Program37 
  {
    static void Main(string[] args)
    {
       while (true)
    {
      string input = Console.ReadLine();
      
      if (input.StartsWith("cmd:"))
      {
        string comando = input.Substring(4);
        switch (comando.ToLower()) 
        {
        case "info":
          Console.WriteLine("Comando info riconosciuto. Mostro le informazioni");
          break;        
        case "exit":
          Console.WriteLine("Comando exit riconosciuto. Uscita in corso...");
          return; // esce dal programma
        default: 
          Console.WriteLine($"Comando {comando} non riconosciuto.");
          break;
      }
      }
      else
      {
        Console.WriteLine("Input non valido. Inserisci un comando");
      }
        Console.WriteLine("\n Inserisci un altro comando:");
    }
    }
  }
```


### 38 - Creo un programma che legge i comandi con cmd: e un secret path con la password

```c#

class Program38
  {
    static void Main(string[] args)
    {
      var nome = "Giammarco";
    Console.WriteLine("Inserisci un comando che parta con cmd:");
    while (true)
    {
      string? input = Console.ReadLine();

      if (input.StartsWith("cmd:"))
      {
        string comando = input.Substring(4);
        switch (comando.ToLower())
        {
          case "info":
            Console.WriteLine("Comando info riconosciuto. Mostro le informazioni");
            break;
          case "name":
            Console.WriteLine($"Ciao {nome}");
            break;
          case "exit":
            Console.WriteLine("Comando exit riconosciuto. Uscita in corso...");
            return; // esce dal programma
          default:
            Console.WriteLine($"Comando {comando} non riconosciuto.");
            break;
        }
      }
      else if (input == "secret")
      {
        Console.WriteLine("Secret informations. Password required");
        string? password = Console.ReadLine();
        if (password == "ciao")
        {
          Console.Write("Good Job: Babbo Natale non esiste!");
          return;
        }
        else {
          Console.Write("Wrong password");
          break;
        }
      }
      else
      {
        Console.WriteLine("Input non valido. Inserisci un comando");
      }
      Console.WriteLine("\n Inserisci un altro comando:");
    }
    }
  }
```

### 39 - drag and drop

```c#

class Program39
  {
    static void Main(string[] args)
    {
    Console.WriteLine ("Trascina un file qui e premi invio");
    string filePath = Console.ReadLine().Trim('"'); 
    // trim rimuove le virgolette che possono apparire nel percorso
    try 
    {
      string content = File.ReadAllText(filePath);
      Console.WriteLine("Contenuto del file:");
      Console.WriteLine(content);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Si e' verificato un errore: {ex.Message}");
    }
    }
  }
```
### 40 - Qualche metodo console

```c#

class Program40
  {
    static void Main(string[] args)
    {
      Console.Beep(); // fa partire un suono per segnalare magari un errore
      Console.Beep(750, 300); // frequenza in hz, durata in ms
      Console.Clear() // pulisce tutto il testo della console
      Console.CursorVisible = bool; // rende visibile (true) o invisibile (false) il cursore
      Console.Title = "La mia applicazione web" // setta il titolo della tua finestra console
    }
  }
```
### 41 - menu con il do while

```c#

class Program41
  {
    static void Main(string[] args)
    {
       Console.Clear(); // pulisce la schermata iniziale
    bool continua = true;
    do
    {
      Console.Clear(); // pulisce la schermata a ogni giro
      
      Console.WriteLine("Menu di Selezione");
      Console.WriteLine("1. Opzione uno");
      Console.WriteLine("2. Opzione due");
      Console.WriteLine("3. Opzione tre");
      Console.WriteLine("4. Esci");

      Console.WriteLine("Inserisci il numero dell'opzione desiderata");
      string? scelta = Console.ReadLine();

      switch (scelta)
      {
        case "1":
          Console.WriteLine("Hai scelto l'opzione 1");
          // inserire qui la logica per l'opzione 1
          break;
        case "2":
          Console.WriteLine("Hai scelto l'opzione 2");
          // inserire qui la logica per l'opzione 2
          break;
        case "3":
          Console.WriteLine("Hai scelto l'opzione 3");
          // inserire qui la logica per l'opzione 3
          break;
        case "4":
          Console.WriteLine("Uscita in corso...");
          return;
        default:
          Console.WriteLine("Selezione non valida. Riprova.");
          break;
      }
      if (continua)
      {
        Console.WriteLine("Premi un tasto per continuare");
        Console.ReadKey(); // aspetta che l'utente prema un tasto prima di continuare
      }
    }
    while (continua);
    }
  }
```
### 42 - funny usage of do while (esegue almeno una volta il codice, poi verifica la condizione) 

```c#

class Program42
  {
    static void Main(string[] args)
    {
      int i = 0;

      do
      {
        Console.WriteLine("i = {0}", i);
        i++;

      } while (i > 5);

    }
  }
```
### 43 - Task asincrono che aspetta un timeout 

```c#

class Program43
  {
   
    int timeoutInSeconds = 5;
    Task inputTask = Task.Run(() =>
    {
        Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi:");
        return Console.ReadLine();
    });

    Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

    if (await Task.WhenAny(inputTask, delayTask) == inputTask)
    {
        // l'utente ha inserito un input o un delay task
        string input = await (inputTask as Task<string>);
        Console.WriteLine($"Hai inserito: {input}");
    }
    else
    {
        Console.WriteLine("Tempo scaduto mf!");
    }

  }
```
### 44 - programmino personale utilizzando le cose imparate finora

```c#

class Program44
  {
    static void Main(string[] args)
    {
    Dictionary<string, int> famiglia = new()
    {
      {"Carlo", 25},
      {"Elvis", 30},
      {"Simone", 40},
      {"Giovanna", 60},
      {"Maurizio", 65},
    };

    Console.WriteLine("nella mia famiglia ci sono:");

    foreach (string key in famiglia.Keys) 
    {
      Console.WriteLine($"{key}");
    }
      
      bool uscita = true;
      while (uscita)
      { 
 
      Console.WriteLine("Di chi vuoi sapere l'eta?");
      string? scelta = Console.ReadLine();
      switch (scelta)
        {
          case "Giovanna":
            Console.WriteLine("Non si chiede l'eta' di una signora");
            break;
          case "Carlo":
            Console.WriteLine($"io ho {famiglia[scelta]} anni");
            break;
          case "Elvis": case "Simone": case "Maurizio":
            Console.WriteLine($"{scelta} ha {famiglia[scelta]} anni");
            break;
          case "x": 
            Console.WriteLine($"{scelta} uscita in corso");
          return;
          default: 
            Console.WriteLine($"{scelta} scelta non valida");
          return;
        }
      }
    }
  }
```
### 45 - come fare una funzione asincrona senza i Task e con il codice che ti aspetta se inizi a scrivere un input

```c#

class Program45
  {
    static void Main(string[] args)
    {
     int timeoutInSeconds = 5;
    Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi:");

    bool inputReceived = false; // inizializza input come non ricevuto finche non si verifica il Console.KeyAvailable
    string? input = ""; // una variabile di tipo stringa assegna un valora a input all'interno del ciclo e poi accerdere a quel valore anche al di fuori del ciclo
    DateTime endTime = DateTime.Now.AddSeconds(timeoutInSeconds); // DateTime restituisce l'ora corrente a cui aggiungiamo i 5 secondi della nostra variabile
    // il risultato sara' percio' una nuova data (oggi tra 5 secondi) ossia il momento in cui dovra' finire il tempo d'attesa

    while (DateTime.Now < endTime)
    {
      if (Console.KeyAvailable) // verifica se e' stato premuto un tasto
      {
        input = Console.ReadLine();
        inputReceived = true; // Dato che il valore di input viene controllato dopo il ciclo riesce a determinare se l'utente ha inserito qualcosa
        break;
      } 
    }

    Thread.Sleep(1300); // piccola pausa per ridurre il carico sulla CPU (serve per non far spammare o se vuoi vedere un messaggio per un po' di tempo)

    if (inputReceived)
    {
      Console.WriteLine($"Hai inserito: {input}");
    }
    else 
    {
      Console.WriteLine("Tempo scaduto!");
    }

    }
  }
```
### 46 - Thread sleep che fa ripetere un ciclo for una volta al secondo (con un secondo di pausa tra uno e l'altro)

```c#

class Program46
  {
    static void Main(string[] args)
    {
      for (int i = 0; i < 4; i++)
      {
        Console.WriteLine("dormi un secondo");
        Thread.Sleep(1000); // piccola pausa per ridurre il carico sulla CPU (serve per non far spammare o se vuoi vedere un messaggio per un po' di tempo)
      }
      Console.WriteLine("Tempo scaduto!");
    }
  }
```
### 47 - Utilizzare la classe Random con il metodo Next() e il costruttore new

```c#

class Program47
  {
    static void Main(string[] args)
    {
      Random random = new Random();
      int somma = 0;
      for (int i = 0; i < 10; i++)
      {
        int numero = random.Next(1,11); // intervallo semiaperto genera un numero tra 1 e 10
        somma += numero; // somma uguale a se stessa piu' numero >> al primo giro 0 + (numero random da 1 a 10) 
        Console.WriteLine($"il numero casuale e' {numero}");
      }
      Console.WriteLine($"La somma e' {somma}");
    }
  }
```
### 48 - Utilizzare la classe Random con il metodo Next() e il costruttore new con aggiunta di parziale e Thread.Sleep

```c#

class Program48
  {
    static void Main(string[] args)
    {
      Random random = new();
      int somma = 0;
      for (int i = 0; i < 5; i++)
      {
        int numero = random.Next(1, 11); // genera un numero tra 1 e 10
        somma += numero; // somma uguale a se stessa piu' numero 
        Console.Write("il numero casuale e' "); // utilizzo Console.Write per non andare a capo
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{numero}");
        Console.ResetColor(); // resettato il colore di default

        Thread.Sleep(500); // inserito una piccola pausa
        Console.WriteLine($"il parziale e' {somma}");
        Thread.Sleep(500);
      }
      Console.Write($"La somma e' ");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"{somma}");
      Console.ResetColor(); 
    }
  }
```
### 49 - Utilizzare Random.Next() per creare 10 numeri da 1 a 10 e calcolare la loro media

```c#

class Program49
  {
    static void Main(string[] args)
    {
      Random random = new Random();
      int somma = 0;
      for (int i = 0; i < 10; i++)
      {
        int numero = random.Next(1,11); // intervallo semiaperto genera un numero tra 1 e 10
        somma += numero; // somma uguale a se stessa piu' numero >> al primo giro 0 + (numero random da 1 a 10) 
        Console.WriteLine($"il numero casuale e' {numero}");
      }
      Console.WriteLine($"La somma e' {somma}");
    }
  }
```