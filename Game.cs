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
        public static void Play()
        {
            List<Player> playerList = PlayerList();
            while (true)
            {
                foreach (var player in playerList)
                {
                    Console.WriteLine("It's " + player.PlayerName + "'s turn to throw the dice!\n\nPress enter to roll dice.");
                    Console.ReadKey();
                    GetScore(ThrowDice(),0,player);
                    Console.WriteLine(player.PlayerName + "'s Score: " + player.PlayerScore);
                    if (player.PlayerScore >= 50)
                    {
                        Console.WriteLine("Congrats, " + player + "won!");
                        break;
                    }
                }
            }
        }

        private static List<int> Reroll(int repeatedTwice)
        {
            List<int> throwOutcome = new List<int>();

            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
            Dice dice4 = new Dice();
            Dice dice5 = new Dice();

            List<Dice> diceList = new List<Dice>(5) { dice1, dice2, dice3, dice4, dice5 };

            int couter = 0;
            for (int i = 0; i < diceList.Count; i++)
            {
                if (i == 0 || i == 1)
                {
                    int dieface = repeatedTwice;
                    throwOutcome.Add(dieface);
                    Console.WriteLine("Dice " + (couter + 1) + " " + dieface + " ");
                    couter++;
                }
                else
                {
                    int dieface = diceList[i].rollDie();
                    throwOutcome.Add(dieface);
                    Console.WriteLine("Dice " + (couter + 1) + " " + dieface + " ");
                    couter++;
                }
            }
            return throwOutcome;
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

            int couter = 0;
            foreach (var die in diceList)
            {
                int dieface = die.rollDie();
                throwOutcome.Add(dieface);
                Console.WriteLine("Dice " + (couter+1) + " " + dieface + " ");
                couter++;
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

        private static void GetScore(List<int> dieValues, int counter, Player player)
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
            Console.WriteLine("Max value is: " + maxValue);

            if (maxValue == 5)
            {
                player.Update_score(12);
            }
            else if (maxValue == 4)
            {
                player.Update_score(6);
            }
            else if (maxValue == 3)
            {
                player.Update_score(3);
            }
            else if (maxValue == 2)
            {
                if (counter < 1)
                {
                    // gets the key of the value with the maximum 
                    int repeatedValue = 0;

                    foreach (var pair in diceThrow)
                    {
                        if (pair.Value == 2)
                        {
                            repeatedValue = pair.Key;
                        }
                    }

                    Console.WriteLine(repeatedValue + " is repeated twice.\nPress enter to re-roll.......");
                    Console.ReadKey();
                    counter++;

                    List<int> newList = Reroll(repeatedValue);
                    GetScore(newList,counter,player);
                }
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
    }
}
