using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewLibrary.ViewModel
{
    class AddBook_ViewModel:ViewModelBase
    {
        string title = "";

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

        /////////////////////////////////////////////////////////////////////

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

        /////////////////////////////////////////////////////////////////////


        string year = "";

        public string Year
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

        /////////////////////////////////////////////////////////////////////

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

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
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


        public AddBook_ViewModel()
        {
            visibilitylol = System.Windows.Visibility.Visible;

        }


        #region AddBookApp
        RelayCommand _AddBook;
        public RelayCommand AddBook
        {
            get
            {
                if (_AddBook == null)
                {
                    _AddBook = new RelayCommand(ExecuteAddBookCommand, CanExecuteAddBookCommand);
                }
                return _AddBook;
            }
        }
        private void ExecuteAddBookCommand(object param)
        {
            VisibilityLol = System.Windows.Visibility.Hidden;

            PasswordCheck pc = new PasswordCheck(Title.Trim(), Author.Trim(), Genre.Trim(), Year.Trim());
            pc.Show();
            //Close();
        }

        private bool CanExecuteAddBookCommand(object param)
        {
            if (Title.Trim().Count() < 1 ||
                Author.Trim().Count() < 1 ||
                Genre.Count() < 3 ||
                Year.Trim().Count() < 1)
                return false;
            else
                return true;
        }
        #endregion
    }
}
