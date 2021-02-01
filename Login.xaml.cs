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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Captcha();
        }

        private void UpdateCaptcha(object sender, RoutedEventArgs e)
        {
            Captcha();
        }
        
        public void Captcha()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {

                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            //CaptchaLabel.FontFamily = new System.Windows.Media.FontFamily("Curlz MT");
            
            CaptchaLabel.Content = pwd;
        }
        private void SignIn(object sender, RoutedEventArgs e)
        {
            var lg = logintext.Text.Trim();
            var pw = passwordtext.Password.Trim();
            var cp = captcha.Text.Trim();
            if (string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин, пароль, капча не введены, повторите попытку!");
                return;
            }
            if (string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && !string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин не введен, повторите попытку!");
                return;
            }
            if (string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин и пароль не введены, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Логин и капча не введены, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && string.IsNullOrEmpty(cp) && !string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Капча не введена, повторите попытку!");
                return;
            }
            if (!string.IsNullOrEmpty(lg) && !string.IsNullOrEmpty(cp) && string.IsNullOrEmpty(pw))
            {
                Captcha();
                MessageBox.Show("Пароль не введен, повторите попытку!");
                return;
            }

            using (var db = new TourBaseEntitiesDB()) 
            {
                var res = from Users in db.Users where Users.login == logintext.Text && Users.password == passwordtext.Password select Users;
                if (res.Count() == 1 && captcha.Text == CaptchaLabel.Content.ToString())
                {
                    Menu mn = new Menu();
                    switch (res.First().Role)
                    { 
                        case "Client":
                            WhatTheRole.role = Role.Client;
                            mn.Visibility = Visibility.Visible;
                            break;
                        case "Admin":
                            WhatTheRole.role = Role.Admin;
                            mn.TicketTake.Visibility = Visibility.Collapsed;
                            mn.Visibility = Visibility.Visible;
                            this.Close();
                            break;
                        case "Manager":
                            WhatTheRole.role = Role.Manager;
                            mn.Visibility = Visibility.Visible;
                            this.Close();
                            break;

                    }
                    
                }
                else if (res.Count() == 1 && captcha.Text != CaptchaLabel.Content.ToString())
                {
                    Captcha();
                    MessageBox.Show("Капча введена не правильно\nПовторите попытку!");
                    return;

                }
                else
                {
                    Captcha();
                    MessageBox.Show("Логин или пароль введены не правильно!\nПовторите попытку!");
                    return;
                }
            }
            
        }


        private void SignUP(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Visibility = Visibility.Visible;
            this.Close();
        }


    }
}
