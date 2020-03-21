using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span > digits.Length || span < 0) throw new ArgumentException();

        var numbers = ConvertToIntegerList(digits);

        long largest = 0;
        for (int i = 0; i <= digits.Count() - span; i++) {
            var slice = numbers.Skip(i).Take(span);
            if (slice.Product() > largest) {
                largest = slice.Product();
            }
        }
        return largest;
    } 

    private static List<int> ConvertToIntegerList(string digits) {
        var digitsList = new List<int>();
        foreach (char digit in digits) {
            var numericValue = char.GetNumericValue(digit);
            if (numericValue >= 0) {
                digitsList.Add((int) numericValue);
            }
            else {
                throw new ArgumentException();
            }
        }
        return digitsList;
    }

    private static int Product(this IEnumerable<int> slice) {
        int result = 1;
        foreach (int digit in slice){
            result *= digit;
        }
        return result;
     }
}