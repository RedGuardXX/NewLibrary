using ServerConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewLibrary.ViewModel
{
    public class UserMenu_ViewModel : ViewModelBase
    {
        DataExchange de = new DataExchange();
        string pn = null;

        string fio = null;
        public string Fio
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
                OnPropertyChanged("Fio");
            }
        }




        public UserMenu_ViewModel(string PhoneNumber)
        {
            pn = PhoneNumber;
            var res = de.GetUserList();

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
            Fio = mainuser.last_name + " " + mainuser.name + " " + mainuser.middle_name;
        }

        /////////////////////////////////////////////////////////////////////////////////////////

        #region SearchApp
        RelayCommand _Search;
        public RelayCommand Search
        {
            get
            {
                if (_Search == null)
                {
                    _Search = new RelayCommand(ExecuteSearchCommand);
                }
                return _Search;
            }
        }

        private void ExecuteSearchCommand(object param)
        {
            UserTable ut = new UserTable();
            ut.Show();
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////////////////////


        #region MyBooksApp
        RelayCommand _MyBooks;
        public RelayCommand MyBooks
        {
            get
            {
                if (_MyBooks == null)
                {
                    _MyBooks = new RelayCommand(ExecuteMyBooksCommand);
                }
                return _MyBooks;
            }
        }

        private void ExecuteMyBooksCommand(object param)
        {
            var res = de.GetUserList();

            User mainuser = new User();
            for (int i = 0; i < res.Count(); i++)
            {
                if (res[i].phone_number == pn)
                {
                    mainuser.user_id = res[i].user_id;
                    mainuser.phone_number = res[i].phone_number;
                    mainuser.password = res[i].password;
                    mainuser.name = res[i].name;
                    mainuser.middle_name = res[i].middle_name;
                    mainuser.last_name = res[i].last_name;

                }
            }
            UserMyBooksTable table = new UserMyBooksTable(mainuser.phone_number);
            table.Show();

        }
        #endregion
    }
}
