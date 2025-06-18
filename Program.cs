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
            var dict = new Dictionary<(int, int), List<Cage>> ();
            foreach (var cage in cages)
            {
                foreach (var cell  in cage.Cells)
                {
                    if (!dict.ContainsKey (cell))
                    {
                        dict[cell] = new List<Cage> ();
                    }
                    dict[cell].Add (cage);
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
