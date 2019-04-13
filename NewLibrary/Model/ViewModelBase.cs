using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewLibrary.ViewModel
{
    //5. Create Base class view Model
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]
                                            String propertyName = "")
        {
            PropertyChanged?.
                Invoke(this, 
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
