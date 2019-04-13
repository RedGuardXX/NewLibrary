using ServerConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.ViewModel
{
    class UserMyBooksTable_ViewModel:ViewModelBase
    {
        DataExchange de = new DataExchange();

        ObservableCollection<ShowUnavailableBooks_cs> collection;

        public ObservableCollection<ShowUnavailableBooks_cs> Collection  // BIND FOR LISTVIEW
        {
            get { return collection; }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }

        public UserMyBooksTable_ViewModel(string PhoneNumber)
        {
            Collection = new ObservableCollection<ShowUnavailableBooks_cs>(de.ShowUsersBooks(PhoneNumber));
        }
    }
}
