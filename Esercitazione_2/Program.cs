class Program
{
  static void Main(string[] args)
  {
    int a = 9;
    int b = 5;
    int c = 5;
    bool maggiore = a > b;
    bool maggioreUguale = c >= b;
    bool minoreUguale = c <= b;
    bool minore = a < b;
    Console.WriteLine($"a e' maggiore di b? {maggiore}");
    Console.WriteLine($"a e' minore di b? {minore}");
    Console.WriteLine($"c e' maggiore uguale di b? {maggioreUguale}");
    Console.WriteLine($"c e' minore uguale di b? {minoreUguale}");
  }
}