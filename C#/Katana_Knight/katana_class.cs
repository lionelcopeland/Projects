using System;

public class Sword
{
    public string Name { get; set; }
    public int AttackDamage { get; set; }
    public int Durability { get; set; }

    public Sword(string name, int attackDamage, int durability)
    {
        Name = name;
        AttackDamage = attackDamage;
        Durability = durability;
    }

    public void Attack()
    {
        if (Durability > 0)
        {
            Console.WriteLine($"Attacking with {Name} - Damage: {AttackDamage}");
            Durability--;
        }
        else
        {
            Console.WriteLine($"{Name} is broken and cannot be used.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a sword
        Sword katana = new Sword("Katana", 20, 50);

        // Use the sword
        katana.Attack();

        // Display sword information
        Console.WriteLine($"Sword: {katana.Name}, Damage: {katana.AttackDamage}, Durability: {katana.Durability}");
    }
}
