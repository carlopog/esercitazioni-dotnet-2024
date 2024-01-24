class Program
{
	static bool Maggiore(int n, int m)
	{
		if (n > m)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	static bool Tra(int a, int b, int c)
	{
		if (a > b && a <= c)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	static void Main(string[] args)
	{
		int punteggio = 0;
		bool end = false;
		while (!end) // ripeto fino a quando non setto true end
		{
			Random random = new();
			int x = random.Next(1, 101);
			int tentativi = 10;
			int input = 0;
			Console.WriteLine("Prova ad indovinare il numero segreto");
			{
				try
				{
					input = int.Parse(Console.ReadLine()!);
				}
				catch (Exception e)
				{
					Console.BackgroundColor = ConsoleColor.Magenta;
					Console.WriteLine("non e' un numero, hai sprecato un tentativo");
					Console.ResetColor();
					Console.WriteLine("");
				}
			}

			while (tentativi >= 0)
			{
				if (input == x)
				{
					Console.BackgroundColor = ConsoleColor.Green;
					Console.WriteLine("Che fortuna hai indovinato!!!");
					int giri = 10 - tentativi;
					punteggio += tentativi;
					Console.WriteLine($"Hai indovinato in {giri} tentativi");
					Console.ResetColor();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"\n il tuo punteggio e' {punteggio}\n");
					Console.ResetColor();
					for (int i = 0; i < 3; i++)
					{
						Console.Write("---   ");
						Thread.Sleep(200);
					}
					Console.Write("\nVuoi continuare a giocare? ");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("s ");
					Console.ResetColor();
					Console.Write("/ ");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("n\n");
					Console.ResetColor();
					string risposta = Console.ReadLine()!;
					if (risposta == "n")
					{
						end = true;
					}
					break;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					tentativi--; // se non hai azzeccato ti leva un tentativo
					Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");
					Console.ResetColor();

					Console.ForegroundColor = ConsoleColor.Blue;
					switch (tentativi)
					{
						case 9:
							{
								Console.WriteLine($"il numero e' Maggiore di 50? {Maggiore(x, 50)}");
								break;
							}
						case 8:
							{
								bool pari = x % 2 == 0;
								Console.WriteLine($"il numero e' pari? {pari}");
								break;
							}
						case 7:
							{
								if (Maggiore(x, 50))
								{
									Console.WriteLine($"il numero e' Maggiore di 75? {Maggiore(x, 75)}");
									break;
								}
								Console.WriteLine($"il numero e' Maggiore di 25? {Maggiore(x, 25)}");
								break;
							}
						case 6:
							{
								if (input > x)
								{ Console.WriteLine($"il numero segreto e' minore di {input}"); }
								else
								{ Console.WriteLine($"il numero segreto e' Maggiore di {input}"); }
								break;
							}
						case 5:
							{
								if (Tra(x, 75, 100))
								{
									Console.WriteLine($"il numero e' Maggiore di 90? {Maggiore(x, 90)}");
									break;
								}
								else if (Tra(x, 50, 75))
								{
									Console.WriteLine($"il numero e' Maggiore di 60? {Maggiore(x, 60)}");
									break;
								}
								else if (Tra(x, 25, 50))
								{
									Console.WriteLine($"il numero e' Maggiore di 40? {Maggiore(x, 40)}");
									break;
								}
								else
								{
									Console.WriteLine($"il numero e' Maggiore di 10? {Maggiore(x, 10)}");
									break;
								}
							}
						case 4:
							{
								if (x > 10)
								{
									int somma = 0;
									somma += x % 10; //aggiungo a somma l'ultima cifra di num;
									int a = x / 10;
									somma += a; //divido num per 10, essendo intero non ci sarà parte decimale
									Console.WriteLine($"La somma delle cifre che compongono il numero e' {somma}");
								}
								break;
							}
						case 3:
							{
								if (Tra(x, 0, 10))
								{
									Console.WriteLine($"il numero e' Maggiore di 5? {Maggiore(x, 5)}");
									break;
								}
								else if (Tra(x, 10, 25))
								{
									Console.WriteLine($"il numero e' Maggiore di 20? {Maggiore(x, 15)}");
									break;
								}

								else if (Tra(x, 25, 40))
								{
									Console.WriteLine($"il numero e' Maggiore di 30? {Maggiore(x, 35)}");
									break;
								}
								else if (Tra(x, 40, 50))
								{
									Console.WriteLine($"il numero e' Maggiore di 45? {Maggiore(x, 45)}");
									break;
								}
								else if (Tra(x, 50, 60))
								{
									Console.WriteLine($"il numero e' Maggiore di 55? {Maggiore(x, 55)}");
									break;
								}
								else if (Tra(x, 60, 75))
								{
									Console.WriteLine($"il numero e' Maggiore di 65? {Maggiore(x, 65)}");
									break;
								}
								else if (Tra(x, 75, 90))
								{
									Console.WriteLine($"il numero e' Maggiore di 85? {Maggiore(x, 85)}");
									break;
								}
								else
								{
									Console.WriteLine($"il numero e' Maggiore di 95? {Maggiore(x, 95)}");
									break;
								}
							}
						case 0:
							{
								Console.BackgroundColor = ConsoleColor.DarkRed;
								Console.WriteLine($"HAI PERSO!\nIl numero era {x}"); // finito il ciclo while (e i tentativi) si arriva qua
								Console.ResetColor();
								return;
							}
					};
					Console.ResetColor();
					{
						try
						{
							input = int.Parse(Console.ReadLine()!);
						}
						catch (Exception e)
						{
							Console.BackgroundColor = ConsoleColor.Magenta;
							Console.WriteLine("Non e' un numero, hai sprecato un tentativo");
							Console.ResetColor();
							Console.WriteLine("");

						}
					}
				}
			}
		}
	}

	private static bool Maggiore()
	{
		throw new NotImplementedException();
	}
}