using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddTour.xaml
    /// </summary>
    public partial class AddTour : Window
    {
        private Tour _currentTour = new Tour();
        public AddTour(Tour _selectedTour)
        {

            if (_selectedTour != null)
                _currentTour = _selectedTour;
            DataContext = _currentTour;
            InitializeComponent();
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            var imageBuffer = BitmapSourceToByteArray((BitmapSource)Picture.Source);
            _currentTour.ImagePreview = imageBuffer;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentTour.TicketCount.ToString()))
                errors.AppendLine("Укажите количество билетов у тура");
            if (string.IsNullOrWhiteSpace(_currentTour.Name))
                errors.AppendLine("Укажите наименование тура");
            if (string.IsNullOrWhiteSpace(_currentTour.Price.ToString()))
                errors.AppendLine("Укажите цену у тура");




            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                TourBaseEntitiesDB.GetContext().Tour.Add(_currentTour);
            }


            TourBaseEntitiesDB.GetContext().SaveChanges();
            MessageBox.Show("Запись успешно сохранена!");
            ToursPage tr = new ToursPage();
            tr.Visibility = Visibility.Visible;
            this.Close();
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            ToursPage tr = new ToursPage();
            tr.Visibility = Visibility.Visible;
            this.Close();
        }

        private void addPicture(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";

            if (openDialog.ShowDialog() != null)
            {
                Picture.Source = new BitmapImage(new Uri(openDialog.FileName));

            }
        }
        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

    }
}
