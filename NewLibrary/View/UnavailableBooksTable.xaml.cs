using ServerConsole;
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
    /// Логика взаимодействия для UnavailableBooksTable.xaml
    /// </summary>
    public partial class UnavailableBooksTable : Window
    {
        public UnavailableBooksTable()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.UnavailableBooksTable_ViewModel();
        }
    }
}
