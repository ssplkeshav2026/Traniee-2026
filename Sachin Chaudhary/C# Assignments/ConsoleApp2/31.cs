//using System;

//namespace program
//{
//    public class Animal
//    {
//        public string Name { get; set; }
//        public virtual void MakeSound()
//        {

//        }
//    }

//    public class Dog : Animal
//    {
       

//        public  virtual void  MakeSound()
//        {
//            Console.WriteLine("Dog says bo bo");
//        }
//    }

//    public class Cat : Animal
//    {
      

//        public virtual  void MakeSound()
//        {
//            Console.WriteLine("cat says miow miou");
//        }
//    }

//    public class Cow : Animal
//    {
        

//        public virtual void MakeSound()
//        {
//            Console.WriteLine("cat says gow gow");
//        }
//    }

//    public class Duck : Animal
//    {
     

//        public virtual void MakeSound()
//        {
//            Console.WriteLine("cat says chi chi");
//        }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool start = true;

//            while (start)
//            {
//                Console.WriteLine("Select Animal:");
//                Console.WriteLine("1. Dog");
//                Console.WriteLine("2. cat");
//                Console.WriteLine("3. Cow");
//                Console.WriteLine("4. duck");
//                Console.WriteLine("5. Exit");

//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                       Dog D=new Dog();
//                        D.MakeSound();

//                        break;

//                    case 2:
//                        Cat cat = new Cat();
//                        cat.MakeSound();
//                        break;

//                    case 3:
//                        Cow cow = new Cow();
//                        cow.MakeSound();
//                        break;

//                    case 4:
//                        Duck duck = new Duck();
//                        duck.MakeSound();
//                        break;
//                    case 5:
//                        start = false;
//                        Console.WriteLine("Bye");
//                        break;
//                }
//            }
//        }
//    }
//}
