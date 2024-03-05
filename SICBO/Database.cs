using Microsoft.EntityFrameworkCore;

class Database : DbContext
{
  public DbSet<Giocatore> Giocatori { get; set; } // DbSet rappresenta una tabella del database in memoria
  public DbSet<Scommessa> Scommesse { get; set; } // DbSet rappresenta una tabella del database in memoria
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
  }
}