using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Calculator.ViewModels;

namespace Xamarin_Calculator.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
        HistoryViewModel viewModel;

		public HistoryPage ()
		{
			InitializeComponent ();

            //Initialize Binding Context
            BindingContext = viewModel = new HistoryViewModel();
        }
	}
}