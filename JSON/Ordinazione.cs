class Ordinazione
{
  public int Id { get; set; }
  public List<Piatto> Piatti { get; set; }
  public int Id_Tavolo { get; set; }
  public Tavolo Tavolo { get; set; }
  public bool Pronto { get; set; }
  
}