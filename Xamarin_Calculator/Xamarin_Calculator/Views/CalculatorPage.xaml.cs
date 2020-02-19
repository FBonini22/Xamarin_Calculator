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


        //Instance Variables
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

            UpdateCalculatorExpression(CalcEngine.HandleCalculatorInput(buttonVal));
        }


        /// <summary>
        /// Method to update the expression display on the screen. This was created as a separate method for the chance
        /// that more code needs to be run when updating the expression.
        /// </summary>
        /// <param name="newExpression"></param>
        private void UpdateCalculatorExpression(string newExpression)
        {
            ExpressionDisplay.Text = newExpression;
        }
    }
}