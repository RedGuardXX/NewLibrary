using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerConsole;
using System.Windows;

namespace NewLibrary.ViewModel
{
    public class Menu_ViewModel : ViewModelBase
    {
        public Menu_ViewModel()
        {

        }
        DataExchange de = new DataExchange();
        string phonenumber = null;
        User mainuser = new User();
        string fio_label = null;

        public string FioLabel_C
        {
            get
            {
                return fio_label;
            }
            set
            {
                fio_label = value;
                OnPropertyChanged("FioLabel_C");
            }
        }

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


        public Menu_ViewModel(string PhoneNumber)
        {
            visibilitylol = System.Windows.Visibility.Visible;

            var res = de.GetUserList();
            phonenumber = PhoneNumber;

            User mainuser = new User();
            for (int i = 0; i < res.Count(); i++)
            {
                if (res[i].phone_number == PhoneNumber)
                {
                    mainuser.user_id = res[i].user_id;
                    mainuser.phone_number = res[i].phone_number;
                    mainuser.password = res[i].password;
                    mainuser.name = res[i].name;
                    mainuser.middle_name = res[i].middle_name;
                    mainuser.last_name = res[i].last_name;
                }
            }
            fio_label = mainuser.last_name + " " + mainuser.name + " " + mainuser.middle_name;
        }



        #region FindBookApp
        RelayCommand _FindBook;
        public RelayCommand FindBookButton
        {
            get
            {
                if (_FindBook == null)
                {
                    _FindBook = new RelayCommand(ExecuteFindBookCommand);
                }
                return _FindBook;
            }
        }

        private void ExecuteFindBookCommand(object param)
        {
            Table table = new Table();
            table.Show();
        }
        #endregion


        #region UnavailableBooksApp
        RelayCommand _UnavailableBooks;
        public RelayCommand UnavailableBooksButton
        {
            get
            {
                if (_UnavailableBooks == null)
                {
                    _UnavailableBooks = new RelayCommand(ExecuteUnavailableBooksCommand);
                }
                return _UnavailableBooks;
            }
        }

        private void ExecuteUnavailableBooksCommand(object param)
        {
            UnavailableBooksTable table = new UnavailableBooksTable();
            table.Show();
        }
        #endregion


        #region FindUserApp
        RelayCommand _FindUser;
        public RelayCommand FindUserButton
        {
            get
            {
                if (_FindUser == null)
                {
                    _FindUser = new RelayCommand(ExecuteFindUserCommand);
                }
                return _FindUser;
            }
        }

        private void ExecuteFindUserCommand(object param)
        {
            SearchUser su = new SearchUser();
            su.Show();
        }
        #endregion


        #region RegUserApp
        RelayCommand _RegUser;
        public RelayCommand RegUserButton
        {
            get
            {
                if (_RegUser == null)
                {
                    _RegUser = new RelayCommand(ExecuteRegUserCommand);
                }
                return _RegUser;
            }
        }

        private void ExecuteRegUserCommand(object param)
        {
            Register reg = new Register();
            reg.Show();
        }
        #endregion


        #region AddBookApp
        RelayCommand _AddBook;
        public RelayCommand AddBookButton
        {
            get
            {
                if (_AddBook == null)
                {
                    _AddBook = new RelayCommand(ExecuteAddBookCommand);
                }
                return _AddBook;
            }
        }

        private void ExecuteAddBookCommand(object param)
        {
            AddBook ab = new AddBook();
            ab.Show();
        }
        #endregion


        #region WindowClosedApp
        RelayCommand _WindowClosed;
        public RelayCommand WindowClosed
        {
            get
            {
                if (_WindowClosed == null)
                {
                    _WindowClosed = new RelayCommand(ExecuteWindowClosedCommand);
                }
                return _WindowClosed;
            }
        }

        private void ExecuteWindowClosedCommand(object param)
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
