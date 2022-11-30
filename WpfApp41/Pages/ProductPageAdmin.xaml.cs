using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp41.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPageAdmin.xaml
    /// </summary>
    public partial class ProductPageAdmin : Page
    {

        static public string modelUpd;
        static public string boattypeUpd;
        static public string NumberOfRowsUpd;
        static public string collorUpd;
        static public string woodUpd;
        static public string basepriceUpd;
        static public string VATUpd;
        static public string Tex3Upd;
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlDataAdapter dataAdapter;
        static public String Boat_ch;
        static public int Boat_c;
        public ProductPageAdmin()
        {
        
            InitializeComponent();
            com.Connection = con;
            com.CommandText = "Select * From Boat$";
            dataAdapter = new SqlDataAdapter(com);
            con.Open();
            dataAdapter.Fill(table);
            dataBoatAdmin.ItemsSource = table.DefaultView;
            con.Close();
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())
                {
                    Object boat_ID = reader["boat_ID"];
                    Boats.Items.Add(Convert.ToString(boat_ID));
                }
            }
            con.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boat_ch = Convert.ToString(Boats.SelectedItem);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Class1.MainFrame.Navigate(new ProductAdd());
        }

        private void Change_Click_1(object sender, RoutedEventArgs e)
        {
            Boat_c = Convert.ToInt32(Boats.SelectedItem);
            modelUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["Model"].ToString();
            boattypeUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["BoatType"].ToString();
            NumberOfRowsUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["NumberOfRowers"].ToString();
            collorUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["Colour"].ToString();
            woodUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["Wood"].ToString();
            basepriceUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["BasePrice"].ToString();
            VATUpd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["VAT"].ToString();
            Tex3Upd = ((DataRowView)dataBoatAdmin.SelectedItems[Boat_c]).Row["boat_ID"].ToString();
            Class1.MainFrame.Navigate(new UpdateChangePage());
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      
    }
}
