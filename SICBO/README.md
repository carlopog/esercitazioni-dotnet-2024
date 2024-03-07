### TODO

- [ ] creare il metodo Scommessa() restituisce int vincita
- [ ] creare int quota = 0
- [ ] creare bool win = true
- [ ] ? creare il metodo ScegliTipoScommessa() restituisce int tipo [in view]
- [ ] creare il metodo TipoScommessa(int tipo) restituisce int quota, int prezzo e int vittoria (0 / 1)
- [ ] creare un metodo per ogni tipo di scommessa:
- [ ] ValoreSingolo()
- [ ] Doppia()
- [ ] Combinazione()
- [ ] Tripla(string gs) 
- [ ] Totale(string tipologia)
- [ ] if (vittoria = 0) { win = false } else { win = true }

```c#
    public int ScegliTipoScommessa()
    {
      int tipo = 0;
      Inizio:
      Console.WriteLine("1. ");
      int scelta = ReadInt("scegli tipo", 1, 6)
      switch (scelta)
      {
        case 1: 
        {
          ValoreSingolo();
        }
        case 2: 
        {
          Doppia();
        }
        case 3: 
        {
          Combinazione();
        }
        case 4:
        {
          GenericoSpecifico:
          Console.WriteLine("Vuoi scommettere su una tripla generica o specifica? g / s");
          string gs = Console.ReadLine()!;
           if (gs == "g") 
           {
            Tripla("g");
           } 
           else if (gs == "s") 
           {
            Tripla("s");
           }
           else
           {
            Console.WriteLine("non è un input valido");
            goto GenericoSpecifico;
           }
        }
        case 5:
        {
          GS:
          Console.WriteLine("Vuoi scommettere su un totale generico o specifico? g / s");
          string gs = Console.ReadLine()!;
           if (gs == "g") 
           {
            Console.WriteLine("1. ");
            int choice = ReadInt("scegli tipo di totale", 1, 5)
            switch (choice)
            {
               case 1: 
               {
                Totale("pari");
               }
               case 2: 
               {
                Totale("dispari");
               }
               case 3: 
               {
                Totale("alto");
               }
               case 4: 
               {
                Totale("basso");
               }
            }
           } 
           else if (gs == "s") 
           {
            Totale("specifico");
           }
           else
           {
            Console.WriteLine("non è un input valido");
            goto GS;
           }
        }
        default:
        {
          goto Inizio;
        }
      }
    }
    public int[] TipoScommessa(int tipo, string name)
      {
        int quota = 1;
          switch (tipo)
          {
            case 1:
            {
              quota = 2;
              Console.WriteLine("7. ");
              
              break;
            }
          }
          ScriviColorato("blu", $"La quota della tua scommessa è {quota}x")
          int prezzo = ValidaInput.ReadInt("quanti euro vuoi scommettere");
          AggiungiScommessa(name, prezzo); // aggiorna lastbet
      }

    public int Scommessa(string name) // ritorna la vincita
    {
      int quota = 0;        
      int vittoria = 1;        
      bool win = true;
      int vincita = 0;
      
      int tipo = ScegliTipoScommessa();

      int[] dati = TipoScommessa(tipo, name); // restituisce [quota, prezzo, vittoria]
      quota = dati[0];
      vittoria = dati[1];

      if (vittoria = 0) 
      { 
        win = false; 
      }

      if (win)
      {
        vincita = quota * prezzo;
      }
      else
      {
        vincita = -prezzo; 
      }
      return vincita;
    }
    ModificaVincita(name, vincita); // aggiorna anche il bottino


```