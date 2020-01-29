/**************** Daria Fedorowicz Zad2 *****************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class Permutation
    {
        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public List<string> Permut(int[] arrOfNumbers, int leftPointer, int rightPointer, List<string> pList)
        {
            if (leftPointer == rightPointer)
            {
                string sequence = "";
                for (int i = 0; i <= rightPointer; i++)
                    sequence += Convert.ToString(arrOfNumbers[i]);

                pList.Add(sequence);
                sequence = "";
            }
            else
                for (int i = leftPointer; i <= rightPointer; i++)
                {
                    Swap(ref arrOfNumbers[leftPointer], ref arrOfNumbers[i]);
                    Permut(arrOfNumbers, leftPointer + 1, rightPointer, pList);
                   Swap(ref arrOfNumbers[leftPointer], ref arrOfNumbers[i]);
                }

            return pList;
        }
    }
    class Program
    {
        private static void PrintChessboard(char[,] board, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }

        private static void SetQueensOnBoard(string sequence)
        {
            int row = 0;
            char[,] chessboard = new char[sequence.Length, sequence.Length];
            for (int column = 0; column < sequence.Length; column++)
            {
                row = Convert.ToInt32(Convert.ToString(sequence[column]));
                chessboard[row, column] = 'Q';
            }
            PrintChessboard(chessboard, sequence.Length);
        }

        private static void ClearArray(ref int[,] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = 0;
                }
            }
        }

        public static List<string> AddPermutationsToSolutionList(List<string> pList, List<string> solutionList)
        {
            string solution = "";
            foreach (string sequence in pList)
            {
                solution = CheckSequence(sequence);
                if (solution != "")
                {
                    solutionList.Add(solution);
                }
            }
            return solutionList;
        }

        public static string CheckSequence(string sequence)
        {
            int seqLength = sequence.Length;
            int column = 0;
            int[,] arr = new int[seqLength, seqLength]; //tablica n x n
            string solution = "";

            while (column < seqLength)
            {
                int row = Convert.ToInt32(Convert.ToString(sequence[column]));
                if (arr[row, column] == 0)              
                {
                    InsertArray(ref arr, column, sequence);
                    solution += Convert.ToString(sequence[column]);
                    ++column;
                }
                else
                {
                    ClearArray(ref arr, seqLength);
                    return "";
                }
            }

            ClearArray(ref arr, seqLength);

            return solution;
        }

        public static int[,] InsertArray(ref int[,] arr, int k, string sequence)
        {
            int seqLength = sequence.Length;
            int row = Convert.ToInt32(Convert.ToString(sequence[k]));
            int col = k;

            for (int j = 0; j < seqLength; j++) // wypełnij wiersz
                arr[row, j] = 1;


            for (int j = 0; j < seqLength; j++) // wypełnij kolumne
                arr[j, k] = 1;

            while (row != seqLength && col != seqLength)// przekątna w dol
            {
                arr[row, col] = 1;
                ++row;
                col++;
            }

            // wróć do pozycji wstawionej królowej (przywróc kolumnę i wiersz)
            row = Convert.ToInt32(Convert.ToString(sequence[k]));
            col = k;

            while (row > -1 && col != seqLength) // przekątna do gory
            {
                arr[row, col] = 1;
                if (row == -1)
                    break;
                --row;
                ++col;
            }
            return arr;
        }

        static void Main(string[] args)
        {

            int n;
            Permutation permutation = new Permutation();
           
            List<string> pList = new List<string>(); // lista permutacji wszystkich

            List<string> solutionList = new List<string>(); // lista permutacji będąca rozwiązaniem 8H

            Console.WriteLine("Podaj n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arrOfNumbers = new int[n];

            for (int i = 0; i < n; i++)
                arrOfNumbers[i] = i;

            pList = permutation.Permut(arrOfNumbers, 0, n - 1, pList);
            Console.WriteLine();
            
            solutionList = AddPermutationsToSolutionList(pList, solutionList);

                foreach (string solution in solutionList)
                {
                    SetQueensOnBoard(solution);
                    Console.WriteLine("\n_____________________________________________\n");
                }

            Console.WriteLine($"Liczba permutacji stanowiących rozwiązanie problemu 8 hetmanów: {solutionList.Count}");
            Console.WriteLine("Permutacje: ");

            foreach (string solution in solutionList)
            {
                Console.WriteLine(solution);
            }

            Console.ReadLine();
        }

    }
}
