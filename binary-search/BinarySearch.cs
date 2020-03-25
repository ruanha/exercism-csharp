using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int index = input.Length / 2;
        int lower = 0;
        int upper = input.Length;

        while (upper != lower && input[index] != value) {
            if (input[index] > value) {
                upper = index;
                index = (lower + index) / 2;
            }
            else {
                lower = index + 1;
                index = (index + upper) / 2;
            }
        }
        if (input.Length == 0) return -1;
        return input[index] == value ? index : -1;
    }
}