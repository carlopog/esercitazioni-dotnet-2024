using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


class User
{
  public int Id { get; set; }
  public string Nome { get; set; }
}
class Database : DbContext
{
  public DbSet<User> Users { get; set; } // DbSet rappresenta una tabella del database in memoria
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
  }

}
class Program
{
  static void Main(string[] args)
  {
    using (var db = new Database()) // using garantisce che il database venga chiuso
    {
      var user = new User { Nome = "Caroti" };
      db.Users.Add(user);
      db.SaveChanges();
      var users = db.Users.ToList(); // Recupero tutti gli utenti dal db
      foreach (var u in users)
      {
        Console.WriteLine($"{u.Id} - {u.Nome}");
      }

      // Read
      Console.WriteLine("Prendo il primo user");
      var first = db.Users
          .OrderBy(f => f.Id)
          .First();

      Console.WriteLine(first.Nome);


      // Update
      first.Nome = "Baldassarre";
      db.SaveChanges();
      Console.WriteLine(first.Nome);


    };

    // var view = new View(db); // View
    // var controller = new Controller(db, view); // Controller
    // controller.MainMenu(); // Menu principale dell'app
  }
}