using System;

namespace assignment_c__1
{
    internal class question31
    {
        public question31()
        {
            Animal myAnimal = new Animal();
            Animal mycat = new cat();
            Animal myDog = new Dog();

            myAnimal.animalSound();
            mycat.animalSound();
            myDog.animalSound();
        }
    }

    class Animal  
    {
        public virtual void animalSound()   
        {
            Console.WriteLine("The animal makes a sound");
        }
    }

    class cat : Animal
    {
        public override void animalSound()   
        {
            Console.WriteLine("The cat says: meau meau");
        }
    }

    class Dog : Animal
    {
        public override void animalSound()
        {
            Console.WriteLine("The dog says: bow wow");
        }
    }
}