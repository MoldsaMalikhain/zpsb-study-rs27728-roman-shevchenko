using System;

namespace Laboratorium_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0, diff = 0;
            bool isDone = true;
            do
            {
                Console.WriteLine("Pease enter values from 10 to 30");
                Console.Write("length : ");
                length = Convert.ToInt16(Console.ReadLine());
                if (length < 10 || length > 30)
                {
                }
                else
                {
                    isDone = false;
                }

            } while (isDone);
            Console.WriteLine("\nMap size {0}x{0}",length);
            Console.WriteLine("Please chouse dificalty\n[1] - eazy\n[2] - normal\n[3] - hard");
            
            diff = Convert.ToInt16(Console.ReadLine());

            Render(Rand(diff, length), length);
            Console.ReadLine();
        }
        static int[,] Rand(int _diff, int _length)
        {
            var rand = new Random();
            int[,] map = new int[_length, _length];

            if (_diff == 1)
            {
                Console.WriteLine("1");
                for (int i = 0; i < _length; i++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        map[i, k] = rand.Next(0,10);
                    }
                }
            }
            else if(_diff == 2)
            {
                Console.WriteLine("2");
                for (int i = 0; i < _length; i++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        map[i, k] = rand.Next(0, 5);
                    }
                }

            }
            else if(_diff == 3)
            {
                Console.WriteLine("3");
                for (int i = 0; i < _length; i++)
                {
                    for (int k = 0; k < _length; k++)
                    {
                        map[i, k] = rand.Next(0, 2);
                    }
                }
            }
            else
            {
                Console.WriteLine("Err");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return map;
        }
        static void Render(int[,] _map, int _length)
        {
            Console.WriteLine("Render");

            for (int i = 0; i < _length; i++)
            {
                for (int k = 0; k < _length; k++)
                {
                    if (_map[i, k] == 1)
                        Console.Write("# ");
                    else
                        Console.Write("_ ");
                }
                Console.Write("\n");
            }
            //foreach (int item in _map)
            //{
            //    //Console.Write(item);
            //    if (item == 1)
            //        Console.Write("#");
            //    else
            //        Console.Write("_");

            //}
        }
    }
}
