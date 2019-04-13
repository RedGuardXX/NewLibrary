using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{
    class SearchUser_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        public SearchUser_ViewModel()
        {
            visibilitylol = System.Windows.Visibility.Visible;

        }
        ////////////////////////////////////////////////////////////////
        string phonenumber;

        public string PhoneNumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                phonenumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        ///////////////////////////////////////////////////////////////


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
            var res = de.GetUserList();

            for (int i = 0; i < res.Count; i++)
            {
                if (res[i].phone_number == PhoneNumber)
                {
                    SearchUserPlate sup = new SearchUserPlate(PhoneNumber);
                    sup.Show();
                    VisibilityLol = System.Windows.Visibility.Hidden;


                    return;
                }
            }
            MyMsgBox msg = new MyMsgBox("Пользователь с таким номером не найден!");
            msg.Show();
            //MessageBox.Show("Пользователь с таким номером не найден!");


        }

        #endregion
    }
}
