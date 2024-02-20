class Fight
{
  public static bool Now()
  {
    bool isAlive = true;
    Random generator = new Random();

    int health = 100;
    int fighter1Health = health;
    int fighter2Health = health;

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

}