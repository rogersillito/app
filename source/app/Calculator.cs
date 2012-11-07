using System;

namespace app
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
      if(i < 0 || i1 < 0)
          throw new ArgumentException("Negatives aren't allowed");
      return i + i1;
    }
  }
}