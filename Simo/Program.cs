class Program
{
    static async Task Main(string[] args)
    {

        int freq, ms; // variabili per le opzioni 5, 6
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
            System.Console.WriteLine("1 - Nascondi il cursore");
            System.Console.WriteLine("2 - Mostra il cursore");
            System.Console.WriteLine("3 - Drag&Drop");
            System.Console.WriteLine("4 - Emetti beep");
            System.Console.WriteLine("5 - Emetti beep prolungato");
            System.Console.WriteLine("6 - Crea melodia random");
            System.Console.WriteLine("7 - Saluto!");
            System.Console.WriteLine("8 - Timeout della console");
            System.Console.WriteLine("9 - Lista della spesa");
            System.Console.WriteLine("e - exit\n");
            System.Console.Write("Scegli un'opzione: ");

            string? input = Console.ReadLine().ToLower(); // prende anche input maiuscoli



            switch (input)
            {
                case "1":
                    System.Console.WriteLine("Hai selezionato l'opzione 1");
                    Console.CursorVisible = false;
                    break;

                case "2":
                    System.Console.WriteLine("Hai selezionato l'opzione 2");
                    Console.CursorVisible = true;
                    break;

                case "3":
                    // drag & drop
                    System.Console.WriteLine("Hai selezionato l'opzione 3");
                    System.Console.WriteLine("Trascina qui dentro un file...");

                    string? filePath = Console.ReadLine().Trim('"'); // rimuove le virgolette
                    System.Console.WriteLine("Premi invio...");
                    Console.ReadLine();

                    try
                    {
                        string contenuto = File.ReadAllText(filePath);
                        System.Console.WriteLine("Contenuto del file: ");
                        System.Console.WriteLine(contenuto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}");

                    }
                    break;

                case "4":
                    System.Console.WriteLine("Hai selezionato l'opzione 4");
                    Console.Beep();
                    break;

                case "5":
                    System.Console.WriteLine("Hai selezionato l'opzione 5");
                    System.Console.WriteLine("Inserisci la frequenza");
                    freq = Int32.Parse(Console.ReadLine());

                    System.Console.WriteLine("Inserisci durata in ms");
                    ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    //
                    System.Console.WriteLine("Hai selezionato l'opzione 6");
                    System.Console.WriteLine("Inserisci un valore tra 1 a 10");

                    int count = Int32.Parse(Console.ReadLine());
                    var random = new Random(); // variabile random

                    for (int i = 0; i < count; i++)
                    {
                        freq = random.Next(1, 10) * 100; // crea un numero random tra 100 e 1000
                        Console.Beep(freq, 500);
                    }
                    break;

                case "7":
                    System.Console.WriteLine("Hai selezionato l'opzione 7");
                    System.Console.WriteLine("Inserici il tuo nome");
                    string? nome = Console.ReadLine();

                    Console.WriteLine($"\nCiao {nome}, piacere di conoscerti!");
                    break;

                case "8":
                    System.Console.WriteLine("Hai selezionato l'opzione 8");
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
                        System.Console.WriteLine("Tempo scaduto! Premi invio...");
                    }
                    break;

                case "9":

                    do
                    {
                        Console.Clear();

                        System.Console.WriteLine("Hai selezionato l'opzione 9");
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
                                    Console.ReadLine();

                                }
                                else
                                {
                                    System.Console.WriteLine("\nLista vuota\n");
                                    System.Console.WriteLine("Premi per continuare...");
                                    Console.ReadLine();
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

                                        prodotto = Console.ReadLine(); // concateno per non perdere il primo elemento
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
            Console.ReadLine();

        }
        while (true);

    }

}
