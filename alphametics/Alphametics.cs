using System;
using System.Linq;
using System.Collections.Generic;

public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        Matrix matrix = new Matrix(equation.Split("==")[0]);
        Matrix resultRow = new Matrix(equation.Split("==")[1]);
        Print(matrix, resultRow);
        //return Search(matrix, resultRow;
        return new Dictionary<char, int>();
    }

    public static void Print(Matrix matrix, Matrix resultRow) {
        Console.WriteLine("Print the matrix and result row");
        var numberOfRows = matrix.Column(0).Count();
        var numberOfColumns = matrix.Row(0).Count();
        var numberOfColumnsInResult = resultRow.Row(0).Count();

        for (int i = 0; i < numberOfRows; i++ ) {
            for (int k = 0; k < numberOfColumnsInResult - numberOfColumns; k++) {
                Console.Write("| ");
            }
            for (int j = 0; j < numberOfColumns; j++) {
                var l = matrix.Cell(i,j).Letter != null ? matrix.Cell(i,j).Letter.ToString() : " ";
                Console.Write("|" + l);
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("-------");
        foreach (Unit u in resultRow.Row(0)) {
            Console.Write("|" + u.Letter);
        }
        Console.WriteLine("|");
    }

    public class Unit {
        public char? Letter;
        public List<int> Values;

        public Unit(char? letter = null) {
            Letter = letter;
            Values = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
    }

    public class Matrix
    {
        private readonly List<Unit[]> _rows = new List<Unit[]>();

        public Matrix(string input)
        {
            var temp = input
                .Split("+")
                .Select(word => word.Trim());
            var lengthOfMatrix = temp
                .Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;
            
            foreach (string word in temp) {
                var row = new Unit[lengthOfMatrix];

                for (int i = lengthOfMatrix - 1; i >= 0; i--) {
                    if (i < word.Length) {
                        row[i] = new Unit(word[i]);
                    } else {
                        row[i] = new Unit();
                    }
                }
                _rows.Add(row.Reverse().ToArray());
            }
        }

        public Unit Cell(int row, int col) {
            return Row(row).ElementAt(col);
        }

        public IEnumerable<Unit> Row(int row) => _rows[row];

        public IEnumerable<Unit> Column(int col) => _rows
            .Select(row => row[ col]);
    }
}

 