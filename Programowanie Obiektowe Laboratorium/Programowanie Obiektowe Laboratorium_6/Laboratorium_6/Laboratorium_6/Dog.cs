using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium_6
{
    public class Dog : Animal
    {
        int tailLength
        {
            get
            {
                return tailLength;
            }
            set
            {
                if (value >= 10 || value <= 0)
                {
                    Console.WriteLine("Incorrect values----Dog");
                }
            }
        }
        public Dog(int t_l)
        {
            type  = "Dog";
            name  = "Dogou";
            group = "Dogou kind";

            tailLength = t_l;
        }
    }
}
