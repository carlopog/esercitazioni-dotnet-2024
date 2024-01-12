class Program
{
  static void Main(string[] args)
  {
    // un array di stringhe con 3 nomi 
    string[] nomi = ["Franco", "Ciccio", "Mario"];
    // creare una lista di destinazione
    List<string> marii = ["Merola"];
    // e cicliamo con un foreach 
    foreach (string nome in nomi) {
    // se il nome e' Mario
      if(nome == "Mario") {
      // aggiunge alla lista con Add
        marii.Add(nome);
      }
    }
    Console.WriteLine($"la lista aggiornata {marii[1]} {marii[0]}");
  }
}