using ServerConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.ViewModel
{
    public class SearchPlateUser_ViewModel:ViewModelBase
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

        public SearchPlateUser_ViewModel(String PhoneNumber)
        {

            var users = de.GetUserList();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].phone_number == PhoneNumber)
                {
                    FIO = users[i].last_name + " " + users[i].name + " " + users[i].middle_name;
                    this.PhoneNumber = users[i].phone_number;
                    Adress = users[i].adress;
                }
            }

            Collection = new ObservableCollection<ShowUnavailableBooks_cs>(de.ShowUsersBooks(PhoneNumber));
        }
    }
}
