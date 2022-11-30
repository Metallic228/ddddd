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
    /// Логика взаимодействия для UpdateChange.xaml
    /// </summary>
    public partial class UpdateChange : Window
    {
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        public UpdateChange()
        {
            InitializeComponent();
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
                    MessageBox.Show("Запись успешно Обновлена!", "Поздравляю!");
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    con.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Все текстовые поля должны быть заполнены", "Ошибка!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Проверьте данные");
            }
               
           
        }
        private void Tex3_TextChanged(object sender, TextChangedEventArgs e)
        {

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

