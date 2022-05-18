using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class Player
    {
        protected int _playerID;
        protected string _playerName;
        protected int _playerScore;
        protected string _playerType;

        public int PlayerID { get { return _playerID; } set { _playerID = value; } }
        public string PlayerName { get { return _playerName; } set { _playerName = value; } }
        public int PlayerScore { get { return _playerScore; } set { _playerScore = value; } }

        public Player(){}

        public Player(int id, string name, int score)
        {
            PlayerID = id;
            PlayerName = name;
            PlayerScore = score;
        }

        public void Update_score(int score)
        {
            PlayerScore += score;
        }
    }
}
