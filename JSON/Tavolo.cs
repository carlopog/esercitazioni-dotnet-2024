class Tavolo
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public int Capacità { get; set; }
  public bool Occupato { get; set; }
  public List<Ordinazione> Ordinazioni { get; set; }

}