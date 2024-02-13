using Newtonsoft.Json;

class Program {

  static void Main(string[] args)
  {
    string[] giocatore = ["Mario", "25", "200", "500"];
  
    Exit(giocatore);
  }

  static void Exit(string[] giocatore)
  {
    string nome = giocatore[0];
    int eta = int.Parse(giocatore[1]);
    int prestito = int.Parse(giocatore[2]);
    int bottino = int.Parse(giocatore[3]);
    if (prestito > 0)
    {
      bottino -= prestito;
    }
    Console.WriteLine("Vuoi continuare a giocare o uscire? c/u");
    string scelta = Console.ReadLine()!;
    string path = @"giocatori.csv";
    if (scelta == "u")
    {
      if (!File.Exists(path))
      {
        File.Create(path).Close();
      }
       if (File.ReadAllLines(path).Any(line => line.StartsWith(nome)))
        {
          string[] righe = File.ReadAllLines(path);
          string[][] players = new string[righe.Length][];
          for (int i = 0; i < righe.Length; i++)
          {
            players[i] = righe[i].Split(',');
          }
          for (int i = 0; i < players.Length; i++)
          {
            if (players[i][0] == nome) // se il nome e' gia' presente nel file
            {
              players[i][2] = prestito.ToString();
              players[i][3] = bottino.ToString();
            }
              string path3 = @"giocatori2.csv";
              if (!File.Exists(path3))
              {
                File.Create(path3).Close();
              }

              foreach (string[] player in players)
              {
                File.AppendAllText(path3, player[0] + "," + int.Parse(player[1]) + "," + int.Parse(player[2]) + "," + int.Parse(player[3])  + "\n");
              }
              string[] nuoviDati = File.ReadAllLines(path3);
              File.Delete(path);
              File.Create(path).Close();
              File.AppendAllLines(path, nuoviDati);
              File.Delete(path3);
            }
          }
        else
        {
          File.AppendAllText(path, nome + "," + eta + "," + prestito + "," + bottino  + "\n");
        }
        }
    }
  }
