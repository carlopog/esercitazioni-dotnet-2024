class Program
{
    static void Main(string[] args)
    {
        // semplice calcolatrice con quattro operatori e selettore switch
        int x, y, risultato = 0;
        string? input, outputString = "";

        do
        {
            Console.Clear();

            Console.WriteLine("**********************");
            Console.WriteLine("**** CALCOLATRICE ****");
            Console.WriteLine("**********************");
            Console.WriteLine("**  +  somma        **");
            Console.WriteLine("**  *  prodotto     **");
            Console.WriteLine("**  -  sottrazione  **");
            Console.WriteLine("**  /  divisione    **");
            Console.WriteLine("**********************\n");

            Console.WriteLine("Inserisci il primo numero");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out x))) // controllo sul primo numero inserito
            {
                Console.WriteLine("Devi inserire un numero intero");
                Console.Write("Inserisci il primo numero: ");
                input = Console.ReadLine();
            }

            Console.Write("Inserisci il secondo numero: ");
            input = Console.ReadLine();

            while (!(int.TryParse(input, out y))) // controllo sul secondo numero inserito
            {
                Console.WriteLine("Devi inserire un numero intero");
                Console.Write("Inserisci il secondo numero: ");
                input = Console.ReadLine();
            }

            Console.Write("Seleziona opzione: ");
            input = Console.ReadLine();

        Verifica:
            switch (input)
            {
                case "+":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x + y;
                    outputString = "La somma";
                    break;

                case "*":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x * y;
                    outputString = "Il prodotto";
                    break;

                case "-":       // esegue la somma tra due numeri e visualizza il risultato
                    risultato = x - y;
                    outputString = "La sottrazione";
                    break;

                case "/":       // esegue la somma tra due numeri e visualizza il risultato
                    while (y == 0)
                    {
                        Console.WriteLine("Non puoi dividere per ZERO!");
                        while (!(int.TryParse(input, out y)) || (int.Parse(input) == 0)) // controllo sul secondo numero inserito
                        {
                            Console.WriteLine("Devi inserire un numero intero");
                            Console.Write("Inserisci il secondo numero: ");
                            input = Console.ReadLine();
                        }

                    }
                    risultato = x / y;
                    int resto = x % y;
                    outputString = "La divisione";
                    break;

                default:
                    Console.WriteLine("Selezione errata.");
                    Console.Write("Seleziona opzione: ");
                    input = Console.ReadLine();
                    goto Verifica;

            }
            Console.WriteLine($"{outputString} tra {x} e {y} = {risultato}");
            Console.WriteLine("Vuoi continuare? s/n");
            input = Console.ReadLine();
            if (input == "n")
            {
                return;
            }
        }
        while (true);
    }

}