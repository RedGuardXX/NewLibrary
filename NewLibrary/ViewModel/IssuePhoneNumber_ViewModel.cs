using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{
    class IssuePhoneNumber_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        int bi;

        public IssuePhoneNumber_ViewModel(int bookid)
        {
            visibilitylol = System.Windows.Visibility.Visible;
            bi = bookid;

        }

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

        #region Search

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
                    VisibilityLol = System.Windows.Visibility.Hidden;

                    Password pass = new Password(true, bi, res[i].user_id);
                    pass.Show();
                    break;
                }
                else
                {
                    if(i == res.Count()-1)
                    {
                        MyMsgBox msg = new MyMsgBox("Пользователь с таким номером не найден!");
                        msg.Show();
                    }
                }

            }
        }

        #endregion
    }
}
