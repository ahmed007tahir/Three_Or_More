using Three_Or_More;

// Dictionary<int, string> dice = DrawDice.printDieFace();
// Console.WriteLine(dice.Values);


// Prints out the game title.
Console.WriteLine(@"
─╔╗╔╗────────────────╔═╗╔═╗
╔╝╚╣║────────────────║║╚╝║║
╚╗╔╣╚═╦═╦══╦══╗╔══╦═╗║╔╗╔╗╠══╦═╦══╗
─║║║╔╗║╔╣║═╣║═╣║╔╗║╔╝║║║║║║╔╗║╔╣║═╣
─║╚╣║║║║║║═╣║═╣║╚╝║║─║║║║║║╚╝║║║║═╣
─╚═╩╝╚╩╝╚══╩══╝╚══╩╝─╚╝╚╝╚╩══╩╝╚══╝");

// main menu screen.
// this while loop brings the user back to the main menu after the game and in the case of unexpected input while on the main menu.
while (true)
{
    // this prints out the options available to the user within the main menu.
    Console.Write(@"
Welcome to the Main Menu!

Please press:
  a) to start a New Game
  b) to exit the Program
Your Response: ");

    // users response is stored into a string variable
    string userResponse = Console.ReadLine();

    // if statements used to determine what the user wishes to do after seeing the main menu.
    if (userResponse == "a")
    {
        Console.WriteLine(@"

-------------------------------------------

█▄░█ █▀▀ █░█░█   █▀▀ ▄▀█ █▀▄▀█ █▀▀
█░▀█ ██▄ ▀▄▀▄▀   █▄█ █▀█ █░▀░█ ██▄");
        // if 'a' is chosen...
        // a new list of player objects is created by the main method using the CreatePlayerList().
        (List<ComputerPlayer> computerPlayers, List<HumanPlayer> humanPlayers) = CreatePlayerList();
        
        // the main method will create a new game object called 'newGame'.
        Game newGame = new Game();
        // the 'Play()' method of the newly created game object is called &
        // the list of Player objects is then fed into the Play() method of the game object.
        newGame.Play(computerPlayers,humanPlayers);
    }
    else if (userResponse == "b")
    {
        // if 'b' is chosen, the user is presented with a message, and the console application is terminated gracefully
        Console.WriteLine("\nThank you for playing!:p");
        System.Environment.Exit(0);
    }
    else
    {
        // if neither 'a' or 'b' is received from user, an error message is displayed and the while loop brings the user back to the main menu.
        Console.WriteLine("Invalid input!\n");
    }
}

// this method returns a list of Player objects with each Player object having it's name property set by the user
(List<ComputerPlayer>, List<HumanPlayer>) CreatePlayerList()
{
    // initializing the variable to hold the number of number of Player objects to be created
    int numberOfHumanPlayers = 0;
    int numberOfComputerPlayers = 0;

    // initializing the variable to hold the Player objects to be created
    List<HumanPlayer> HumanPlayerList = new List<HumanPlayer>();
    List<ComputerPlayer> ComputerPlayerList = new List<ComputerPlayer>();

    // this loop handles exceptions while getting user input
    while (true)
    {
        // asking the user to enter the number of players playing, which will determine the number of Player objects to be created
        Console.Write("\nPlease pick the number of HUMAN players: ");

        try
        {
            numberOfHumanPlayers = Int32.Parse(Console.ReadLine());
            if (numberOfHumanPlayers == 0) Console.WriteLine("You must have at least 1 human! :(");
            else break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        catch 
        {
            Console.WriteLine("Invalid Input!");
        }
    }
    while (true)
    {
        // asking the user to enter the number of players playing, which will determine the number of Player objects to be created
        Console.Write("\nPlease pick the number of COMPUTER players: ");

        try
        {
            numberOfComputerPlayers = Int32.Parse(Console.ReadLine());
            break;
        }
        catch
        {
            Console.WriteLine("Invalid Input!");
        }
    }

    // this for loop iterates through the list of player objects, setting the playerName property of each dice
    for (int i = 0; i < numberOfComputerPlayers; i++)
    {
        int playerID = i + 1;
        Console.Write("Please enter the name of  COMPUTER player " + playerID + ": ");
        string playerName = Console.ReadLine();

        ComputerPlayerList.Add(new ComputerPlayer(playerID, playerName, 0));
    }

    for (int i = 0; i < numberOfHumanPlayers; i++)
    {
        int playerID = i + 1;
        Console.Write("Please enter the name of HUMAN player " + playerID + ": ");
        string playerName = Console.ReadLine();

        HumanPlayerList.Add(new HumanPlayer(playerID, playerName, 0));
    }

    // the function returns a list of object Player with each Player object having it's playerID property set
    return (ComputerPlayerList,HumanPlayerList);
}



