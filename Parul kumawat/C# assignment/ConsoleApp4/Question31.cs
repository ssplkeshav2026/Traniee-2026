using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Animal
    {
        public virtual string makeSound()
        {
            return "Animal make sound";
        }
        public virtual string getAnimalName()
        {
            return "Animal name";

        }

    }
    public class Dog : Animal {

        public override string makeSound()
        {
            return "bhow bhow.....";
        
        }
        public override string getAnimalName()
        {
            return "Dog";
        }
    
    
    }


    public class Cat : Animal
    {

        public override string makeSound()
        {
            return "Meow Meow.....";

        }
        public override string getAnimalName()
        {
            return "Cat";
        }


    }

    public class Cow : Animal
    {

        public override string makeSound()
        {
            return "Moo Mooo.....";

        }
        public override string getAnimalName()
        {
            return "Cow";
        }


    }

    public class Duck : Animal
    {

        public override string makeSound()
        {
            return "Quack Quack.....";

        }
        public override string getAnimalName()
        {
            return "Duck";
        }


    }


    public class Question31
    {
        bool keepRun = true;

        public Question31()
        {

            while (keepRun)
            {
                Console.WriteLine(" Select an animal ");
                Console.WriteLine("1 = Dog");
                Console.WriteLine("2 = Cat");
                Console.WriteLine("3 = Cow");
                Console.WriteLine("4 = Duck");
                Console.WriteLine("5 = Exit");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                       
                        Dog c = new Dog();
                        Console.WriteLine($"the animal name is : {c.getAnimalName()} , and the animal sound like : {c.makeSound()}");
                        break;

                    case 2:
                        
                        Cat cat = new Cat();
                        Console.WriteLine($"the animal name is : {cat.getAnimalName()} , and the animal sound like : {cat.makeSound()}");
                        break;

                    case 3:
                        Cow cow = new Cow();
                        Console.WriteLine($"the animal name is : {cow.getAnimalName()} , and the animal sound like : {cow.makeSound()}");
                        break;

                    case 4:
                        Duck duck = new Duck();
                        Console.WriteLine($"the animal name is : {duck.getAnimalName()} , and the animal sound like : {duck.makeSound()}");
                        break;

                    case 5:
                        keepRun = false;
                        Console.WriteLine("exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;

                }
            }
        }
    }
}

