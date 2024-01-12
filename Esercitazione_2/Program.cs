class Program
{
  static void Main(string[] args)
  {
    // un array di stringhe con 3 nomi 
    string[] nomi = ["Franco", "Ciccio", "Mario", "Mario", "Mario", "Mario"];
    // creare una lista di destinazione
    List<string> lista = ["Merola"];
    // e cicliamo con un foreach 
    foreach (string nome in nomi) {
    // se il nome e' Mario
      if(nome == "Mario") {
    // aggiunge alla lista con Add
        lista.Add(nome);
      }
    }
    // stampa ogni elemento trovato in console
    foreach (string mario in lista) {
      Console.WriteLine($"{mario}");
    }
  }
}