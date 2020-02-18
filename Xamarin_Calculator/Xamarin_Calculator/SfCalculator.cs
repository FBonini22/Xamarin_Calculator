using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.Calculate;

namespace Xamarin_Calculator
{
    /// <summary>
    /// A class utilizing Syncfusion's built-in calculation engine. This removes the need for me to make a calculation parser.
    /// </summary>
    public class SfCalculator
    {
        //INSTANCE VARIABLES
        private CalcEngine Engine;
        private string lastCalculatedValue;
        private string currentResult;
        

        /// <summary>
        /// Default constructor for initializing the main calculator class. This class utilizes Syncfusion's calculation engine.
        /// </summary>
        public SfCalculator()
        {
            Engine = new CalcEngine(new CalcData());

            //var test = engine.ParseAndComputeFormula("5+15/0");
        }

        /// <summary>
        /// Method to parse and calculate a string expression.
        /// This method utilizes Syncfusion's <see cref="Syncfusion.Calculate.CalcEngine"/> class.
        /// </summary>
        /// <param name="expression">The string expression you want to calculate. An example would be "5+15/3" which would result in "10".</param>
        /// <returns>A string result. This can be a number or represent an error.</returns>
        public string Calculate(string expression)
        {
            //Calculate the result
            var result = Engine.ParseAndComputeFormula(expression);

            currentResult = result;
            lastCalculatedValue = result;

            return result;
        }

    }
}
