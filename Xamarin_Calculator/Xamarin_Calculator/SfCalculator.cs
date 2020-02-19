using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.Calculate;

namespace Xamarin_Calculator
{
    /// <summary>
    /// A class utilizing Syncfusion's built-in calculation engine. This removes the need for me to make my own calculation parser.
    /// </summary>
    public class SfCalculator
    {
        //CONSTANTS
        private readonly string OPERATORS = "+-÷×";

        //INSTANCE VARIABLES
        private CalcEngine Engine;
        private string lastCalculatedValue;
        private string currentResult;
        /// <summary>
        /// Keeps track of whether the current number already has a decimal added. This will prevent adding 2 decimal points to a number.
        /// This variable should be reset every time an operator is added.
        /// </summary>
        bool doesCurrentWordHaveDot = false;
        /// <summary>
        /// Keeps track of whether the expression ends with an operator. This will be used to prevent contiguous operators.
        /// </summary>
        bool doesExpHaveEndingOperator = false;
        string calculatorExpression = "";


        /// <summary>
        /// Default constructor for initializing the main calculator class. This class utilizes Syncfusion's calculation engine.
        /// </summary>
        public SfCalculator()
        {
            Engine = new CalcEngine(new CalcData());

            //var test = engine.ParseAndComputeFormula("5+15/0");
        }

        /// <summary>
        /// Calculator logic handling. This processes the button input. This also calls <see cref="UpdateCalculatorExpression"/> to update
        /// the displayed expression.
        /// </summary>
        /// <param name="inpt">The value of the button that was pressed.</param>
        public string HandleCalculatorInput(string inpt)
        {
            //Handle operators
            //Note that ÷ and × are special HTML characters.
            if (OPERATORS.Contains(inpt))
            {
                //Reset the decimal tracker
                doesCurrentWordHaveDot = false;
                calculatorExpression += inpt;

            }

            //Handle decimal points
            else if (inpt == "." && !doesCurrentWordHaveDot)
            {
                calculatorExpression += ".";
                doesCurrentWordHaveDot = true;
            }

            //Handle equals
            else if (inpt == "=")
            {
                //If the current expression ends with an operator, do not process it.
                foreach (var op in OPERATORS.ToCharArray())
                {
                    if (calculatorExpression.EndsWith(op.ToString()))
                    {
                        return calculatorExpression;
                    }
                }

                //Calculate the input
                calculatorExpression = Calculate(ConvertExpression(calculatorExpression));
            }

            //Handle CLEAR
            else if (inpt == "CLEAR")
            {
                calculatorExpression = "";


            }

            //Handle all digits
            else
            {
                calculatorExpression += inpt;
            }

            return calculatorExpression;
        }

        /// <summary>
        /// Method to parse and calculate a string expression.
        /// This method utilizes Syncfusion's <see cref="Syncfusion.Calculate.CalcEngine"/> class.
        /// </summary>
        /// <param name="expression">The string expression you want to calculate. An example would be "5+15/3" which would result in "10".</param>
        /// <returns>A string result. This can be a number or represent an error.</returns>
        private string Calculate(string expression)
        {

            //Calculate the result
            var result = Engine.ParseAndComputeFormula(expression);

            //These variables aren't used yet.
            currentResult = result;
            lastCalculatedValue = result;

            return result;
        }

        /// <summary>
        /// Method to convert the calculator's displayed expression to one parsable by the SfCalculation Engine. This is mainly for
        /// converting between display operators and actual operators (÷ vs /)
        /// </summary>
        /// <param name="expression">The expression to convert</param>
        /// <returns>An expression which can be parsed by the SfCalculation Engine</returns>
        private string ConvertExpression(string expression)
        {
            
            expression = expression.Replace("÷", "/");
            expression = expression.Replace("×", "*");

            return expression;
        }
    }
}
