using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class Game
    {
        public static void play()
        {
            List<Player> playerList = PlayerList();
            while (true)
            {
                foreach (var player in playerList)
                {
                    player.Update_score(score(ThrowDice()));
                    Console.WriteLine(player.PlayerName + " " + player.PlayerScore);
                    Console.Read();
                }
            }
        }

        // this method returns a List of numbers that appear on the dice faces once the dice is thrown
        private static List<int> ThrowDice()
        {
            List<int> throwOutcome = new List<int>();
            
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
            Dice dice4 = new Dice();
            Dice dice5 = new Dice();

            List<Dice> diceList = new List<Dice>(5) { dice1, dice2, dice3, dice4, dice5 };
            
            foreach (var die in diceList)
            {
                int dieface = die.rollDie();
                throwOutcome.Add(dieface);
                Console.Write(dieface + " ");
            }
            return throwOutcome;
        }
        
        private static List<Player> PlayerList()
        {
            int numberOfPlayers = 0;
            List<Player> playerList = new List<Player>();

            while (true)
            {
                Console.Write("Please pick the number of players: ");
                try
                {
                    numberOfPlayers = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            for (int i = 0; i < numberOfPlayers; i++)
            {
                int playerID = i + 1;
                Console.Write("Please enter the name of player " + playerID + ": ");
                string playerName = Console.ReadLine();

                playerList.Add(new Player(playerID, playerName, 0));
            }

            return playerList;
        }

        private static int score(List<int> dieValues)
        {
            int score = 0;
            Dictionary<int,int> diceThrow = new Dictionary<int,int>(6)
            {
                {1,0},
                {2,0},
                {3,0},
                {4,0},
                {5,0},
                {6,0}
                };
            foreach (int dieValue in dieValues)
            {
                diceThrow[dieValue]++;
            }

            int maxValue = diceThrow.Values.Max();

            if (maxValue == 5)
            {
                score = 12;
            }
            else if (maxValue == 4)
            {
                score = 6;
            }
            else if (maxValue == 3)
            {
                score = 3;
            }


            return score;
        }
    }
}
