using System;
using System.Collections.Generic;

namespace Zad7
{
    public class Board
    {
        public Player HUMAN;
        public Player COMPUTER;

        public static readonly char emptySpot = '.';
        public static readonly char computer = 'O';
        public static readonly char human = 'X';

        public char[,] gameBoard = { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };

        public Cell computerMove;

        public Board()
        {
            ShowHeader();
            this.HUMAN = new Player(PlayerName(), true, this);
            this.COMPUTER = new Player("computer", false, this);
        }

        private string PlayerName()
        {
            Console.WriteLine("\nNote : Human always gets 'X' and Computer gets 'O'\n\n\n");
            Console.Write("Enter Player name : ");
            string name = Console.ReadLine(); //Read User Name

            return name;
        }
        public bool isGameOver()
        {
            return hasWon(computer) || hasWon(human) || getAvailableCells().Count == 0;
        }
        public bool hasWon(char player)
        {
            // sprawdza przekątne
            if ((gameBoard[0, 0] == gameBoard[1, 1] &&
                gameBoard[0, 0] == gameBoard[2, 2] &&
                 gameBoard[0, 0] == player) ||
                (gameBoard[0, 2] == gameBoard[1, 1] &&
                gameBoard[0, 2] == gameBoard[2, 0] &&
                 gameBoard[0, 2] == player))
            {
                return true;
            }

            //sprawdza kolumny i wiersze 
            for (int i = 0; i < 3; i++)
            {
                if ((gameBoard[i, 0] == gameBoard[i, 1] &&
                gameBoard[i, 0] == gameBoard[i, 2] &&
                 gameBoard[i, 0] == player) ||
                   (gameBoard[0, i] == gameBoard[1, i] &&
                gameBoard[0, i] == gameBoard[2, i] &&
                 gameBoard[0, i] == player))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Cell> getAvailableCells()
        {
            List<Cell> availableCells = new List<Cell>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == emptySpot)
                    {
                        availableCells.Add(new Cell(i, j));
                    }
                }
            }
            return availableCells;
        }

        public bool PlaceMove(Cell cell, char player)
        {
            if (gameBoard[cell.x, cell.y] != Board.emptySpot)  // komorka zajeta
                return false;

            gameBoard[cell.x, cell.y] = player;
            return true;
        }
        private void ShowHeader()
        {
            Console.WriteLine("\t\t\t\tGRA W KÓŁKO I KRZYŻYK\n\t\t\t\t\n");
        }

        public void display()
        {
            Console.Clear();
            ShowHeader();
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t  A   B   C");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\t\t\t\t");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
                Console.Write("\t\t\t      ");
                Console.Write("{0} | ", i + 1);


                for (int j = 0; j < 3; j++)
                {
                    string value = ".";

                    if (gameBoard[i, j] == computer)
                        value = "O";
                    else if (gameBoard[i, j] == human)
                        value = "X";

                    Console.Write("{0} | ", value);
                }
                Console.WriteLine();
            }
            Console.Write("\t\t\t\t");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" ---");
            }
            Console.WriteLine();
        }

        public void Start()
        {
            display(); 

            while (!isGameOver())
            {
                HUMAN.GetPlayerMove();
                display();

                if (isGameOver())
                {
                    break;
                }
                COMPUTER.GetPlayerMove();
                display();

                if (isGameOver())
                {
                    break;
                }
            }

            if (hasWon(Board.computer))
            {
                Console.WriteLine("Przegrałeś z komputerem.");
            }
            else if (hasWon(Board.human))
            {
                Console.WriteLine("Wygrałeś z komputerem!");
            }
            else
            {
                Console.WriteLine("REMIS!");
            }
        }
    }
}
