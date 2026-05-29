using Project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project1
{
    abstract class Animal
    {
        public abstract void MakeSound();
    }

    class Dog : Animal
    {

        public override void MakeSound()
        {
            Console.WriteLine("The Dog says Woof");
        }
    }

    class Cat : Animal
    {
        
        public override void MakeSound()
        {
            Console.WriteLine("The Cat says Meow");

        }
    }

    class Cow : Animal
    {
        
        public override void MakeSound()
        {
            Console.WriteLine("The Cow says Moo");
        }
    }

    class Duck : Animal
    {

        public override void MakeSound()
        {
            Console.WriteLine("The Duck says Quack");
            
        }
    }
    class AnimalSound
    {
        public void Sound()
        {
            int option;
            do
            {
                Console.WriteLine("Select an animal:");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.WriteLine("3. Cow");
                Console.WriteLine("4. Duck");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice: ");
                option = Convert.ToInt32(Console.ReadLine());

                Animal animal = null;

                switch (option)
                {
                    case 1:
                        animal = new Dog();
                        break;
                    case 2:
                        animal = new Cat();
                        break;
                    case 3:
                        animal = new Cow();
                        break;
                    case 4:
                        animal = new Duck();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option...");
                        continue;
                }
            } while (option != 5);
        }
    }
    
}