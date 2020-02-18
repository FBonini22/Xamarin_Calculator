using Syncfusion.Calculate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_Calculator
{
    /// <summary>
    /// Placeholder class for something that implements <see cref="Syncfusion.Calculate.ICalcData"/>. Syncfusion's calculation 
    /// engine doesn't work without an input that implements <see cref="ICalcData"/>.
    /// None of the methods in the implementation are required for evaluating/parsing a formula, so they are left blank and return null.
    /// </summary>
    class CalcData : ICalcData
    {
        public event ValueChangedEventHandler ValueChanged;

        public object GetValueRowCol(int row, int col)
        {
            return null;
        }

        public void SetValueRowCol(object value, int row, int col)
        {
        }

        public void WireParentObject()
        {            
        }
    }
}
