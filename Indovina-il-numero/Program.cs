class Program
{
    static void Main(string[] args)
    {
        // programma che genera un numero tra 1 e 100 e chiede di indivinare il numero
        // se sbaglio esce, se indovino mi avvisa con un output. Ho a disposizione 
        // 10 tentativi

        Random random = new();
        int x = random.Next(1,101);
        int input, tentativi = 10;
        
				Console.WriteLine($"{x}");
				
        // Console.Clear();
        
        Console.WriteLine("Prova ad indovinare il numero segreto");
        input = int.Parse(Console.ReadLine()!);

		

        while(tentativi != 0) // ripeto fino a quando hai l'ultimo tentativo poi finisce il gioco
        {
            if (input == x)
            {
              Console.WriteLine("Che fortuna!!!");
              return;
            }

						tentativi--; // se non hai azzeccato ti leva un tentativo
            Console.WriteLine($"Mi dispiace, hai ancora {tentativi} tentativi");

		    		switch (tentativi)
            	{
								case 9:
            	  	{
										bool maggiore50 = x > 50;
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
										bool maggiore50 = x > 50;
										if (maggiore50)
										{
											bool maggiore70 = x > 70;
            	  	  	Console.WriteLine($"il numero e' maggiore di 70? {maggiore70}");
											break;
										} 
										bool maggiore30 = x > 30;
            	  	  Console.WriteLine($"il numero e' maggiore di 30? {maggiore30}");
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
											bool maggiore90 = x > 90;
            	  	  	Console.WriteLine($"il numero e' maggiore di 90? {maggiore90}");
											break;
										}
										else if (tra50e75)
										{
											bool maggiore60 = x > 60;
            	  	  	Console.WriteLine($"il numero e' maggiore di 60? {maggiore60}");
											break;
										}
										else if (tra25e50)
										{
											bool maggiore40 = x > 40;
            	  	  	Console.WriteLine($"il numero e' maggiore di 40? {maggiore40}");
											break;
										}
										else 
										{
											bool maggiore10 = x > 10;
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
     									int a = x/10; 
											somma += a; //divido num per 10, essendo intero non ci sarà parte decimale
											Console.WriteLine($"La somma delle cifre che compongono il numero e' {somma}");
										}
										break;
									}
								case 3:
            	  	{
										bool tra0e10 = x < 10;
										bool tra10e25 = x > 10 & x < 25;
										bool tra25e40= x > 25 & x < 40;
										bool tra40e50 = x > 40 & x < 50;
										bool tra50e60 = x > 50 & x < 60;
										bool tra60e75 = x > 60 & x < 75;
										bool tra75e90 = x > 75 & x < 90;

										if (tra0e10)
										{
											bool maggiore5 = x > 5;
            	  	  	Console.WriteLine($"il numero e' maggiore di 5? {maggiore5}");
											break;
										}
										else if (tra10e25)
										{
											bool maggiore20 = x > 20;
            	  	  	Console.WriteLine($"il numero e' maggiore di 20? {maggiore20}");
											break;
										}

										else if (tra25e40)
										{
											bool maggiore30 = x > 30;
            	  	  	Console.WriteLine($"il numero e' maggiore di 30? {maggiore30}");
											break;
										}
										else if (tra40e50)
										{
											bool maggiore45 = x > 45;
            	  	  	Console.WriteLine($"il numero e' maggiore di 45? {maggiore45}");
											break;
										}
										else if (tra50e60)
										{
											bool maggiore55 = x > 55;
            	  	  	Console.WriteLine($"il numero e' maggiore di 55? {maggiore55}");
											break;
										}
										else if (tra60e75)
										{
											bool maggiore70 = x > 70;
            	  	  	Console.WriteLine($"il numero e' maggiore di 70? {maggiore70}");
											break;
										}
										else if (tra75e90)
										{
											bool maggiore80 = x > 80;
            	  	  	Console.WriteLine($"il numero e' maggiore di 80? {maggiore80}");
											break;
										}
										else 
										{
											bool maggiore95 = x > 95;
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