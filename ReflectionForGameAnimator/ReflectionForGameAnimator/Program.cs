using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionForGameAnimator
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo thisFoo = new Foo();
            thisFoo.PrintAttributes();
            Console.ReadLine();

        }
    }

    class Foo
    {
        public void PrintAttributes()
        {
            foreach (FieldInfo o in this.GetType().GetFields())
            {
                Console.WriteLine(o.Name);
                object oo = o.GetValue(this);

                foreach(FieldInfo f in oo.GetType().GetFields())
                {
                    Console.WriteLine(f.Name + "," + f.GetValue(oo));
                }
            }
        }
        public Bar Bar1;
        public Bar Bar2;

        public Foo()
        {
            Bar1 = new Bar { pint = 2.87, shot = 1 };
            Bar2 = new Bar { pint = 3.80, shot = 2.50 };
        }

    }

    class Bar
    {
        public void CallTime() {; }
        public double pint;
        public double shot;
        public double chaser()
        {
            return pint + shot;
        }
        private double room = 300;
    }

}
