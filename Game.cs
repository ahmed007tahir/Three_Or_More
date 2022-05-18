using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{

    // this class contains the code for the game 'Three or More'
    internal class Game
    {
        // this method returns a list of Player objects with each Player object having it's name property set by the user
        private static List<Player> PlayerList()
        {
            // initializing the variable to hold the number of number of Player objects to be created
            int numberOfPlayers = 0;

            // initializing the variable to hold the Player objects to be created
            List<Player> playerList = new List<Player>();

            // this loop handles exceptions while getting user input
            while (true)
            {
                // asking the user to enter the number of players playing, which will determine the number of Player objects to be created
                Console.Write("Please pick the number of players: ");

                try
                {
                    numberOfPlayers = Int32.Parse(Console.ReadLine());
                    if (numberOfPlayers == 0) Console.WriteLine("Invalid Input!");
                    else break;
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            // this for loop iterates through the list of player objects, setting the playerName property of each dice
            for (int i = 0; i < numberOfPlayers; i++)
            {
                int playerID = i + 1;
                Console.Write("Please enter the name of player " + playerID + ": ");
                string playerName = Console.ReadLine();

                playerList.Add(new Player(playerID, playerName, 0));
            }

            // the function returns a list of object Player with each Player object having it's playerID property set
            return playerList;
        }

        
        private static List<int> ThrowDice(int repeatedTwice)
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

            if (maxValue == 5)
            {
                Console.Write("Jackpot!");
                player.Update_score(12);
            }
            if (maxValue == 4)
            {
                player.Update_score(6);
            }
            if (maxValue == 3)
            {
                player.Update_score(3);
            }
            if (maxValue == 2)
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

                    Console.WriteLine(repeatedValue + " is repeated twice.\nPress enter to roll the dice again!\n");
                    Console.ReadKey();
                    counter++;

                    List<int> newList = ThrowDice(repeatedValue);
                    GetScore(newList,counter,player);
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }
            }
            
        }

        // thus function is called at the beginning of the program 
        public void Play()
        {
            // a list of Player objects is created using the 'PlayerList' method
            List<Player> playerList = PlayerList();
            int highest_score = 0;

            while (highest_score < 50)
            {
                foreach (var player in playerList)
                {
                    // add some lining here like ---------------------------------------------------------------------
                    Console.WriteLine("\nIt's " + player.PlayerName + "'s turn to throw the dice!\n\nPress enter to roll dice.");
                    Console.ReadKey();
                    GetScore(ThrowDice(), 0, player);
                    Console.WriteLine(player.PlayerName + "'s Score: " + player.PlayerScore);
                    if (player.PlayerScore >= 50)
                    {
                        Console.WriteLine("Congrats, " + player + "won!");
                    }

                    if (highest_score < player.PlayerScore)
                    {
                        highest_score = player.PlayerScore;
                    }
                }
            }
            // main menu return
            Console.WriteLine("game finished!");
        }
    }
}
