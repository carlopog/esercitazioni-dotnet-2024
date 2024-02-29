class Cliente
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Cognome { get; set; }
  public bool Assunto { get; set; }
  public List<Prodotto> Prodotti { get; set; } // FOREIGN KEY
}