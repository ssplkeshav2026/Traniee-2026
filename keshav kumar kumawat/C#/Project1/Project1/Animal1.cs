using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    abstract class Animal
    {
        public abstract string MakeSound();
        public abstract string GetName();
    }

    class Dog : Animal
    {
        public override string MakeSound()
        {
            return "Woof";
        }
        public override string GetName()
        {
            return "Dog";
        }
    }

    class Cat : Animal
    {
        public override string MakeSound()
        {
            return "Meow";
        }
        public override string GetName()
        {
            return "Cat";
        }
    }

    class Cow : Animal
    {
        public override string MakeSound()
        {
            return "Moo";
        }
        public override string GetName()
        {
            return "Cow";
        }
    }

    class Duck : Animal
    {
        public override string MakeSound()
        {
            return "Quack";
        }
        public override string GetName()
        {
            return "Duck";
        }
    }

    public class Animal1
    {
        public Animal1()
        {
            Console.WriteLine("Select an animal:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Cow");
            Console.WriteLine("4. Duck");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();
            Animal selectedAnimal = null;

            switch (choice)
            {
                case "1":
                         selectedAnimal = new Dog();
                         break;
                case "2":
                         selectedAnimal = new Cat(); 
                         break;
                case "3":
                         selectedAnimal = new Cow();
                         break;
                case "4": 
                         selectedAnimal = new Duck(); 
                         break;
                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            Console.WriteLine($"The {selectedAnimal.GetName()} says {selectedAnimal.MakeSound()}");

        }
    }
}
