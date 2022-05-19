using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class ComputerPlayer : Player
    {
        public ComputerPlayer(int id, string name, int score)
        {
            PlayerID = id;
            PlayerName = name;
            PlayerScore = score;
            IsHuman = false;

        }
    }
}
