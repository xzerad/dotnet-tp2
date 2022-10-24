using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetTp2
{
    class A
    {
        public virtual void Print()
        {
            Console.WriteLine("Class A Implementation");
        }
    }

    class B: A
    {
        public override void Print()
        {
            Console.WriteLine("Class B Overriding Print() Method");
        }

    }
    class C: A
    {
        public override void Print()
        {
            Console.WriteLine("Class C Overriding Print() Method");
        }
    }

    class D : B
    {

    }
     class Ex2
    {
        public static void Main()
        {
            D d = new D();
            d.Print();
        }

    }
}
