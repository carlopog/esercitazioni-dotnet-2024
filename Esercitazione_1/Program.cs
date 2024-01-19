class Program
{
    static void Main(string[] args)
    {
        int toprand = 1001;
        Random random = new Random();
        int numero = random.Next(1, toprand);
        Console.WriteLine("Indovina il numero sorteggiato");
        int tentativi = 0;
        
        while (true)
        {
            // suggerisci la somma delle cifre del numero
            int somma = 0;
            int numeroTemporaneo = numero;
            while (numeroTemporaneo > 0)
            {
                somma += numeroTemporaneo % 10;
                numeroTemporaneo /= 10;
            }

            int tentativo = int.Parse(Console.ReadLine()!);
            tentativi++;
            if (tentativo == numero)
            {
                Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
                break;
            }
            else
            {
                if (tentativo > numero)
                {
                    Console.WriteLine("Il numero è minore");
                }
                else
                {
                    Console.WriteLine("Il numero è maggiore");
                }
                Console.WriteLine($"La somma delle cifre del numero è {somma}");
            }
            if (tentativi == 5)
            {
                Console.WriteLine("Hai esaurito i tentativi");
                // stampa il numero da indovinare
                Console.WriteLine($"Il numero da indovinare era {numero}");

                break;
            }
        }
    }
}