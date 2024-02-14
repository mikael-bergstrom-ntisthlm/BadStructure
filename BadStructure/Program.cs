
/* -----------------------------------------------------------------------------
      VARIABLER
------------------------------------------------------------------------------*/


#region WORLD STATE
string place = "start";



bool fightHappened = false;
#endregion

#region PLAYER STATS
int Money = 0;
bool isAlive = true;
List<string> inventory = new List<string>();
#endregion

/* -----------------------------------------------------------------------------
      MAIN LOOP
------------------------------------------------------------------------------*/
while (place != "exit" && isAlive)
{
  Console.WriteLine($"Your balance is: {Money} valuables");

  if (inventory.Contains("trash"))
  {
    Console.WriteLine("You stink of filth.");
  }

  /* -----------------------------------------------------------------------------
        RUM: START
  ------------------------------------------------------------------------------*/
  if (place == "start")
  {
    place = Rooms.StartRoom(place);
  }

  /* -----------------------------------------------------------------------------
        RUM: WHEELHOUSE
  ------------------------------------------------------------------------------*/

  if (place == "wheelhouse")
  {
    Console.WriteLine("You enter the Wheelhouse.");
    Console.WriteLine("Your choices are: Door, Hallway, Back");
    string choice = Console.ReadLine();
    choice = choice.ToLower();

    if (choice == "door")
    {
      place = "escapepod";
    }

    else if (choice == "back")
    {
      place = "start";
    }

    else if (choice == "hallway")
    {
      place = "hallway";

      isAlive = Fight();

      fightHappened = true;
    }

    else
    {
      place = "wheelhouse";
    }
  }

  /* -----------------------------------------------------------------------------
        RUM: HALLWAY
  ------------------------------------------------------------------------------*/
  if (fightHappened && place == "hallway")
  {
    if (isAlive == true)
    {
      Console.WriteLine("You defeated the enemy. Go to the next are? Choices: Yes, No, Back");
    }
    string choice = Console.ReadLine();
    choice = choice.ToLower();

    if (choice == "yes")
    {
      place = "vendingRoom";
      Money += 100;
    }
    else if (choice == "no")
    {
      place = "hallway";
    }

    else if (choice == "back")
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


static bool Fight()
{
  Random generator = new Random();

  int health = 100;
  int fighter1Health = health;
  int fighter2Health = health;
  bool isAlive = true;

  while (fighter1Health > 0 && fighter2Health > 0)
  {
    int damage = generator.Next(1, 20);
    fighter1Health -= damage;

    damage = generator.Next(1, 200);
    fighter2Health -= damage;

    Console.WriteLine($"Fighter 1 health {fighter1Health}");
    Console.WriteLine($"Fighter 2 health {fighter2Health}");
    Console.ReadLine();

    if (fighter1Health < 0)
    {
      Console.WriteLine("Fighter 2 wins");
      Console.ReadLine();

      Console.ReadLine();

      isAlive = false;
    }

    else if (fighter2Health < 0)
    {
      Console.WriteLine("fighter 1 wins");
      Console.ReadLine();

      Console.ReadLine();
      isAlive = true;
    }
  }
  return isAlive;
}