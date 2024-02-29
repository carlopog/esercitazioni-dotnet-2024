class Program 
{
  static void Main(string[] args)
  {
    using (var db = new Database())
    {
      var clienti = new List<Cliente> 
      {
        new Cliente { Nome = "Mario", Cognome = "Rossi", Assunto = false},
        new Cliente { Nome = "Ma", Cognome = "Rio", Assunto = true },
        new Cliente { Nome = "Rosso", Cognome = "Mari", Assunto = true }
      };
      Console.WriteLine("clienti");
      db.InserisciClienti(clienti); // Inserimento di una lista di clienti
      db.StampaClienti(); // Stampa di tutti i clienti

      var prodotti = new List<Prodotto>
      {
        new Prodotto { Nome = "Banana", Prezzo = 2.00, ClienteId = 1 },
        new Prodotto { Nome = "Ban", Prezzo = 5.00, ClienteId = 1 },
        new Prodotto { Nome = "Bananas", Prezzo = 2.50, ClienteId = 1 },
        new Prodotto { Nome = "Ba nana", Prezzo = 5.55, ClienteId = 2 },
        new Prodotto { Nome = "Baaaaa nana", Prezzo = 3.30, ClienteId = 2},
        new Prodotto { Nome = "B", Prezzo = 2.03, ClienteId = 2 },
        new Prodotto { Nome = "Bananina", Prezzo = 88.00, ClienteId = 2 },
        new Prodotto { Nome = "Banano", Prezzo = 8.80, ClienteId = 3 },
        new Prodotto { Nome = "Bananaaaaa", Prezzo = 9.00, ClienteId = 3 },
        new Prodotto { Nome = "Befana", Prezzo = 2.09, ClienteId = 3 }
      };
      Console.WriteLine("prodotti per clienti");
      db.InserisciProdotti(prodotti); // Inserimento di una lista di clienti
      db.StampaProdotti(); // Stampa di tutti i clienti
    }
  }
}