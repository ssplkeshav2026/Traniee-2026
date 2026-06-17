//////using System;
////////using System.Transactions; // Allows using classes from the System namespace

//////namespace HelloWorldApp
//////{

//////    class Program
//////    {
//////        //        static void Main(string[] args)
//////        //        {
//////        //            // WriteLine prints text to the console
//////        //            int num;
//////        //            Console.WriteLine(" enter the numbewr");
//////        //            num = Convert.ToInt32(Console.ReadLine());

//////        //            double d = 3457.56;
//////        //            int i;
//////        //            int a = 10;
//////        //            float b = 20;

//////        //            Console.WriteLine("Hello, World! sachin!");
//////        //            Console.WriteLine("sum of two value are " + (a + b));
//////        //            i = (int)d;
//////        //            Console.WriteLine(i);
//////        //                if(num>90)
//////        //                  {
//////        //                      Console.WriteLine("grade A");
//////        //                  }
//////        //                  else if (num>=80)
//////        //                  {
//////        //                      Console.WriteLine("grade B");
//////        //                  }
//////        //                  else if (num >= 70)
//////        //                  {
//////        //                      Console.WriteLine("GRADE c");
//////        //                  }
//////        //                  else
//////        //                  {
//////        //                      Console.WriteLine("GRADE F");
//////        //                  }


//////        //            switch (num) {
//////        //                case 1:
//////        //                    Console.WriteLine("Grade A");
//////        //                    break;
//////        //                case 2:
//////        //                    Console.WriteLine("Grade B");
//////        //                    break;

//////        //                case 3:
//////        //                    Console.WriteLine("Grade c");
//////        //                    break;

//////        //                case 4:
//////        //                    Console.WriteLine("Grade D");
//////        //                    break;

//////        //                default:
//////        //                    Console.WriteLine("you are fail by mistake");
//////        //                    break;

//////        //            }

//////        //            int[] arr = {2, 45, 65, 5, 4, 7, 6, 8, 9};

//////        //            foreach(int j in arr)
//////        //            {
//////        //                if (j<2)
//////        //                {
//////        //                    break;
//////        //                }
//////        //                else { 

//////        //               Console.WriteLine(j); 
//////        //                }


//////        //            }


//////        //  void sachins(int a)
//////        //            {
//////        //                Console.WriteLine("sachin is the powerful person");
//////        //                Console.WriteLine(a);
//////        //            }
//////        // void sachins(int b,int c)
//////        //            {
//////        //                Console.WriteLine(b+c);
//////        //            }
//////        //            sachins(45);
//////        //            sachins(23, 554);

//////        //        }

//////        //    }
//////        //}
//////static int PlusMethodInt(int x, int y)
//////        {
//////            return x + y;
//////        }

//////        static double PlusMethodDouble(double x, double y)
//////        {
//////            return x + y;
//////        }

//////        static void Main(string[] args)
//////        {
//////            int myNum1 = PlusMethodInt(8, 5);
//////            double myNum2 = PlusMethodDouble(4.3, 6.26);
//////            Console.WriteLine("Int: " + myNum1);
//////            Console.WriteLine("Int: " + myNum2);
//////            for (int j=0; j < 100; j++)
//////            {

//////                Console.WriteLine("ram ram jaane yaaro majalew bo ek hakitak jo ckdkskskdkskdkdkdkdkdkddkddkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkddkdkdkdkdkdkdddkdkdkdkdkdkdkdkddkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkkdkdkdkdkdkdkkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkdkdkdkdkdkd ");


//////            }


//////        }

//////    }

//////}
//////using System;
//////using System.Reflection;

//////namespace program
//////{


//////    class helo
//////    {

//////        public String carname;
//////        public double accelators;
//////        public string models;
//////        public void show()
//////        {
//////            Console.WriteLine($"my car name is {carname} and accelators {accelators} and model is {models}");
//////        }

//////    }


//////    class helo2 : helo
//////    {


//////        public void show1()
//////        {
//////            Console.WriteLine($"my car name is {carname} and accelators {accelators} and model is {models}");
//////        }


//////    }
//////    class drive : helo2
//////    {

//////        public void display()
//////        {
//////            Console.WriteLine("my car name is  ");
//////        }

//////        class a
//////        {

//////            public string name;
//////            public int age;
//////            public double salary;

//////            static void Main(string[] args)
//////            {

//////                a obj = new a();
//////                helo obj2 = new helo();
//////                obj2.carname = "maruti sizuki";
//////                obj2.accelators = 100;
//////                obj2.models = "honda";
//////                obj.name = "sachin";
//////                obj.age = 20;
//////                obj.salary = 20000;
//////                Console.WriteLine(obj.name);
//////                Console.WriteLine(obj.age);
//////                Console.WriteLine(obj.salary);
//////                Console.WriteLine(obj2.carname);
//////                Console.WriteLine(obj2.accelators);
//////                Console.WriteLine(obj2.models);
//////                obj2.show();

