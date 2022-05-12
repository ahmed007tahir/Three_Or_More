using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class Player
    {
        private int _playerId;
        private string _playerName;
        private int _playerScore;

        public int PlayerId { get { return _playerId; } set { _playerId = value; } }
        public string PlayerName { get { return _playerName; } set { _playerName = value; } }
        public int PlayerScore { get { return _playerScore; } set { _playerScore = value; } }

        public Player(int id, string name, int score)
        {
            PlayerId = id;
            PlayerName = name;
            PlayerScore = score;
        }

        public void Update_score(int score)
        {
            PlayerScore += score;
        }
    }
}
