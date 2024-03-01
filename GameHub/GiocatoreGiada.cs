/// <summary>
/// Questa sottoclasse estende il giocatore
/// con gli attributi propri del gioco di Giada
/// </summary>
class GiocatoreProva : Giocatore
{
    private string cognome;
    private int eta;

    public global::System.String Cognome { get => cognome; set => cognome = value; }
    public global::System.Int32 Eta { get => eta; set => eta = value; }
}
