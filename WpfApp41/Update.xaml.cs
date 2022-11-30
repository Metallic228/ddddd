using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using WpfApp41.Pages;

namespace WpfApp41
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        public Update()
        {
            InitializeComponent();
            com.Connection = con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)UserType.SelectedItem;
                string usertype = Convert.ToString(ComboItem.Content);

                if (!string.IsNullOrWhiteSpace(UpdLogin.Text) && !string.IsNullOrWhiteSpace(UpdPassword.Text ) && !string.IsNullOrWhiteSpace((string)ComboItem.Content))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand($"Update Users set Login='{UpdLogin.Text}', Password='{UpdPassword.Text}', Role='{usertype}', LastChangePassword='{DateTime.Now}' where Login='{tex3.Text}'", con);
                    command.ExecuteNonQuery();
                  
                    MessageBox.Show("Запись успешно Обновлена!", "Поздравляю!");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    com.CommandText = "Select * From User";
                    dataAdapter = new SqlDataAdapter(com);
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Все текстовые поля должны быть заполнены", "Ошибка!");
                }
                con.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
           
        }

        private void UpdLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tex3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