//////                helo2 obj3 = new helo2();
//////                obj3.show();
//////                obj3.show1();
//////                drive obj4 = new drive();
//////                obj4.show();
//////                obj4.show1();
//////                obj4.display();
//////            }
//////        }
//////    }
//////}




//////using System;
//////using System.Reflection;

//////namespace program
//////{

//////    class Parent
//////    {
//////        public int show(int x)
//////        {

//////            return x + 1;
//////        }
//////        public int show(int x, int y)
//////        {

//////            return x + y;
//////        }
//////        public int show(int x, int y, int z)
//////        {
//////            {

//////                return x + y + z;
//////            }


//////        }
//////        class A
//////        {

////// static void Main(string[] args)
//////            {
//////                Parent obj = new Parent();
//////               Console.WriteLine( obj.show(10));
//////                Console.WriteLine(obj.show(20,70));
//////                Console.WriteLine(obj.show(50, 40));
//////            }
//////        }
//////    }
//////}

//////using System;
//////using System.Reflection;

//////namespace program
//////{

//////    abstract class Shape
//////    {

//////        public abstract int area();

//////    }

//////    class Rectangle:Shape{
//////        private int length;
//////        private int width;

//////        public  Rectangle(int a=0,int b=0)
//////        {
//////            length= a;
//////            width= b;

//////        }
//////        public override int area()
//////        {
//////            Console.WriteLine("area of rectangle:");
//////            return (width * length);
//////        }


//////        }
//////        class A
//////        {

//////            static void Main(string[] args)
//////            {
//////              Rectangle r= new Rectangle();
//////            Console.WriteLine(r.area());
//////        }
//////        }
//////    }


//////using System;
//////using System.Reflection;

//////namespace program
//////{

//////    abstract class Shape
//////    {

//////        public abstract int area();
//////        public void show()
//////        {

//////        }

//////    }

//////    class Rectangle : Shape
//////    {
//////        private int length;
//////        private int width;

//////        public Rectangle(int a = 0, int b = 0)
//////        {
//////            length = a;
//////            width = b;

//////        }
//////        public override int area()
//////        {
//////            Console.WriteLine("area of rectangle:");
//////            return (width * length);
//////        }
//////        public  void show()
//////        {
//////            Console.WriteLine("helo ");
//////        }

//////    }
//////    class A
//////    {

//////        static void Main(string[] args)
//////        {
//////            Rectangle r = new Rectangle();
//////            Console.WriteLine(r.area());
//////           r.show();
//////        }
//////    }
//////}

//////using System;
//////namespace program
//////{
//////    public enum Days
//////    {
//////        monday,
//////        tuesday,
//////        wednesday,
//////        thuesday,
//////        friday,
//////        satarday,
//////        sunday,


//////    }
//////    class a
//////    {

//////        static void Main(string[] args)
//////        {
//////            Days d = (Days)2;
//////            Console.WriteLine(d);
//////            Console.BackgroundColor = ConsoleColor.Green;
//////            Console.WriteLine("helo sachin ");



//////        }

//////    }
//////}
//////using System;
//////namespace program
//////{
//////    class Animal  
//////    {
//////        public virtual void animalSound()
//////        {
//////            Console.WriteLine("The animal makes a sound");
//////        }
//////    }
//////    class Pig : Animal  
//////    {
//////        public override void animalSound()
//////        {
//////            Console.WriteLine("The pig says: wee wee");
//////        }
//////    }
//////    class Dog : Animal  
//////    {
//////        public override void animalSound()
//////        {
//////            Console.WriteLine("The dog says: bow wow");
//////        }
//////    }

//////    class a
//////    {

//////        static void Main(string[] args)
//////        {
//////          Animal A=new Animal();
//////          Animal P = new Pig();

//////            Animal D = new Dog();
//////            A.animalSound();
//////            P.animalSound();
//////            D.animalSound();
//////        }

//////    }
//////}


//////using System;
//////namespace program
//////{

//////    class A
//////    {
//////        public string name;
//////        public A (string Modelname)
//////        {
//////            name = Modelname;
//////        }

//////        static void Main(string[] args)
//////        {
//////           A obj = new A("Mustang");
//////            Console.WriteLine(obj.name);
//////        }

//////    }
//////}
//////using System.IO;
//////using System;
//////namespace program
//////{
//////    class price
//////    {

//////        static void Main(string[] args)
//////        {
//////            FileStream file = new FileStream("sample.txt", FileMode.OpenOrCreate,FileAccess.ReadWrite);
//////            for(int i=0; i <10; i++)
//////            {
//////                file.WriteByte((byte)i);
//////            }
//////            file.Position= 0;
//////            for (int i = 0; i < 10; i++)
//////            {
//////                Console.Write(file.ReadByte() + " ");
//////            }
//////            file.Close();
//////            Console.ReadKey();


//////        }
//////    }
//////}


//////using System.IO;
//////using System;
//////namespace program
//////{
//////    class price
//////    {

