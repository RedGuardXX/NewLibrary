using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Diagnostics;

namespace NewLibrary.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        DataExchange de = new DataExchange();
        string phoneNumerText;
        string passwordText;

        public string PhoneNumberText
        {
            get
            {
                return phoneNumerText;
            }
            set
            {
                phoneNumerText = value;
                OnPropertyChanged("PhoneNumberText");
            }
        }
        public string PasswordText
        {
            get
            {

                return passwordText;
            }
            set
            {
                passwordText = value;
                OnPropertyChanged("PasswordText");
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

        public MainWindowViewModel()
        {
            visibilitylol = System.Windows.Visibility.Visible;
            Process.Start("ServerConsole.exe");
        }

        #region LoginApp
        RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteEnterCommand);
                }
                return _loginCommand;
            }
        }
        private void ExecuteLoginCommand(object param)
        {
            try
            {
                if (de.Authentification(phoneNumerText, passwordText))
                {
                    if (phoneNumerText == "Admin")
                    {
                        Menu mainmenu = new Menu(phoneNumerText);
                        mainmenu.Show();

                    }
                    else
                    {
                        UserMenu usermenu = new UserMenu(phoneNumerText);
                        usermenu.Show();
                    }
                }
                else
                {
                    MyMsgBox msg = new MyMsgBox("Пользователь с такими данными не найден!");
                    msg.Show();
                    return;
                }
                VisibilityLol = System.Windows.Visibility.Hidden;
            }
            catch
            {
                MyMsgBox msg = new MyMsgBox("Нету подключения к сервису!");
                msg.Show();
            }


        }

        private bool CanExecuteEnterCommand(object param)
        {
            if (phoneNumerText == "" || phoneNumerText == null)
                return false;
            if (passwordText == "" || passwordText == null)
                return false;
            else
                return true;
        }
        #endregion
    }
}
