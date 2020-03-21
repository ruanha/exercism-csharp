using System;
using System.Linq;
using System.Collections.Generic;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64) {
            throw new ArgumentOutOfRangeException("Has to be a number between 1 and 64");
        }
        return Convert.ToUInt64( Math.Pow(2, n - 1) );
    }

    public static ulong Total()
    {
        IEnumerable<int> range = Enumerable.Range(1, 64).Select( x => (int)x );
        
        ulong result = 0;
        foreach (int num in range) {
            result += Square(num);
        }
        return result;
    }
}