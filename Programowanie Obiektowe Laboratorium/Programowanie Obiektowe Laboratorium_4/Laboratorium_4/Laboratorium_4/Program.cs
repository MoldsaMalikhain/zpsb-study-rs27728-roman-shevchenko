using System;

namespace Laboratorium_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your character name : ");
            Player pl = new Player(Convert.ToString(Console.ReadLine()));
            do
            {
                Console.Write(" * ******************"    + "\n" +
                                  "Co mam zrobic ?  *  " + "\n" +
                                  "Info         [1] *  " + "\n" +
                                  "LvlUp        [2] *  " + "\n" +
                                  "TakeDamage   [3] *  " + "\n" +
                                  "Heal         [4] *  " + "\n" +
                                  "Exit         [5] *  " + "\n" +
                                  "*******************"  + "\n");
                pl.GetInput(Convert.ToInt32(Console.ReadLine()));
            } while (true);
        }

    }
    public class Player
    {
        public string PlayerName { get; set; }
        int PlayerLvl = 1;
        double PlayerHP = 100;
        public Player(string _name) 
        {
            PlayerName = _name;
        }

        public void Info()
        {
            Console.WriteLine("Your character {0} has {1} Lvl and {2} HP", PlayerName, PlayerLvl, PlayerHP);
        }
        public int Lvl()
        {
            return PlayerLvl += 1;
        }
        public double TakeDamage()
        {
            return PlayerHP -= 1;
        }
        public double Heal()
        {
            if (PlayerHP < 100)
                return PlayerHP += 1;
            else
                return 0;
        }
        public void GetInput(int input)
        {
            if (input == 1)
            {
                Info();
            }
            else if (input == 2)
            {
                Lvl();
            }
            else if (input == 3)
            {
                TakeDamage();
            }
            else if (input == 4)
            {
                Heal();
            }
            else if (input >= 5)
            {
                Environment.Exit(0);
            }

        }
    }
  
    
}
