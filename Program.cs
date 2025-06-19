using System;
using System.Collections.Generic;
using System.Diagnostics;
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

public class KillerSudokuSolver
{
    private const int Size = 9;
    private int[,] board = new int[Size, Size];
    private List<Cage> cages;
    private Dictionary<(int, int), Cage> cellToCage = new();

    public KillerSudokuSolver(List<Cage> cages)
    {
        this.cages = cages;
        foreach (var cage in cages)
        {
            foreach (var cell in cage.Cells)
            {
                cellToCage[cell] = cage;
            }
        }
    }

    public bool Solve()
    {
        return ForwardCheck();
    }

    private bool ForwardCheck()
    {
        (int row, int col)? next = SelectUnassignedCell();
        if (!next.HasValue)
            return true;

        int r = next.Value.row;
        int c = next.Value.col;

        foreach (int num in OrderDomainValues(r, c))
        {
            board[r, c] = num;
            if (IsValid(r, c) && ForwardCheck())
                return true;
            board[r, c] = 0;
        }

        return false;
    }

    private (int, int)? SelectUnassignedCell()
    {
        int minOptions = int.MaxValue;
        (int, int)? best = null;

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (board[i, j] == 0)
                {
                    var options = GetPossibleValues(i, j);
                    if (options.Count < minOptions)
                    {
                        minOptions = options.Count;
                        best = (i, j);
                        if (minOptions == 1) return best;
                    }
                }
            }
        }

        return best;
    }

    private List<int> OrderDomainValues(int row, int col)
    {
        var options = GetPossibleValues(row, col);
        options.Sort((a, b) => CountConstraints(row, col, a).CompareTo(CountConstraints(row, col, b)));
        return options;
    }

    private int CountConstraints(int row, int col, int value)
    {
        int count = 0;
        for (int i = 0; i < Size; i++)
        {
            if (board[row, i] == 0) count++;
            if (board[i, col] == 0) count++;
        }
        return count;
    }

    private List<int> GetPossibleValues(int row, int col)
    {
        var possible = Enumerable.Range(1, 9).ToList();

        for (int i = 0; i < Size; i++)
        {
            possible.Remove(board[row, i]);
            possible.Remove(board[i, col]);
        }

        int boxRow = (row / 3) * 3;
        int boxCol = (col / 3) * 3;
        for (int i = boxRow; i < boxRow + 3; i++)
            for (int j = boxCol; j < boxCol + 3; j++)
                possible.Remove(board[i, j]);

        if (cellToCage.TryGetValue((row, col), out var cage))
        {
            var filledValues = new HashSet<int>();
            int sum = 0;
            int empty = 0;

            foreach (var (r, c) in cage.Cells)
            {
                int v = board[r, c];
                if (v != 0)
                {
                    filledValues.Add(v);
                    sum += v;
                }
                else
                {
                    empty++;
                }
            }

            possible = possible.Where(v => !filledValues.Contains(v) && sum + v <= cage.TargetSum).ToList();
        }

        return possible;
    }

    private bool IsValid(int row, int col)
    {
        int val = board[row, col];

        for (int i = 0; i < Size; i++)
        {
            if (i != col && board[row, i] == val) return false;
            if (i != row && board[i, col] == val) return false;
        }

        int boxRow = (row / 3) * 3;
        int boxCol = (col / 3) * 3;
        for (int i = boxRow; i < boxRow + 3; i++)
            for (int j = boxCol; j < boxCol + 3; j++)
                if ((i != row || j != col) && board[i, j] == val) return false;

        if (cellToCage.TryGetValue((row, col), out var cage))
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
}

class Program
{
    static void Main()
    {
        var cages = new List<Cage>
        {
            new Cage(9,  new List<(int, int)> { (0, 0), (1, 0) }),
            new Cage(28, new List<(int, int)> { (0, 1), (0, 2), (1, 2), (2, 2), (1,3) }),
            new Cage(7,  new List<(int, int)> { (1, 1), (2, 1) }),
            new Cage(11, new List<(int, int)> { (0, 3), (0, 4), (0, 5), (0,6) }),
            new Cage(15, new List<(int, int)> { (0, 7), (1, 7) }),
            new Cage(11, new List<(int, int)> { (0, 8), (1, 8)}),
            new Cage(21, new List<(int, int)> {(1, 4), (2,4), (2,3)}),
            new Cage(12, new List<(int, int)> {(1, 5), (2,5) }),
            new Cage(18, new List<(int, int)> {(1, 6), (2,6), (2,7), (2,8), (3,7) }),
            new Cage(23, new List<(int, int)> {(2,0), (3,0), (4,0), (5,0) }),
            new Cage(12, new List<(int, int)> {(3,1), (4, 1), (3, 2)}),
            new Cage(18, new List<(int, int)> {(3, 3), (4, 3), (5, 3), (4,2)}),
            new Cage(19, new List<(int, int)> {(3, 4), (4, 4), (5, 4)}),
            new Cage(16, new List<(int, int)> {(3, 5), (4, 5), (5, 5)}),
            new Cage(14, new List<(int, int)> {(3, 6), (4, 6), (4, 7)}),
            new Cage(18, new List<(int, int)> {(3, 8), (4, 8), (5, 8), (6,8)}),
            new Cage(9, new List<(int, int)> {(5, 1), (5, 2)}),
            new Cage(12, new List<(int, int)> {(5, 6), (5, 7)}),
            new Cage(44, new List<(int, int)> {(6, 0), (7, 0), (8, 0), (6,1), (7,1), (8,1), (6,2), (7,2)}),
            new Cage(15, new List<(int, int)> {(6, 3), (7, 3)}),
            new Cage(16, new List<(int, int)> {(6, 4), (7, 4), (6, 5)}),
            new Cage(11, new List<(int, int)> {(6, 6), (6, 7)}),
            new Cage(9, new List<(int, int)> {(7,5), (7, 6), (8, 6)}),
            new Cage(24, new List<(int, int)> {(7, 7), (7, 8), (8,7), (8,8)}),
            new Cage(13, new List<(int, int)> {(8, 2), (8, 3), (8, 4), (8,5)})
        };

        var solver = new KillerSudokuSolver(cages);
        var stopwatch = Stopwatch.StartNew();

        if (solver.Solve())
        {
            stopwatch.Stop();
            Console.WriteLine("Solved Killer Sudoku:");
            solver.PrintBoard();
            Console.WriteLine($"Solved in {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            stopwatch.Stop();
            Console.WriteLine("No solution found.");
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}