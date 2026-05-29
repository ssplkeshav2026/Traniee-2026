using System;


//31.Animal Sound System: Create base Animal class with virtual MakeSound().Console
//displays:
//Select an animal:
//1.Dog
//2.Cat
//3.Cow
//4.Duck
//Then display: 'The [animal] says [sound]'

namespace Assignment1
{
    internal class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The Dog says Bark");
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

    class Question31
    {
        bool isRunning = true;
        public Question31() 
            {
                while (isRunning)
                {
                    Console.WriteLine("\n\nSelect an animal:");
                    Console.WriteLine("1. Dog");
                    Console.WriteLine("2. Cat");
                    Console.WriteLine("3. Cow");
                    Console.WriteLine("4. Duck");
                    Console.WriteLine("5. Exit...");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    Animal animal = new Animal();
                    switch (choice)
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
                            isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice!");
                            return;
                    }
                    animal.MakeSound();
                }
            }
        }
    }



