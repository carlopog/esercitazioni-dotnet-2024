public class VerificaDoppia
{
  public int Id { get; set; }
  public required string RispostaUtente { get; set; }
  public required string RispostaGiusta1{ get; set; } 
  public required string RispostaGiusta2{ get; set; } 
  public bool Uguali { get; set; } 
  // se e' 0 non ne hai presa una se e' 1 una e' uguale se e' 2 sono uguali tutte e 2
  // su 3 opzioni ne scegli 2 quindi puo' essere 0 solo se risposta 1 e risposta 2 sono uguali 
}