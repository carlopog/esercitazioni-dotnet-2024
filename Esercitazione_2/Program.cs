class Program
{
  static void Main(string[] args)
  {
    // inizializzazione di un array di interi
    int[] numeri = new int[] {1, 2, 3, 4, 5};
    int[] numeriDue = [1, 2, 3, 4, 5];

    // inizializzazione di un array di stringhe
    string[] nomi = new string[] {"Mario", "Luigi", "Yoshi"};
    string[] nomiDue = ["Mario", "Luigi", "Yoshi"];

    // inizializzazione di un list di interi
    List<int> listaNumeri = new List<int> {1, 2, 3, 4, 5};
    List<int> listaNumeriDue = new List<int> {1, 2, 3, 4, 5};

    // inizializzazione di un list di stringhe
    List<string> listaNomi = new List<string> {"Mario", "Luigi", "Yoshi"};
    List<string> listaNomiDue = ["Mario", "Luigi", "Yoshi"];

    // inizializzazione di uno stack (pila) di interi
    Stack<int> pilaNumeri = new Stack<int>(new int[] {1, 2, 3, 4, 5});
    Stack<int> pilaNumeriDue = new([1, 2, 3, 4, 5]);

    // inizializzazione di una queue (coda) di stringhe
    Queue<string> codaNomi = new Queue<string>(new string[] {"Mario", "Luigi", "Yoshi"});
    Queue<string> codaNomiDue = new(["Mario", "Luigi", "Yoshi"]);

    Console.WriteLine($"Array numeri: {numeri[0]}, {numeriDue[1]}");
    Console.WriteLine($"Array stringhe: {nomi[0]}, {nomiDue[1]}");
    Console.WriteLine($"Lista numeri: {listaNumeriDue[0]}, {listaNumeri[1]}");
    Console.WriteLine($"Lista stringhe: {listaNomiDue[0]}, {listaNomi[1]}");
    Console.WriteLine($"Pila numeri: {pilaNumeri.Pop()}, {pilaNumeri.Pop()}");
    Console.WriteLine($"Pila DUE numeri: {pilaNumeriDue.Pop()}, {pilaNumeriDue.Pop()}");
    Console.WriteLine($"Coda stringhe: {codaNomi.Dequeue()}, {codaNomi.Dequeue()}");
    Console.WriteLine($"Coda DUE stringhe: {codaNomiDue.Dequeue()}, {codaNomiDue.Dequeue()}");
  }
}