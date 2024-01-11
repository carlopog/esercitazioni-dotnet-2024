class Program
{
  static void Main(string[] args)
  {
    List<int> numeri = new List<int>();
    numeri.Add(3);
    numeri.Add(5);
    numeri.Add(5);
    numeri.Add(5);
    numeri.Add(5);
    numeri.Add(5);
    numeri.Add(7);
    Console.WriteLine($"Lista di numeri: {numeri[0]}, {numeri[1]} e {numeri[2]}");
    Console.WriteLine($"ci sono {numeri.Count} numeri");
  }
}