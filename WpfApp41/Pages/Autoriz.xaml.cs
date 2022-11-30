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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Threading;
namespace WpfApp41.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        DispatcherTimer time = new DispatcherTimer();
        int timec = 15;
        int g;
        public DateTime date1 = new DateTime();
        public string role;
        public string name;
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        
        SqlDataReader reader;
        
            public static string LoginIn;
        

        public Autoriz()
        {
            InitializeComponent();
            com.Connection = con;
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        private void Autoriz_Button_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login.Text, Password.Text);
     
        }
        public bool Auth(string login, string password)
        {
            bool ch = false;
            con.Open();
            com.CommandText = $"Select Role From Users Where Login='{login}' and Password ='{password}'";
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                con.Close();
                return false;
             
            }
            else
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Введите пароль");
                    con.Close();
                    return false;
                }
                else
                {
                    reader = com.ExecuteReader();
                    while (reader.Read()) { ch = true; Object Role = reader["Role"]; role = (Convert.ToString(Role)); }
                    con.Close();
                    if (ch == true)
                    {
                        if (role == "Admin")
                        {
                            con.Open();
                            SqlCommand com3 = new SqlCommand($"Select LastAutoriz from Users where Login='{login}'", con);
                            DateTime now = DateTime.Now;
                            DateTime then = (DateTime)com3.ExecuteScalar();
                            TimeSpan ts = now.Subtract(then);
                            double diff = ts.TotalDays;
                            if (diff >= 30)
                            {
                                MessageBox.Show("Вы не заходили в свой аккаунт более 30 дней, учётнай запись заблокирована, обратитесь к администратору.");
                                con.Close();
                            }
                            else
                            {
                                SqlCommand com4 = new SqlCommand($"Select LastChangePassword from Users where Login='{login}'", con);
                                DateTime then2 = (DateTime)com4.ExecuteScalar();
                                TimeSpan ts2 = now.Subtract(then2);
                                double diff2 = ts2.TotalDays;
                                if (diff2 >= 14)
                                {
                                    ChangePassword change = new ChangePassword();
                                    MessageBox.Show("Вы не меняли пароль более 14 дней");
                                    Class1.MainFrame.Navigate(new AdminPage());
                                    change.tex3.Text = login;
                                    change.ShowDialog();
                                    con.Close();

                                }
                                else
                                {
                                    SqlCommand command = new SqlCommand($"Update Users set LastAutoriz='{DateTime.Now}' Where Login='{login}'", con);
                                    MessageBox.Show("Добро пожаловать Адмнистратор");
                                    LoginIn = login;
                                    Class1.MainFrame.Navigate(new AdminPage());
                                    command.ExecuteNonQuery();
                                    con.Close();
                                    return true;

                                }
                                return false;

                            }
                            return false;
                        }


                        else
                        {
                            con.Open();
                            SqlCommand com3 = new SqlCommand($"Select LastAutoriz from Users where Login='{login}'", con);
                            DateTime now = DateTime.Now;
                            DateTime then = (DateTime)com3.ExecuteScalar();
                            TimeSpan ts = now.Subtract(then);
                            double diff = ts.TotalDays;

                            if (diff >= 30)
                            {
                                MessageBox.Show("Вы не заходили в свой аккаунт более 30 дней, учётнай запись заблокирована");
                                con.Close();
                                

                            }
                            else
                            {
                                SqlCommand com4 = new SqlCommand($"Select LastChangePassword from Users where Login='{login}'", con);
                                DateTime then2 = (DateTime)com4.ExecuteScalar();
                                TimeSpan ts2 = now.Subtract(then2);
                                double diff2 = ts2.TotalDays;
                                if (diff2 >= 14)
                                {
                                    ChangePassword change = new ChangePassword();
                                    MessageBox.Show("Вы не меняли пароль более 14 дней");
                                    Class1.MainFrame.Navigate(new DataPage());
                                    change.tex3.Text = login;
                                    change.ShowDialog();
                                    con.Close();
                                    
                                }

                                else
                                {
                                    LoginIn = login;
                                    SqlCommand command = new SqlCommand($"Update Users set LastAutoriz='{DateTime.Now}' Where Login='{login}'", con);
                                    MessageBox.Show("Добро пожаловать Пользователь");
                                    LoginIn = login;
                                    Class1.MainFrame.Navigate(new DataPage());
                                    command.ExecuteNonQuery();
                                    con.Close();
                                    
                                }
                            }
                        }
                    }

                    else if (ch == false)
                    {
                        g = g + 1;
                        if (g == 4)
                        {
                            MessageBox.Show("Неправельные данные введены 4 раза");
                            con.Close();
                            Autoriz_Button.IsEnabled = false;
                            time.Tick += new EventHandler(time_Tick);
                            time.Interval = TimeSpan.FromSeconds(timec);
                            time.Start();
                            timec += 10;                  
                        }
                        MessageBox.Show("Данный введены неправильно");
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        private void time_Tick(object sender, EventArgs e)
        {
            Autoriz_Button.IsEnabled = true;
            g = 0;
        }
        private void Regis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class1.MainFrame.Navigate(new RegPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
