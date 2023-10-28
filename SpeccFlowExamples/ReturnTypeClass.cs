using System;
using System.Collections.Generic;
using System.Text;

namespace SpeccFlowExamples
{
    public class ReturnTypeClass
    {

        int Base;
        int Height;
        public ReturnTypeClass(int b, int h)
        {
            Base = b;
            Height = h;
        }
        public void Multiply()
        {
            Console.WriteLine("Multiplication of two number is" + Base * Height);
        }
    }
}
