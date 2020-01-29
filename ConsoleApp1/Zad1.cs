/********************* Daria Fedorowicz zadanie 1 *****************/

using System;
using System.Collections.Generic;


namespace ConsoleApp1
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
    class Zad1
    {
        static void Main(string[] args)
        {

            int n;
            Permutation permutation = new Permutation();
            List<string> pList = new List<string>();
            
            Console.WriteLine("Podaj n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arrOfNumbers = new int[n];

            for (int i = 0; i < n; i++)
                arrOfNumbers[i] = i;

            Console.Write($"\nPermutacje dla {n} cyfr: \n");

            pList = permutation.Permut(arrOfNumbers, 0, n - 1, pList);
            Console.WriteLine();

            foreach (string sequence in pList)
                Console.Write(sequence + " \n");

            Console.ReadLine();
        }
    }
}