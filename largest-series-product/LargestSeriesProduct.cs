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

        long largest = 0;
        for (int i = 0; i <= digits.Count() - span; i++) {
            var slice = numbers.Skip(i).Take(span);
            if (slice.Product() > largest) {
                largest = slice.Product();
            }
        }
        return largest;
    } 

    private static int Product(this IEnumerable<int> slice) {
        int result = 1;
        foreach (int digit in slice){
            result *= digit;
        }
        return result;
     }
}