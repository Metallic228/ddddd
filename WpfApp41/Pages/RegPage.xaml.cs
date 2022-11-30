using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp41.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        static public SqlCommand com = new SqlCommand();
        static public SqlConnection con = new SqlConnection(@"Data Source=JO4\SQLEXPRESS; Initial Catalog = Verph 2; Integrated Security=true;");
        SqlDataReader reader;
        public string log;

        public RegPage()
        {
            InitializeComponent();
            com.Connection = con;
               
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            if (!string.IsNullOrEmpty(RegLogin.Text) && !string.IsNullOrWhiteSpace(RegLogin.Text) && !string.IsNullOrEmpty(RegPassword.Text) && !string.IsNullOrWhiteSpace(RegPassword.Text))
            {
               try
               {
                   
                   SqlCommand command = new SqlCommand("Insert Into Users (Login, Password)" + $"Values ('{RegLogin.Text}','{RegPassword.Text}')", con);
                   command.ExecuteNonQuery();
                   MessageBox.Show("Запись успешно добавлена!", "Поздравляю!");
                   com.CommandText = "Select * From User";
                   SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                   con.Close();
                   Class1.MainFrame.Navigate(new Autoriz());
                }
               catch 
               {
                   MessageBox.Show("Пользователь с таким логином уже есть" , "Error!");
                   con.Close();
               }
            }
        }

        private void RegLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RegPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
