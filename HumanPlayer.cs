using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(int id, string name, int score)
        {
            _playerID = id;
            _playerName = name;
            _playerType = "Human";
            PlayerScore = score;
        }
    }
}
