using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeffrey_Smith_Challenge3_Q4
{
    // Define delegate
    // TODO: declare public delegate int OperationHandler(int a, int b)

    public delegate int OperationHandler(int a, int b);


    public class Calculator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    class Jeffrey_Smith_Challenge3_Q4
    {
        static void Main(string[] args)
        {
            // TODO: create delegate instances pointing to Calculator.Add and Calculator.Multiply
            // Example:
            OperationHandler addOp = new OperationHandler(Calculator.Add);
            OperationHandler mulOp = new OperationHandler(Calculator.Multiply);
            //
            Console.WriteLine(addOp(3,4)); // 7
            Console.WriteLine(mulOp(3,4)); // 12
        }
    }

}
