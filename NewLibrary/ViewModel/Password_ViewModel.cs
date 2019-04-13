using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{
    class Password_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        bool choice;
        int book_id;
        int user_id;

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////
        /// </summary>

        string title;               // Bind Window.Title
        public string Title
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

        ///////////////////////////////////////////////////////////////////////


        string passwordtext;

        public string PasswordText
        {
            get
            {
                return passwordtext;
            }
            set
            {
                passwordtext = value;
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


        public Password_ViewModel(bool choice, int book_id, int user_id)
        {
            visibilitylol = System.Windows.Visibility.Visible;

            this.choice = choice;
            this.book_id = book_id;
            this.user_id = user_id;
            if (choice == false)
            {
                Title = "Новая Библиотека | Подтвердите сдачу книги";
            }
            else
            {
                Title = "Новая Библиотека | Подтвердите выдачу книги";
            }
        }

#region ConfirmAdd

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
                if (users[i].phone_number == "Admin" && users[i].password == PasswordText)
                {
                    if (choice == false)
                    {
                        VisibilityLol = System.Windows.Visibility.Hidden;

                        de.PassBook(book_id);
                        MyMsgBox msg = new MyMsgBox("Книги сдана!");
                        msg.Show();
                        return;
                    }
                    if (choice == true)
                    {
                        for (int j = 0; j < users.Count; j++)
                        {
                            if (users[j].user_id == user_id)
                            {
                                VisibilityLol = System.Windows.Visibility.Hidden;

                                Issue issue = new Issue(users[j].phone_number, book_id);
                                issue.Show();

                                MyMsgBox msg = new MyMsgBox("Книга выдана!");
                                msg.Show();
                                return;
                            }

                        }
                    }
                }
                if (i == users.Count() - 1)
                {
                    MyMsgBox msg1 = new MyMsgBox("Пароль введен неверно!");
                    msg1.Show();
                    break;
                }


            }

            // НЕ РАБОТАЕТ

        }

        #endregion
    }
}
