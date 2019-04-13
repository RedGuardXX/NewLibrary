using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{
    class Register_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        /////////////////////////////////////////////////////////////////////////////////////////////////

        string lastname = "";
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        string middlename = "";
        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
                OnPropertyChanged("MiddleName");
            }
        }

        string phonenumber = "";
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

        /////////////////////////////////////////////////////////////////////////////////////////////////

        string adress = "";

        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////


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

        public Register_ViewModel()
        {
            visibilitylol = System.Windows.Visibility.Visible;

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        #region RegisterApp
        RelayCommand _Register;
        public RelayCommand Register
        {
            get
            {
                if (_Register == null)
                {
                    _Register = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
                }
                return _Register;
            }
        }
        private void ExecuteRegisterCommand(object param)
        {
            var res = de.GetUserList();
            if (res.Where(x => x.phone_number == PhoneNumber).Count() == 1)
            {
                MyMsgBox msg = new MyMsgBox("Пользователь с таким номером уже есть!");
                msg.Show();

                return;
            }
            else
            {
                de.AddUser(LastName, Name, MiddleName, PhoneNumber, Adress);

                VisibilityLol = System.Windows.Visibility.Hidden;
                MyMsgBox msg = new MyMsgBox("Пользователь зарегистрирован!");
                msg.Show();
            }


        }

        private bool CanExecuteRegisterCommand(object param)
        {
            if (LastName.Trim().Count() < 1 ||
                Name.Trim().Count() < 1 ||
                MiddleName.Trim().Count() < 1 ||
                PhoneNumber.Trim().Count() < 10 ||
                Adress.Trim().Count() == 0)
                return false;
            else
                return true;
        }

        #endregion
    }
}
