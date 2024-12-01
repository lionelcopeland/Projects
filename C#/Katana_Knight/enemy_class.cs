using System;

namespace SamuraiGame
{
    public class Enemy
    {
        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public bool IsAlive => Health > 0;

        // Constructor
        public Enemy(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        // Methods
        public void Attack(Player player)
        {
            if (IsAlive)
            {
                int damage = Math.Max(AttackPower - player.Defense, 0);
                player.TakeDamage(damage);
                Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
            }
        }

        public void TakeDamage(int damage)
        {
            int effectiveDamage = Math.Max(damage - Defense, 0);
            Health -= effectiveDamage;
            Console.WriteLine($"{Name} takes {effectiveDamage} damage! Remaining health: {Health}");

            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Enemy: {Name}, Health: {Health}, Attack Power: {AttackPower}, Defense: {Defense}");
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Player(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        public void TakeDamage(int damage)
        {
            int effectiveDamage = Math.Max(damage - Defense, 0);
            Health -= effectiveDamage;
            Console.WriteLine($"{Name} takes {effectiveDamage} damage! Remaining health: {Health}");
        }

        public void Attack(Enemy enemy)
        {
            if (Health > 0)
            {
                int damage = Math.Max(AttackPower - enemy.Defense, 0);
                enemy.TakeDamage(damage);
                Console.WriteLine($"{Name} attacks {enemy.Name} for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Attack Power: {AttackPower}, Defense: {Defense}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a player and an enemy
            Player samurai = new Player("Samurai", 100, 20, 5);
            Enemy bandit = new Enemy("Bandit", 50, 15, 3);

            // Display their initial statuses
            samurai.DisplayStatus();
            bandit.DisplayStatus();

            // Simulate combat
            samurai.Attack(bandit);
            bandit.Attack(samurai);
            samurai.Attack(bandit);

            // Display their statuses after combat
            samurai.DisplayStatus();
            bandit.DisplayStatus();
        }
    }
}

