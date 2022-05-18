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
            _playerID = id;
            _playerName = name;
            _playerType = "Computer";
            PlayerScore = score;
        }
    }
}
