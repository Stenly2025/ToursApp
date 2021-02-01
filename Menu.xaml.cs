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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void backButton(object sender, RoutedEventArgs e)
        {
            Login lg = new Login();
            lg.Visibility = Visibility.Visible;
            this.Close();
        }

        private void hotelsWindow(object sender, RoutedEventArgs e)
        {
            HotelsPage ht = new HotelsPage();
            if (WhatTheRole.role == Role.Client)
            {
                ht.BtnAdd.Visibility = Visibility.Hidden;
                ht.BtnDelete.Visibility = Visibility.Hidden;
                ht.BtnChange.Visibility = Visibility.Hidden;
                
            }
            
            ht.Visibility = Visibility.Visible;
            this.Close();
        }

        private void toursWindow(object sender, RoutedEventArgs e)
        {
            ToursPage tp = new ToursPage();
            if (WhatTheRole.role == Role.Client)
            {
                tp.BtnAdd.Visibility = Visibility.Hidden;
                tp.BtnDelete.Visibility = Visibility.Hidden;
                tp.BtnChange.Visibility = Visibility.Hidden;

            }
            tp.Visibility = Visibility.Visible;
            this.Close();
        }

        private void taskWindow(object sender, RoutedEventArgs e)
        {
            TakeTicket tt = new TakeTicket();
            tt.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
