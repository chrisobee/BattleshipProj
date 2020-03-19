using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Ship
    {
        //Member Variables
        public string name;
        public int spaceSize;
        public int hitCounter;
        public bool isDestroyed;
        //Constructor
        public Ship(string name, int spaceSize)
        {
            this.name = name;
            this.spaceSize = spaceSize;
            isDestroyed = false;
        }
        //Member Methods
        
    }
}
