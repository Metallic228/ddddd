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
using System.Windows.Shapes;



namespace WpfApp41
{
    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand($"Update Users set Password='{UpdPassword.Text}', LastChangePassword='{DateTime.Now}' where Login='{tex3.Text}'", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно Обновлена!", "Поздравляю!");
                SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                con.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tex3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
