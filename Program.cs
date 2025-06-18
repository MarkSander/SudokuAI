using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

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
                //new Cage(15, new List<(int, int)> { (0, 0), (0, 1), (1, 0), (1, 1) }),
                //new Cage(10, new List<(int, int)> { (0, 2), (0, 3), (1, 2), (1, 3) }),

                new Cage(9,  new List<(int, int)> { (0, 0), (1, 0) }),
                new Cage(28, new List<(int, int)> { (0, 1), (0, 2), (1, 2), (2, 2), (3,1) }),
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

        public KillerSudokuSolver(int[,] board, List<Cage> cages)
        {
            this.board = board;
            this.cages = cages;
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
                            if (IsSafe(row, col, num))
                            {
                                board[row, col] = num;

                                if (Solve())
                                {
                                    return true;
                                }

                                board[row, col] = 0; // backtrack
                            }
                        }
                        return false;
                    }
                }
            }
            return true; // Solved
        }

        private bool IsSafe(int row, int col, int num)
        {
            // Check row
            for (int x = 0; x < SIZE; x++)
            {
                if (board[row, x] == num)
                {
                    return false;
                }
            }

            // Check column
            for (int x = 0; x < SIZE; x++)
            {
                if (board[x, col] == num)
                {
                    return false;
                }
            }

            // Check 3x3 subgrid
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i + startRow, j + startCol] == num)
                    {
                        return false;
                    }
                }
            }

            // Check cages
            foreach (var cage in cages)
            {
                if (cage.Cells.Contains((row, col)))
                {
                    int currentSum = 0;
                    int emptyCells = 0;

                    foreach (var cell in cage.Cells)
                    {
                        int r = cell.Item1;
                        int c = cell.Item2;
                        if (board[r, c] == 0)
                        {
                            emptyCells++;
                        }
                        currentSum += board[r, c];
                    }

                    if (currentSum + num > cage.TargetSum)
                    {
                        return false;
                    }

                    if (emptyCells == 1 && currentSum + num != cage.TargetSum)
                    {
                        return false;
                    }
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
        }
    }
}
