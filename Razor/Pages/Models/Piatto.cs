public class Piatto
{
  public int Id { get; set; }
  public required string Nome { get; set; }
  public required string Categoria { get; set; }
  public int Prezzo { get; set; }
  public bool Disponibile { get; set; }
  public string? Descrizione { get; set; }
  public string? Immagine { get; set; }
}