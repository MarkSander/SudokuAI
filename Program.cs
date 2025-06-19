using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        var cages = new List<KillerSudokuSolver.Cage>
{
    new(9,  new() { (0, 0), (1, 0) }),
    new(28, new() { (0, 1), (0, 2), (1, 2), (2, 2), (1, 3) }),
    new(7,  new() { (1, 1), (2, 1) }),
    new(11, new() { (0, 3), (0, 4), (0, 5), (0, 6) }),
    new(15, new() { (0, 7), (1, 7) }),
    new(11, new() { (0, 8), (1, 8) }),
    new(21, new() { (1, 4), (2, 4), (2, 3) }),
    new(12, new() { (1, 5), (2, 5) }),
    new(18, new() { (1, 6), (2, 6), (2, 7), (2, 8), (3, 7) }),
    new(23, new() { (2, 0), (3, 0), (4, 0), (5, 0) }),
    new(12, new() { (3, 1), (4, 1), (3, 2) }),
    new(18, new() { (3, 3), (4, 3), (5, 3), (4, 2) }),
    new(19, new() { (3, 4), (4, 4), (5, 4) }),
    new(16, new() { (3, 5), (4, 5), (5, 5) }),
    new(14, new() { (3, 6), (4, 6), (4, 7) }),
    new(18, new() { (3, 8), (4, 8), (5, 8), (6, 8) }),
    new(9,  new() { (5, 1), (5, 2) }),
    new(12, new() { (5, 6), (5, 7) }),
    new(44, new() { (6, 0), (7, 0), (8, 0), (6, 1), (7, 1), (8, 1), (6, 2), (7, 2) }),
    new(15, new() { (6, 3), (7, 3) }),
    new(16, new() { (6, 4), (7, 4), (6, 5) }),
    new(11, new() { (6, 6), (6, 7) }),
    new(9,  new() { (7, 5), (7, 6), (8, 6) }),
    new(24, new() { (7, 7), (7, 8), (8, 7), (8, 8) }),
    new(13, new() { (8, 2), (8, 3), (8, 4), (8, 5) })
};


        var solver = new KillerSudokuSolver(cages);
        var stopwatch = Stopwatch.StartNew();
        bool solved = solver.Solve();
        stopwatch.Stop();

        if (solved)
        {
            solver.Print();
            Console.WriteLine($"Solved in {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("No solution found.");
            Console.ReadLine();
        }

    }

}



public class KillerSudokuSolver
{
    const int Size = 9;
    int[,] Grid = new int[Size, Size];
    Dictionary<(int, int), List<int>> Domains = new();
    List<Cage> Cages;

    public record Cage(int Sum, List<(int Row, int Col)> Cells);

    public KillerSudokuSolver(List<Cage> cages)
    {
        Cages = cages;
        InitializeDomains();
    }

    void InitializeDomains()
    {
        for (int r = 0; r < Size; r++)
            for (int c = 0; c < Size; c++)
                Domains[(r, c)] = Enumerable.Range(1, 9).ToList();
    }

    public bool Solve()
    {
        return Backtrack();
    }

    bool Backtrack()
    {
        var unassigned = Domains
            .Where(kv => Grid[kv.Key.Item1, kv.Key.Item2] == 0)
            .OrderBy(kv => kv.Value.Count)
            .ToList();

        if (!unassigned.Any())
            return true; // Solved

        var cell = unassigned.First().Key;
        var domain = unassigned.First().Value;

        foreach (var value in domain.ToList())
        {
            if (IsValid(cell.Item1, cell.Item2, value))
            {
                var backupGrid = (int[,])Grid.Clone();
                var backupDomains = DeepCloneDomains();

                Grid[cell.Item1, cell.Item2] = value;

                if (ForwardCheck(cell.Item1, cell.Item2, value))
                {
                    if (Backtrack())
                        return true;
                }

                Grid = backupGrid;
                Domains = backupDomains;
            }
        }
        return false;
    }

    bool IsValid(int row, int col, int value)
    {
        for (int i = 0; i < Size; i++)
        {
            if (Grid[row, i] == value || Grid[i, col] == value)
                return false;
        }

        int startRow = (row / 3) * 3, startCol = (col / 3) * 3;
        for (int r = startRow; r < startRow + 3; r++)
            for (int c = startCol; c < startCol + 3; c++)
                if (Grid[r, c] == value)
                    return false;

        return true;
    }

    bool ForwardCheck(int row, int col, int value)
    {
        foreach (var pos in GetPeers(row, col))
        {
            Domains[pos].Remove(value);
            if (!Domains[pos].Any() && Grid[pos.Item1, pos.Item2] == 0)
                return false;
        }

        foreach (var cage in Cages.Where(c => c.Cells.Contains((row, col))))
        {
            var assigned = cage.Cells
                .Where(p => Grid[p.Row, p.Col] != 0)
                .Select(p => Grid[p.Row, p.Col])
                .ToList();

            var unassigned = cage.Cells
                .Where(p => Grid[p.Row, p.Col] == 0)
                .ToList();

            int remaining = cage.Sum - assigned.Sum();

            if (unassigned.Count == 0)
                return assigned.Sum() == cage.Sum && assigned.Distinct().Count() == assigned.Count;

            var combos = GetValidCombinations(unassigned.Count, remaining, assigned);
            var allowed = combos.SelectMany(c => c).ToHashSet();

            foreach (var cell in unassigned)
            {
                Domains[cell] = Domains[cell].Where(d => allowed.Contains(d)).ToList();
                if (!Domains[cell].Any())
                    return false;
            }
        }

        return true;
    }

    List<List<int>> GetValidCombinations(int count, int sum, List<int> exclude)
    {
        return Enumerable.Range(1, 9)
            .Where(i => !exclude.Contains(i))
            .ToList()
            .Combinations(count)
            .Where(c => c.Sum() == sum)
            .ToList();
    }

    List<(int, int)> GetPeers(int row, int col)
    {
        var peers = new HashSet<(int, int)>();

        for (int i = 0; i < Size; i++)
        {
            if (i != col) peers.Add((row, i));
            if (i != row) peers.Add((i, col));
        }

        int startRow = (row / 3) * 3, startCol = (col / 3) * 3;
        for (int r = startRow; r < startRow + 3; r++)
            for (int c = startCol; c < startCol + 3; c++)
                if (r != row || c != col) peers.Add((r, c));

        return peers.ToList();
    }

    Dictionary<(int, int), List<int>> DeepCloneDomains()
    {
        return Domains.ToDictionary(
            kv => kv.Key,
            kv => new List<int>(kv.Value)
        );
    }

    public void Print()
    {
        for (int r = 0; r < Size; r++)
        {
            for (int c = 0; c < Size; c++)
                Console.Write($"{Grid[r, c]} ");
            Console.WriteLine();
        }
    }
}

public static class Extensions
{
    public static IEnumerable<List<T>> Combinations<T>(this List<T> list, int length)
    {
        if (length == 0) yield return new List<T>();
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                var head = list[i];
                var tail = list.Skip(i + 1).ToList();
                foreach (var tailComb in tail.Combinations(length - 1))
                {
                    tailComb.Insert(0, head);
                    yield return tailComb;
                }
            }
        }
    }
}

