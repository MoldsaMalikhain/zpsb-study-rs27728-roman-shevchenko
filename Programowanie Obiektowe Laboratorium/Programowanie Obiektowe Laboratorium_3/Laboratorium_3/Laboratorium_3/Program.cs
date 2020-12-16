﻿using System;
using System.Xml;   

namespace Laboratorium_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            int n;

            Console.WriteLine("Podaj dla jakiej liczby obliczyc silnie.\n");
            line = Console.ReadLine();
            n = int.Parse(line);

            Console.WriteLine(n + "! = " + silnia1(n));
        }

        private static int silnia1(int i)
        {
            if (i < 1)
                return 1;
            else
                return i * silnia1(i - 1);
        }

    }
}
