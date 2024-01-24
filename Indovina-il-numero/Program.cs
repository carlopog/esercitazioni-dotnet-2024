class Program
{
	// creo una funzione che prende due argomenti e restituisce true se il primo è maggiore del secondo
	static bool Maggiore(int a, int b) 
	{
		if (a > b)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	// creo una funzione che prende tre argomenti e restituisce true se il primo è maggiore del secondo e minore uguale del terzo
	// quindi ritorna true se il primo e' compreso tra gli altri due 
	static bool Intervallo(int a, int b, int c)
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
			int x = random.Next(1, 101); // creo un numero casuale da 1 a 100 
			int tentativi = 10; // metto staticamente dieci tentativi
			int input = 0; // inizializzo la variabile input
			Console.WriteLine("Prova ad indovinare il numero segreto");
			{
				try
				{
					input = int.Parse(Console.ReadLine()!); // assegno il valore digitato dall'utente alla variabile input se ha digitato un intero 
				}
				catch (Exception e)
				{
					Console.BackgroundColor = ConsoleColor.Magenta;
					Console.WriteLine("non e' un numero valido, hai sprecato un tentativo"); 
					Console.ResetColor();
					Console.WriteLine("");
				}
			}

			while (tentativi >= 0) // finchè non arrivi a zero tentativi si ripete questo ciclo
			{
				if (input == x) // se input digitato è uguale al numero segreto (hai indovinato)
				{
					Console.BackgroundColor = ConsoleColor.Green; // coloro
					Console.WriteLine("Che fortuna hai indovinato!!!");
					int giri = 10 - tentativi; // creo la variabile giri che sarebbero i tentativi usati per indovinare
					punteggio += tentativi; // il punteggio è dato dai tentativi rimanenti
					Console.WriteLine($"Hai indovinato in {giri} tentativi");
					Console.ResetColor();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"\n il tuo punteggio e' {punteggio}\n");
					Console.ResetColor();
					for (int i = 0; i < 3; i++) // per 3 volte
					{
						Console.Write("---   "); // disegno questi trattini per separare
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
					tentativi--; // se non hai indovinato il numero ti leva un tentativo
					Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");
					Console.ResetColor();

					Console.ForegroundColor = ConsoleColor.Blue;
					switch (tentativi) // a seconda di quanti tentativi ti rimangono succederanno cose diverse
					{
						case 9:
							{
								Console.WriteLine($"il numero e' Maggiore di 50? {Maggiore(x, 50)}"); // ti dice se è maggiore di 50
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
								if (Maggiore(x, 50)) // se è maggiore di 50
								{
									Console.WriteLine($"il numero e' Maggiore di 75? {Maggiore(x, 75)}"); // controllo se sia maggiore di 75
									break;
								}
								Console.WriteLine($"il numero e' Maggiore di 25? {Maggiore(x, 25)}"); // se è minore di 50 controllo se sia maggiore di 25
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
								if (Intervallo(x, 75, 100)) // a seconda delle risposte precedenti so in che intervallo sta il numero segreto
								{
									Console.WriteLine($"il numero e' Maggiore di 90? {Maggiore(x, 90)}"); // ti dà consigli specifici in base all'intervallo in cui si trova
									break;
								}
								else if (Intervallo(x, 50, 75))
								{
									Console.WriteLine($"il numero e' Maggiore di 60? {Maggiore(x, 60)}");
									break;
								}
								else if (Intervallo(x, 25, 50))
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
								if (x > 10) // se il numero segreto è un numero a due (o tre) cifre
								{
									int somma = 0;
									somma += x % 10; //aggiungo a somma l'ultima cifra di num;
									int a = x / 10;
									somma += a; //divido num per 10, essendo il risultato intero non conterà la parte decimale
									Console.WriteLine($"La somma delle cifre che compongono il numero e' {somma}");
								}
								break;
							}
						case 3:
							{
								if (Intervallo(x, 0, 10))
								{
									Console.WriteLine($"il numero e' Maggiore di 5? {Maggiore(x, 5)}");
									break;
								}
								else if (Intervallo(x, 10, 25))
								{
									Console.WriteLine($"il numero e' Maggiore di 20? {Maggiore(x, 15)}");
									break;
								}

								else if (Intervallo(x, 25, 40))
								{
									Console.WriteLine($"il numero e' Maggiore di 30? {Maggiore(x, 35)}");
									break;
								}
								else if (Intervallo(x, 40, 50))
								{
									Console.WriteLine($"il numero e' Maggiore di 45? {Maggiore(x, 45)}");
									break;
								}
								else if (Intervallo(x, 50, 60))
								{
									Console.WriteLine($"il numero e' Maggiore di 55? {Maggiore(x, 55)}");
									break;
								}
								else if (Intervallo(x, 60, 75))
								{
									Console.WriteLine($"il numero e' Maggiore di 65? {Maggiore(x, 65)}");
									break;
								}
								else if (Intervallo(x, 75, 90))
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
							input = int.Parse(Console.ReadLine()!); // faccio inserire un nuovo valore a input all'utente, ripetendo il controllo che sia un numero valido
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

	private static bool Maggiore() // questo mi si è autogenerato quando ho creato la funzione, non so cosa faccia ma senza mi dà errore
	{
		throw new NotImplementedException();
	}
}