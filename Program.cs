using System.Diagnostics;

class Program
{
    static void Main()
    {
        var cages = new List<KillerSudokuSolver.Cage>
        {
            // EASY
/*            new(7,  new() { (4, 2), (4, 3) }),
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
            new(14, new() { (0, 0), (0, 1) })*/

            // MEDIUM
            /*new(3,  new() { (0, 0), (0, 1) }),
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
            new(13, new() { (7, 7), (8, 7), (8, 8) })*/

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
    Dictionary<(int, int), List<(int, int)>> PeerCache = new();

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
                Domains[(r, c)] = Enumerable.Range(1, 9).ToList();
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

    bool Backtrack()
    {
        var unassigned = Domains
            .Where(kv => Grid[kv.Key.Item1, kv.Key.Item2] == 0) // Lege cellen
            .OrderBy(kv => kv.Value.Count) // MRV: sorteren op kleinste domein
            .ToList();

        if (!unassigned.Any())
            return true; // Solved

        var cell = unassigned.First().Key; // MRV: cel met kleinste domein (en dus minste valide opties)
        var domain = unassigned.First().Value;

        // LCV: domein wordt gesorteerd op least constraining value (komt minste voor bij peers)
        List<int> domainSortedByLeastConstraints;
        if (domain.Count > 6)
        {
            domainSortedByLeastConstraints = domain
                .Select(value => (value, Constraints: PeerCache[(cell.Item1, cell.Item2)].Count(p => Domains[p].Contains(value))))
                .OrderByDescending(x => x.Constraints)
                .Select(x => x.value)
                .ToList();
        }
        else
        {
            domainSortedByLeastConstraints = domain.ToList();
        }

        foreach (var value in domainSortedByLeastConstraints)
        {
            if (IsValid(cell.Item1, cell.Item2, value)) // Basis sudoku check row col grid
            {
                var backupGrid = (int[,])Grid.Clone(); // Backup huidige grid
                var backupDomains = DeepCloneDomains(); // Backup huidige domains 

                Grid[cell.Item1, cell.Item2] = value;

                if (ForwardCheck(cell.Item1, cell.Item2, value)) // FC: value verwijderen uit domain van cellen in zelfde row col grid en cage en geldigheid checken
                {
                    if (Backtrack()) // Recursieve backtrack
                        return true;
                }

                // Grid terugzetten als FC faalt
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
        foreach (var pos in PeerCache[(row, col)]) // Value verwijderen uit domein van cellen in zelfde row col en grid
        {
            Domains[pos].Remove(value);
            if (!Domains[pos].Any() && Grid[pos.Item1, pos.Item2] == 0) return false; // Faal als domein leeg raakt voor een lege peer
        }

        foreach (var cage in Cages.Where(c => c.Cells.Contains((row, col)))) // Cage waar de cel in zit
        {
            // Cellen in cage die al ingevuld zijn
            var assigned = cage.Cells
                .Where(p => Grid[p.Row, p.Col] != 0)
                .Select(p => Grid[p.Row, p.Col])
                .ToList();

            // Cellen in cage die nog leeg zijn
            var unassigned = cage.Cells
                .Where(p => Grid[p.Row, p.Col] == 0)
                .ToList();

            int remaining = cage.Sum - assigned.Sum();

            // Als alle cellen ingevuld zijn moet de som kloppen en moeten de values uniek zijn
            if (unassigned.Count == 0)
                return assigned.Sum() == cage.Sum && assigned.Distinct().Count() == assigned.Count;

            var combos = GetValidCombinations(unassigned.Count, remaining, assigned); // Geldige combinaties die de rest van de som maken met de hoeveelheid lege cellen
            var allowed = combos.SelectMany(c => c).ToHashSet();

            foreach (var cell in unassigned)
            {
                Domains[cell] = Domains[cell].Where(allowed.Contains).ToList(); // Intersectie domain en geldige combinaties
                if (!Domains[cell].Any()) return false; // Faal als domain leeg raakt
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

