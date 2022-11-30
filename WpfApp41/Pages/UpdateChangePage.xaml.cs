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
    /// Логика взаимодействия для UpdateChangePage.xaml
    /// </summary>
    public partial class UpdateChangePage : Page
    {
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        public UpdateChangePage()
        {
            InitializeComponent();
            Model.Text = ProductPageAdmin.modelUpd;
            BoatType.Text = ProductPageAdmin.boattypeUpd;
            NumbersOfRows.Text = ProductPageAdmin.NumberOfRowsUpd;
            Color.Text = ProductPageAdmin.collorUpd;
            Model.Text = ProductPageAdmin.modelUpd;
            Wood.Text = ProductPageAdmin.woodUpd;
            BasePrice.Text = ProductPageAdmin.basepriceUpd;
            VAT.Text = ProductPageAdmin.VATUpd;
            Tex3.Text = ProductPageAdmin.Tex3Upd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)Mast.SelectedItem;
                string mast = Convert.ToString(ComboItem.Content);

                if (!string.IsNullOrWhiteSpace(Model.Text) && !string.IsNullOrWhiteSpace(BoatType.Text) && !string.IsNullOrWhiteSpace(NumbersOfRows.Text) && !string.IsNullOrWhiteSpace((string)ComboItem.Content) && !string.IsNullOrWhiteSpace(Color.Text) && !string.IsNullOrWhiteSpace(Wood.Text) && !string.IsNullOrWhiteSpace(BasePrice.Text) && !string.IsNullOrWhiteSpace(VAT.Text))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand($"Update Boat$ set Model='{Model.Text}', BoatType='{BoatType.Text}', NumberOfRowers='{NumbersOfRows.Text}', Mast='{mast}', Colour='{Color.Text}', Wood='{Wood.Text}', BasePrice='{BasePrice.Text}', VAT='{VAT.Text}' where boat_ID='{Tex3.Text}'", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно обновлена!", "Поздравляю!");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    com.CommandText = "Select * From Boat$";
                    dataAdapter = new SqlDataAdapter(com);
                    con.Close();
                    Class1.MainFrame.Navigate(new ProductPageAdmin());

                }
                else
                {
                    MessageBox.Show("Все текстовые поля должны быть заполнены", "Ошибка!");
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void VAT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Wood_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Color_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Mast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NumbersOfRows_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BoatType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Model_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tex3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
