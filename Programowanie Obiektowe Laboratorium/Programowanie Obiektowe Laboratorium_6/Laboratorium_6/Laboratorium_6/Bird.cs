using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium_6
{
    public class Bird : Animal
    {
        int wingspan { 
            get
            {
                return wingspan;
            } 
            set
            {
                if (value > 15 || value <= 0)
                {
                    Console.WriteLine("Incorrect values----bird");
                }
            } 
        }
        public Bird(int w)
        {
            type  = "Bird";
            name  = "Birv";
            group = "Bird kind";

            wingspan = w;
        }
    }
}
