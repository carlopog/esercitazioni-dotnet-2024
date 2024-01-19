class Program
{
    static void Main(string[] args)
    {
        // semplice calcolatrice con quattro operatori e selettore switch
        int x, y, risultato;
        string? input;

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

            Console.Write("Seleziona opzione: ");

            input = Console.ReadLine();

            switch (input)
            {
                case "+":       // esegue la somma tra due numeri e visualizza il risultato
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

                    risultato = x + y;
                    Console.WriteLine($"La somma tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();


                    break;

                case "*":       // esegue la somma tra due numeri e visualizza il risultato
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

                    risultato = x * y;
                    Console.WriteLine($"Il prodotto tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                case "-":       // esegue la somma tra due numeri e visualizza il risultato
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

                    risultato = x - y;
                    Console.WriteLine($"La sottrazione tra {x} e {y} = {risultato}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                case "/":       // esegue la somma tra due numeri e visualizza il risultato
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

                    while (!(int.TryParse(input, out y)) || (int.Parse(input) == 0)) // controllo sul secondo numero inserito
                    {
                        Console.WriteLine("\nATTENZIONE!!!\nDevi inserire un numero intero e diverso da ZERO\n");
                        Console.Write("Inserisci il secondo numero: ");
                        input = Console.ReadLine();
                    }

                    risultato = x / y;
                    int resto = x % y;
                    Console.WriteLine($"La divisione intera tra {x} e {y} = {risultato} con resto {resto}");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();

                    break;

                default:
                    Console.WriteLine("Selezione errata.");
                    Console.WriteLine("Premi per continuare...");
                    Console.ReadKey();
                    break;

            }

        }
        while (true);
    }

}