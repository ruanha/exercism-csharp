using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span > digits.Length || span < 0 || digits.Any(c => Char.GetNumericValue(c) < 0 ))
            throw new ArgumentException();

        var numbers = digits.Select(c => (int)Char.GetNumericValue(c));

        var range = Enumerable.Range(0, digits.Length - span + 1);

        return range.Select  (i => numbers
                    .Skip    (i)
                    .Take    (span)
                    .Product ())
                    .Max     ()
                    ;
    } 

    private static int Product(this IEnumerable<int> slice) => 
        slice.Aggregate(1, (i, p) => i * p);
}