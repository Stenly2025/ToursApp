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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Window
    {
        public ToursPage()
        {
            InitializeComponent();
            DGridTours.ItemsSource = TourBaseEntitiesDB.GetContext().Tour.ToList();

        }


        private void backBtn(object sender, RoutedEventArgs e)
        {
            Menu mn = new Menu();
            if (WhatTheRole.role == Role.Admin)
            {
                mn.TicketTake.Visibility = Visibility.Collapsed;
            }
            
            mn.Visibility = Visibility.Visible;
            this.Close();
        }

        private void RemoveBtn(object sender, RoutedEventArgs e)
        {
            var TourForRemoving = DGridTours.SelectedItems.Cast<Tour>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {TourForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourBaseEntitiesDB.GetContext().Tour.RemoveRange(TourForRemoving);
                    TourBaseEntitiesDB.GetContext().SaveChanges();
                    MessageBox.Show("Данны успешно удалены!");

                    DGridTours.ItemsSource = TourBaseEntitiesDB.GetContext().Tour.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void changeBtn(object sender, RoutedEventArgs e)
        {
            if (DGridTours.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись");
                return;
            }
            var std = DGridTours.SelectedItem as Tour;

            AddTour fur = new AddTour(std);
            fur.Visibility = Visibility.Visible;
            this.Close();
        }

        private void addBtn(object sender, RoutedEventArgs e)
        {
            AddTour ad = new AddTour(null);
            ad.Visibility = Visibility.Visible;
            this.Close();
        }

        private void UpdateEquipment()
        {
            var currentTour = TourBaseEntitiesDB.GetContext().Tour.ToList();

            currentTour = currentTour.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            DGridTours.ItemsSource = currentTour.OrderBy(p => p.Name).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateEquipment();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEquipment();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TourBaseEntitiesDB.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridTours.ItemsSource = TourBaseEntitiesDB.GetContext().Tour.ToList();
            }
        }
    }
}
