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
    class Issue_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();
        ///////////////////////////////////////////////////////////////////

        string fio;

        public string FIO
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }

        ///////////////////////////////////////////////////////////////////

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

        ///////////////////////////////////////////////////////////////////

        string adress;
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

        ///////////////////////////////////////////////////////////////////

        ObservableCollection<ShowUnavailableBooks_cs> collection = new ObservableCollection<ShowUnavailableBooks_cs>();

        public ObservableCollection<ShowUnavailableBooks_cs> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public Issue_ViewModel(String PhoneNumber, int bookid)
        {
            visibilitylol = System.Windows.Visibility.Visible;

            var users = de.GetUserList();


            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].phone_number == PhoneNumber)
                {
                    de.IssueBook(users[i].user_id, bookid, DateTime.Now.ToString());
                    FIO = users[i].last_name + " " + users[i].name + " " + users[i].middle_name;
                    PhoneNumber = users[i].phone_number;
                    Adress = users[i].adress;

                    MyMsgBox msg = new MyMsgBox("Книга выдана!");
                }
            }

            var res = new ObservableCollection<ShowUnavailableBooks_cs>(de.ShowUsersBooks(PhoneNumber));
            Collection = res;
        }
    }
}
