public class Prodotto
{
  public int Id { get; set; }
  public required string Nome { get; set; }
  public decimal Prezzo { get; set; }
  public string? Dettaglio { get; set; }
  public string? Immagine { get; set; }
}

