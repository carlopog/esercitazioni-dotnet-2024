class Program
{
	// creo una funzione che prende due argomenti e restituisce true se il primo è maggiore del secondo
	static void Maggiore(int x, int b)
	{
		if (x > b)
		{
			Console.WriteLine($"il numero segreto è Maggiore di {b}");
		}
		else
		{
			Console.WriteLine($"il numero segreto è Minore o Uguale a {b}");
		}
	}
	/* creo una funzione che prende tre argomenti e restituisce true se il primo è maggiore del secondo e minore uguale del terzo
	 quindi ritorna true se il primo e' compreso tra gli altri due */
	static bool Intervallo(int x, int b, int c)
	{
		if (x > b && x <= c)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	static int Ultimo(Array a)
	{
		return a.Length - 1;
	}
	static void Main(string[] args)
	{
		int punteggioPartita = 0;
		bool end = false;
		string pathNome = @"nome.txt";
		string pathScore = @"score.txt";
		string nome = File.ReadAllText(pathNome);
		while (!end) // ripeto fino a quando non setto true end
		{
			Random random = new();
			int x = random.Next(1, 101); // creo un numero casuale da 1 a 100 
			int tentativi = 10; // metto staticamente dieci tentativi
			int input = 0; // inizializzo la variabile input
			Console.WriteLine($"Ciao {nome},");
			Console.WriteLine("Prova ad indovinare il numero segreto tra 1 e 100");
			{
				try
				{
					input = int.Parse(Console.ReadLine()!); // assegno il valore digitato dall'utente alla variabile input se ha digitato un intero 
				}
				catch (Exception)
				{
					Console.BackgroundColor = ConsoleColor.Magenta;
					Console.WriteLine("Non è un numero valido, hai sprecato un tentativo");
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
					int giri = 11 - tentativi; // creo la variabile giri che sarebbero i tentativi usati per indovinare
					punteggioPartita += tentativi - 1; // il punteggio è dato dai tentativi rimanenti
					Console.WriteLine($"Hai indovinato in {giri} tentativi");
					Console.ResetColor();
					Console.ForegroundColor = ConsoleColor.Green;
					if (!File.Exists(pathScore))
					{
						File.Create(pathScore).Close();
						File.AppendAllText(pathScore, $"{punteggioPartita}\n");
					}
					else
					{
						string[] s = File.ReadAllLines(pathScore);
						int somma = punteggioPartita + int.Parse(s[Ultimo(s)]);
						File.AppendAllText(pathScore, $"{somma}\n");
					}
					string[] scores = File.ReadAllLines(pathScore);
					Console.WriteLine($"\n il tuo punteggio dopo {scores.Length} partite è di: {scores[Ultimo(scores)]} CarloPoints\n");
					Console.ResetColor();
					for (int i = 0; i < 3; i++) // per 3 volte
					{
						Console.Write("---   "); // disegno questi trattini per separare
						Thread.Sleep(400);
					}
					Console.Write("\n\nVuoi continuare a giocare? ");
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
					else
					{
						punteggioPartita = 0;
					}
					break;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					tentativi--; // se non hai indovinato il numero ti leva un tentativo
					Console.WriteLine($"No mi dispiace, hai ancora {tentativi} tentativi");
					Console.ResetColor();

					Console.ForegroundColor = ConsoleColor.Blue;
					switch (tentativi) // a seconda di quanti tentativi ti rimangono succederanno cose diverse
					{
						case 9:
							{
								Console.Write("Suggerimento n.1 ----->  ");
								Maggiore(x, 50); // ti dice se è maggiore di 50
								break;
							}
						case 8:
							{
								bool pari = x % 2 == 0;
								Console.Write("Suggerimento n.2 ----->  ");
								if (pari)
								{
									Console.WriteLine("il numero segreto è Pari");
								}
								else
								{
									Console.WriteLine("il numero segreto è Dispari");
								}
								break;
							}
						case 7:
							{
								Console.Write("Suggerimento n.3 ----->  ");
								if (x > 50) // se è maggiore di 50
								{
									Maggiore(x, 75);
									break;
								}
								// altrimenti se è minore di 50 controllo se sia maggiore di 25
								else
								{
									Maggiore(x, 25);
									break;
								}
							}
						case 6:
							{
								Console.WriteLine("Ce la puoi fare");
								break;
							}
						case 5:
							{
								Console.Write("Suggerimento n.4 ----->  ");
								Dictionary<int, int> steps = new()
								{
									{0, 25},
									{25, 50},
									{50, 75},
									{75, 100}
								};
								foreach (KeyValuePair<int, int> entry in steps)
								{
									int y = ((entry.Key + entry.Value) / 2) + 3;
									if (Intervallo(x, entry.Key, entry.Value))
									{
										Maggiore(x, y);
										break;
									}
								}
								break;
							}
						case 4:
							{
								Console.BackgroundColor = ConsoleColor.Cyan;
								Console.WriteLine("Non sei molto bravo a questo gioco...");
								Console.ResetColor();
								break;
							}
						case 3:
							{
								Console.Write("Suggerimento n.5 ----->  ");
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
									if (Intervallo(x, entry.Key, entry.Value))
									{
										Maggiore(x, y);
										break;
									}
								}
								break;
							}
						case 2:
							{
								Console.Write("Suggerimento n.6 ----->  ");
								if (input > x)
								{ Console.WriteLine($"il numero segreto è Minore di {input}"); }
								else
								{ Console.WriteLine($"il numero segreto è Maggiore di {input}"); }
								break;
							}
						case 1:
							{
								Console.Write("Suggerimento n.7 ----->  ");
								if (x > 10) // se il numero segreto è un numero a due (o tre) cifre
								{
									int somma = 0;
									somma += x % 10; //aggiungo a somma l'ultima cifra di num;
									int a = x / 10;
									somma += a; //divido num per 10, essendo il risultato intero non conterà la parte decimale
									Console.WriteLine($"La somma delle cifre che compongono il numero è {somma}");
								}
								break;
							}
						case 0:
							{
								Console.BackgroundColor = ConsoleColor.DarkRed;
								Console.WriteLine($"HAI PERSO!\nIl numero era {x}"); // finito il ciclo while (e i tentativi) si arriva qua
								Console.ResetColor();
								return;
							}
					}
					Console.ResetColor();
					{
						try
						{
							input = int.Parse(Console.ReadLine()!); // faccio inserire un nuovo valore a input all'utente, ripetendo il controllo che sia un numero valido
						}
						catch (Exception)
						{
							Console.BackgroundColor = ConsoleColor.Magenta;
							Console.WriteLine("Non è un numero valido, hai sprecato un tentativo");
							Console.ResetColor();
							Console.WriteLine("");
						}
					}
				}
			}
		}
	}
}