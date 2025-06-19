/*using System;
using System.Collections.Generic;
using System.Linq;

public class Cage
{
    public int TargetSum { get; }
    public List<(int, int)> Cells { get; }

    public Cage(int targetSum, List<(int, int)> cells)
    {
        TargetSum = targetSum;
        Cells = cells;
    }
}

public class ForwardTracking
{
    private const int Size = 9;
    private int[,] board = new int[Size, Size];
    private List<Cage> cages;

    public ForwardTracking(List<Cage> cages)
    {
        this.cages = cages;
    }

    public bool Solve()
    {
        return ForwardCheck(0, 0);
    }

    private bool ForwardCheck(int row, int col)
    {
        if (row == Size)
            return true;

        int nextRow = col == Size - 1 ? row + 1 : row;
        int nextCol = col == Size - 1 ? 0 : col + 1;

        if (board[row, col] != 0)
            return ForwardCheck(nextRow, nextCol);

        for (int num = 1; num <= 9; num++)
        {
            board[row, col] = num;
            if (IsValid(row, col) && ForwardCheck(nextRow, nextCol))
                return true;
            board[row, col] = 0;
        }

        return false;
    }

    private bool IsValid(int row, int col)
    {
        int val = board[row, col];

        // Check row and column
        for (int i = 0; i < Size; i++)
        {
            if (i != col && board[row, i] == val) return false;
            if (i != row && board[i, col] == val) return false;
        }

        // Check 3x3 box
        int boxRow = (row / 3) * 3;
        int boxCol = (col / 3) * 3;
        for (int i = boxRow; i < boxRow + 3; i++)
        {
            for (int j = boxCol; j < boxCol + 3; j++)
            {
                if ((i != row || j != col) && board[i, j] == val) return false;
            }
        }

        // Check cage constraint
        foreach (var cage in cages)
        {
            if (cage.Cells.Any(cell => cell.Item1 == row && cell.Item2 == col))
            {
                int sum = 0;
                var values = new HashSet<int>();
                foreach (var (r, c) in cage.Cells)
                {
                    int v = board[r, c];
                    if (v != 0)
                    {
                        if (!values.Add(v)) return false;
                        sum += v;
                    }
                }
                if (values.Count == cage.Cells.Count && sum != cage.TargetSum) return false;
                if (sum > cage.TargetSum) return false;
            }
        }

        return true;
    }

    public void PrintBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}*/