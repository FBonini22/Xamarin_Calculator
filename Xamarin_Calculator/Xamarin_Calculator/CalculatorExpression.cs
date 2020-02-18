using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Calculator
{
    class CalculatorExpression
    {
        //CONSTANTS
        private readonly char DELIMITER = ' ';

        //Accessors
        public string Operator { get; private set; }
        public double Operand1 { get; private set; }
        public double Operand2 { get; private set; }

        /// <summary>
        ///Initializes a <see cref="CalculatorExpression"/> class and parses the string into 3 sections: operand 1, operator, operand 2
        /// </summary>
        /// <param name="expression">The expression passed from the calculator's input</param>
        public CalculatorExpression(string expression)
        {
            var parsed = expression.Split(DELIMITER);

            Operand1 = double.Parse(parsed[0]);
            Operand2 = double.Parse(parsed[2]);
            Operator = parsed[1];
        }
    }
}
