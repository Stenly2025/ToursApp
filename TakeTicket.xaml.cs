using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для TakeTicket.xaml
    /// </summary>
    public partial class TakeTicket : Window
    {
        
        public TakeTicket()
        {
            InitializeComponent();
            CBoxTour.ItemsSource = TourBaseEntitiesDB.GetContext().Tour.ToList();
            CBoxHotel.ItemsSource = TourBaseEntitiesDB.GetContext().Hotel.ToList();
        }
       
        private void backBtn(object sender, RoutedEventArgs e)
        {
            Menu mn = new Menu();
            mn.Visibility = Visibility.Visible;
            this.Close();
        }

        private void userTicket(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var midname = MidName.Text;
            var lastname = LastName.Text;
            var howvidan = howVidan.Text;
            var placereg = placeRegister.Text;
            var Serial = serial.Text;
            var Number = number.Text;

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(name.ToString()))
                errors.AppendLine("Заполните поле Имя");
            if (string.IsNullOrWhiteSpace(midname.ToString()))
                errors.AppendLine("Заполните поле Фамилия");
            if (string.IsNullOrWhiteSpace(lastname.ToString()))
                errors.AppendLine("Заполните поле Отчество");
            if (string.IsNullOrWhiteSpace(howvidan.ToString()))
                errors.AppendLine("Заполните поле Кем выдан");
            if (string.IsNullOrWhiteSpace(placereg.ToString()))
                errors.AppendLine("Заполните поле Место регистрации");
            if (string.IsNullOrWhiteSpace(Serial.ToString()))
                errors.AppendLine("Заполните поле Серия");
            if (string.IsNullOrWhiteSpace(Number.ToString()))
                errors.AppendLine("Заполните поле Номер");
            if (Serial.Length!=4)
                errors.AppendLine("Некоректно заполнено поле Серия");
            if (Number.Length != 6)
                errors.AppendLine("Некоректно заполнено поле Номер");
            if (CBoxHotel.SelectedItem == null)
                errors.AppendLine("Не выбран отель.");
            if (CBoxTour.SelectedItem == null)
                errors.AppendLine("Не выбран тур");




            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {


                using (StreamWriter incdate = File.AppendText(@"C:\ticketsUser\ticket.txt"))
                {
                    incdate.WriteLine(Name.Text, '\n');
                    incdate.WriteLine(MidName.Text, '\n');
                    incdate.WriteLine(LastName.Text, '\n');
                    incdate.WriteLine(howVidan.Text, '\n');
                    incdate.WriteLine(placeRegister.Text, '\n');
                    incdate.WriteLine(serial.Text, '\n');
                    incdate.WriteLine(number.Text, '\n');
                    incdate.WriteLine(CBoxTour.SelectedIndex.ToString(), '\n');
                    incdate.WriteLine(CBoxHotel.SelectedIndex.ToString(), '\n');
                }
                
                
                    //MailAddress from = new MailAddress("denis_filatov_553@mail.ru", "Denis");
                    //MailAddress to = new MailAddress(Email.Text.ToString());
                    //MailMessage m = new MailMessage(from, to);
                    //m.Subject = "Тест";
                    //m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
                    //m.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient("smtp.mail.ru", 465);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new NetworkCredential("denis_filatov_553@mail.ru", "Ltybc55329");
                    //smtp.EnableSsl = true;
                    //smtp.Send(m);
       

                using (var db = new TourBaseEntitiesDB())
                {
                    
                }
                    MessageBox.Show("Данные успешно сохранены и отправлены вам на почту");
            }
            
        }

        public static void databaseFilePut(string varFilePath)
        {
            byte[] file;
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
        }
        private void CBoxTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBoxHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
