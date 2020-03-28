using System.Linq;
using System.Collections.Generic;

public class Matrix
{
    private readonly List<int[]> _rows = new List<int[]>();

    public Matrix(string input)
    {
        _rows = input
            .Split("\n")
            .Select(row => row.Split(" ")
                .Select(num => int.Parse(num))
                .ToArray())
            .ToList();
    }

    public IEnumerable<int> Row(int row) => _rows[row - 1];

    public IEnumerable<int> Column(int col) => _rows
        .Select(row => row[ col -1]);
}