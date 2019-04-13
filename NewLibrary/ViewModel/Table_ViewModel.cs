using ServerConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{

    class Table_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public ObservableCollection<ShowAllBooks_cs> res = new ObservableCollection<ShowAllBooks_cs>();

        public ObservableCollection<ShowAllBooks_cs> n2 = new ObservableCollection<ShowAllBooks_cs>();
        public ObservableCollection<ShowAllBooks_cs> Collection  // BIND FOR LISTVIEW
        {
            get { return res; }
            set
            {
                res = value;
                OnPropertyChanged("Collection");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////

        int selectedindex;

        public int SelectedIndex            // BIND Выбранный индекс по doubleclick
        {
            get
            {
                return selectedindex;
            }
            set
            {
                selectedindex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        bool visibility;

        public bool Visibility      // BIND Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");

            }
        }


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

        //public ObservableCollection<ShowAllBooks_cs> Collection { get; set; } // BIND LISTVIEW


        System.Windows.Visibility visibilitylol;

        public Visibility VisibilityLol
        {
            get
            {
                return visibilitylol;
            }
            set
            {
                visibilitylol = value;
                OnPropertyChanged("VisibilityLol");
            }
        }


        public Table_ViewModel()
        {
            visibilitylol = System.Windows.Visibility.Visible;

            ObservableCollection<ShowAllBooks_cs> collection1 = new ObservableCollection<ShowAllBooks_cs>(de.ShowAllBooks());
            Collection = collection1;
            n2 = new ObservableCollection<ShowAllBooks_cs>(de.ShowAllBooks());
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
            ObservableCollection<ShowAllBooks_cs> n = new ObservableCollection<ShowAllBooks_cs>();


            ObservableCollection <ShowAllBooks_cs> res = new ObservableCollection<ShowAllBooks_cs>(de.ShowAllBooks());

            if (TxtSearch != "")
            {
                for (int i = 0; i < res.Count; i++)
                {
                    if (res[i]._author.Contains(TxtSearch) ||
                        res[i]._genre.Contains(TxtSearch) ||
                        res[i]._title.Contains(TxtSearch) ||
                        res[i]._year.Contains(TxtSearch)
                       )
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


        #region DoubleClickApp
        RelayCommand _DoubleClick;
        public RelayCommand DoubleClick
        {
            get
            {
                if (_DoubleClick == null)
                {
                    _DoubleClick = new RelayCommand(ExecuteDoubleClickCommand);
                }
                return _DoubleClick;
            }
        }
        private void ExecuteDoubleClickCommand(object param)
        {
            var res = SelectedIndex;
            int bookid;
            bool choice;
            int user_id;


            //MessageBox.Show(res.ToString());

            for (int i = 0; i < n2.Count; i++)
            {
                if (i == res)
                {

                    if (n2[i]._available == "0")
                    {

                        choice = false;
                        bookid = n2[i]._book_id;

                        string ud = n2[i]._user_id.ToString();
                        user_id = Convert.ToInt32(ud);

                        VisibilityLol = System.Windows.Visibility.Hidden;



                        Password pass = new Password(choice, bookid, user_id);
                        pass.Show();

                        //Close(); // Привязка Visibility
                    }
                    else
                    {
                        VisibilityLol = System.Windows.Visibility.Hidden;

                        choice = true;           // выбор выдать книгу
                        bookid = n2[i]._book_id; // Выбранная книга в листвью

                        IssuePhoneNumber ipn = new IssuePhoneNumber(bookid);
                        ipn.Show();

                        //Close();
                    }
                }
            }

        }

        #endregion
    }
}
