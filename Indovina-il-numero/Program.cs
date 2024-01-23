﻿class Program
{
	static void Main(string[] args)
	{

		int punteggio = 0;
		bool end = false;

		while (!end) // ripeto fino a quando non setto true end
		{
			Random random = new();
			int x = random.Next(1, 101);
			int input, tentativi = 10;
			Console.WriteLine("Prova ad indovinare il numero segreto");
			input = int.Parse(Console.ReadLine()!);

			bool maggiore5 = x > 5;
			bool maggiore10 = x > 10;
			bool maggiore15 = x > 15;
			bool maggiore20 = x > 20;
			bool maggiore25 = x > 25;
			bool maggiore30 = x > 30;
			bool maggiore35 = x > 35;
			bool maggiore40 = x > 40;
			bool maggiore45 = x > 45;
			bool maggiore50 = x > 50;
			bool maggiore55 = x > 55;
			bool maggiore60 = x > 60;
			bool maggiore65 = x > 65;
			bool maggiore70 = x > 70;
			bool maggiore75 = x > 75;
			bool maggiore80 = x > 80;
			bool maggiore85 = x > 85;
			bool maggiore90 = x > 90;
			bool maggiore95 = x > 95;

			while (tentativi >= 0)
			{

				if (input == x)
				{
					Console.WriteLine("Che fortuna!!!");
					int giri = 10 - tentativi;
					punteggio += tentativi;
					Console.WriteLine($"Hai indovinato in {giri} tentativi");
					Console.WriteLine($"il tuo punteggio e' {punteggio}");

					for (int i = 0; i < 3; i++)
					{
						Console.Write("---   ");
						Thread.Sleep(200);
					}

					Console.WriteLine("\nVuoi continuare a giocare? s/n");
					string risposta = Console.ReadLine()!;
					if (risposta == "n")
					{
						end = true;
					}
					break;
				}

				else
				{
					tentativi--; // se non hai azzeccato ti leva un tentativo
					Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");

					switch (tentativi)
					{
						case 9:
							{
								Console.WriteLine($"il numero e' maggiore di 50? {maggiore50}");
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
								if (maggiore50)
								{
									Console.WriteLine($"il numero e' maggiore di 75? {maggiore75}");
									break;
								}
								Console.WriteLine($"il numero e' maggiore di 25? {maggiore25}");
								break;
							}
							case 6:
							{
								Console.WriteLine("Not even close Bro");
								break;
							}

						case 5:
							{
								bool tra0e25 = x < 25;
								bool tra25e50 = x > 25 && x < 50;
								bool tra50e75 = x > 50 && x < 75;
								bool tra75e100 = x > 75;

								if (tra75e100)
								{
									Console.WriteLine($"il numero e' maggiore di 90? {maggiore90}");
									break;
								}
								else if (tra50e75)
								{
									Console.WriteLine($"il numero e' maggiore di 60? {maggiore60}");
									break;
								}
								else if (tra25e50)
								{
									Console.WriteLine($"il numero e' maggiore di 40? {maggiore40}");
									break;
								}
								else
								{
									Console.WriteLine($"il numero e' maggiore di 10? {maggiore10}");
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
									/* alex way 

									while (true)
        					{
            				int somma = 0;
            				int numeroTemporaneo = numero;
            				while (numeroTemporaneo > 0)
            				{
            				    somma += numeroTemporaneo % 10;
            				    numeroTemporaneo /= 10;
            				}

									}

									*/

									break;
								}
						case 3:
							{
								bool tra0e10 = x < 10;
								bool tra10e25 = x > 10 & x < 25;
								bool tra25e40 = x > 25 & x < 40;
								bool tra40e50 = x > 40 & x < 50;
								bool tra50e60 = x > 50 & x < 60;
								bool tra60e75 = x > 60 & x < 75;
								bool tra75e90 = x > 75 & x < 90;

								if (tra0e10)
								{
									Console.WriteLine($"il numero e' maggiore di 5? {maggiore5}");
									break;
								}
								else if (tra10e25)
								{
									Console.WriteLine($"il numero e' maggiore di 20? {maggiore15}");
									break;
								}

								else if (tra25e40)
								{
									Console.WriteLine($"il numero e' maggiore di 30? {maggiore35}");
									break;
								}
								else if (tra40e50)
								{
									Console.WriteLine($"il numero e' maggiore di 45? {maggiore45}");
									break;
								}
								else if (tra50e60)
								{
									Console.WriteLine($"il numero e' maggiore di 55? {maggiore55}");
									break;
								}
								else if (tra60e75)
								{
									Console.WriteLine($"il numero e' maggiore di 65? {maggiore65}");
									break;
								}
								else if (tra75e90)
								{
									Console.WriteLine($"il numero e' maggiore di 85? {maggiore85}");
									break;
								}
								else
								{
									Console.WriteLine($"il numero e' maggiore di 95? {maggiore95}");
									break;
								}
							}
						case 0:
							{
								Console.WriteLine($"HAI PERSO!\nIl numero era {x}"); // finito il ciclo while (e i tentativi) si arriva qua
								return;
							}
					};
					input = int.Parse(Console.ReadLine()!);
				}

			}
		}

	}
}