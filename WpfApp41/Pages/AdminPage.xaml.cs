using System;
using System.Collections.Generic;
using System.Data;
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
namespace WpfApp41.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
       
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        public static string loginUpd;
        public static string passwordUpd;
        DataTable table = new DataTable();
        SqlDataAdapter dataAdapter;
        static public String log_ch;
        static public int log_c;
        public AdminPage()
        {
            InitializeComponent();
            com.Connection = con;
            com.CommandText = "Select * From Users";
            dataAdapter = new SqlDataAdapter(com);
            con.Open();
            dataAdapter.Fill(table);
            dataUser.ItemsSource = table.DefaultView;
            con.Close();
            texU.Text = Autoriz.LoginIn;


            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    Object Login = reader["Login"];
                    Users.Items.Add(Convert.ToString(Login));
                }
            }
            con.Close();
        }  

        private void DataUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            log_ch = Convert.ToString(Users.SelectedItem);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new Add());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand com2 = new SqlCommand();
            com2.Connection = con;
            com2.CommandText = "Select Login From Users";
            var da = new SqlDataAdapter(com2);
            da.Fill(dt);
            string str = dt.DefaultView[dataUser.SelectedIndex]["Login"].ToString();
            dataUser.ItemsSource = null;
            dataUser.Items.Clear();
            DataTable table1 = new DataTable();
            com.CommandText = $"Delete Users Where Login='{str}' Select Login,Password,Role,LastAutoriz,LastChangePassword from Users";
            dataAdapter.Fill(table1);
            dataUser.ItemsSource = table1.DefaultView;
            con.Close();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                log_c = Convert.ToInt32(Users.SelectedItem);
               
                loginUpd = ((DataRowView)dataUser.SelectedItems[log_c]).Row["Login"].ToString();
                passwordUpd = ((DataRowView)dataUser.SelectedItems[log_c]).Row["Password"].ToString();
                Class1.MainFrame.Navigate(new UpdatePage());


            }
            catch 
            {
                MessageBox.Show("Выберите строку");
            }
           
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new ProductPageAdmin());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
