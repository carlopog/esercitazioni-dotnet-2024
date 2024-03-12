class Ordinazione
{
  [Key]
  public int OrdinazioneId { get; set; }
  public List<Piatto> Piatti { get; set; }
  [ForeignKey("Tavolo")]
  public int TavoloId { get; set; } 
  public Tavolo Tavolo { get; set; }
  public bool Disponibile { get; set; }
  
}