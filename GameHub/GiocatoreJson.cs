/// <summary>
/// Questa è la classe del Giocatore generico <br/>
/// contiene il nome del giocatore <br/>
/// il punteggio, i crediti, <br/>
/// le partite giocate e le partite vinte
/// </summary>
class GiocatoreJson
{
    private string Nome { get; set; };
    private int Punteggio { get; set; };
    private int Crediti { get; set; };
    private int PartiteGiocate { get; set; };
    private int PartiteVinte { get; set; };


/// <summary>
/// Questo metodo stampa i dati di un Giocatore
/// una riga alla volta
/// </summary>
  public virtual void Stampa()
  {
    Console.WriteLine($"Nome: " + nome);
    Console.WriteLine($"Punteggio: " + punteggio);
    Console.WriteLine($"crediti: " + crediti);
    Console.WriteLine($"Partite Giocate: " + PartiteGiocate);
    Console.WriteLine($"Partite Vinte: " + PartiteVinte);
  }

  /// <summary>
  /// Questo metodo prende in argomento un booleano vittoria
  /// se hai vinto aumenta di 1 i tuoi crediti e partite vinte e giocate <br/>
  /// altrimenti solo le partite giocate
  /// </summary>
  /// <param name="win"></param>
  public virtual void Vincita(bool win)
  {
    if (win)
    {
      crediti ++;
      PartiteVinte++;
    }
      PartiteGiocate++;
  }
}