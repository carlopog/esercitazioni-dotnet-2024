class Ordinazioni
{
  public int Id { get; set; }
  public int Id_Piatto { get; set; }
  public Piatto Piatto { get; set; }
  public int Id_Turno { get; set; }
  public Turno Turno { get; set; }
  public int Id_Tavolo { get; set; }
  public Tavolo Tavolo { get; set; }
  public int Quantità { get; set; }
  public bool Pronto { get; set; }
  
}