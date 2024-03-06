using System.Data.SQLite;

class View
{
  private Database _db; // Riferimento al modello
  public View(Database db)
  {
    _db = db; // Inizializzazione del riferimento al modello
  }

  static void CreateFile(string path)
  {
    if (!File.Exists(path))
    {
      File.Create(path).Close();
    }
  }
  public void Authentication()
  {
    string pathGiocatoreAttuale = @"giocatoreAttuale.csv";
    CreateFile(pathGiocatoreAttuale);
    Console.WriteLine("Ciao, per giocare a Super Sic Bo devi essere maggiorenne, hai almeno 18 anni? (s/n)");
    string siNo = Console.ReadLine()!; // legge il tipo di operazione scelta
    if (siNo == "s")
    {
      Console.WriteLine("Come ti chiami?");
      string nomeGiocatore = Console.ReadLine()!; // ti fa inserire il nome del giocatore attuale
      File.WriteAllText(pathGiocatoreAttuale, nomeGiocatore);
    }
    else
    {
      Console.WriteLine($"allora non puoi giocare");
      return;
    }
  }
  public void ShowMainMenu()
  {
    Console.WriteLine($"1. Aggiungi Giocatore");
    Console.WriteLine($"2. Aggiungi Scommessa e Modifica Lastbet");
    Console.WriteLine($"3. Modifica Vincita e Bottino");
    Console.WriteLine($"4. Modifica Prestito e Bottino");
    Console.WriteLine($"5. Modifica Bottino");
    Console.WriteLine($"6. Rimuovi Giocatore");
    Console.WriteLine($"e. Esci");
  }
  public int ReadInt(string dato)
  {
  Start:
    Console.WriteLine($"Inserisci {dato}:");
    try
    {
      int num = int.Parse(Console.ReadLine()!);
      return num;
    }
    catch
    {
      Console.WriteLine("devi inserire un numero");
      goto Start;
    }
  }
}
