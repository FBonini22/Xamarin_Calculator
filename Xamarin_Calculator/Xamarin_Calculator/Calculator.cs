using System;
using System.Collections.Generic;
using System.Text;


namespace Xamarin_Calculator
{
    /// <summary>
    /// A class which is contains various functions used to calculate things.
    /// </summary>
    public class Calculator
    {
        //CONSTANTS



        //INSTANCE VARIABLES
        private double lastCalculatedValue = 0f;

        /// <summary>
        /// Default constructor. Currently, this class requires no parameters.
        /// </summary>
        public Calculator()
        {

        }


        public double Calculate(CalculatorExpression exp)
        {
            
            switch (exp.Operator)
            {
                case "/":
                    break;
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
            }

            return 0f;
        }



        private double Add(double operand1, double operand2)
        {
            double sum = operand1 + operand2;

            return sum;
        }



    }
}
