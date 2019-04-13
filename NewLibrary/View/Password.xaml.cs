using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewLibrary
{
    public partial class Password : Window
    {
        public Password(bool choice, int book_id, int user_id)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Password_ViewModel(choice, book_id, user_id);
        }
    }
}
