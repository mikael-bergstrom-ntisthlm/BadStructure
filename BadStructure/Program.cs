
/* =============================================================================
    * * * * * ~~~~~~~~~~~~~~ DEKLARERA VARIABLER ~~~~~~~~~~~~~~ * * * * *
================================================================================
------------------------------------------------------------------------------*/
string place = "start";

Fight.Now();

int Money = 0;
bool isAlive = true;
bool fightHappened = false;

List<string> inventory = new List<string>();

while (place != "exit" && isAlive)
{
  Console.WriteLine($"Your balance is: {Money} valuables");

  if (inventory.Contains("trash"))
  {
    Console.WriteLine("You stink of filth.");
  }

/* -----------------------------------------------------------------------------
   STARTRUMMET
----------------------------------------------------------------------------- */
  if (place == "start")
  {
    #region Description
    Console.WriteLine("Your name is XF344 and you are currently in the docking station of the allied forces ship, there is a door ahead of you leading to the wheelhouse.");
    Console.WriteLine("You hear a robotic voice say: If you want to enter, state your ID out loud, Robot.");
    Console.WriteLine("{Btw when you enter prompts later on you will want to enter them when the terminal says your current valuables.}");
    Console.WriteLine("Go full screen for best experience.");
    #endregion

    string go = Console.ReadLine();
    go = go.ToLower();

    if (go == "xf344")
    {
      place = "wheelhouse";
    }

    else if (go != "xf344")
    {
      place = "start";
      Console.WriteLine("That isn't a registered ID, Who are you? The robot voice exclaims.");
      Console.ReadLine();

    }

  }

/* -----------------------------------------------------------------------------
   WHEELHOUSE
----------------------------------------------------------------------------- */
  if (place == "wheelhouse")
  {
    Console.WriteLine("You enter the Wheelhouse.");
    Console.WriteLine("Your choices are: Door, Hallway, Back");
    string go = Console.ReadLine();
    go = go.ToLower();

    if (go == "door")
    {
      place = "escapepod";
    }

    else if (go == "back")
    {
      place = "start";
    }

    else if (go == "hallway")
    {
      place = "hallway";
      
      isAlive = Fight.Now();

      fightHappened = true;
    }

    else
    {
      place = "wheelhouse";
    }
  }
  if (fightHappened && place == "hallway")
  {
    if (isAlive == true)
    {
      Console.WriteLine("You defeated the enemy. Go to the next are? Choices: Yes, No, Back");
    }
    string choice2 = Console.ReadLine();
    choice2 = choice2.ToLower();

    if (choice2 == "yes")
    {
      place = "vendingRoom";
      Money += 100;
    }
    else if (choice2 == "no")
    {
      place = "hallway";
    }

    else if (choice2 == "back")
    {
      place = "wheelhouse";
    }
  }
  if (place == "vendingRoom")
  {
    Console.WriteLine("You are met with an ominous vending machine, do you want to buy something? Choices: Yes, Back, Continue");
    string choice3 = Console.ReadLine();
    choice3 = choice3.ToLower();

    if (choice3 == "yes")
    {
      inventory.Add("trash");
      Money -= 100;
    }

    else if (choice3 == "back")
    {
      place = "hallway";
    }

    else if (choice3 == "continue")
    {
      place = "garbageDisposal";
    }
  }

  if (place == "garbageDisposal")
  {
    Console.WriteLine("The garbage disposal is a long narrow room with different trash chutes along it's walls.");
    Console.WriteLine("Do you want to go down into one of the chutes? Choices: Enter, Ignore, Back");
    string choice4 = Console.ReadLine();
    choice4 = choice4.ToLower();

    if (choice4 == "enter" && (inventory.Contains("trash")))
    {
      Console.WriteLine("'Trash detected' A robotic voice exclaims.");
      Console.ReadLine();
      Console.WriteLine("Suddenly four robotic arms shoot out of different sockets and grab all of your limbs, you get violently stuffed into the chute and die.");
      Console.ReadLine();
      place = "exit";
    }
    else if (choice4 == "enter"! & (inventory.Contains("trash")))
    {
      Console.WriteLine("No trash detected.");
      place = "garbageDisposal";
    }
    else if (choice4 == "ignore")
    {
      Console.WriteLine("You ignore the trash chutes and continue walking.");
      Console.ReadLine();
      place = "finalRoom";
    }
    else if (choice4 == "back")
    {
      place = "vendingRoom";
    }

    else
    {
      place = "garbageDisposal";
    }
  }

  if (place == "finalRoom")
  {
    Console.WriteLine("nuh uh");
    Console.WriteLine("This isn't finished, type 'back'.");
    string choice5 = Console.ReadLine();
    choice5 = choice5.ToLower();

    if (choice5 == "back")
    {
      place = "garbageDisposal";
    }

    else if (choice5 != "back")
    {
      Console.WriteLine("Like i said this isnt finished yet, type 'back' to go back to the last room.");
      Console.ReadLine();
    }
  }
  if (place == "escapepod")
  {
    Console.WriteLine("You are in the escape room, there is a spare pod left over from the crew leaving.");
    Console.WriteLine("Say 'Exit' to leave.(exit or back)");
    string leave = Console.ReadLine();
    leave = leave.ToLower();

    if (leave == "exit")
    {
      place = "exit";
    }

    else if (leave == "back")
    {
      place = "wheelhouse";
    }

    else
    {
      place = "escapepod";
    }
  }
}