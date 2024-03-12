class Tavolo
{
  public int TavoloId { get; set; }
  public string Nome { get; set; }
  public int Capacita { get; set; }
  public bool Disponibile { get; set; }
  public List<Ordinazione> Ordinazioni { get; set; }

}