using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        Enumerable
            .Range    (0, max)
            .Where    (x => multiples
                .Any  (m => m != 0 && x % m == 0))
            .Distinct ()
            .Sum      ();
}