//////        static void Main(string[] args)
//////        {
//////            try{ int a = 40;
//////            int b = 10;
//////            int c = a / b;
//////            Console.WriteLine(c);
//////            }
//////            catch (DivideByZeroException)
//////            {
//////                Console.WriteLine("arthmatical Excaption b is not equal to 0");
//////            }
//////        }
//////    }
//////}



////// ATTRIBUTES IN c#

//////using System;
//////namespace program
//////{
//////    class A
//////    {

//////        static void Main(string[] args)
//////        {

//////            [Obsolete("Dont use Old Method,instead of use New method",false)]
//////            static void OldMethoid()
//////            {

//////                Console.WriteLine("it is new method");
//////                 }
//////           // [Obsolete("Dont use Old Method,instead of use New method", false)]
//////            static void NewMethod()
//////            {

//////                Console.WriteLine("it is old method");
//////            }
//////            OldMethoid();
//////            NewMethod();
//////            Console.ReadKey();

//////        }

//////    }
//////}
//////using System;
//////using System.Reflection;
//////namespace program
//////{
//////class B
//////    {
//////        static void Main(string[] args)
//////        {
//////            Console.WriteLine("enter the first number:");
//////             int num=Convert.ToInt32(Console.ReadLine());
//////            Console.WriteLine("enter the Second number:");
//////            int num2 = Convert.ToInt32(Console.ReadLine());
//////            Console.WriteLine($"fIRST VALUE {num}" +$"Second Value {num2}\n");
//////            int num3;
//////            num3 = num;
//////            num = num2;
//////            num2 = num3;
//////            Console.WriteLine($"After swapping Two number\n");
//////            Console.WriteLine($"fIRST VALUE {num}" + $"Second Value {num2}");
//////        }


//////    }

//////}


////// Factorial of two numbers
//////using System;
//////using System.Reflection;
//////namespace program
//////{


//////class B
//////    {
//////        static void Main(string[] args)
//////        {
//////            Console.WriteLine("enter the facto number:");
//////            int num = Convert.ToInt32(Console.ReadLine());


//////         Double result= Factorial(num);
//////            Console.WriteLine($"Factorial of  number:{result}");

//////        }

//////        static Double Factorial(int num)
//////        {
//////            int facto = 1;
//////            if (num < 0) return -1;

//////            for (int i = 1; i <= num; i++)
//////            {
//////                facto = facto * i;

//////            }
//////            return facto;
//////        }
//////    }

//////}


//////using System;
//////using System.Reflection;
//////namespace program
//////{
////// class B
//////    {
//////        static void Main(string[] args)
//////        {

//////            Console.WriteLine("enter the number:");
//////            int num=Convert.ToInt32(Console.ReadLine());
//////            int reversed_num = 0;
//////            while (num > 0)
//////            {
//////                int rem = num % 10;
//////                reversed_num = (reversed_num * 10) + rem;
//////                num=num/10;

//////            }
//////            Console.WriteLine("reverse number is:"+(reversed_num));

//////        }
//////    }
//////}

//////using System;
//////using System.Reflection;
//////namespace program
//////{
//////    class B
//////    {
//////        static void Main(string[] args)
//////        {

//////            Console.WriteLine("enter the number:");
//////            int num = Convert.ToInt32(Console.ReadLine());
//////           for(int i = 1; i <=  10; i++)
//////            {
//////                Console.WriteLine($"{num}*{i}=="+(num * i));
//////            }

//////        }
//////    }
//////}



//////using System;

//////namespace program
//////{
//////    class B
//////    {  
//////        bool Isprime(int num)
//////        {
//////            if (num <= 1) return false;


//////        }
//////        static void Main(string[] args)
//////        {

//////            Console.WriteLine("enter the number:");
//////            int num = Convert.ToInt32(Console.ReadLine());


//////        }
//////    }
//////}




using ConsoleApp2;
using System;

namespace program
{
    class B
    {

        static void Main(string[] args)
        {
            //  q1 obj=new q1();


            //q2 obj1= new q2();
            //    obj1.Menu();


            //q3 cal=new q3 ();
            //cal.Menu1();

            // q4 great=new q4();

            // q5 ticket=new q5();

            //  q6 bmi = new q6();



            // Q7 bmi = new Q7();

            //Q8 bmi = new Q8();

            // Q9 bmi = new Q9();
            //     Q10 patt = new Q10();


            //  Q11 patt1 = new Q11();
            // Q12 patt2 = new Q12();
            //    Q16 fab= new Q16();
            // Q17 arm = new Q17();
            //  Q18 facto = new Q18();
            // Q19 con = new Q19();
            //   Q20 str = new Q20();
            //   Q21 str = new Q21();
            // BankAccount bank = new BankAccount();
            // Student patt=new Student();
            // Program q = new Program();
            // Q32 obj= new Q32();

            //Q33 obj = new Q33();
            // Q13 obj = new Q13();
            //  Q14 obj = new Q14();
            // Q15 obj = new Q15();
            //  Q22 obj = new Q22();
           // q24 obj = new q24();
           Q23 obj=new Q23();
        }
    }
}

