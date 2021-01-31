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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Window
    {
        public HotelsPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddHotel fur = new AddHotel(null);
            fur.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var HotelForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {HotelForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TourBaseEntitiesDB.GetContext().Hotel.RemoveRange(HotelForRemoving);
                    TourBaseEntitiesDB.GetContext().SaveChanges();
                    MessageBox.Show("Данны успешно удалены!");

                    DGridHotels.ItemsSource = TourBaseEntitiesDB.GetContext().Hotel.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            if (DGridHotels.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись");
                return;
            }
            var std = DGridHotels.SelectedItem as Hotel;

            AddHotel fur = new AddHotel(std);
            fur.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Menu mn = new Menu();
            mn.Visibility = Visibility.Visible;
            this.Close();
        }

        private void UpdateEquipment()
        {
            var currentHotel = TourBaseEntitiesDB.GetContext().Hotel.ToList();

            currentHotel = currentHotel.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            DGridHotels.ItemsSource = currentHotel.OrderBy(p => p.Name).ToList();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateEquipment();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateEquipment();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TourBaseEntitiesDB.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = TourBaseEntitiesDB.GetContext().Hotel.ToList();
            }
        }
    }
}
