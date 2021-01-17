using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public class MyClass : IFile1, IFile2
    {
        void IFile2.A()
        {
            Console.WriteLine("2A");
        }

        void IFile1.A()
        {
            Console.WriteLine("1A");
        }

        void IFile1.B()
        {
            Console.WriteLine("1B");
        }

        void IFile2.D()
        {
            Console.WriteLine("2D");
        }
    }
}
