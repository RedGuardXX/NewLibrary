using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{

    class PasswordCheck_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();

        string title;

        string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        //////////////////////////////////////////////////////////////////////////////

        string author = "";

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        //////////////////////////////////////////////////////////////////////////////

        string genre = "";
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }
        //////////////////////////////////////////////////////////////////////////////

        string year = "";
        string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        //////////////////////////////////////////////////////////////////////////////

        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
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


        public PasswordCheck_ViewModel(string title, string author, string genre, string year)
        {
            visibilitylol = System.Windows.Visibility.Visible;

            this.title = title;
            this.author = author;
            this.genre = genre;
            this.year = year;
        }


        #region ConfirmApp
        RelayCommand _Confirm;
        public RelayCommand Confirm
        {
            get
            {
                if (_Confirm == null)
                {
                    _Confirm = new RelayCommand(ExecuteConfirmCommand);
                }
                return _Confirm;
            }
        }
        private void ExecuteConfirmCommand(object param)
        {
            var users = de.GetUserList();

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].phone_number == "Admin" && users[i].password == Password)
                {
                    VisibilityLol = System.Windows.Visibility.Hidden;

                    de.AddBook(title, author, year, genre);
                    MyMsgBox msg = new MyMsgBox("Книга добавлена!");
                    msg.Show();
                    return;

                }

                if (i == users.Count() - 1)
                {
                    MyMsgBox msg1 = new MyMsgBox("Пароль введен неверно!");
                    msg1.Show();
                    break;
                }
            }
        }
        #endregion
    }
}
