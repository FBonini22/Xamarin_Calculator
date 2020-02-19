using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Xamarin_Calculator.Models
{
    /// <summary>
    /// Data model to represent an entry in the calculator's history.
    /// </summary>
    public class CalcHistoryEntry
    {

        public CalcHistoryEntry(string expression)
        {
            _timestamp = DateTime.UtcNow;
            _expression = expression;
        }

        private DateTime _timestamp { get; set; }
        private string _expression { get; set; }

        /// <summary>
        /// The expression that was entered into the calculator.
        /// </summary>
        public string Expression { get { return _expression; }}
        public string TimeStamp { get { return _timestamp.ToLongDateString(); }}


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
