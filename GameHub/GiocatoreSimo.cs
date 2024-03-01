/// <summary>
/// Questa sottoclasse estende la classe Giocatore
///  aggiungendo livello ed esperienza
/// </summary>
class GiocatoreSimo : Giocatore
{
  private string coloreArmata;
  private List<string> territori;


    public global::System.String ColoreArmata { get => coloreArmata; set => coloreArmata = value; }
    public List<global::System.String> Territori { get => territori; set => territori = value; }

    public GiocatoreSimo(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte, string coloreArmata, List<string> territori ) : base(nome, punteggio, crediti, partiteGiocate, partiteVinte)
  {
    this.coloreArmata = coloreArmata;
    this.territori = territori;
  }
    /// <summary>
    ///  Questo override estende il metodo Stampa
    ///  aggiungendo la stampa di colore armata e territori
    /// </summary>
    public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Colore Armata: {coloreArmata}");
    Console.WriteLine($"Territori: {territori}");
  }
}
