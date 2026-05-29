using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//7.Right - Angled Triangle
//*
//**
//***
//*****
//******

namespace Assignment1
{
    internal class Question7
    {
        public Question7()
        {
            Console.WriteLine("Enter number of rows ");
            int row = int.Parse(Console.ReadLine());

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
