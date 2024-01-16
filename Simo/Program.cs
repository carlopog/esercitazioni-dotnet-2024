class Program
{
    static async Task Main(string[] args)
    {

        int freq, ms; // variabili per le opzioni 5, 6 per ora son tutte vuote
        bool continua; // variabile per opzione 9
        string? prodotto = ""; // variabile per opzione 9
        List<string> listaSpesa = new List<string>(); // lista per opzione 9
                                                      // listaSpesa.Add("Vuota"); // prova di debug
                                                      // System.Console.WriteLine(listaSpesa.Count);

        do
        {
            Console.Clear(); // pulisce lo schermo

            // stampa il menu
            System.Console.WriteLine("Menu delle opzioni:");
            System.Console.WriteLine("1 - Drag&Drop"); // ti fa leggere il testo dei documenti che ci trascini
            System.Console.WriteLine("2 - Emetti beep prolungato");
            System.Console.WriteLine("3 - Crea melodia random");
            System.Console.WriteLine("4 - Timeout della console");
            System.Console.WriteLine("5 - Lista della spesa");
            System.Console.WriteLine("e - exit\n");
            System.Console.Write("Scegli un'opzione: ");

            string? input = Console.ReadLine().ToLower(); // prende anche input maiuscoli



            switch (input)
            {
                case "1":
                    // drag & drop
                    System.Console.WriteLine("Hai selezionato l'opzione 1");
                    System.Console.WriteLine("Trascina qui dentro un file...");

                    string? filePath = Console.ReadLine().Trim('"'); // rimuove le virgolette
                    System.Console.WriteLine("Premi invio...");
                    Console.ReadLine();

                    try // try e catch sono usati nei casi in cui potrebbero esserci degli errori in combinazione
                    {
                        string contenuto = File.ReadAllText(filePath); // qui gli dico di leggere il testo col metodo
                        System.Console.WriteLine("Contenuto del file: "); 
                        System.Console.WriteLine(contenuto);
                    }
                    catch (Exception ex) // catch prende gli errori e li gestisce
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}");
                      // gestione dell'errore a seconda del tipo specificando all'utente cos'e' successo
                    }
                    break;

                case "2":
                    System.Console.WriteLine("Hai selezionato l'opzione 2");
                    System.Console.WriteLine("Inserisci la frequenza");
                    freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "3":
                    //
                    System.Console.WriteLine("Hai selezionato l'opzione 3");
                    System.Console.WriteLine("Inserisci il numero di note");

                    int count = Int32.Parse(Console.ReadLine());
                    var random = new Random(); // variabile random

                    for (int i = 0; i < count; i++)
                    {
                        freq = random.Next(1, 20) * 100; // crea un numero random tra 1 e 20 e lo moltiplica per 100
                        Console.Beep(freq, 300); // la singola nota avra' freq tra 100 e 2000 e dura mezzo secondo
                    }
                    break;


                case "4":
                    System.Console.WriteLine("Hai selezionato l'opzione 4");
                    System.Console.Write("Inserisci un timer per la console in secondi: ");
                    int timeoutInSeconds = Int32.Parse(Console.ReadLine());

                    Task inputTask = Task.Run(() =>
                    {
                        Console.WriteLine($"Inserisici un input entro {timeoutInSeconds} secondi:");
                        return Console.ReadLine();
                    });

                    Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

                    if (await Task.WhenAny(inputTask, delayTask) == inputTask)
                    {
                        // l'utente ha inserito un input
                        input = await (inputTask as Task<string>);
                        Console.WriteLine($"Hai inserito: {input}");
                    }
                    else
                    {
                        // il tempo è scaduto
                        System.Console.WriteLine("Tempo scaduto!");
                        Console.WriteLine("Non hai inserito una mazzas");
                        
                        // TODO dopo questa cosa dovrebbe uscire invece aspetta che gli scriva qualcosa
                    }
                    break;

                case "5":

                    do
                    {
                        Console.Clear();

                        System.Console.WriteLine("Hai selezionato l'opzione 5");
                        System.Console.WriteLine("Lista della spesa:");
                        System.Console.WriteLine("v - Visualizza lista");
                        System.Console.WriteLine("a - Aggiungi");
                        System.Console.WriteLine("d - Elimina");
                        System.Console.WriteLine("r - Torna indietro\n");
                        System.Console.Write("Scegli un'opzione: ");

                        input = Console.ReadLine().ToLower(); // prende anche input minuscoli
                        continua = true;

                        switch (input)
                        {
                            case "v":
                                // visualizza gli elementi salvati nella lista
                                Console.Clear();

                                if (listaSpesa.Count != 0)
                                {
                                    System.Console.WriteLine("Lettura lista..\n");
                                    foreach (string elemento in listaSpesa)
                                    {
                                        Console.WriteLine($"- {elemento}");
                                    }
                                    System.Console.WriteLine("\nPremi per continuare...");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    System.Console.WriteLine("\nLista vuota\n");
                                    System.Console.WriteLine("Premi per continuare...");
                                    Console.ReadKey();
                                }

                                break;

                            case "a":
                                // aggiunge elementi alla lista senza ripetizioni
                                bool inserisci = true;

                                while (inserisci)
                                {
                                    Console.Clear();

                                    System.Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    System.Console.Write("Inserisci un prodotto: ");


                                    ConsoleKeyInfo keyInfo = Console.ReadKey(); // salva il primo carattere digitato

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0) // verifica se ho premuto 'ctrl'
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            System.Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {

                                        prodotto = keyInfo.Key + Console.ReadLine(); // concateno per non perdere il primo elemento
                                                                                         // Console.WriteLine($"Prova inserimento {prodotto}"); // debug
                                                                                         // System.Console.WriteLine("Premi invio..");
                                                                                         // Console.ReadLine();

                                        while (listaSpesa.Contains(prodotto)) // controlla che l elemento sia unico nella lista
                                        {
                                            System.Console.WriteLine("Hai gia inserito questo prodotto.");
                                            System.Console.Write("Riprova... ");
                                            prodotto = Console.ReadLine();
                                        }

                                        listaSpesa.Add(prodotto);
                                        System.Console.WriteLine($"Hai inserito '{prodotto}'\n");
                                        Thread.Sleep(1000);
                                    }
                                }

                                break;

                            case "d":
                                // elimina un elemento se nella lista
                                Console.Clear();

                                System.Console.WriteLine("Elimina prodotti");
                                if (listaSpesa.Count != 0) // se la lista non è gia vuota esegue il codice
                                {
                                    System.Console.WriteLine("Premi 'ctrl'+'h' per terminare");
                                    System.Console.Write("Inserisci il prodotto da eliminare: ");

                                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                                    if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
                                    {
                                        if (keyInfo.Key == ConsoleKey.H)
                                        {
                                            System.Console.WriteLine("\nFine inserimento..");
                                            inserisci = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        prodotto = keyInfo.KeyChar + Console.ReadLine();

                                        while (!(listaSpesa.Contains(prodotto)))
                                        {
                                            System.Console.WriteLine($"'{prodotto}' non presente nella lista");
                                            System.Console.WriteLine("Ecco la lista completa:");
                                            foreach (string elemento in listaSpesa)
                                            {
                                                System.Console.WriteLine($"- {elemento}");
                                            }
                                            System.Console.Write("\nQuale prodotto vuoi eliminare? ");
                                            prodotto = Console.ReadLine();

                                        }
                                        listaSpesa.Remove(prodotto);
                                        System.Console.WriteLine($"Hai eliminato '{prodotto}' dalla lista");
                                    }

                                }
                                else
                                {
                                    System.Console.WriteLine("La lista della spesa è vuota");
                                }
                                break;

                            case "r":
                                // torna al menu principale se premiamo 'r'
                                System.Console.WriteLine("Salvataggio lista...");

                                // attende 1 secondi prima di proseguire per simulare un salvataggio
                                Thread.Sleep(1200);

                                System.Console.WriteLine("Fatto!");
                                continua = false;
                                break;

                            default:
                                // errore di selezione
                                System.Console.WriteLine("Selezione errata. Riprova");
                                break;

                        }
                    }
                    while (continua);

                    break;

                case "e":
                    System.Console.WriteLine("Uscita in corso...");
                    return;

                default:
                    System.Console.WriteLine("Selezione errata. Riprova");
                    break;

            }

            System.Console.WriteLine("\nPremi un tasto per continuare...");
            Console.ReadKey();

        }
        while (true);

    }

}
