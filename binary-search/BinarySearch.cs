using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) {
            return -1;
        }

        int index = input.Length / 2;

        while (input[index] != value) {
            
        }

        return index;
    }
}