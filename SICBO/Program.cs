using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
class Program
{
  static void Main(string[] args)
  {
    var db = new Database(); // Model
    // var view = new View(db); // View
    var testview = new TestView(db); // View
    var controller = new Controller (db, testview); // Controller
    controller.MainMenu(); // Menu principale dell'app
  }
}

