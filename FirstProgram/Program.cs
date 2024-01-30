class Program
{
  static void Main(string[] args)
  {
      string path = @"test.csv";
      string[] lines = File.ReadAllLines(path);
      string[][] nomi = new string[lines.Length][]; // array di array sarebbe una matrice righe e colonne
      for (int i = 0; i < lines.Length; i++)
      {
        nomi[i] = lines[i].Split(',');
      }
      foreach (string[] nome in nomi)
      {
          string path2 = nome[0] + ".csv"; // il file deve essere nella stessa cartella del programma
          File.Create(path2).Close(); // crea il file e lo chiude per poterlo modificare
          for (int i = 1; i < nome.Length; i++)
          {
            File.AppendAllText(path2, nome[i] + "\n"); // scrive la riga nel file
        }
        // elimino il primo file che contiene le intestazioni delle colonne 
        File.Delete("nome.csv");
      }
  }
}
