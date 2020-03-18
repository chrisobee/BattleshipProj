using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Helper
    {
        //Member Variables

        //Constructor

        //Member Methods
        public string CheckInput()
        {
            bool correctPosition;
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (char.IsLetter(userInput.Trim()[0]) && char.IsDigit(userInput.Trim()[1]))
                {
                    correctPosition = true;
                }
                else
                {
                    correctPosition = false;
                    Console.WriteLine("Not a correct input. Type another");
                }
            }
            while (correctPosition == false);

            return userInput.ToLower();
            
        }

        public string CheckDirection()
        {
            string userInput;
            userInput = Console.ReadLine();

            switch (userInput.Trim().ToLower())
            {
                case "up":
                    return userInput;
                case "down":
                    return userInput;
                case "left":
                    return userInput;
                case "right":
                    return userInput;
                default:
                    Console.WriteLine("Invalid direction. Type another");
                    return CheckDirection();
            }
        }

        public int GetCharCoordinate(string position)
        {
            char tempChar;
            int numberOfAlphabet = 1;
            char charCheck;

            charCheck = position[0];
            for(tempChar = 'a'; tempChar < 'z'; tempChar++)
            {
                if(tempChar == charCheck)
                {
                    return numberOfAlphabet;
                }
                else
                {
                    numberOfAlphabet++;
                }
            }
            return numberOfAlphabet;
        }

        public int GetIntCoordinate(string position)
        {
            int rowCoordinate;
            rowCoordinate = Convert.ToInt32(position[1].ToString());
            return rowCoordinate;
        }

        public bool CheckValidPosition(int rowCheck, int columnCheck, string[,] board)
        {
            bool validPosition;
            if(board[rowCheck, columnCheck] == "0")
            {
                Console.WriteLine("Valid Position");
                validPosition = true;
            }
            else
            {
                Console.WriteLine("Invalid Position");
                validPosition = false;
            }

            return validPosition;
        }

        public bool CheckValidDirection(int rowCheck, int columnCheck, string[,] board, string direction, int spaceSize)
        {
            int limit = 1;
            string emptyCheck = "0";
            bool validDirection = true;
            switch (direction)
            {
                case "up":
                    for(int i = rowCheck - 1; limit < spaceSize; i--)
                    {
                        if(board[i, columnCheck] != emptyCheck)
                        {
                            validDirection = false;
                            Console.WriteLine("Invalid Direction");
                            return validDirection;
                        }
                        else
                        {
                            limit++;
                        }
                    }
                    return validDirection;
                case "down":
                    for(int i = rowCheck + 1; limit < spaceSize; i++)
                    {
                        if(board[i, columnCheck] != emptyCheck)
                        {
                            validDirection = false;
                            Console.WriteLine("Invalid Direction");
                            return validDirection;
                        }
                        else
                        {
                            limit++;
                        }
                    }
                    return validDirection;
                case "right":
                    for(int i = columnCheck + 1; limit < spaceSize; i++)
                    {
                        if(board[rowCheck, i] != emptyCheck)
                        {
                            validDirection = false;
                            Console.WriteLine("Invalid Direction");
                            return validDirection;
                        }
                        else
                        {
                            limit++;
                        }
                    }
                    return validDirection;
                case "left":
                    for (int i = columnCheck - 1; limit < spaceSize; i--)
                    {
                        if (board[rowCheck, i] != emptyCheck)
                        {
                            validDirection = false;
                            Console.WriteLine("Invalid Direction");
                            return validDirection;
                        }
                        else
                        {
                            limit++;
                        }
                    }
                    return validDirection;
                default:
                    return validDirection;
            }
        }
    }
}
