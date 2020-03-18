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
        //Constructor

        //Member Methods
        public void RunGame()
        {
            playerOne.personalGameBoard.CreateBoardBoundries();
            playerOne.personalGameBoard.InitializeBoard();
            playerOne.personalGameBoard.PrintBoardToConsole();
        }
    }
}
