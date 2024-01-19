
    class Program
{
    static void Main(string[] args)
    {
        int punteggio = 0;
        while (true)
        {
            Random random = new Random();
            int numero = random.Next(1, 11);
            Console.WriteLine("Indovina il numero sorteggiato");
            int tentativi = 0;
            while (true)
            {
                int tentativo = int.Parse(Console.ReadLine()!);
                tentativi++;
                if (tentativo == numero)
                {
                    Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
                    punteggio += 10 - tentativi;
                    Console.WriteLine($"Il tuo punteggio è {punteggio}");
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
                }
                if (tentativi == 10)
                {
                    Console.WriteLine("Hai esaurito i tentativi");
                    break;
                }
            }
            Console.WriteLine("Vuoi continuare? (s/n)");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }
    }
}