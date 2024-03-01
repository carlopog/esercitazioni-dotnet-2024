using Microsoft.EntityFrameworkCore;

class Database : DbContext
{
  public DbSet<Cliente> Clienti { get; set; } // DbSet rappresenta una tabella del database in memoria
  public DbSet<Prodotto> Prodotti { get; set; } // DbSet rappresenta una tabella del database in memoria
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // optionsBuilder.UseInMemoryDatabase("MyDatabase"); // crea database provvisorio
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite"); // crea database con sqlite
  }
  public void InserisciClienti(List<Cliente> clienti)
  {
    Clienti.AddRange(clienti); // AddRange aggiunge una lista di clienti al database
    SaveChanges();
  }

  public void StampaClienti()
  {
    var clienti = Clienti.Include(c => c.Prodotti).ToList(); // Include recupera tutti i prodotti per ogni cliente dal db
    foreach (var c in clienti)
    {
      Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - Assunto? {c.Assunto}"); // Stampa di tutti i clienti
      foreach (var p in Prodotti)
      {
        Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo}");
      }
    }
  }

  public void InserisciProdotti(List<Prodotto> prodotti)
  {
    Prodotti.AddRange(prodotti);
    SaveChanges();
  }

  public void StampaProdotti()
  {
    var prodotti = Prodotti.ToList();
    foreach (var p in prodotti)
    {
      Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} {p.Cliente.Cognome}");
    }
  }
}