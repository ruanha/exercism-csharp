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
        int lower = 0;
        int upper = input.Length;

        while (input[index] != value) {
            if (input[index] > value) {
                upper = index - 1;
                index = (lower + index) / 2;
            }
            else {
                lower = index + 1;
                index = index + (upper - index);
            }
        }

        return index;
    }
}