//Backtracking

using System.Diagnostics;
using System.Linq;

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
            }; var cagesEasy = new List<Cage>
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
            var cagesMedium = new List<Cage>
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
            var cagesMedium2 = new List<Cage>
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
            var cages15893 = new List<Cage>
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
            var cagesHard = new List<Cage>
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
            var cages8229 = new List<Cage>
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
            var cagesHard2 = new List<Cage>
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
            var cagesTwoStarP2 = new List<Cage>
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
            var cagesTwoStar = new List<Cage>
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
            var puzzles = new List<(string Name, List<Cage> Cages)>
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
            };

            // Solve all sudokus 

            // foreach (var (name, cages) in puzzles)
            // {
            //     Console.WriteLine($"Puzzle: {name}");
            //     var times = new List<double>();
            //     KillerSudokuSolver lastSolver = null;
            //     bool anySolved = false;                // Solve the puzzle 10 times
            //     for (int attempt = 1; attempt <= 10; attempt++)
            //     {
            //         var solver = new KillerSudokuSolver(cages);
            //         var stopwatch = Stopwatch.StartNew();
            //         bool solved = solver.Solve();
            //         stopwatch.Stop();
            //         if (solved)
            //         {
            //             anySolved = true;
            //             lastSolver = solver;
            //             times.Add(stopwatch.Elapsed.TotalMilliseconds);
            //         }
            //     }
            //     if (anySolved)
            //     {
            //         Console.WriteLine("\nSolution:");
            //         lastSolver.PrintBoard();
            //         double averageTime = times.Average();
            //         double fastestTime = times.Min();
            //         Console.WriteLine($"\nStatistics:");
            //         Console.WriteLine($"  Successful solves: {times.Count}/10");
            //         Console.WriteLine($"  Average time: {averageTime:F3} ms");
            //         Console.WriteLine($"  Fastest time: {fastestTime:F3} ms");
            //     }
            //     else
            //     {
            //         Console.WriteLine("No solution found in any attempt.");
            //     }
            //     Console.WriteLine(new string('-', 50));
            // }

            // Solve specific sudoku 
            var solver = new KillerSudokuSolver(cagesHard);
            var stopwatch = Stopwatch.StartNew();
            bool solved = solver.Solve();
            stopwatch.Stop();
            if (solved)
            {
                solver.PrintBoard();
                Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
            }
            else
            {
                Console.WriteLine("No solution found for the specific sudoku.");
            }
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
        private bool[,] rowUsed = new bool[9, 10];
        private bool[,] colUsed = new bool[9, 10];
        private bool[,] gridUsed = new bool[9, 10];        public KillerSudokuSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
            cellCages = CellsToCages();
        }

        public KillerSudokuSolver(List<Cage> cages)
        {
            this.board = new int[9, 9]; // Initialize empty board
            this.cages = cages;
            cellCages = CellsToCages();
        }

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

        public bool Solve()
        {
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
                    Console.Write($"{board[r, d]} ");
                }
                Console.WriteLine();
            }
        }
    }
}