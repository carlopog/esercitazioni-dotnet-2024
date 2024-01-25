class Program
{
  static void Main(string[] args)
  {
    string[] nomi = ["Franco", "Ciccio", "Mario"];
    List<string> lista = ["Merio"];

    foreach (string nome in nomi)
    {
      if (nome == "Mario")
      {
        lista.Add(nome);
      }
    }
    foreach (string mario in lista)
    {
      Console.WriteLine("scrivi il cognome");
      string? cognome = Console.ReadLine();
      Console.WriteLine($"ciao {mario} {cognome}");
    }
      Console.WriteLine("press any key");
      Console.ReadKey();
  }
}

/*  Esercizio: un array di stringhe con 3 nomi, cicliamo con un foreach, se il nome e' Mario, aggiungere a una lista 
 aggiungeremo un ReadKey e un ReadLine

per ciclare su un dictionary sempre con il foreach
ad esempio
			Dictionary<int, int> step = new()
								{
									{0, 10},
									{10, 25},
									{25, 40},
									{40, 50},
									{50, 60},
									{60, 75},
									{75, 90},
									{90, 100}
								};
								foreach (KeyValuePair<int, int> entry in step)
								{
									int y = (entry.Key + entry.Value) / 2;
									if (Func1(x, entry.Key, entry.Value))
									{
										Function2(x, y);
										break;
									}
								}

 */