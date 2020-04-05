using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var result = new List<(int, int)>();

        var numberOfRows = matrix.GetLength(0);
        var numberOfCols = matrix.GetLength(1);

        var maximums = Maximums(matrix);
        foreach (var point in maximums) {
            if (IsMinimumIn(point, matrix)) {
                result.Add(point);
            }
        }

        return result.Select(x => (x.Item1 + 1, x.Item2 + 1) ).ToArray();
    }

    private static List<(int, int)> Maximums(int[,] matrix) {
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

    private static bool IsMinimumIn((int, int) point,int[,] matrix) {
        var value = matrix[point.Item1, point.Item2];

        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (matrix[i, point.Item2] < value) {
                return false;
            }
        }
        return true;
    }
}
