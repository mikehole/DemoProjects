using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;

namespace SQLightDemo.ViewModels
{
    public class DetailPageViewModel : SQLightDemo.Mvvm.ViewModelBase
    {
        #region Hide stuff...


        public DetailPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                this.Value = "Designtime value";
                return;
            }
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {

            GetData();

            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value))) Value = state[nameof(Value)]?.ToString();
                // clear any cache
                state.Clear();
            }
            else
            {
                // use navigation parameter
                Value = parameter?.ToString();
            }
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(Value)] = Value;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            args.Cancel = false;
        }

        private string _Value = "Default";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        #endregion /Hide stuff...

        private void GetData()
        {

            using (SQLiteConnection db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), @"Data\Shopkins.db"))
            {
                var query = db.Table<Shopkins>().OrderBy(c => c.ShopkinName);

                foreach (var thing in query)
                {
                    if(thing != null)
                    { }
                }
            }


        }

    }
}
