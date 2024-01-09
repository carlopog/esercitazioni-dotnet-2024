class Program
{
  static void Main(string[] args)
  {
    string nome = "Pino";
    string cognome = "Paoli";
    bool uguali = nome == cognome;
    bool diversi = nome != cognome;
    Console.WriteLine($"i due nomi sono uguali? {uguali}");
    Console.WriteLine($"i due nomi sono diversi? {diversi}");
  }
}