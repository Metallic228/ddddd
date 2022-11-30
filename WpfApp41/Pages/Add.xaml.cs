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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        static public SqlCommand com = new SqlCommand();
        static public SqlConnection con = new SqlConnection(@"Data Source=JO4\SQLEXPRESS; Initial Catalog = Verph 2; Integrated Security=true;");
        SqlDataReader reader;
        string usertype;
        public Add()
        {
            InitializeComponent();
            com.Connection = con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)UserType.SelectedItem;
            usertype = ComboItem.Name;


            con.Open();
            if (!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrWhiteSpace(Login.Text) && !string.IsNullOrEmpty(Password.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                try
                {
                    SqlCommand command = new SqlCommand("Insert Into Users (Login, Password, Role)" + $"Values ('{Login.Text}','{Password.Text}','{ComboItem.Content}')", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!", "Поздравляю!");
                    com.CommandText = "Select * From User";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    con.Close();
                    Class1.MainFrame.Navigate(new AdminPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Возможно пользователь с таким именем уже есть или перепроверьте введённые данные", "Проверьте данные");
                    con.Close();
                }
            }
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
