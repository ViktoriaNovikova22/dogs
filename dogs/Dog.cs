using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dogs
{
    internal class Dog
    {
        public int power;
        public string name;
        public int age;
        public Dog(int power, int age, string name)
        {
            this.power = power;
            this.age = age;
            this.name = name;
        }
    }
}
