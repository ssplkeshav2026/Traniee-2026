using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Question6
    {
        public Question6()
        {

            double BMIvalue = calculateBMI();
            if (BMIvalue < 18.5)
            {
                Console.WriteLine("UnderWeight");
                Console.WriteLine("Health Recommendation : Focus on nutrient-dense foods, increasing calorie intake, and strength training to build muscle mass");
            }
            else if (BMIvalue >= 18.5 && BMIvalue <= 24.9)
            {
                Console.WriteLine("Normal Weight");
                Console.WriteLine("Health Recommendation :  Maintain a balanced diet, regular physical activity, and healthy lifestyle habits");

            }
            else if (BMIvalue >= 25 && BMIvalue <= 29.9)
            {
                Console.WriteLine("Over Weight");
                Console.WriteLine("Health Recommendation :  Aim for moderate weight loss (1–2 pounds per week) through a combination of reduced calorie intake and increased physical activity. Focus on heart-healthy, high-fiber foods.");

            }
            else
            {
                Console.WriteLine("Obese if BMIvalue is 30 or higher");
                Console.WriteLine("Health Recommendation :  Seek professional guidance from a doctor or dietitian for a structured weight loss program, as this range is associated with high risks for heart disease, diabetes, and sleep apnea");

            }

        }


        static double calculateBMI()
        {
            Console.WriteLine("Enter your weight :");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your height :");
            double height = Convert.ToDouble(Console.ReadLine());


            double totalBMI = weight / Math.Pow(height, 2);
            return totalBMI;
        }
    }
}
