using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength < 1) 
            throw new ArgumentException("slice length can't be larger than number length");

        var result = new List<string>();
        for (int i = 0; i <= numbers.Length - sliceLength; i++ ) {
            result.Add(numbers.Substring(i, sliceLength));
        }
        return result.ToArray();
    }
}