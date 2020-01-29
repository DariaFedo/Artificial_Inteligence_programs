using System;
using System.Threading;

namespace Zad7
{
    public class Player
    {
        private string name;
        private char marker; // 'X' or 'O' // czy gracz jest człowiekiem
        private bool human;

        Board b;
        AI computer;

        public Player() { }
        public Player(string name, bool human, Board b)
        {
            this.name = name;
            this.marker = human ? 'X' : 'O';
            this.human = human;
            this.b = b;
            this.computer = new AI(this.b);
        }

        public string GetName()
        {
            return name;
        }
        public char GetMarker()
        {
            return marker;
        }
        public bool IsHuman()
        {
            return human;
        }
        public void GetPlayerMove() //get the currentPlayer Move
        {
            if (this.IsHuman())
            {
                GetHumanMove();
            }
            else
            {
                GetComputerMove();
            }
        }

        private void GetHumanMove()
        {
            bool moveOk = true;

            Cell cell = new Cell();
            string move;

            do
            {
                if (!moveOk)
                {
                    Console.WriteLine("Cell already filled...");
                }
                do
                {
                    Console.Write(this + ":");
                    move = Console.ReadLine().ToUpper();

                    switch (move)
                    {
                        case "A1":
                            {
                                cell.x = 0; cell.y = 0;
                                break;
                            }
                        case "A2":
                            {
                                cell.x = 1; cell.y = 0;
                                break;
                            }
                        case "A3":
                            {
                                cell.x = 2; cell.y = 0;
                                break;
                            }
                        case "B1":
                            {
                                cell.x = 0; cell.y = 1;
                                break;
                            }
                        case "B2":
                            {
                                cell.x = 1; cell.y = 1;
                                break;
                            }
                        case "B3":
                            {
                                cell.x = 2; cell.y = 1;
                                break;
                            }
                        case "C1":
                            {
                                cell.x = 0; cell.y = 2;
                                break;
                            }
                        case "C2":
                            {
                                cell.x = 1; cell.y = 2;
                                break;
                            }
                        case "C3":
                            {
                                cell.x = 2; cell.y = 2;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Błędnie wpisana nazwa pola...");
                                break;
                            }
                    }
                }
                while (move != "A1" && move != "A2" && move != "A3" &&
                   move != "B1" && move != "B2" && move != "B3" &&
                   move != "C1" && move != "C2" && move != "C3"); // do czasu az podamy własciwe pole


                moveOk = b.PlaceMove(cell, Board.human); //(PlaceMove - sprawdza czy pole zajęte, jesli nie to wstawia X i zwraca true)
            }
            while (!moveOk); // do czasu aż wypełnimy PUSTE POLE 
        }
        private void GetComputerMove()
        {
            computer.MinMax(0, this.GetMarker());
            b.PlaceMove(b.computerMove, Board.computer);
            Thread.Sleep(2000);
        }

        public override string ToString()
        {
            return this.GetName() + "(" + this.GetMarker() + ")";
        }
    }
}
