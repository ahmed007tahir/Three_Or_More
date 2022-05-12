using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    // This class holds the abstraction of a die: which is a small cube with each side having a different
    // number of spots on it, ranging from one to six, thrown and used in games involving chance.
    // Note: this version allows for a die with number of faces other than just the conventional '6'.
    internal class Dice
    {
        // This property sets the number of faces the die has 
        private readonly int _numberOfDieFaces = 6;

        // This property will allow access to the number of die property from other classes
        public int numberOfDieFaces
        {
            get { return _numberOfDieFaces; }
        }

        // This method returns a random number ranging from 1 to the number of faces defined in the 'Dice' Class
        public int rollDie()
        {
            Random random = new Random();
            return random.Next(1, numberOfDieFaces);
        }

    }
}
