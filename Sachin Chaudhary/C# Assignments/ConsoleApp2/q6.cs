using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class q6
    {
        public q6()
        {
            Console.WriteLine("enter the weight ");
            int W=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the Height ");
            int H = Convert.ToInt32(Console.ReadLine());
            int bmi = (W / H * H);

            if (bmi <18.5) {
                Console.WriteLine("you are underweight");
                Console.WriteLine("Boost Calories Healthily: Aim for a surplus of 300–500 extra calories per day. Focus on nutrient-dense foods like nuts, avocados, cheese, and whole grains rather than empty sugars.\r\nEat Frequently: Try 5–6 smaller meals instead of three large ones, especially if you have a small appetite.\r\nBuild Muscle: Incorporate strength training or yoga to increase lean muscle mass and potentially stimulate your appetite.\r\nProfessional Check: See a doctor to rule out underlying issues like thyroid problems, malabsorption, or clinical malnutrition.");
            }
            else if (bmi > 18.5 && bmi<24.9)
            {
                Console.WriteLine("you are healthy");
                Console.WriteLine("Stay Active: Maintain at least 150 minutes of moderate-intensity aerobic activity (like brisk walking) every week.\r\nBalanced Nutrition: Follow a \"heart-healthy\" plan rich in fruits, vegetables, and lean proteins.\r\nMonitor Habits: Regularly track your sleep (7–9 hours) and manage stress to keep hormone levels stable, which helps regulate appetite.");

            }
            else if (bmi > 25.5 && bmi < 29.9)
            {
                Console.WriteLine("you are Overweight");
                Console.WriteLine("Sustainable Loss: Aim to lose 1–2 pounds (0.5–1 kg) per week. Losing even 3–5% of your total body weight can significantly improve blood sugar and cholesterol levels.\r\nDietary Swaps: Limit added sugars and refined carbohydrates (like white bread and soda). Use water to stay hydrated and promote a feeling of fullness.\r\nIncrease Movement: Aim for 300 minutes of moderate activity per week for more effective weight loss and maintenance.\r\nConsult Specialists: If lifestyle changes alone aren't enough, talk to your provider about therapeutic options, which may include medically supervised weight loss or bariatric surgery for higher BMI classes.");
            }
            else if (bmi > 30.0)
            {
                Console.WriteLine("you are Obesity");
                Console.WriteLine("you are healthy");
            }

        }


    }
}
