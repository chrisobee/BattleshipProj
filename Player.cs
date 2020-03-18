using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        //Member Variables
        public string name;
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
        
    }
}
