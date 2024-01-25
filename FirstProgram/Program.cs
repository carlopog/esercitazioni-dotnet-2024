class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string path2 = @"test2.txt"; 
    File.Create(path2).Close();
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    int a = 0; // introduco una variabile per avere un secondo counter
    for (int i = 0; i < lines.Length; i++)
    {
      if ( lines[i].StartsWith("c") )
      {
        nomi[a] = lines[i]; 
        a++; // a ogni parola che inizia con la c inserita aggiorno il counter
      }
    }
    if (a < 1) // se il counter e' zero
    {
      Console.WriteLine("Non ci sono righe con la c");
    }
    Array.Resize(ref nomi, a); // diminuisco la dimensione del secondo array per non avere stringhe vuote
    Array.ForEach(nomi, nome => File.AppendAllText(path2, nome + "\n"));
  }
}
