using System.Diagnostics;

class Program
{
    static void Main()
    {
        var cagesEasy = new List<KillerSudokuSolver.Cage>
        {
            // EASY
            new(7,  new() { (4, 2), (4, 3) }),
            new(7,  new() { (2, 1), (2, 2) }),
            new(12, new() { (1, 2), (1, 3) }),
            new(12, new() { (3, 5), (3, 6) }),
            new(10, new() { (4, 0), (4, 1) }),
            new(8,  new() { (1, 0), (1, 1) }),
            new(8,  new() { (0, 2), (0, 3) }),
            new(13, new() { (7, 2), (7, 3) }),
            new(17, new() { (6, 2), (6, 3) }),
            new(11, new() { (5, 0), (5, 1) }),
            new(8,  new() { (8, 1), (8, 2) }),
            new(9,  new() { (7, 0), (7, 1) }),
            new(10, new() { (3, 4), (4, 4) }),
            new(7,  new() { (6, 5), (6, 6) }),
            new(7,  new() { (8, 5), (8, 6) }),
            new(9,  new() { (5, 2), (5, 3) }),
            new(9,  new() { (7, 6), (7, 7) }),
            new(12, new() { (1, 7), (1, 8) }),
            new(8,  new() { (1, 5), (1, 6) }),
            new(11, new() { (7, 4), (7, 5) }),
            new(13, new() { (1, 4), (2, 4) }),
            new(5,  new() { (3, 7), (3, 8) }),
            new(7,  new() { (2, 0), (3, 0) }),
            new(17, new() { (5, 5), (5, 6) }),
            new(14, new() { (0, 8), (0, 7) }),
            new(9,  new() { (8, 4), (8, 3) }),
            new(8,  new() { (6, 8), (7, 8) }),
            new(13, new() { (8, 7), (8, 8) }),
            new(5,  new() { (6, 1), (6, 0) }),
            new(5,  new() { (6, 4), (5, 4) }),
            new(10, new() { (3, 1), (3, 2) }),
            new(11, new() { (2, 5), (2, 6) }),
            new(8,  new() { (4, 8), (5, 8) }),
            new(9,  new() { (2, 8), (2, 7) }),
            new(13, new() { (4, 7), (5, 7) }),
            new(7,  new() { (0, 5), (0, 6) }),
            new(14, new() { (2, 3), (3, 3) }),
            new(7,  new() { (6, 7) }),
            new(8,  new() { (8, 0) }),
            new(2,  new() { (0, 4) }),
            new(11, new() { (4, 6), (4, 5) }),
            new(14, new() { (0, 0), (0, 1) })
        };
        var cagesMedium = new List<KillerSudokuSolver.Cage>
        {
            // MEDIUM
            new(3,  new() { (0, 0), (0, 1) }),
            new(10, new() { (0, 2), (0, 3) }),
            new(7,  new() { (0, 4), (1, 4) }),
            new(8,  new() { (0, 5), (1, 5) }),
            new(15, new() { (0, 6), (1, 6) }),
            new(10, new() { (0, 7), (1, 7) }),
            new(14, new() { (0, 8), (1, 8) }),
            new(12, new() { (1, 0), (1, 1) }),
            new(11, new() { (1, 2), (1, 3) }),
            new(15, new() { (2, 0), (2, 1), (3, 0) }),
            new(14, new() { (2, 2), (2, 3) }),
            new(16, new() { (2, 4), (3, 4) }),
            new(10, new() { (2, 5), (2, 6), (2, 7), (2, 8) }),
            new(9,  new() { (3, 1), (3, 2) }),
            new(15, new() { (3, 3), (4, 2), (4, 3) }),
            new(16, new() { (3, 5), (3, 6), (4, 6) }),
            new(14, new() { (3, 7), (4, 7) }),
            new(23,  new() { (3, 8), (4, 8), (5, 7), (5, 8) }),
            new(15, new() { (4, 0), (4, 1), (5, 0) }),
            new(15,  new() { (4, 4), (5, 4), (6, 4) }),
            new(9,  new() { (4, 5), (5, 5) }),
            new(13, new() { (5, 1), (5, 2) }),
            new(12,  new() { (5, 3), (6, 3) }),
            new(7,  new() { (5, 6), (6, 6) }),
            new(9, new() { (6, 0), (7, 0) }),
            new(5, new() { (6, 1), (6, 2) }),
            new(9, new() { (6, 5), (7, 5) }),
            new(12, new() { (6, 7), (6, 8), (7, 8) }),
            new(30,  new() { (7,1), (8, 0), (8, 1), (8, 2) }),
            new(6, new() { (7, 2), (7, 3) }),
            new(8, new() { (7, 4), (8, 3), (8, 4) }),
            new(20, new() { (7, 6), (8, 5), (8, 6) }),
            new(13, new() { (7, 7), (8, 7), (8, 8) })
        };
        var cagesHard = new List<KillerSudokuSolver.Cage>
        {
            // HARD
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
        var cagesNightmare = new List<KillerSudokuSolver.Cage> {
            new(4,  new() { (1, 0), (1, 1) }),
            new(7, new() { (1, 2), (2, 2)}),
            new(5, new(){(0,5), (0,6)}),
            new(8, new() {(0,7), (1,7)}),
            new(14, new() {(1,5), (2,5)}),
            new(13, new() {(2,0), (3,0)}),
            new(11, new() {(2, 6), (2,7)}),
            new(10, new() {(3,1), (3,2)}),
            new(6, new() {(3,3), (3,4)}),
            new(9, new() {(3,5), (4,5)}),
            new(13, new() {(4,3), (5,3)}),
            new(12, new() {(5,4), (5,5)}),
            new(6, new() {(5,6), (5,7)}),
            new(9, new() {(5,8), (6,8)}),
            new(7, new() {(6,1), (6,2)}),
            new(10, new() {(6,3), (7,3)}),
            new(15, new() {(6,6), (7,6)}),
            new(16, new() {(7,1), (8,1)}),
            new(12, new() {(7,7), (7,8)}),
            new(13, new() {(8,2), (8,3)})
        };
        var cages2star = new List<KillerSudokuSolver.Cage>
        {
            new(10, new() {(0,0), (0,1), (0,2), (0,3)}),
            new(18, new() {(0,4), (1,4), (2,4), (3,4)}),
            new(26, new() {(0,5), (0,6), (0,7), (0,8)}),
            new(17, new() {(1,0), (1,1), (1,2)}),
            new(22, new() {(1,3), (2,3), (3,3)}),
            new(11, new() {(1,5), (2,5), (3,5)}),
            new(13, new() {(1,6), (1,7), (1,8)}),
            new(13, new() {(2,0), (2,1)}),
            new(7, new() {(2,2), (3,2)}),
            new(6, new() {(2,6), (3,6)}),
            new(13, new() {(2,7), (2,8)}),
            new(16, new() {(3,0), (4,0), (3,1)}),
            new(18, new() {(3,7), (3,8), (4,8)}),
            new(22, new() {(4,1), (4,2), (5,2), (5,3)}),
            new(20, new() {(4,3), (4,4), (4,5)}),
            new(19, new() {(4,6), (4,7), (5,5), (5,6)}),
            new(15, new() {(5,0), (5,1),(6,1)}),
            new(8, new() {(5,4), (6,4)}),
            new(14, new() {(5,7), (5,8), (6,7)}),
            new(24, new() {(6,0), (7,0), (8,0)}),
            new(14, new() {(6,2), (6,3), (7,2), (7,3)}),
            new(23, new() {(6,5), (6,6), (7,5), (7,6)}),
            new(6, new() {(6,8), (7,8), (8,8)}),
            new(7, new() {(7,1), (8,1), (8,2)}),
            new(20, new() {(8,3), (8,4), (8,5), (7,4)}),
            new(23, new() {(7,7), (8,6), (8,7)})
        };


        var solver = new KillerSudokuSolver(cagesEasy);
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
    Dictionary<(int, int), int> Domains = new();
    List<Cage> Cages;
    Dictionary<(int, int), List<(int, int)>> PeerCache = new();
    Dictionary<(int count, int sum, string excluded), List<List<int>>> CombinationCache = new();


    public record Cage(int Sum, List<(int Row, int Col)> Cells);

    public KillerSudokuSolver(List<Cage> cages)
    {
        Cages = cages;
        InitializeDomains();
        InitializePeers();

    }


    void InitializeDomains()
    {
        for (int r = 0; r < Size; r++)
            for (int c = 0; c < Size; c++)
                Domains[(r, c)] = BitmaskHelper.FullMask;
    }


    void InitializePeers()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                var peers = new HashSet<(int, int)>();

                for (int i = 0; i < Size; i++)
                {
                    if (i != col) peers.Add((row, i)); // row
                    if (i != row) peers.Add((i, col)); // column
                }

                int startRow = (row / 3) * 3, startCol = (col / 3) * 3;
                for (int r = startRow; r < startRow + 3; r++)
                    for (int c = startCol; c < startCol + 3; c++)
                        if (r != row || c != col)
                            peers.Add((r, c)); // box

                PeerCache[(row, col)] = peers.ToList();
            }
        }
    }

    public bool Solve()
    {
        return Backtrack();
    }
    int backtrackCalls = 0;
    int maxDepth = 0;
    bool Backtrack(int depth = 0)
    {
        backtrackCalls++;
        maxDepth = Math.Max(maxDepth, depth);
        var unassigned = Domains
            .Where(kv => Grid[kv.Key.Item1, kv.Key.Item2] == 0)
            .OrderBy(kv => BitmaskHelper.Count(kv.Value))
            .ToList();

        if (!unassigned.Any())
            return true;

        var cell = unassigned.First().Key;
        var domainMask = Domains[cell];

        List<int> domainSorted;
        if (BitmaskHelper.Count(domainMask) > 6)
        {
            domainSorted = BitmaskHelper.Values(domainMask)
                .Select(value => (value, constraints: PeerCache[cell].Count(p => BitmaskHelper.Contains(Domains[p], value))))
                .OrderByDescending(x => x.constraints)
                .Select(x => x.value)
                .ToList();
        }
        else
        {
            domainSorted = BitmaskHelper.Values(domainMask).ToList();
        }

        foreach (var value in domainSorted)
        {
            if (IsValid(cell.Item1, cell.Item2, value))
            {
                Grid[cell.Item1, cell.Item2] = value;

                // Nieuwe: verzamel wijzigingen in deze lijst
                var domainChanges = new Stack<((int, int), int)>();

                if (ForwardCheck(cell.Item1, cell.Item2, value, domainChanges))
                {
                    if (Backtrack(depth +1))
                        return true;
                }

                // Undo domeinwijzigingen
                while (domainChanges.Count > 0)
                {
                    var (pos, oldMask) = domainChanges.Pop();
                    Domains[pos] = oldMask;
                }

                Grid[cell.Item1, cell.Item2] = 0; // Undo waarde
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

    bool ForwardCheck(int row, int col, int value, Stack<((int, int), int)> domainChanges)
    {
        foreach (var pos in PeerCache[(row, col)])
        {
            if (Grid[pos.Item1, pos.Item2] == 0 && BitmaskHelper.Contains(Domains[pos], value))
            {
                domainChanges.Push((pos, Domains[pos]));
                Domains[pos] = BitmaskHelper.Remove(Domains[pos], value);
                if (Domains[pos] == 0) return false;
            }
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
                var oldMask = Domains[cell];
                var newMask = 0;
                foreach (var val in BitmaskHelper.Values(oldMask))
                {
                    if (allowed.Contains(val))
                        newMask |= 1 << (val - 1);
                }

                if (newMask != oldMask)
                {
                    domainChanges.Push((cell, oldMask));
                    Domains[cell] = newMask;
                }

                if (Domains[cell] == 0)
                    return false;
            }
        }

        return true;
    }

    List<List<int>> GetValidCombinations(int count, int sum, List<int> exclude)
    {
        string keyExclude = string.Join(",", exclude.OrderBy(x => x));
        var key = (count, sum, keyExclude);

        if (CombinationCache.TryGetValue(key, out var cached))
            return cached;

        var combos = Enumerable.Range(1, 9)
            .Where(i => !exclude.Contains(i))
            .ToList()
            .Combinations(count)
            .Where(c => c.Sum() == sum)
            .ToList();

        CombinationCache[key] = combos;
        return combos;
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
        Console.WriteLine($"Backtrack calls: {backtrackCalls}, Max depth: {maxDepth}");

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
public static class BitmaskHelper
{
    public const int FullMask = 0b111111111; // All values 1–9 allowed

    public static int ToMask(List<int> values)
    {
        int mask = 0;
        foreach (var v in values)
            mask |= 1 << (v - 1);
        return mask;
    }

    public static List<int> FromMask(int mask)
    {
        var list = new List<int>();
        for (int i = 0; i < 9; i++)
            if ((mask & (1 << i)) != 0)
                list.Add(i + 1);
        return list;
    }

    public static int Remove(int mask, int value)
        => mask & ~(1 << (value - 1));

    public static bool Contains(int mask, int value)
        => (mask & (1 << (value - 1))) != 0;

    public static int Count(int mask)
        => System.Numerics.BitOperations.PopCount((uint)mask);

    public static IEnumerable<int> Values(int mask)
    {
        for (int i = 0; i < 9; i++)
            if ((mask & (1 << i)) != 0)
                yield return i + 1;
    }
}




/*
using System.Diagnostics;

namespace KillerSudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] board = new int[9, 9]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            // Killer sudoku hokken
            List<Cage> cages = new List<Cage>
            {
                // killer 1
                //new Cage(15, new List<(int, int)> { (0, 0), (0, 1), (1, 0), (1, 1) }),
                //new Cage(10, new List<(int, int)> { (0, 2), (0, 3), (1, 2), (1, 3) }),

                // killer 2

                

new Cage(9, new List<(int, int)> {(0, 0), (1, 0)}),
new Cage(28, new List<(int, int)> {(0, 1), (0, 2), (1, 2), (2, 2), (1, 3)}),
new Cage(7, new List<(int, int)> {(1, 1), (2, 1)}),
new Cage(11, new List<(int, int)> {(0, 3), (0, 4), (0, 5), (0, 6)}),
new Cage(15, new List<(int, int)> {(0, 7), (1, 7)}),
new Cage(11, new List<(int, int)> {(0, 8), (1, 8)}),
new Cage(21, new List<(int, int)> {(1, 4), (2, 4), (2, 3)}),
new Cage(12, new List<(int, int)> {(1, 5), (2, 5)}),
new Cage(18, new List<(int, int)> {(1, 6), (2, 6), (2, 7), (2, 8), (3, 7)}),
new Cage(23, new List<(int, int)> {(2, 0), (3, 0), (4, 0), (5, 0)}),
new Cage(12, new List<(int, int)> {(3, 1), (4, 1), (3, 2)}),
new Cage(18, new List<(int, int)> {(3, 3), (4, 3), (5, 3), (4, 2)}),
new Cage(19, new List<(int, int)> {(3, 4), (4, 4), (5, 4)}),
new Cage(16, new List<(int, int)> {(3, 5), (4, 5), (5, 5)}),
new Cage(14, new List<(int, int)> {(3, 6), (4, 6), (4, 7)}),
new Cage(18, new List<(int, int)> {(3, 8), (4, 8), (5, 8), (6, 8)}),
new Cage(9, new List<(int, int)> {(5, 1), (5, 2)}),
new Cage(12, new List<(int, int)> {(5, 6), (5, 7)}),
new Cage(44, new List<(int, int)> {(6, 0), (7, 0), (8, 0), (6, 1), (7, 1), (8, 1), (6, 2), (7, 2)}),
new Cage(15, new List<(int, int)> {(6, 3), (7, 3)}),
new Cage(16, new List<(int, int)> {(6, 4), (7, 4), (6, 5)}),
new Cage(11, new List<(int, int)> {(6, 6), (6, 7)}),
new Cage(9, new List<(int, int)> {(7, 5), (7, 6), (8, 6)}),
new Cage(24, new List<(int, int)> {(7, 7), (7, 8), (8, 7), (8, 8)}),
new Cage(13, new List<(int, int)> {(8, 2), (8, 3), (8, 4), (8, 5)})





                // etc..
            };

            Stopwatch atimer = Stopwatch.StartNew();
            KillerSudokuSolver solver = new KillerSudokuSolver(board, cages);
            if (solver.Solve())
            {
                Console.WriteLine("Solved Killer Sudoku:");
                solver.PrintBoard();
            }
            else
            {
                Console.WriteLine("No solution exists.");
            }
            atimer.Stop();
            Console.WriteLine("Elapsed time: " + atimer.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }
    }

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
        private int[,] board;
        private List<Cage> cages;
        private const int SIZE = 9;
        private Dictionary<(int, int), List<Cage>> cellCages;

        // Klassieke sudoku constraints: row, col en grid  
        private bool[,] rowUsed = new bool[9, 10];
        private bool[,] colUsed = new bool[9, 10];
        private bool[,] gridUsed = new bool[9, 10];

        public KillerSudokuSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
            cellCages = CellsToCages();
        }

        // Maak dictionary van welke cage bij elke cel hoort
        private Dictionary<(int, int), List<Cage>> CellsToCages()
        {
            var dict = new Dictionary<(int, int), List<Cage>>();
            foreach (var cage in cages)
            {
                foreach (var cell in cage.Cells)
                {
                    if (!dict.ContainsKey(cell))
                    {
                        dict[cell] = new List<Cage>();
                    }
                    dict[cell].Add(cage);
                }
            }
            return dict;
        }
        int backtrackcalls = 0;
        public bool Solve()
        {
            backtrackcalls++;
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    if (board[row, col] == 0)
                    {
                        for (int num = 1; num <= SIZE; num++)
                        {
                            int box = GetGridIndex(row, col);
                            // Check constraints van rows, cols, grids en cages
                            if (!rowUsed[row, num] && !colUsed[col, num] && !gridUsed[box, num] && IsCageConstrained(row, col, num))
                            {
                                board[row, col] = num;
                                rowUsed[row, num] = true;
                                colUsed[col, num] = true;
                                gridUsed[box, num] = true;

                                if (Solve()) return true; // Recursie 

                                // Backtracking als het faalt
                                board[row, col] = 0;
                                rowUsed[row, num] = false;
                                colUsed[col, num] = false;
                                gridUsed[box, num] = false;
                            }
                        }

                        return false;
                    }
                }
            }
            return true; // Solved
        }

        private int GetGridIndex(int row, int col)
        {
            return (row / 3) * 3 + (col / 3);
        }

        // Check of de value in de cage mag volgens de cage constraints
        private bool IsCageConstrained(int row, int col, int num)
        {
            if (cellCages.TryGetValue((row, col), out var cagesForCell))
            {
                foreach (var cage in cagesForCell)
                {
                    int currentSum = 0;
                    int emptyCells = 0;

                    foreach (var cell in cage.Cells)
                    {
                        int r = cell.Item1;
                        int c = cell.Item2;

                        // Getallen mogen niet dubbel voorkomen in de cage
                        if (board[r, c] == num && (r != row || c != col))
                            return false;

                        // Lege cellen tellen en som optellen
                        if (board[r, c] == 0)
                            emptyCells++;
                        currentSum += board[r, c];
                    }

                    // De som van getallen mag niet boven het target uitkomen
                    if (currentSum + num > cage.TargetSum)
                        return false;

                    // Bij de laatste lege cel moet de som gelijk zijn aan het target
                    if (emptyCells == 1 && currentSum + num != cage.TargetSum)
                        return false;
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            for (int r = 0; r < SIZE; r++)
            {
                for (int d = 0; d < SIZE; d++)
                {
                    Console.Write(board[r, d]);
                    Console.Write(" ");
                }
                Console.WriteLine();

                if ((r + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"Backtrack calls: {backtrackcalls}");
        }
    }
}*/