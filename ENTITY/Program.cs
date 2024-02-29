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

      db.InserisciClienti(clienti); // Inserimento di una lista di clienti
      db.StampaClienti(); // Stampa di tutti i clienti
    }
  }
}