using Three_Or_More;

// Dictionary<int, string> dice = DrawDice.printDieFace();
// Console.WriteLine(dice.Values);


// Title screen
Console.WriteLine(@"
─╔╗╔╗────────────────╔═╗╔═╗
╔╝╚╣║────────────────║║╚╝║║
╚╗╔╣╚═╦═╦══╦══╗╔══╦═╗║╔╗╔╗╠══╦═╦══╗
─║║║╔╗║╔╣║═╣║═╣║╔╗║╔╝║║║║║║╔╗║╔╣║═╣
─║╚╣║║║║║║═╣║═╣║╚╝║║─║║║║║║╚╝║║║║═╣
─╚═╩╝╚╩╝╚══╩══╝╚══╩╝─╚╝╚╝╚╩══╩╝╚══╝");


while (true)
{
    Console.Write(@"
Welcome to the Main Menu!

Please press:
  a) to start a New Game
  b) to exit the Program
Your Response: ");

    string userResponse = Console.ReadLine();

    if (userResponse == "a")
    {
        Game newGame = new Game();
        newGame.Play();
    }
    else if (userResponse == "b")
    {
        Console.WriteLine("\nThank you for playing!:p");
        System.Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Invalid input!\n");
    }
}
