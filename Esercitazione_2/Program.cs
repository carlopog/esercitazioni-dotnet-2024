class Program
{
  static void Main(string[] args)
  {
      Queue<string> nomi = new Queue<string>();
      nomi.Enqueue("Mario");    
      nomi.Enqueue("Kevin");    
      nomi.Enqueue("Paolo");    
      Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue()}");
  }
}