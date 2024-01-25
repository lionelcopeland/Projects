using System;

public class Swordsman
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int AttackDamage { get; set; }

    public Swordsman(string name, int level, int health, int attackDamage)
    {
        Name = name;
        Level = level;
        Health = health;
        AttackDamage = attackDamage;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks with a sword - Damage: {AttackDamage}");
    }

    public void LevelUp()
    {
        Level++;
        Health += 10; // Increase health on level up
        AttackDamage += 5; // Increase attack damage on level up
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }
}

class Program
{
    static void Main()
    {
        // Create a Swordsman
        Swordsman player = new Swordsman("Hero", 1, 100, 20);

        // Use the sword
        player.Attack();

        // Level up
        player.LevelUp();

        // Display player information
        Console.WriteLine($"Player: {player.Name}, Level: {player.Level}, Health: {player.Health}, Attack Damage: {player.AttackDamage}");
    }
}
