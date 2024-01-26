class Program
{
  static void Main(string[] args)
  {
    string path = @"test.txt"; 
    string[] lines = File.ReadAllLines(path);
    string[] nomi = new string[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
      nomi[i] = lines[i]; 
    }
    Random random = new Random(); // crea un oggetto random
    int index = random.Next(nomi.Length); // genera un numero random tra 0 e la lunghezza dell'array
    Console.WriteLine(nomi[index]); // stampa il nome corrispondente all'indice generato casualmente
    string path2 = @"test2.txt";
    if (!File.Exists(path2)) // controlla se il file esiste
    {
      File.Create(path2).Close();
    }
    if (!File.ReadAllLines(path2).Contains(nomi[index])) // controlla se il nome sorteggiato è già presente nel file
    {
      File.AppendAllText(path2, $"{nomi[index]}\n");
    }
    else
    {
      Console.WriteLine("il nome è già presente nel file");
    }
  }
}
