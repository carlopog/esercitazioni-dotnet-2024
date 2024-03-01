/// <summary>
/// Questa sottoclasse estende la classe Giocatore
///  aggiungendo livello ed esperienza
/// </summary>
class GiocatoreCarlo : Giocatore
{

    private int eta;
    private int bottino;
    private int lastbet;
    private int prestito;

    public GiocatoreCarlo(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte, int eta,int bottino,int lastbet,int prestito  ) : base(nome, punteggio, crediti, partiteGiocate, partiteVinte)
  {
    this.coloreArmata = coloreArmata;
    this.territori = territori;
  }

    public global::System.Int32 Eta { get => eta; set => eta = value; }
    public global::System.Int32 Bottino { get => bottino; set => bottino = value; }
    public global::System.Int32 Lastbet { get => lastbet; set => lastbet = value; }
    public global::System.Int32 Prestito { get => prestito; set => prestito = value; }

    /// <summary>
    ///  Questo override estende il metodo Stampa
    ///  aggiungendo la stampa di eta, bottino, lastbet, prestito 
    /// </summary>
    public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Eta: {eta}");
    Console.WriteLine($"Bottino: {bottino}");
    Console.WriteLine($"Lastbet: {lastbet}");
    Console.WriteLine($"Prestito: {prestito}");   
  }
}
