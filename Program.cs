// Optimized Killer Sudoku Solver with Forward Checking, MRV, and Efficient Constraint Checking
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KillerSudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[9, 9];
            List<Cage> cages = new List<Cage>
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
                new Cage(13, new List<(int, int)> {(8, 2), (8, 3), (8, 4), (8,5)}),
            };

            Stopwatch timer = Stopwatch.StartNew();
            var solver = new ForwardCheckingSolver(board, cages);
            if (solver.Solve())
            {
                Console.WriteLine("Solved:");
                solver.PrintBoard();
            }
            else
            {
                Console.WriteLine("No solution found.");
            }
            timer.Stop();
            Console.WriteLine("Time: " + timer.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }
    }

    public class Cage
    {
        public int TargetSum;
        public List<(int, int)> Cells;
        public Cage(int targetSum, List<(int, int)> cells) { TargetSum = targetSum; Cells = cells; }
    }

    public class ForwardCheckingSolver
    {
        private readonly int[,] board;
        private readonly List<Cage> cages;
        private readonly Dictionary<(int, int), HashSet<int>> domains;

        public ForwardCheckingSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
            domains = new();
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    domains[(r, c)] = new HashSet<int>(Enumerable.Range(1, 9));
        }

        public bool Solve() => Backtrack();

        private bool Backtrack()
        {
            var unassigned = domains.Where(d => board[d.Key.Item1, d.Key.Item2] == 0)
                                     .OrderBy(d => d.Value.Count).ToList();
            if (!unassigned.Any()) return true;
            var cell = unassigned.First().Key;
            foreach (int val in unassigned.First().Value.ToList())
            {
                if (IsValid(cell.Item1, cell.Item2, val))
                {
                    var savedDomains = SaveDomains(cell);
                    board[cell.Item1, cell.Item2] = val;
                    domains[cell].Clear();
                    domains[cell].Add(val);
                    if (ForwardCheck(cell, val))
                    {
                        if (Backtrack()) return true;
                    }
                    RestoreDomains(savedDomains);
                    board[cell.Item1, cell.Item2] = 0;
                }
            }
            return false;
        }

        private bool IsValid(int row, int col, int val)
        {
            for (int i = 0; i < 9; i++)
                if (board[row, i] == val || board[i, col] == val)
                    return false;

            int boxRow = row / 3 * 3, boxCol = col / 3 * 3;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[boxRow + r, boxCol + c] == val)
                        return false;

            var cage = cages.FirstOrDefault(c => c.Cells.Contains((row, col)));
            if (cage != null)
            {
                var values = cage.Cells.Select(cell => board[cell.Item1, cell.Item2]).Where(x => x != 0).ToList();
                if (values.Contains(val)) return false;
                int sum = values.Sum() + val;
                int unassigned = cage.Cells.Count(x => board[x.Item1, x.Item2] == 0);
                if (unassigned == 1 && sum != cage.TargetSum) return false;
                if (unassigned > 1 && sum >= cage.TargetSum) return false;
            }

            return true;
        }

        private bool ForwardCheck((int, int) cell, int val)
        {
            int row = cell.Item1, col = cell.Item2;
            foreach (var (r, c) in RowColBoxPeers(row, col))
                if (board[r, c] == 0)
                    domains[(r, c)].Remove(val);

            foreach (var cage in cages)
            {
                int sum = 0, count = 0;
                List<(int, int)> unassigned = new();
                foreach (var (r, c) in cage.Cells)
                {
                    int v = board[r, c];
                    if (v == 0) unassigned.Add((r, c));
                    else sum += v;
                }
                if (!unassigned.Any()) continue;
                int needed = cage.TargetSum - sum;
                if (needed <= 0 || needed > 9 * unassigned.Count) return false;

                var combinations = GenerateCombinations(unassigned.Count, needed);
                var validVals = new HashSet<int>(combinations.SelectMany(x => x));
                foreach (var u in unassigned)
                {
                    domains[u].RemoveWhere(x => !validVals.Contains(x));
                    if (domains[u].Count == 0) return false;
                }
            }
            return true;
        }

        private IEnumerable<List<int>> GenerateCombinations(int count, int sum, int max = 9, int min = 1)
        {
            if (count == 1)
            {
                if (sum >= min && sum <= max) yield return new List<int> { sum };
                yield break;
            }
            for (int i = min; i <= Math.Min(sum - count + 1, max); i++)
            {
                foreach (var combo in GenerateCombinations(count - 1, sum - i, max, i + 1))
                {
                    combo.Insert(0, i);
                    yield return combo;
                }
            }
        }

        private List<((int, int), HashSet<int>)> SaveDomains((int, int) cell)
        {
            var copy = new List<((int, int), HashSet<int>)>();
            foreach (var kv in domains)
                copy.Add((kv.Key, new HashSet<int>(kv.Value)));
            return copy;
        }

        private void RestoreDomains(List<((int, int), HashSet<int>)> saved)
        {
            foreach (var (key, value) in saved)
                domains[key] = value;
        }

        private IEnumerable<(int, int)> RowColBoxPeers(int row, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != col) yield return (row, i);
                if (i != row) yield return (i, col);
            }
            int boxRow = row / 3 * 3, boxCol = col / 3 * 3;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    int rr = boxRow + r, cc = boxCol + c;
                    if ((rr, cc) != (row, col)) yield return (rr, cc);
                }
        }

        public void PrintBoard()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                    Console.Write(board[r, c] + " ");
                Console.WriteLine();
            }
        }
    }
}
