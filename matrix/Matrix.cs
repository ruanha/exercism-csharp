using System;
using System.Linq;
using System.Collections.Generic;

public class Matrix
{
    public List<int[]> _rows = new List<int[]>();

    public Matrix(string input)
    {
        string[] rowsAsStrings = input
            .Split("\n");
        
        foreach (string row in rowsAsStrings) {
            int[] arr = row.Split(" ").Select(x => int.Parse(x)).ToArray();
            _rows.Add(arr);
        }
    }

    public int Rows
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Cols
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int[] Row(int row)
    {
        return _rows[row - 1];
    }

    public int[] Column(int col)
    {
        var result = new List<int>();
        foreach (int[] row in _rows) {
            result.Add(row[col - 1]);
        }
        return result.ToArray();
    }
}