using System.Linq.Expressions;
using System.Reflection.Metadata;

class Program
{
  static void Main(string[] args)
  {
      string path = @"test.csv";
      File.Create(path).Close(); // crea il file e lo chiude per poterlo modificare
      while (true)
      {
        Console.WriteLine($"inserisci nome, cognome ed eta");
        string nome = Console.ReadLine()!; // legge il nome
        string cognome = Console.ReadLine()!; // legge il nome
        string eta = Console.ReadLine()!; // legge il nome
        if (!File.ReadAllLines(path).Any(line => line.StartsWith(nome))) // controlla che nessuna linea inizi col nome
        {
          File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n"); // scrive la riga nel file
        }
        else
        {
          string[] lines = File.ReadAllLines(path); // legge tutte le righe del file
          string[][] nomi = new string[lines.Length][]; // crea un array di array di stringhe con la lunghezza dell'array lines (numero di righe del file)
          for (int i = 0; i < lines.Length; i++)
          {
            nomi[i] = lines[i].Split(','); // assegna ad ogni elemento dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzando la virgola come separatore
          }
          for (int i = 0; i < nomi.Length; i++)
          {
            if (nomi[i][0] == nome) // se il nome e' gia' presente nel file
            {
              nomi[i][1] = cognome; // aggiorno il cognome
              nomi[i][2] = eta; // aggiorno l'eta'
            }
          }
          File.Delete(path);
          File.Create(path).Close();
          foreach (string[] n in nomi)
          {
            File.AppendAllText(path, n[0] + "," + n[1] + "," + n[2] + "\n");
          }
        }
        Console.WriteLine("vuoi inserire un altro nome? (s/n)");
        string risposta = Console.ReadLine()!;
        if (risposta == "n")
        {
          break;
        }
      }
  }
}
