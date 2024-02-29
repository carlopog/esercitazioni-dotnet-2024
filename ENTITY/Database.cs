using Microsoft.EntityFrameworkCore;

class Database : DbContext
{
  public DbSet<Cliente> Clienti { get; set; } // DbSet rappresenta una tabella del database in memoria
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseInMemoryDatabase("MyDatabase");
  }
  public void InserisciClienti(List<Cliente> clienti)
  {
    Clienti.AddRange(clienti); // AddRange aggiunge una lista di clienti al database
    SaveChanges();
  }

  public void StampaClienti()
  {
    var clienti = Clienti.ToList(); // ToList recupera tutti i clienti dal db
    foreach (var c in clienti)
    {
      Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - Assunto? {c.Assunto}"); // Stampa di tutti i clienti
    }
  }
}