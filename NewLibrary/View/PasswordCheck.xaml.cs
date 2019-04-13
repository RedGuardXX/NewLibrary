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
    /// <summary>
    /// Логика взаимодействия для PasswordCheck.xaml
    /// </summary>
    public partial class PasswordCheck : Window
    {
        public PasswordCheck(string title, string author, string genre, string year)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.PasswordCheck_ViewModel(title, author, genre, year);
        }
    }
}
