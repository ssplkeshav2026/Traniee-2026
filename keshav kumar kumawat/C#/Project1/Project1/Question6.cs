using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Question6
    {
        public Question6()
        {
            Console.WriteLine("enter the weight ");
            int W = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the Height ");
            int H = Convert.ToInt32(Console.ReadLine());
            int bmi = (W / H * H);

            if (bmi < 18.5)
            {
                Console.WriteLine("you are underweight");
                Console.WriteLine("Try to include more nutrient-dense foods in your diet.");
            }
            else if (bmi > 18.5 && bmi < 24.9)
            {
                Console.WriteLine("you are healthy");
                Console.WriteLine("Keep up the healthy lifestyle!");

            }
            else if (bmi > 25.5 && bmi < 29.9)
            {
                Console.WriteLine("you are Overweight");
                Console.WriteLine("Focus on regular physical activity and a balanced diet.");
            }
            else if (bmi > 30.0)
            {
                Console.WriteLine("you are Obesity");
                Console.WriteLine("you are healthy");
            }
        }
    }
}