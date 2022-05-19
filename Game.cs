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
        // this private property will hold the gameID which will be used to track the score history for multiple sessions of the game
        private int _gameID;
        // this public 
        public int GameID { get { return _gameID; } set { _gameID = value; } }


        // this method returns a List of numbers that appear on the dice faces once the dice is thrown.
        private static List<int> ThrowDice(bool secondThrow = false, int repeatedTwice = 0)
        {
            // initializing a list of typy integer to hold the values of the dice that appear once the dice is thrown
            List<int> throwOutcome = new List<int>();

            // here we create 5 dice ob
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Dice dice3 = new Dice();
            Dice dice4 = new Dice();
            Dice dice5 = new Dice();

            List<Dice> diceList = new List<Dice>(5) { dice1, dice2, dice3, dice4, dice5 };

            int couter = 0;

            bool jackpot = ((diceList[0] == diceList[1]) && (diceList[1] == diceList[2]) &&
                            (diceList[2] == diceList[3]) &&
                            (diceList[3] == diceList[4]));
            if (jackpot)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }


            for (int i = 0; i < diceList.Count; i++)
            {
                if ((i == 0 || i == 1) && (secondThrow == true) && (repeatedTwice != 0) && !jackpot)
                {
                    throwOutcome.Add(repeatedTwice);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(DrawDice.printDieFace(repeatedTwice));
                    Console.ForegroundColor = ConsoleColor.White;

                    couter++;
                }
                else
                {
                    int dieface = diceList[i].rollDie();
                    throwOutcome.Add(dieface);
                    Console.Write(DrawDice.printDieFace(dieface));
                    couter++;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
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
                Console.Write("\nJackpot!!!\nYou scored 12 points this round!\n");
                player.Update_score(12);
            }
            if (maxValue == 4)
            {
                Console.Write("\nYou scored 6 points this round!\n");
                player.Update_score(6);
            }
            if (maxValue == 3)
            {
                Console.Write("\nYou scored 3 points this round!\n");
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

                    Console.WriteLine(repeatedValue + " is repeated twice.\n");
                    if (player.IsHuman)
                    {
                        Console.WriteLine("Press enter to roll the dice again!\n");
                        Console.ReadKey();
                    }
                    counter++;

                    List<int> newList = ThrowDice(true,repeatedValue);
                    GetScore(newList,counter,player);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You scored no points this round :(\nBetter luck next time!\n");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            if (maxValue == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You scored no points this round :(\nBetter luck next time!\n");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

        // this function is called at the beginning of the program 
        // this method take in a list of Player objects and acts as an initiation for the game
        public void Play(List<Player> players)
        {
            int highest_score = 0;
            
            while (highest_score < 50)
            {
                foreach (var player in players)
                {
                    Console.WriteLine("-------------------------------------------\n");
                    if (player.IsHuman)
                    {
                        Console.WriteLine("\nIt's " + player.PlayerName + "'s turn to throw the dice!\n\nPress enter to roll dice.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nIt's the COMPUTER player " + player.PlayerName + "'s turn to throw the dice!");
                    }
                    GetScore(ThrowDice(), 0, player);
                    Console.WriteLine(player.PlayerName + "'s Total Score is : " + player.PlayerScore);
                    if (player.PlayerScore >= 50)
                    {
                        Console.WriteLine("Congrats, " + player.PlayerName + "won!");
                    }

                    if (highest_score < player.PlayerScore)
                    {
                        highest_score = player.PlayerScore;
                    }
                }
            }
            // main menu return
            // save file with scores
            Console.WriteLine("game finished!");
        }
    }
}
