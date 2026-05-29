using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class question6
    {
        public question6()
        { 
                double weight, height, bmi;

                Console.Write("Enter your weight (kg): ");
                weight = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter your height (meters): ");
                height = Convert.ToDouble(Console.ReadLine());

                bmi = weight / (height * height);

                Console.WriteLine("Your BMI is: " + bmi);

                if (bmi < 18.5)
                {
                    Console.WriteLine("Category: Underweight");
                    Console.WriteLine("Recommendation: Increase healthy food intake.");
                }
                else if (bmi >= 18.5 && bmi < 25)
                {
                    Console.WriteLine("Category: Normal weight");
                    Console.WriteLine("Recommendation: Maintain your current healthy lifestyle.");
                }
                else if (bmi >= 25 && bmi < 30)
                {
                    Console.WriteLine("Category: Overweight");
                    Console.WriteLine("Recommendation: Exercise regularly.");
                }
                else
                {
                    Console.WriteLine("Category: Obesity");
                    Console.WriteLine("Recommendation: Follow a weight-loss plan.");
                }


        }

    }
}

