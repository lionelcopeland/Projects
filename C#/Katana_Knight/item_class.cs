using System;

namespace SamuraiGame
{
    public class Item
    {
        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public int EffectValue { get; set; }

        // Constructor
        public Item(string name, string description, ItemType type, int effectValue)
        {
            Name = name;
            Description = description;
            Type = type;
            EffectValue = effectValue;
        }

        // Methods
        public void Use(Player player)
        {
            switch (Type)
            {
                case ItemType.HealthPotion:
                    player.RestoreHealth(EffectValue);
                    Console.WriteLine($"{Name} restores {EffectValue} health to {player.Name}.");
                    break;

                case ItemType.AttackBoost:
                    player.BoostAttack(EffectValue);
                    Console.WriteLine($"{Name} increases {player.Name}'s attack power by {EffectValue} for the next turn.");
                    break;

                case ItemType.DefenseBoost:
                    player.BoostDefense(EffectValue);
                    Console.WriteLine($"{Name} increases {player.Name}'s defense by {EffectValue} for the next turn.");
                    break;

                default:
                    Console.WriteLine($"{Name} has no effect.");
                    break;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Item: {Name}, Type: {Type}, Effect: {EffectValue}, Description: {Description}");
        }
    }

    public enum ItemType
    {
        HealthPotion,
        AttackBoost,
        DefenseBoost
    }

    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        // Additional attributes
        private int temporaryAttackBoost = 0;
        private int temporaryDefenseBoost = 0;

        public Player(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        public void RestoreHealth(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name}'s health is now {Health}.");
        }

        public void BoostAttack(int amount)
        {
            temporaryAttackBoost += amount;
        }

        public void BoostDefense(int amount)
        {
            temporaryDefenseBoost += amount;
        }

        public int GetCurrentAttackPower() => AttackPower + temporaryAttackBoost;
        public int GetCurrentDefense() => Defense + temporaryDefenseBoost;

        public void ResetTemporaryBoosts()
        {
            temporaryAttackBoost = 0;
            temporaryDefenseBoost = 0;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Attack Power: {GetCurrentAttackPower()}, Defense: {GetCurrentDefense()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a player
            Player samurai = new Player("Samurai", 100, 20, 5);

            // Create items
            Item healthPotion = new Item("Health Potion", "Restores health.", ItemType.HealthPotion, 30);
            Item attackBoost = new Item("Attack Boost", "Increases attack power temporarily.", ItemType.AttackBoost, 10);
            Item defenseBoost = new Item("Defense Boost", "Increases defense temporarily.", ItemType.DefenseBoost, 5);

            // Display initial player status
            samurai.DisplayStatus();

            // Use items
            healthPotion.Use(samurai);
            attackBoost.Use(samurai);
            defenseBoost.Use(samurai);

            // Display player status after using items
            samurai.DisplayStatus();

            // Reset temporary boosts
            samurai.ResetTemporaryBoosts();
            samurai.DisplayStatus();
        }
    }
}
