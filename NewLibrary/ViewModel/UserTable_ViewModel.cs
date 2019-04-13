using ServerConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.ViewModel
{
    class UserTable_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();

        ObservableCollection<ShowAllBooks_cs> collection = new ObservableCollection<ShowAllBooks_cs>();

        public ObservableCollection<ShowAllBooks_cs> Collection         // Bind ListView
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }

        //////////////////////////////////////////////////////////////////////////////

        string textsearch;

        public string TxtSearch     // BIND строка активного поиска
        {
            get
            {
                return textsearch;
            }
            set
            {
                textsearch = value;
                OnPropertyChanged("TxtSearch");
            }
        }

        public UserTable_ViewModel()
        {
            Collection = new ObservableCollection<ShowAllBooks_cs>(de.ShowAllBooks());
        }

        #region TextChangedApp
        RelayCommand _TextChanged;
        public RelayCommand TextChanged
        {
            get
            {
                if (_TextChanged == null)
                {
                    _TextChanged = new RelayCommand(ExecuteTextChangedCommand);
                }
                return _TextChanged;
            }
        }
        private void ExecuteTextChangedCommand(object param)
        {
            var res = new ObservableCollection<ShowAllBooks_cs>(de.ShowAllBooks());
            if (TxtSearch != "")
            {
                ObservableCollection<ShowAllBooks_cs> n = new ObservableCollection<ShowAllBooks_cs>();

                for (int i = 0; i < res.Count; i++)
                {
                    if (res[i]._title.Contains(TxtSearch) || res[i]._author.Contains(TxtSearch) || res[i]._genre.Contains(TxtSearch))
                    {
                        n.Add(res[i]);
                    }
                }

                Collection = n;
            }
            else
            {
                Collection = res;
            }

        }
        #endregion
    }
}
