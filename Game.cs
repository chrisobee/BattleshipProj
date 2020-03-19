using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game
    {
        //Member Variables
        public Player playerOne = new Player();
        public Player playerTwo = new Player();
        Random rand = new Random();
        //Constructor

        //Member Methods

        public void RunGame()
        {
            Console.WriteLine($"BATTLESHIP\nPress Enter to Start\n-------------------------------------------");
            playerOne.ChooseName();
            playerTwo.ChooseName();
            CreateBothPlayersBoards();
            playerOne.PlaceShipPhase();
            Console.Clear();
            playerTwo.PlaceShipPhase();
            Console.Clear();

            do
            {
                DisplayMenu(playerOne, playerTwo);
                if(playerOne.destroyedShips.Count == 4)
                {
                    break;
                }
                DisplayMenu(playerTwo, playerOne);
                if(playerTwo.destroyedShips.Count == 4)
                {
                    break;
                }
            }
            while ((playerOne.destroyedShips.Count != 4) && (playerTwo.destroyedShips.Count != 4));

            if(playerOne.destroyedShips.Count == 4)
            {
                Console.WriteLine($"{playerOne.name} is the Winner!!!");
                Console.ReadLine();
            }
            else if(playerTwo.destroyedShips.Count == 4)
            {
                Console.WriteLine($"{playerTwo.name} is the Winner!!!");
                Console.ReadLine();
            }
        }

        public void DisplayMenu(Player currentPlayer, Player enemyPlayer)
        {
            bool hasAttacked = false;
            do
            {
                Console.WriteLine($"It is {currentPlayer.name}'s Turn");
                Console.WriteLine($"What would you like to do this round\n1) Display your own Board\n2) Display the known Enemy Board\n3) Check how many Ships are destroyed\n4) Attack specific Coordinate");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("PERSONAL BOARD");
                        currentPlayer.personalGameBoard.PrintBoardToConsole();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("KNOWN ENEMY BOARD");
                        currentPlayer.enemyGameBoard.PrintBoardToConsole();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        if(currentPlayer.destroyedShips.Count == 0)
                        {
                            Console.WriteLine("No ships destroyed yet :(");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            foreach (Ship ship in currentPlayer.destroyedShips)
                            {
                                Console.WriteLine(ship.name);
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        Attack(currentPlayer, enemyPlayer);
                        hasAttacked = true;
                        Console.WriteLine("KNOWN ENEMY BOARD");
                        currentPlayer.enemyGameBoard.PrintBoardToConsole();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            while (hasAttacked == false);
            
        }

        public void CreateBothPlayersBoards()
        {
            playerOne.personalGameBoard.CreateBoardBoundries();
            playerOne.personalGameBoard.InitializeBoard();
            playerOne.enemyGameBoard.CreateBoardBoundries();
            playerOne.enemyGameBoard.InitializeBoard();

            playerTwo.personalGameBoard.CreateBoardBoundries();
            playerTwo.personalGameBoard.InitializeBoard();
            playerTwo.enemyGameBoard.CreateBoardBoundries();
            playerTwo.enemyGameBoard.InitializeBoard();
        }

        public void Attack(Player currentPlayer, Player enemyPlayer)
        {
            string coordinate;
            int columnCheck;
            int rowCheck;
            bool isHit;

            currentPlayer.enemyGameBoard.PrintBoardToConsole();
            Console.WriteLine("Choose the coordinate you would like to attack");
            coordinate = currentPlayer.validate.CheckInput();
            columnCheck = currentPlayer.validate.GetCharCoordinate(coordinate);
            rowCheck = currentPlayer.validate.GetIntCoordinate(coordinate);

            if (enemyPlayer.personalGameBoard.board[rowCheck, columnCheck] == "0" || enemyPlayer.personalGameBoard.board[rowCheck,columnCheck] == "M")
            {
                Console.WriteLine("That's a Miss!");
                isHit = false;
                UpdateBoards(currentPlayer, enemyPlayer, rowCheck, columnCheck, isHit);
            }
            else
            {
                Console.WriteLine("That's a hit!");
                isHit = true;
                UpdateBoards(currentPlayer, enemyPlayer, rowCheck, columnCheck, isHit);
            }
        }

        public void UpdateBoards(Player currentPlayer, Player enemyPlayer, int rowCheck, int columnCheck, bool isHit)
        {
            if (isHit)
            {
                CheckForShipDestruction(currentPlayer, enemyPlayer, rowCheck, columnCheck);
                currentPlayer.enemyGameBoard.board[rowCheck, columnCheck] = "H";
                enemyPlayer.personalGameBoard.board[rowCheck, columnCheck] = "H";
            }
            else
            {
                currentPlayer.enemyGameBoard.board[rowCheck, columnCheck] = "M";
                enemyPlayer.personalGameBoard.board[rowCheck, columnCheck] = "M";
            }
        }

        public void CheckForShipDestruction(Player currentPlayer, Player enemyPlayer, int rowCheck, int columnCheck)
        {
            switch (enemyPlayer.personalGameBoard.board[rowCheck, columnCheck])
            {
                case "D":
                    enemyPlayer.destroyer.hitCounter++;
                    if(enemyPlayer.destroyer.hitCounter == enemyPlayer.destroyer.spaceSize)
                    {
                        Console.WriteLine("The Enemy's Destroyer has been Destroyed ;)");
                        enemyPlayer.destroyer.isDestroyed = true;
                        currentPlayer.destroyedShips.Add(enemyPlayer.destroyer);
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "S":
                    enemyPlayer.submarine.hitCounter++;
                    if(enemyPlayer.submarine.hitCounter == enemyPlayer.submarine.spaceSize)
                    {
                        Console.WriteLine("The Enemy's Submarine has been Destroyed");
                        enemyPlayer.submarine.isDestroyed = true;
                        currentPlayer.destroyedShips.Add(enemyPlayer.submarine);
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "B":
                    enemyPlayer.battleship.hitCounter++;
                    if(enemyPlayer.battleship.hitCounter == enemyPlayer.battleship.spaceSize)
                    {
                        Console.WriteLine("The Enemy's Battleship has been Destroyed");
                        enemyPlayer.battleship.isDestroyed = true;
                        currentPlayer.destroyedShips.Add(enemyPlayer.battleship);
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "A":
                    enemyPlayer.aircraftCarrier.hitCounter++;
                    if(enemyPlayer.aircraftCarrier.hitCounter == enemyPlayer.aircraftCarrier.spaceSize)
                    {
                        Console.WriteLine("The Enemy's Aircraft Carrier has been Destroyed");
                        enemyPlayer.aircraftCarrier.isDestroyed = true;
                        currentPlayer.destroyedShips.Add(enemyPlayer.aircraftCarrier);
                        break;
                    }
                    else
                    {
                        break;
                    }
                default:
                    break;
            }
        }


    }
}
