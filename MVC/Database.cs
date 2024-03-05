using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


class Database : DbContext
{
  public DbSet<User> Users { get; set; } // DbSet rappresenta una tabella del database in memoria
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
  }
}