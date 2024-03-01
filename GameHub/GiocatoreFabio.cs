/// <summary>
/// Questa sottoclasse estende il giocatore
/// con gli attributi propri del gioco di Giada
/// </summary>
class GiocatoreFabio : Giocatore
{
    private int eta;

    public global::System.Int32 Eta { get => eta; set => eta = value; }

     public GiocatoreFabio(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte, int eta) : base(nome, punteggio, crediti, partiteGiocate, partiteVinte)
  {
    this.eta = eta;
  }

   public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Eta: {eta}");
  }


}
