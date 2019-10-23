using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korniienko_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(1);
            p1.InputFromConsole();
            p1.Print();
            Polynomial p2 = new Polynomial(2);
            p2.InputFromConsole();
            p2.Print();
            Polynomial p3 = p1 - p2;
            p3.Print();
            Console.ReadKey();
        }
    }
}
