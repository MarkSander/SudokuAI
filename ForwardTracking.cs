using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class ForwardTracking
    {
        public void RunForwardTracking()
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


                // etc..
            };
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

        public KillerSudokuSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
        }
        public bool Solve()
        {
            return SolveInternal();
        }

        private bool SolveInternal()
        {
            (int row, int col)? cell = FindNextCell();
            if (cell == null)
                return true;

            var (r, c) = cell.Value;
            foreach (var val in Enumerable.Range(1, 9))
            {
                if (IsValid(r, c, val))
                {
                    board[r, c] = val;
                    if (SolveInternal())
                        return true;
                    board[r, c] = 0;
                }
            }
            return false;
        }

        private (int, int)? FindNextCell()
        {
            (int row, int col)? bestCell = null;
            int minOptions = 10;

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r, c] == 0)
                    {
                        int options = Enumerable.Range(1, 9).Count(v => IsValid(r, c, v));
                        if (options < minOptions)
                        {
                            minOptions = options;
                            bestCell = (r, c);
                            if (options == 1) return bestCell;
                        }
                    }
                }
            }
            return bestCell;
        }

        private bool IsValid(int row, int col, int val)
        {
            for (int i = 0; i < 9; i++)
                if (board[row, i] == val || board[i, col] == val)
                    return false;

            int boxRow = row / 3 * 3;
            int boxCol = col / 3 * 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[boxRow + i, boxCol + j] == val)
                        return false;

            foreach (var cage in cages)
            {
                if (cage.Cells.Contains((row, col)))
                {
                    int sum = val;
                    HashSet<int> used = new HashSet<int> { val };
                    foreach (var (r, c) in cage.Cells)
                    {
                        if ((r, c) == (row, col)) continue;
                        int v = board[r, c];
                        if (v != 0)
                        {
                            if (used.Contains(v)) return false;
                            used.Add(v);
                            sum += v;
                        }
                    }

                    if (sum > cage.TargetSum) return false;
                    if (used.Count == cage.Cells.Count && sum != cage.TargetSum)
                        return false;
                }
            }

            return true;
        }
        public void PrintBoard()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    Console.Write(board[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    }
