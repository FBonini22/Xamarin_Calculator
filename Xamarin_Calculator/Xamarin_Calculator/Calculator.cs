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
        }



        private double Add(double operand1, double operand2)
        {
            double sum = operand1 + operand2;


        }


        //Accessors
        /// <summary>
        /// Gets the delimiter used to parse <see cref="Calculator"/> input strings.
        /// </summary>
        /// <returns>Returns the delimiter as a string. This should be one character.</returns>
        public string GetDelimiter()
        {
            return DELIMITER;
        }
    }
}
