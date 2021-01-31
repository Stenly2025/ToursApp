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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void backBtn(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Visibility = Visibility.Visible;
            this.Close();
        }

        private void saveBtn(object sender, RoutedEventArgs e)
        {
            var lg = loginn.Text;
            var pw = password.Password;
            using (var db = new TourBaseEntitiesDB())
            {
                StringBuilder errors = new StringBuilder();
                var p = db.Users.Any(l => l.login == loginn.Text);


                if (pw.Length < 6 || pw.Length > 20)
                    errors.AppendLine("Длина пароля должна состоять от 6 до 20 символов");
                if (!pw.Any(char.IsUpper))
                    errors.AppendLine("Пароль должен содержать хотя бы одну заглавную букву");
                if (!pw.Any(char.IsDigit))
                    errors.AppendLine("Пароль должен содержать хотя бы одну цифру");
                if (pw.Intersect("!@#$%^").Count() == 0)
                    errors.AppendLine("Пароль должен содержать хотя бы один символ из набора  '!@#$%^'");
                if (String.IsNullOrEmpty(lg))
                    errors.AppendLine("Логин не введен, повторите попытку");
                if (String.IsNullOrEmpty(pw))
                    errors.AppendLine("Пароль не введен, повторите попытку");
                if (password.Password != repeatpassword.Password)
                    errors.AppendLine("Пароли не совпадают, повторите попытку!");
                if (p == true)
                    errors.AppendLine("Пользователь с таким логином уже существует, придумайте другой.");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                else
                {
                    Users user = new Users
                    {
                        login = loginn.Text,
                        password = password.Password,
                        name = name.Text,
                        surname = surname.Text,
                        Role = "Simple_user",
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Аккаунт успешно создан!");

                    Login login = new Login();
                    login.Visibility = Visibility.Visible;
                    this.Close();
                }
            }








        }
    }
}
