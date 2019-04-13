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
    /// Логика взаимодействия для MyMsgBox.xaml
    /// </summary>
    public partial class MyMsgBox : Window
    {
        public MyMsgBox(string labeltext)
        {
            InitializeComponent();
            text_label.Content = labeltext;
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
