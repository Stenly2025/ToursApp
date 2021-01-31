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
    /// Логика взаимодействия для AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        private Hotel _currentHotel = new Hotel();
        List<Country> countries = new List<Country>();
        
        public AddHotel(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
                _currentHotel = selectedHotel;
            DataContext = _currentHotel;
            CountryCB.ItemsSource = TourBaseEntitiesDB.GetContext().Country.ToList();
            countries = TourBaseEntitiesDB.GetContext().Country.ToList();

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HotelsPage ht = new HotelsPage();
            ht.Visibility = Visibility.Visible;
            this.Close();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentHotel.CountOfStars.ToString()))
                errors.AppendLine("Укажите количество звезд у отеля");
            if (_currentHotel.CountOfStars > 5)
                errors.AppendLine("Количество звезд у отеля не может быть больше 5");
            if (_currentHotel.CountOfStars < 1)
                errors.AppendLine("Количество звезд у отеля не может быть меньше 1");
            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errors.AppendLine("Укажите наименование отеля");
            if (string.IsNullOrWhiteSpace(_currentHotel.CountryCode))
                errors.AppendLine("Укажите страну у отеля");


            
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                TourBaseEntitiesDB.GetContext().Hotel.Add(_currentHotel);
            }
            

            TourBaseEntitiesDB.GetContext().SaveChanges();
            MessageBox.Show("Запись успешно сохранена!");
            HotelsPage ht = new HotelsPage();
            ht.Visibility = Visibility.Visible;
            this.Close();
        }
        
        private void CountryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = CountryCB.SelectedIndex;
            _currentHotel.CountryCode = countries[id].Code;
        }
    }
}
