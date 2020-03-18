using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        //Member Variables
        public string name;
        public Helper validate = new Helper();
        public GameBoard personalGameBoard = new GameBoard();
        public GameBoard enemyGameBoard = new GameBoard();
        public Ship destroyer = new Ship("Destroyer", 2);
        public Ship submarine = new Ship("Submarine", 3);
        public Ship battleship = new Ship("Battleship", 4);
        public Ship aircraftCarrier = new Ship("Aircraft Carrier", 5);
        //Constructor
        public Player()
        {
            
        }

        //Member Methods
        public void PlaceShipPhase()
        {
            string startPosition;
            string direction;
            int columnCheck;
            int rowCheck;
            bool validPosition;
            bool validDirection;
            List<Ship> ships = new List<Ship>() { destroyer, submarine, battleship, aircraftCarrier };

            foreach(Ship ship in ships)
            {
                Console.WriteLine($"You are now placing {ship.name} that takes up {ship.spaceSize} spaces.");
                do
                {
                    do
                    {
                        Console.WriteLine($"Choose the start position of your {ship.name}");
                        startPosition = validate.CheckInput();
                        columnCheck = validate.GetCharCoordinate(startPosition);
                        rowCheck = validate.GetIntCoordinate(startPosition);
                        validPosition = validate.CheckValidPosition(rowCheck, columnCheck, personalGameBoard.board);
                    }
                    while (validPosition == false);

                    Console.WriteLine("Choose a direction that you'd like to place your ship");
                    direction = validate.CheckDirection();
                    validDirection = validate.CheckValidDirection(rowCheck, columnCheck, personalGameBoard.board, direction, ship.spaceSize);
                }
                while (validDirection == false);

                PlaceShip(ship.name, rowCheck, columnCheck, direction, ship.spaceSize);
                Console.Clear();
                personalGameBoard.PrintBoardToConsole();

            }


        }

        public void PlaceShip(string name, int rowCheck, int columnCheck, string direction, int spaceSize)
        {
            string shipPlaceholder;
            int limit = 1;
            shipPlaceholder = name[0].ToString();

            personalGameBoard.board[rowCheck, columnCheck] = shipPlaceholder;

            switch (direction)
            {
                case "up":
                    for (int i = rowCheck - 1; limit < spaceSize; i--)
                    {
                        personalGameBoard.board[i, columnCheck] = shipPlaceholder;
                        limit++;
                    }
                    break;
                case "down":
                    for (int i = rowCheck + 1; limit < spaceSize; i++)
                    {
                        personalGameBoard.board[i, columnCheck] = shipPlaceholder;
                        limit++;
                    }
                    break;
                case "right":
                    for (int i = columnCheck + 1; limit < spaceSize; i++)
                    {
                        personalGameBoard.board[rowCheck, i] = shipPlaceholder;
                        limit++;
                    }
                    break;
                case "left":
                    for (int i = columnCheck - 1; limit < spaceSize; i--)
                    {
                        personalGameBoard.board[rowCheck, i] = shipPlaceholder;
                        limit++;
                    }
                    break;
                default:
                    break;
            }
        }
        
    }
}
