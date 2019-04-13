﻿using ServerConsole;
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
    /// Логика взаимодействия для SearchUserPlate.xaml
    /// </summary>
    public partial class SearchUserPlate : Window
    {
        public SearchUserPlate(String PhoneNumber)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.SearchPlateUser_ViewModel(PhoneNumber);
        }
    }
}
