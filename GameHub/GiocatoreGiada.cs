/// <summary>
/// Questa sottoclasse estende il giocatore
/// con gli attributi propri del gioco di Giada
/// </summary>
class GiocatoreGiada : Giocatore
{
    private string cognome;
    private int eta;

    public global::System.String Cognome { get => cognome; set => cognome = value; }
    public global::System.Int32 Eta { get => eta; set => eta = value; }

     public GiocatoreGiada(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte, int eta, string cognome) : base(nome, punteggio, crediti, partiteGiocate, partiteVinte)
  {
    this.cognome = cognome;
    this.eta = eta;
  }

   public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Cognome: {cognome}");
    Console.WriteLine($"Eta: {eta}");
  }


}
