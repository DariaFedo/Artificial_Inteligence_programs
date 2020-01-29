/******************** Lista 3 Daria Fedorowicz *************************/

using System;

namespace Zad3Backtrack
{
    class Backtrack
    {
        bool placeQueen(int[,] chessBoard, int column)
        {
            /* we've reached 8th column - we have a solution */
            if (column >= 8)
                return true;

            for (int i = 0; i < 8; i++)
            {
                if (checkPosition(chessBoard, i, column))
                {
                    /* Place queen in chessBoard[i,column] */
                    chessBoard[i, column] = 1;

                    if (placeQueen(chessBoard, column + 1))
                        return true;
                    
                    // BACKTRACK 
                    chessBoard[i, column] = 0; 
                }
            }

            return false;
        }

        bool checkPosition(int[,] board, int row, int column)
        {
            int i, j;

            /* Check left row */
            for (i = 0; i < column; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }

            /* Check left upper diagonal */
            for (i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }
              
            /* Check left lower diagonal */
            for (i = row, j = column; j >= 0 && i < 8; i++, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }
               
            return true;
        }
    
        void printChessBoard(int[,] board)
        {
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t  A   B   C   D   E   F   G   H");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("\t\t\t\t");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
                Console.Write("\t\t\t      ");
                Console.Write("{0} | ", i + 1);


                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{board[i, j]} | ");
                }
                Console.WriteLine();
            }
            Console.Write("\t\t\t\t");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(" ---");
            }
            Console.WriteLine();
        }

        bool solveNQ()
        {
            int[,] board = new int [8,8];

            if (!placeQueen(board, 0))
            {
                Console.Write("Solution does not exist");
                return false;
            }

            printChessBoard(board);
            return true;
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Jedno z rozwiązań dla problemu 8 hetmanów za pomocą algorytmu backtrack: \n");
            Backtrack Backtrack = new Backtrack();
            Backtrack.solveNQ();
            Console.ReadLine();
        }
    }
}
