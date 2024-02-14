class Rooms
{
  public static string StartRoom(string place)
  {
    Console.WriteLine("Your name is XF344 and you are currently in the docking station of the allied forces ship, there is a door ahead of you leading to the wheelhouse.");
    Console.WriteLine("You hear a robotic voice say: If you want to enter, state your ID out loud, Robot.");
    Console.WriteLine("{Btw when you enter prompts later on you will want to enter them when the terminal says your current valuables.}");
    Console.WriteLine("Go full screen for best experience.");
    string choice = Console.ReadLine();
    choice = choice.ToLower();

    if (choice == "xf344")
    {
      place = "wheelhouse";
    }

    else if (choice != "xf344")
    {
      place = "start";
      Console.WriteLine("That isn't a registered ID, Who are you? The robot voice exclaims.");
      Console.ReadLine();
    }

    return place;
  }
}