/// <summary>
/// Questa è la classe del Giocatore generico <br/>
/// contiene il nome del giocatore <br/>
/// il punteggio, i crediti, <br/>
/// le partite giocate e le partite vinte
/// </summary>
class Giocatore
{
    private int id;
    private string nome;
    private int punteggio;
    private int crediti;
    private int partiteGiocate;
    private int partiteVinte;

    public global::System.String Nome { get => nome; set => nome = value; }
    public global::System.Int32 Punteggio { get => punteggio; set => punteggio = value; }
    public global::System.Int32 Crediti { get => crediti; set => crediti = value; }
    public global::System.Int32 PartiteGiocate { get => partiteGiocate; set => partiteGiocate = value; }
    public global::System.Int32 PartiteVinte { get => partiteVinte; set => partiteVinte = value; }
    public global::System.Int32 Id { get => id; set => id = value; }


    /// <summary>
    /// Questo metodo crea un Giocatore
    /// con tutti i suoi dati
    /// </summary>
    /// <param name="nome">Nome del giocatore</param>
    /// <param name="punteggio">Punteggio di tutte le partite</param>
    /// <param name="crediti">Crediti rimasti al giocatore</param>
    /// <param name="partiteGiocate">Numero di partite giocate</param>
    /// <param name="partiteVinte">Numero di partite vinte</param>
    public Giocatore(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte)
  {
    this.id = id;
    this.nome = nome;
    this.punteggio = punteggio;
    this.crediti = crediti;
    this.partiteGiocate = partiteVinte;
    this.partiteVinte = partiteVinte;
  }

/// <summary>
/// Questo metodo stampa i dati di un Giocatore
/// una riga alla volta
/// </summary>
  public virtual void Stampa()
  {
    Console.WriteLine($"id: " + id);
    Console.WriteLine($"Nome: " + nome);
    Console.WriteLine($"Punteggio: " + punteggio);
    Console.WriteLine($"crediti: " + crediti);
    Console.WriteLine($"partiteGiocate: " + partiteVinte);
    Console.WriteLine($"partiteVinte: " + partiteVinte);
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
      partiteVinte++;
    }
      partiteGiocate++;
  }
}