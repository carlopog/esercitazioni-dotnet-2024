class Program
{
  static void Main(string[] args)
  {
      Stack<string> nomi = new Stack<string>();
      nomi.Push("Mario");    
      nomi.Push("Kevin");    
      nomi.Push("Paolo");    
      Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()} e {nomi.Pop()}");
  }
}