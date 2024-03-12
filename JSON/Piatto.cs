class Piatto
{
  [Key]
  public int PiattoId { get; set; }
  public string Nome { get; set; }
  public string Descrizione { get; set; }
  public int Prezzo { get; set; }
  public string Categoria { get; set; }
  public bool Disponibile { get; set; }
  public List<Ordinazione> Ordinazioni { get; set; }

}