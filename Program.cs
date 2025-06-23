using System.Diagnostics;

class Program
{
    static void Main()
    {
        var cagesEasy = new List<KillerSudokuSolver.Cage>
        {
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
        var cagesMedium2 = new List<KillerSudokuSolver.Cage>
        {
            new(11, new () { (0, 0), (1, 0) }),
            new(11, new () { (0, 1), (1, 1) }),
            new(3, new () { (0, 2), (1, 2) }),
            new(12, new () { (0, 3), (1, 3) }),
            new(18, new () { (0, 4), (0, 5), (0, 6) }),
            new(7, new () { (0, 7), (0, 8) }),
            new(14, new () { (1, 4), (2, 4), (2, 3) }),
            new(25, new () { (1, 5), (1, 6), (2, 5), (2, 6) }),
            new(14, new () { (1, 7), (1, 8), (2, 7), (2, 8) }),
            new(15, new () { (2, 0), (3, 0), (4, 0) }),
            new(10, new () { (2, 1), (3, 1) }),
            new(14, new () { (2, 2), (3, 2) }),
            new(14, new () { (3, 3), (3, 4) }),
            new(17, new () { (3, 5), (4, 5), (5, 5) }),
            new(6, new () { (3, 6), (4, 6) }),
            new(9, new () { (3, 7), (3, 8) }),
            new(11, new () { (4, 1), (4, 2) }),
            new(10, new () { (4, 3), (4, 4), (5, 3) }),
            new(23, new () { (4, 7), (4, 8), (5, 7), (6, 7) }),
            new(23, new () { (5, 0), (5, 1), (6, 1), (7, 1) }),
            new(7, new () { (5, 2), (6, 2) }),
            new(25, new () { (5, 4), (6, 4), (6, 5), (7, 4), (8, 4) }),
            new(7, new () { (5, 6), (6, 6) }),
            new(9, new () { (5, 8), (6, 8) }),
            new(12, new () { (6, 0), (7, 0), (8, 0) }),
            new(12, new () { (6, 3), (7, 3), (7, 2) }),
            new(11, new () { (7, 5), (7, 6) }),
            new(13, new () { (7, 7), (7, 8) }),
            new(20, new () { (8, 1), (8, 2), (8, 3) }),
            new(7, new () { (8, 5), (8, 6) }),
            new(15, new () { (8, 7), (8, 8) }),
        };
        var cages15893 = new List<KillerSudokuSolver.Cage>
        {
            new(10, new() { (0, 0), (0, 1) }),
            new(12, new() { (0, 2), (0, 3), (0, 4) }),
            new(15, new() { (0, 5), (0, 6), (0, 7) }),
            new(9, new() { (0, 8), (1, 8) }),
            new(7, new() { (1, 0), (1, 1) }),
            new(21, new() { (1, 2), (1, 3), (1, 4) }),
            new(16, new() { (1, 5), (1, 6), (1, 7) }),
            new(19, new() { (2, 0), (3, 0), (4, 0) }),
            new(14, new() { (2, 1), (3, 1), (4, 1) }),
            new(6, new() { (2, 2), (3, 2) }),
            new(16, new() { (2, 3), (3, 3) }),
            new(6, new() { (2, 4), (2, 5) }),
            new(9, new() { (2, 6), (2, 7) }),
            new(15, new() { (2, 8), (3, 8) }),
            new(4, new() { (3, 4), (3, 5) }),
            new(18, new() { (3, 6), (3, 7), (4, 6) }),
            new(12, new() { (4, 2), (5, 2), (5, 1) }),
            new(19, new() { (4, 3), (4, 4), (4, 5) }),
            new(14, new() { (4, 7), (5, 7), (6, 7) }),
            new(12, new() { (4, 8), (5, 8), (6, 8) }),
            new(12, new() { (5, 0), (6, 0) }),
            new(10, new() { (5, 3), (5, 4) }),
            new(12, new() { (5, 5), (6, 5) }),
            new(10, new() { (5, 6), (6, 6) }),
            new(3, new() { (6, 1), (6, 2) }),
            new(14, new() { (6, 3), (6, 4) }),
            new(11, new() { (7, 0), (8, 0) }),
            new(19, new() { (7, 1), (7, 2), (7, 3) }),
            new(12, new() { (7, 4), (7, 5), (7, 6) }),
            new(7, new() { (7, 7), (7, 8) }),
            new(14, new() { (8, 1), (8, 2), (8, 3) }),
            new(11, new() { (8, 4), (8, 5), (8, 6) }),
            new(16, new() { (8, 7), (8, 8) }),
        };
        var cagesHard = new List<KillerSudokuSolver.Cage>
        {
            new(9, new() { (0, 0), (1, 0) }),
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
        var cages8229 = new List<KillerSudokuSolver.Cage>
        {
            new(22, new() { (0, 0), (0, 1), (0, 2) }),
            new(10, new() { (0, 3), (1, 3) }),
            new(6, new() { (0, 4), (1, 4) }),
            new(14, new() { (0, 5), (1, 5) }),
            new(13, new() { (0, 6), (0, 7), (0, 8) }),
            new(14, new() { (1, 0), (1, 1), (2, 0), (2, 1) }),
            new(27, new() { (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2) }),
            new(34, new() { (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6) }),
            new(21, new() { (1, 7), (1, 8), (2, 7), (2, 8) }),
            new(13, new() { (2, 3), (3, 3), (4, 3) }),
            new(10, new() { (2, 4), (3, 4) }),
            new(17, new() { (2, 5), (3, 5), (4, 5) }),
            new(9, new() { (3, 0), (3, 1) }),
            new(10, new() { (3, 7), (3, 8) }),
            new(14, new() { (4, 0), (5, 0), (6, 0) }),
            new(11, new() { (4, 1), (5, 1) }),
            new(13, new() { (4, 4), (5, 4) }),
            new(9, new() { (4, 7), (5, 7) }),
            new(15, new() { (4, 8), (5, 8), (6, 8) }),
            new(11, new() { (5, 3), (6, 3) }),
            new(3, new() { (5, 5), (6, 5) }),
            new(21, new() { (6, 1), (7, 1), (7, 2), (7, 3) }),
            new(11, new() { (6, 4), (7, 4) }),
            new(26, new() { (6, 7), (7, 7), (7, 6), (7, 5) }),
            new(7, new() { (7, 0), (8, 0) }),
            new(7, new() { (7, 8), (8, 8) }),
            new(12, new() { (8, 1), (8, 2) }),
            new(21, new() { (8, 3), (8, 4), (8, 5) }),
            new(4, new() { (8, 6), (8, 7) }),
        };
        var cagesHard2 = new List<KillerSudokuSolver.Cage>
        {
            new(11, new() { (0, 0), (1, 0) }),
            new(23, new() { (0, 1), (1, 1), (1, 2), (1, 3) }),
            new(17, new() { (0, 2), (0, 3) }),
            new(8, new()  { (0, 4), (0, 5) }),
            new(15, new() { (0, 6), (0, 7), (1, 6), (2, 6) }),
            new(20, new() { (0, 8), (1, 8), (1, 7) }),
            new(12, new() { (1, 4), (1, 5), (2, 5) }),
            new(11, new() { (2, 0), (2, 1), (2, 2) }),
            new(11, new() { (2, 3), (3, 3), (3, 2) }),
            new(8, new()  { (2, 4), (3, 4) }),
            new(10, new() { (2, 7), (2, 8) }),
            new(12, new() { (3, 0), (3, 1) }),
            new(8, new()  { (3, 5), (3, 6) }),
            new(9, new()  { (3, 7), (4, 7) }),
            new(18, new() { (3, 8), (4, 8), (5, 8) }),
            new(9, new()  { (4, 0), (5, 0), (6, 0) }),
            new(17, new() { (4, 1), (5, 1), (6, 1) }),
            new(14, new() { (4, 2), (5, 2) }),
            new(16, new() { (4, 3), (4, 4) }),
            new(10, new() { (4, 5), (4, 6) }),
            new(10, new() { (5, 3), (6, 3) }),
            new(11, new() { (5, 4), (5, 5) }),
            new(7, new()  { (5, 6), (5, 7) }),
            new(6, new()  { (6, 2), (7, 2) }),
            new(21, new() { (6, 4), (6, 5), (7, 5) }),
            new(14, new() { (6, 6), (6, 7), (7, 6) }),
            new(9, new()  { (6, 8), (7, 8), (8, 8) }),
            new(8, new()  { (7, 0), (8, 0) }),
            new(20, new() { (7, 1), (8, 1), (8, 2) }),
            new(18, new() { (7, 3), (7, 4), (8, 3), (8, 4), (8, 5) }),
            new(22, new() { (7, 7), (8, 7), (8, 6) }),
        };
        var cagesTwoStarP2 = new List<KillerSudokuSolver.Cage>
        {
            new(11, new() { (0, 0), (0, 1) }),
            new(23, new() { (0, 2), (0, 3), (0, 4)}),
            new(10, new() { (0, 5), (0, 6), (0, 7)}),
            new(14, new() { (0, 8), (1, 7), (1, 8)}),
            new(14, new() { (1, 0), (2, 0), (2, 1)}),
            new(15, new() { (1, 1), (1, 2), (1, 3)}),
            new(11, new() { (1, 4), (1, 5), (1, 6)}),
            new(14, new() { (2, 2), (2, 3), (2, 4)}),
            new(21, new() { (2, 5), (2, 6), (2, 7)}),
            new(19, new() { (2, 8), (3, 7), (3, 8)}),
            new(17, new() { (3, 0), (4, 0), (4, 1)}),
            new(9, new() { (3, 1), (3, 2), (3, 3)}),
            new(12, new() { (3, 4), (3, 5), (3, 6)}),
            new(15, new() { (4, 2), (4, 3), (4, 4)}),
            new(17, new() { (4, 5), (4, 6), (4, 7)}),
            new(12, new() { (4, 8), (5, 7), (5, 8)}),
            new(11, new() { (5, 0), (6, 0), (6, 1)}),
            new(15, new() { (5, 1), (5, 2), (5, 3)}),
            new(13, new() { (5, 4), (5, 5), (5, 6)}),
            new(16, new() { (6, 2), (6, 3), (6, 4)}),
            new(22, new() { (6, 5), (6, 6), (6, 7)}),
            new(18, new() { (6, 8), (7, 7), (7, 8)}),
            new(18, new() { (7, 0), (8, 0), (8, 1)}),
            new(12, new() { (7, 1), (7, 2), (7, 3)}),
            new(10, new() { (7, 4), (7, 5), (7, 6)}),
            new(24, new() { (8, 2), (8, 3), (8, 4)}),
            new(7, new() { (8, 5), (8, 6), (8, 7)}),
            new(5, new() { (8, 8)}),
        };
        var cagesTwoStar = new List<KillerSudokuSolver.Cage>
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

        var puzzles = new List<(string Name, List<KillerSudokuSolver.Cage> Cages)>
        {
            ("cagesEasy", cagesEasy),
            ("cagesMedium", cagesMedium),
            ("cagesMedium2", cagesMedium2),
            ("cages15893", cages15893),
            ("cagesHard", cagesHard),
            ("cages8229", cages8229),
            ("cagesHard2", cagesHard2),
            ("cagesTwoStarP2", cagesTwoStarP2),
            ("cagesTwoStar", cagesTwoStar),
        };        foreach (var (name, cages) in puzzles)
        {
            const int iterations = 10;
            var times = new List<double>();
            bool allSolved = true;
            
            Console.WriteLine($"Puzzle: {name}");
            
            for (int i = 0; i < iterations; i++)
            {
                var solver = new KillerSudokuSolver(cages);
                var stopwatch = Stopwatch.StartNew();
                bool solved = solver.Solve();
                stopwatch.Stop();
                
                if (solved)
                {
                    times.Add(stopwatch.Elapsed.TotalMilliseconds);
                }
                else
                {
                    allSolved = false;
                    Console.WriteLine($"  Run {i + 1}: No solution found");
                    break;
                }
            }
            
            if (allSolved && times.Count > 0)
            {
                var avgTime = times.Average();
                var minTime = times.Min();
                var maxTime = times.Max();
                
                Console.WriteLine($"  Solved successfully in all {iterations} runs");
                Console.WriteLine($"  Average time: {avgTime:F3} ms");
                Console.WriteLine($"  Fastest time: {minTime:F3} ms");
                Console.WriteLine($"  Slowest time: {maxTime:F3} ms");
                
                // Print the solution from the last solver
                var finalSolver = new KillerSudokuSolver(cages);
                finalSolver.Solve();
                finalSolver.Print();
            }
            else if (!allSolved)
            {
                Console.WriteLine($"  Failed to solve in at least one run");
            }
            
            Console.WriteLine();
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
    Dictionary<(int, int), List<Cage>> CellToCagesCache = new();
    Dictionary<(int count, int sum), List<List<int>>> CombinationCache = new();
    public record Cage(int Sum, List<(int Row, int Col)> Cells);
    int backtrackCalls = 0;

    public KillerSudokuSolver(List<Cage> cages)
    {
        Cages = cages;
        InitializeDomains();
        InitializePeers();
        InitializeCellToCagesCache();
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
                    if (i != col) peers.Add((row, i));
                    if (i != row) peers.Add((i, col)); 
                }

                int startRow = (row / 3) * 3, startCol = (col / 3) * 3;
                for (int r = startRow; r < startRow + 3; r++)
                    for (int c = startCol; c < startCol + 3; c++)
                        if (r != row || c != col)
                            peers.Add((r, c));

                PeerCache[(row, col)] = peers.ToList();
            }
        }
    }

    void InitializeCellToCagesCache()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                CellToCagesCache[(row, col)] = new List<Cage>();
            }
        }

        foreach (var cage in Cages)
        {
            foreach (var (row, col) in cage.Cells)
            {
                CellToCagesCache[(row, col)].Add(cage);
            }
        }
    }

    public bool Solve()
    {
        return Backtrack();
    }

    bool Backtrack(int depth = 0)
    {
        backtrackCalls++;
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

                var domainChanges = new Stack<((int, int), int)>();

                if (ForwardCheck(cell.Item1, cell.Item2, value, domainChanges))
                {
                    if (Backtrack(depth +1))
                        return true;
                }

                while (domainChanges.Count > 0)
                {
                    var (pos, oldMask) = domainChanges.Pop();
                    Domains[pos] = oldMask;
                }

                Grid[cell.Item1, cell.Item2] = 0;
            }
        }
        return false;
    }
    bool IsValid(int row, int col, int value)
    {
        foreach (var (r, c) in PeerCache[(row, col)])
        {
            if (Grid[r, c] == value)
                return false;
        }
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

        foreach (var cage in CellToCagesCache[(row, col)])
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
        var key = (count, sum);

        if (CombinationCache.TryGetValue(key, out var cached))
        {
            // Filter cached combinations on-the-fly based on exclusions
            return cached
                .Where(combo => !combo.Any(val => exclude.Contains(val)))
                .ToList();
        }

        // Generate all combinations for this count and sum (without exclusions)
        var combos = Enumerable.Range(1, 9)
            .ToList()
            .Combinations(count)
            .Where(c => c.Sum() == sum)
            .ToList();

        CombinationCache[key] = combos;

        // Return filtered combinations
        return combos
            .Where(combo => !combo.Any(val => exclude.Contains(val)))
            .ToList();
    }

    public void Print()
    {
        for (int r = 0; r < Size; r++)
        {
            for (int c = 0; c < Size; c++)
                Console.Write($"{Grid[r, c]} ");
            Console.WriteLine();
        }
        Console.WriteLine($"Backtrack calls: {backtrackCalls}");
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
    public const int FullMask = 0b111111111; 

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