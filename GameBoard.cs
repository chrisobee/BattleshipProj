using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class GameBoard
    {
        //Member Variables
        public string[,] board = new string[21, 21];
        //Constructor
        public GameBoard()
        {

        }
        //Member Methods
        public void CreateBoardBoundries()
        {
            //giving the side of game board values
            char currentLetter = 'A';
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                board[i, 0] = i.ToString();
            }
            for (int i = 1; i <= board.GetUpperBound(1); i++)
            {
                board[0, i] = currentLetter.ToString();
                currentLetter++;
            }
        }
        public void InitializeBoard()
        {
            for(int i = 1; i <= board.GetUpperBound(0); i++)
            {
                for(int j = 1; j <= board.GetUpperBound(1); j++)
                {
                    board[i, j] = "0";
                }
            }
        }
        public void PrintBoardToConsole()
        {
            string columnCheck = "";
            for(int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    if(board[i,j].Length == 1)
                    {
                        columnCheck += ($"{board[i, j]}  ");
                    }
                    else
                    {
                        columnCheck += ($"{board[i, j]} ");
                    }
                }
                Console.WriteLine(columnCheck);
                columnCheck = "";
                Console.WriteLine($"\n");
            }
        }
        
}
}
