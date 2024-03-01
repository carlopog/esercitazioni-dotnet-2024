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
    this.Livello = livello;
    this.Esperienza = esperienza;
  }
  /// <summary>
  ///  Questo override estende il metodo Stampa
  ///  aggiungendo la stampa di livello ed esperienza
  /// </summary>
  public override void Stampa()
  {
    base.Stampa();
    Console.WriteLine($"Livello: {Livello}");
    Console.WriteLine($"Esperienza: {Esperienza}");
  }


  public override void Vincita(bool win)
  {
    base.Vincita();
    if (win)
    {
      Esperienza += 10;
    }
    if (Esperienza >= 50)
    {
      Livello++;
    }
  }

}