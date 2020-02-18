using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Calculator.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorPage : ContentPage
	{
        //CONSTANTS
        private readonly string OPERATORS = "+-÷×";

        //Instance Variables
        /// <summary>
        /// Keeps track of whether the current number already has a decimal added. This will prevent adding 2 decimal points to a number.
        /// This variable should be reset every time an operator is added.
        /// </summary>
        bool doesCurrentWordHaveDot = false;
        string calculatorExpression = "";
        SfCalculator CalcEngine;

		public CalculatorPage ()
		{
			InitializeComponent ();

            CalcEngine = new SfCalculator();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            var buttonVal = ((Button)sender).Text;
            //this.DisplayAlert("Button pressed: ", buttonVal, "Ok");
            Console.WriteLine(buttonVal);

            HandleCalculatorInput(buttonVal);
        }

        /// <summary>
        /// Calculator logic handling. This processes the button input. This also calls <see cref="UpdateCalculatorExpression"/> to update
        /// the displayed expression.
        /// </summary>
        /// <param name="inpt">The value of the button that was pressed.</param>
        private void HandleCalculatorInput(string inpt)
        {
            //Handle operators
            //Note that ÷ and × are special HTML characters.
            if (OPERATORS.Contains(inpt))
            {
                //Reset the decimal tracker
                doesCurrentWordHaveDot = false;

                //Switch to handle special characters (× and ÷)
                switch (inpt)
                {
                    case "÷":
                        calculatorExpression += "/";
                        break;
                    case "×":
                        calculatorExpression += "*";
                        break;
                    default:
                        calculatorExpression += inpt;
                        break;
                }
            }

            //Handle decimal points
            else if (inpt == "." && !doesCurrentWordHaveDot)
            {
                calculatorExpression += ".";
                doesCurrentWordHaveDot = true;
            }

            //Handle equals
            else if(inpt == "=")
            {
                //If the current expression ends with an operator, do not process it.
                foreach(var op in OPERATORS.ToCharArray())
                {
                    if (calculatorExpression.EndsWith(op.ToString()))
                    {
                        return;
                    }
                }

                //Calculate the input
                calculatorExpression = CalcEngine.Calculate(calculatorExpression);
            }

            //Handle CLEAR
            else if(inpt == "CLEAR")
            {
                calculatorExpression = "";


            }

            //Handle all digits
            else
            {
                calculatorExpression += inpt;
            }

            UpdateCalculatorExpression();
        }

        private void UpdateCalculatorExpression()
        {
            ExpressionDisplay.Text = calculatorExpression;
        }
    }
}