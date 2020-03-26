using System;
using System.Linq;
using System.Collections.Generic;

public class Matrix
{
    public List<int[]> _rows = new List<int[]>();
    public Matrix(string input)
    {
        var rowsAsStrings = input
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
        throw new NotImplementedException("You need to implement this function.");
    }
}