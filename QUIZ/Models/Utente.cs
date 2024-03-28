public class Utente 
{
  public required string Nome { get; set; }
  public required string Password { get; set; }
  public int Record { get; set; }
  public int[]? Punteggi { get; set; }
}