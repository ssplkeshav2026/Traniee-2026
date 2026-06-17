using System;
using System.Collections.Generic;
using System.Text;

namespace assignment_c__1
{
    internal class question6
    {
        public question6 () 
        { 
            

            Console.Write("Enter your weight in kg: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter your height in meters: ");
            double height= Convert.ToDouble(Console.ReadLine());

            double bmi = weight / (height * height);
            Console.WriteLine("The bmi is :" + bmi);

            if (bmi < 18.5)
            {
                Console.WriteLine("You are underweight");
                Console.ReadLine();
            }
            else if (bmi <= 24.9)
            {
                Console.WriteLine("You are normal");
                Console.ReadLine();
            }
            else if(bmi <= 29.9)
            {
                Console.WriteLine("You are overweigt");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You are obese");
                Console.ReadLine();
            }
        }
    }
}
