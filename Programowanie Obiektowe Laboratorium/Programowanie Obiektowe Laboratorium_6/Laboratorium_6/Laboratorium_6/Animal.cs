using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorium_6
{
    public class Animal
    {
        protected string type  = "___";
        protected string group = "+++";
        protected string name  = "***";
        Bird bird = new Bird(15);
        Dog dog = new Dog(10);
        Fish fish = new Fish(8);

        public void Introduce()
        {
            Console.WriteLine("My type is : {0}\nMy name is : {1}\nAnd my group is : {2}", type, name, group);
            Console.WriteLine("My type is : {0}\nMy name is : {1}\nAnd my group is : {2}", bird.type, bird.name, bird.group);
            Console.WriteLine("My type is : {0}\nMy name is : {1}\nAnd my group is : {2}", dog.type, dog.name, dog.group);
            Console.WriteLine("My type is : {0}\nMy name is : {1}\nAnd my group is : {2}", fish.type, fish.name, fish.group);

        }
        public void ReturnVoise()
        {
            Console.WriteLine("Woof!");
        }
        public void Move()
        {
            Console.WriteLine("Is running!");
        }
    }
}
