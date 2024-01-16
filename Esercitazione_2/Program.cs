using System;
using System.Collections;
using System.Runtime.Intrinsics.Arm;

class Example
{
  public static void Main()
  {
    int i = 0;

    do
    {
      Console.WriteLine("i = {0}", i);
      i++;

    } while (i > 5);

  }
}