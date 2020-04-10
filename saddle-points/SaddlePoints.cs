using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix) => matrix
        .RowMaximums()
        .Where(point => matrix.IsColumnMinimum(point))
        .ToOneBasedArray();

    private static List<(int, int)> RowMaximums(this int[,] matrix) {
        var result = new List<(int, int)>();

        for (int i = 0; i < matrix.GetLength(0); i++) {
            var max = matrix[i,0];

            var pointsOfInterest = new List<(int, int)>{(i,0)};
            
            for (int j = 1; j < matrix.GetLength(1); j++) {
                if (matrix[i,j] > max) {
                    max = matrix[i,j];
                    pointsOfInterest.Clear();
                    pointsOfInterest.Add((i, j));
                } 
                else if (matrix[i,j] == max) {
                    pointsOfInterest.Add((i, j));
                }
            }
            result.AddRange(pointsOfInterest);
        }
        return result;
    }

    private static bool IsColumnMinimum(this int[,] matrix, (int, int) point) {
        int valueAtPoint = matrix[point.Item1, point.Item2];

        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (matrix[i, point.Item2] < valueAtPoint) {
                return false;
            }
        }
        return true;
    }

    private static (int, int)[] ToOneBasedArray(this IEnumerable<(int, int)> list) =>
        list.Select(x => (x.Item1 + 1, x.Item2 + 1) ).ToArray();
}
