using System;
using System.Data;

namespace app
{
  public class Calculator
  {
      IDbConnection connection;

      public Calculator(IDbConnection dbConnection)
      {
          connection = dbConnection;
      }

    public int add(int i, int i1)
    {
      if(i < 0 || i1 < 0)
          throw new ArgumentException("Negatives aren't allowed");
        connection.Open();
      return i + i1;
    }
  }
}