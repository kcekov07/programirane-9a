using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kz1
{
    internal class Kz1_RGBGAME
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your hero's name: ");
            var name = Console.ReadLine();
            Console.Write("Pick a hero from the ones listed below\n(Mage, Knight, Priest, Ranged, Rogue): ");
            var heroChosen = Console.ReadLine();
            Hero hero = null;

            switch (heroChosen)
            {
                case "Knight":
                    hero = new Hero(name, Fraction.Knight);
                    break;
                case "Mage":
                    hero = new Hero(name, Fraction.Mage);
                    break;
                case "Priest":
                    hero = new Hero(name, Fraction.Priest);
                    break;
                case "Ranged":
                    hero = new Hero(name, Fraction.Ranged);
                    break;
                case "Rogue":
                    hero = new Hero(name, Fraction.Rogue);
                    break;
                default:
                    Console.WriteLine("Invalid hero chosen.");
                    return;
            }

            Console.WriteLine($"Hero created successfully!\nHero's statistics - Name: {hero.Name}, Fraction: {hero.Fraction}, Level: {hero.Level}");
            Item item = new Item("Sword", 5, 5);
            hero.ItemSet.Add(item);
            Console.WriteLine($"{hero.Name}'s attack: {hero.GetAttack()}");
            Console.WriteLine($"{hero.Name}'s defence: {hero.GetDefence()}");
            hero.LevelUp();
            Console.WriteLine($"{hero.Name}'s LVL (after LVL up): {hero.Level}");
            item.UpgradeAttack(20);
            item.UpgradeDefence(15);
            Console.WriteLine($"{hero.Name}'s attack (after item upgrade): {hero.GetAttack()}");
            Console.WriteLine($"{hero.Name}'s defence (after item upgrade): {hero.GetDefence()}");
           
        }
    }

    public enum Fraction
    {
        Mage,
        Knight,
        Priest,
        Ranged,
        Rogue
    }

    public class Hero
    {
        private double attackCoef = 15.0;
        private double defenceCoef = 20.0;
        public string Name { get; }
        public Fraction Fraction { get; set; }
        public int Level { get; private set; }
        public double Health { get; private set; }
        public double Stamina { get; private set; }
        public double Mana { get; private set; }
        public List<Item> ItemSet { get; }

        public Hero(string name, Fraction fraction)
        {
            Name = name;
            Fraction = fraction;
            Level = 0;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            ItemSet = new List<Item>();
        }
        public int LevelUp()
        {
            Level++;
            Health = 100;
            Stamina = 100;
            Mana = 100;
            return Level;
        }
        public double GetAttack()
        {
            double totalAttack = 0;
            foreach (var item in ItemSet)
            {
                totalAttack += item.Attack;
            }
            return totalAttack + (Level * attackCoef);
        }
        public double GetDefence()
        {
            double totalDefence = 0;
            foreach (var item in ItemSet)
            {
                totalDefence += item.Defence;
            }
            return totalDefence + (Level * defenceCoef);
        }
    }
    public class Item
    {
        public string Name { get; }
        public double Attack { get; private set; }
        public double Defence { get; private set; }
        public Item(string name, double atk, double def)
        {
            if (atk < 0 || atk > 10)
            {
                throw new ArgumentException("Invalid Attack item value");
            }
            if (def < 0 || def > 10)
            {
                throw new ArgumentException("Invalid Defence item value");
            }

            Name = name;
            Attack = atk;
            Defence = def;
        }

        public void UpgradeAttack(double atk)
        {
            if (atk < 0 || atk > 50)
            {
                Console.WriteLine("Invalid Attack improvement value");
                return;
            }
            Attack += atk;
        }

        public void UpgradeDefence(double def)
        {
            if (def < 0 || def > 50)
            {
                Console.WriteLine("Invalid Defence improvement value");
                return;
            }
            Defence += def;
        }
    }

}

