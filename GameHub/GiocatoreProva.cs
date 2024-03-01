/// <summary>
/// Questa sottoclasse estende la classe Giocatore
///  aggiungendo livello ed esperienza
/// </summary>
class GiocatoreProva : Giocatore
{
    private int livello;
    private int esperienza;

    public global::System.Int32 Livello { get => livello; set => livello = value; }
    public global::System.Int32 Esperienza { get => esperienza; set => esperienza = value; }

    public GiocatoreProva(string nome,int punteggio,int crediti,int partiteGiocate,int partiteVinte, int livello, int esperienza) : base(nome, punteggio, crediti, partiteGiocate, partiteVinte)
  {
    this.livello = livello;
    this.esperienza = esperienza;
  }
  /// <summary>
  ///  Questo override estende il metodo Stampa
  ///  aggiungendo la stampa di livello ed esperienza
  /// </summary>
  public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Livello: {livello}");
    Console.WriteLine($"Esperienza: {esperienza}");
  }


  public override void Vincita(bool win)
  {
    base.Vincita();
    if (win)
    {
      esperienza += 10;
    }
    if (esperienza >= 50)
    {
      livello++;
    }
  }

}