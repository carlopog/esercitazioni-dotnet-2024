- [x] creare classe giocatore
- [x] creare classe scommessa

SELECT id from scommesse WHERE nome = '{nome}' ORDER BY id DESC LIMIT 1 

```c#
   public void VisualizzaGiocatori(List<string> giocatori)
   {
     foreach (var giocatore in giocatori)
     {
      Console.WriteLine(giocatore); // Visualizzazione dei nomi degli utenti
      Thread.Sleep(500);
     }
   }
          Console.WriteLine("Hai scelto di visualizzare un elenco in base ad un valore numerico,");
          Console.WriteLine("Cosa vuoi visualizzare?");
          Console.WriteLine("1 - Elenco completo dal maggiore al minore");
          Console.WriteLine("2 - Elenco completo dal minore al maggiore");
          Console.WriteLine("3 - Valori superiori a un determinato numero");
          Console.WriteLine("4 - Valori inferiori a un determinato numero");
          Console.WriteLine("5 - Solo valori uguali a un determinato numero");
          string numScelta = Console.ReadLine()!;
          switch (numScelta)
          {
            case "1":
              {
                SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                connection.Open();
                string sql = $"SELECT * FROM {prodotti} ORDER BY {numero} DESC";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                  counter++;
                  Thread.Sleep(300);
                }
                connection.Close();
                if (counter == 0)
                {
                  Console.WriteLine("Non c'è nessun dato");
                }
                break;
              }
            case "2":
              {
                SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                connection.Open();
                string sql = $"SELECT * FROM {prodotti} ORDER BY {numero} ASC";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                  counter++;
                  Thread.Sleep(300);
                }
                connection.Close();
                if (counter == 0)
                {
                  Console.WriteLine("Non c'è nessun dato");
                }
                break;
              }
            case "3":
              {
              Superiore:
                Console.WriteLine("Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} > {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore maggiore di {paragone.ToString()}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Superiore;
                }

              }
            case "4":
              {
              Inferiore:
                Console.WriteLine($"Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} < {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore minore di {paragone}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Inferiore;
                }

              }
            case "5":
              {
              Inizio:
                Console.WriteLine($"Inserisci il valore del numero da paragonare");
                try
                {
                  int paragone = int.Parse(Console.ReadLine()!);
                  SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
                  connection.Open();
                  string sql = $"SELECT * FROM {prodotti} DESC WHERE {numero} = {paragone}";
                  SQLiteCommand command = new SQLiteCommand(sql, connection);
                  SQLiteDataReader reader = command.ExecuteReader();

                  while (reader.Read())
                  {
                    Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, {numero}: {reader[$"{numero}"]}");
                    counter++;
                    Thread.Sleep(300);
                  }
                  connection.Close();
                  if (counter == 0)
                  {
                    Console.WriteLine($"Non c'è nessun dato con un valore uguale a {paragone}");
                  }
                  break;
                }
                catch (Exception)
                {
                  Console.WriteLine("devi inserire un numero");
                  goto Inizio;
                }
              }
            default:
              {
                Console.WriteLine($"devi scegliere un numero tra 1 e 5");
                goto Valori;
              }
          }
          break;
        }
      default:
        {
          Console.WriteLine("Devi inserire un numero da 1 a 5, riprova");
          break;
        }
    }
  }


```