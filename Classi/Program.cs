class Program
{
  public static void Main(string[] args)
  {
    Animale a1 = new Cane("Fido", 5, "Labrador");
    Animale a2 = new Gatto("Felix", 5, "Nero");

    a1.Stampa();
    a2.Stampa();
  }
}