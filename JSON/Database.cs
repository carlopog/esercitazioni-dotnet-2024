using Microsoft.EntityFrameworkCore;

class Database : DbContext
{
  public DbSet<Piatto> Piatti { get; set; }  
  public DbSet<Tavolo> Tavoli { get; set; }  
  public DbSet<Ordinazione> Ordinazioni { get; set; }  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
  }
}