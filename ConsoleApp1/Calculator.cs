using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMathLibrary_Testing_Using_NUnit
{
    public class Calculator
    {
        public int Add(int x, int y) { return x + y; }
        public int sub(int x, int y) => x - y;// returning values usig lambda expression "=>" 
    }
}
