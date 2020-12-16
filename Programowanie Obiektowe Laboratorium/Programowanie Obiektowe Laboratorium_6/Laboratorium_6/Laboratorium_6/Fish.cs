using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium_6
{
    public class Fish : Animal
    { 
        int finsAmount {
            get
            {
                return finsAmount;
            }
            set
            {
                if (value > 8 || value <= 0)
                {
                    Console.WriteLine("Incorrect values----Fish");
                }
            } 
        }
        public Fish(int f_a)
        {
            type  = "fish";
            name  = "Fishy";
            group = "Fish kind";

            finsAmount = f_a;
        }
    }
}
