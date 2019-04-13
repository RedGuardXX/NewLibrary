using ServerConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.ViewModel
{
    class UnavailableBooksTable_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();


        public ObservableCollection<ShowUnavailableBooks_cs> n2 = new ObservableCollection<ShowUnavailableBooks_cs>();



        ///////////////////////////////////////////////////////////////////////////////////////////

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

        ///////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<ShowUnavailableBooks_cs> res = new ObservableCollection<ShowUnavailableBooks_cs>();


        public ObservableCollection<ShowUnavailableBooks_cs> Collection     // Bind ListView
        {
            get
            {
                return res;
            }
            set
            {
                res = value;
                OnPropertyChanged("Collection");
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////


        public UnavailableBooksTable_ViewModel()
        {
            res = new ObservableCollection<ShowUnavailableBooks_cs>(de.ShowAllUnavailableBooks());

            Collection = res;
            n2 = res;

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
            ObservableCollection<ShowUnavailableBooks_cs> n = new ObservableCollection<ShowUnavailableBooks_cs>();


            var res = new ObservableCollection<ShowUnavailableBooks_cs>(de.ShowAllUnavailableBooks());

            if (TxtSearch != "")
            {
                for (int i = 0; i < res.Count; i++)
                {
                    //if (res[i]._title.Contains(txt_Search.Text.ToString()) || res[i]._last_name.Contains(txt_Search.Text.ToString()) || res[i]._name.Contains(txt_Search.Text.ToString()) || res[i]._middle_name.Contains(txt_Search.Text.ToString()) || res[i]._phone_number.Contains(txt_Search.Text.ToString()))
                    if (res[i]._title.Contains(TxtSearch) ||
                        res[i]._adress.Contains(TxtSearch) ||
                        res[i]._author.Contains(TxtSearch) ||
                        res[i]._available.Contains(TxtSearch) ||
                        res[i]._date_of_issue.Contains(TxtSearch) ||
                        res[i]._genre.Contains(TxtSearch) ||
                        res[i]._last_name.Contains(TxtSearch) ||
                        res[i]._middle_name.Contains(TxtSearch) ||
                        res[i]._name.Contains(TxtSearch) ||
                        res[i]._phone_number.Contains(TxtSearch) ||
                        res[i]._year.Contains(TxtSearch))
                    {
                        n.Add(res[i]);
                    }
                }
                Collection = n;
                n2 = n;

            }
            else
            {
                Collection = res;
                n2 = res;

            }

        }

        #endregion
    }
}
