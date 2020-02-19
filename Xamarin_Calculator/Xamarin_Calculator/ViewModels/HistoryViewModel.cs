using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_Calculator.Models;
using Xamarin_Calculator.Services;

namespace Xamarin_Calculator.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {

        public ObservableCollection<CalcHistoryEntry> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private static BaseViewModel instance;

        public HistoryViewModel()
        {
            Items = new ObservableCollection<CalcHistoryEntry>();
            LoadItemsCommand = new Command(new Action(ExecuteLoadItemsCommand));

            instance = this;
        }

        /// <summary>
        /// This loads the items using the <see cref="CalcHistoryHelper"/>. It does not need to be a task or async becuase this
        /// is a simple operation (There is no file I/O).
        /// </summary>
        private void ExecuteLoadItemsCommand()
        {
            //
            if (IsBusy)
            {
                return;
            }

            //Set this to true so the app knows we are attempting to load a list. If the user tries to refresh the ListView while
            //it's already being refreshed in a previous request, there could be an error. This prevents that.
            IsBusy = true;

            Items.Clear();

            var historyLogs = CalcHistoryHelper.ReadHistoryLog();

            foreach(var log in historyLogs)
            {
                Items.Add(log);
            }

            IsBusy = false;
        }
    }
}
