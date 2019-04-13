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
using ServerConsole;
using System.ComponentModel;

namespace NewLibrary
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu(string PhoneNumber)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Menu_ViewModel(PhoneNumber);
        }
    }
}
