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
    /// Логика взаимодействия для SearchUser.xaml
    /// </summary>
    public partial class SearchUser : Window
    {
        public SearchUser()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.SearchUser_ViewModel();
        }
    }
}
