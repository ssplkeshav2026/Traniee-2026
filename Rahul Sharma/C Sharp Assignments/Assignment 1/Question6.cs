using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//6.Write a program that determines BMI category and displays health 
//    recommendations based on the calculated BMI value.

namespace Assignment1
{
    internal class Question6
    {
           public Question6() 
        { 
            Console.WriteLine("Enter your weight in kg:");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your height in meters:");
            double height = Convert.ToDouble(Console.ReadLine());

            double bmi = weight / (height * height);

            Console.WriteLine("Your BMI is: " + bmi);

            if (bmi< 18.5)
            {
                Console.WriteLine("Category: Underweight");
                Console.WriteLine("Recommendation: Eat more nutritious food and consult a doctor if needed.");
            }
            else if (bmi >= 18.5 && bmi< 24.9)
            {
                Console.WriteLine("Category: Normal weight");
                Console.WriteLine("Recommendation: Maintain your healthy lifestyle.");
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                Console.WriteLine("Category: Overweight");
                Console.WriteLine("Recommendation: Exercise regularly and maintain a balanced diet.");
            }
            else
            {
                Console.WriteLine("Category: Obese");
                Console.WriteLine("Recommendation: Consult a doctor and follow a strict diet and exercise plan.");
            }
        }
        

    }
}
