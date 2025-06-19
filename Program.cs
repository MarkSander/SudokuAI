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
            timer.Stop();
            Console.WriteLine("Elapsed time: " + timer.ElapsedMilliseconds + " ms");
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
        private Dictionary<(int, int), HashSet<int>> domains;
        private Dictionary<(int, int), List<(int, int)>> neighbors;

        private bool[,] rowUsed = new bool[9, 10];
        private bool[,] colUsed = new bool[9, 10];
        private bool[,] gridUsed = new bool[9, 10];

        public KillerSudokuSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
            cellCages = CellsToCages();
            domains = Domains();
            neighbors = InitNeighbors(); // Nieuw: precompute neighbors
        }

        private Dictionary<(int, int), List<Cage>> CellsToCages()
        {
            var dict = new Dictionary<(int, int), List<Cage>>();
            foreach (var cage in cages)
                foreach (var cell in cage.Cells)
                {
                    if (!dict.ContainsKey(cell))
                        dict[cell] = new List<Cage>();
                    dict[cell].Add(cage);
                }
            return dict;
        }

        private Dictionary<(int, int), HashSet<int>> Domains()
        {
            var dict = new Dictionary<(int, int), HashSet<int>>();
            for (int row = 0; row < SIZE; row++)
                for (int col = 0; col < SIZE; col++)
                    if (board[row, col] == 0)
                        dict[(row, col)] = new HashSet<int>(Enumerable.Range(1, 9));
            return dict;
        }

        private Dictionary<(int, int), List<(int, int)>> InitNeighbors()
        {
            var dict = new Dictionary<(int, int), List<(int, int)>>();

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    var set = new HashSet<(int, int)>();

                    for (int i = 0; i < SIZE; i++)
                    {
                        set.Add((row, i));
                        set.Add((i, col));
                    }

                    int boxRow = (row / 3) * 3;
                    int boxCol = (col / 3) * 3;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            set.Add((boxRow + i, boxCol + j));

                    if (cellCages.TryGetValue((row, col), out var cageList))
                        foreach (var cage in cageList)
                            foreach (var cell in cage.Cells)
                                set.Add(cell);

                    set.Remove((row, col));
                    dict[(row, col)] = set.ToList();
                }
            }

            return dict;
        }

        public bool Solve()
        {
            (int row, int col)? next = null;
            int minDomainSize = 10;

            foreach (var cell in domains.Keys)
            {
                if (board[cell.Item1, cell.Item2] == 0)
                {
                    int domainSize = domains[cell].Count;
                    if (domainSize < minDomainSize)
                    {
                        next = cell;
                        minDomainSize = domainSize;
                        if (domainSize == 1) break; // early exit
                    }
                }
            }

            if (next == null) return true;

            int r = next.Value.Item1;
            int c = next.Value.Item2;

            foreach (int num in domains[(r, c)])
            {
                int grid = GetGridIndex(r, c);
                if (!rowUsed[r, num] && !colUsed[c, num] && !gridUsed[grid, num] && IsCageConstrained(r, c, num))
                {
                    board[r, c] = num;
                    rowUsed[r, num] = true;
                    colUsed[c, num] = true;
                    gridUsed[grid, num] = true;

                    var removed = ForwardCheck(r, c, num);
                    if (removed != null)
                    {
                        if (Solve()) return true;
                        UndoForwardCheck(removed);
                    }

                    board[r, c] = 0;
                    rowUsed[r, num] = false;
                    colUsed[c, num] = false;
                    gridUsed[grid, num] = false;
                }
            }

            return false;
        }


        private int GetGridIndex(int row, int col) => (row / 3) * 3 + (col / 3);

        private bool IsCageConstrained(int row, int col, int num)
        {
            if (!cellCages.TryGetValue((row, col), out var cagesForCell)) return true;

            foreach (var cage in cagesForCell)
            {
                int currentSum = 0, empty = 0;

                foreach (var (r, c) in cage.Cells)
                {
                    if (board[r, c] == num && (r != row || c != col)) return false;
                    if (board[r, c] == 0) empty++;
                    currentSum += board[r, c];
                }

                if (currentSum + num > cage.TargetSum) return false;
                if (empty == 1 && currentSum + num != cage.TargetSum) return false;
            }
            return true;
        }

        private List<((int, int), int)> ForwardCheck(int r, int c, int num)
        {
            var removed = new List<((int, int), int)>();
            foreach (var neighbor in neighbors[(r, c)])
            {
                if (board[neighbor.Item1, neighbor.Item2] == 0 && domains[neighbor].Contains(num))
                {
                    domains[neighbor].Remove(num);
                    removed.Add((neighbor, num));
                    if (domains[neighbor].Count == 0)
                    {
                        UndoForwardCheck(removed);
                        return null;
                    }
                }
            }
            return removed;
        }

        private void UndoForwardCheck(List<((int, int), int)> removed)
        {
            foreach (var (cell, value) in removed)
                domains[cell].Add(value);
        }

        public void PrintBoard()
        {
            for (int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                    Console.Write(board[r, c] + " ");
                Console.WriteLine();
                if ((r + 1) % 3 == 0) Console.WriteLine();
            }
        }
    }
}
