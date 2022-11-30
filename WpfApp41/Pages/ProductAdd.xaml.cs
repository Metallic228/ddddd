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
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Page
    {
        static public SqlCommand com = new SqlCommand();
        static public SqlConnection con = new SqlConnection(@"Data Source=JO4\SQLEXPRESS; Initial Catalog = Verph 2; Integrated Security=true;");
        SqlDataReader reader;
        string mast;
        public ProductAdd()
        {
            InitializeComponent();
            com.Connection = con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)Mast.SelectedItem;
            mast = ComboItem.Name;


            con.Open();
            if (!string.IsNullOrWhiteSpace(Model.Text) && !string.IsNullOrWhiteSpace(BoatType.Text) && !string.IsNullOrWhiteSpace(NumbersOfRows.Text) && !string.IsNullOrWhiteSpace(Mast.Text) && !string.IsNullOrWhiteSpace(Color.Text) && !string.IsNullOrWhiteSpace(Wood.Text) && !string.IsNullOrWhiteSpace(BasePrice.Text) && !string.IsNullOrWhiteSpace(VAT.Text))
            {
                try
                {
                    SqlCommand command = new SqlCommand("Insert Into Boat$ (Model, BoatType, NumberOfRowers, Mast, Colour, Wood, BasePrice, VAT)" + $"Values ('{Model.Text}','{BoatType.Text}','{NumbersOfRows.Text}','{ComboItem.Content}','{Color.Text}','{Wood.Text}','{BasePrice.Text}','{VAT.Text}')", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!", "Поздравляю!");
                    com.CommandText = "Select * From Boat$";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    con.Close();
                    Class1.MainFrame.Navigate(new AdminPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message , "Проверьте данные");
                    con.Close();
                }
            }
        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BoatType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NumbersOfRows_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Mast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Color_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Wood_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VAT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
