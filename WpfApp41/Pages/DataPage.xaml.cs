using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;



namespace WpfApp41.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        static public SqlConnection con = new SqlConnection(@"Data Source = JO4\SQLEXPRESS;Initial Catalog=Verph 2;Integrated Security=true");
        static public SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        DataTable table = new DataTable();
        SqlDataAdapter dataAdapter;
        
        private BaseFont helveticaBase;
        public DataPage()
        {
            InitializeComponent();
            com.Connection = con;
            tex1.Text = Autoriz.LoginIn;
            com.CommandText = "Select * From Boat$";
            dataAdapter = new SqlDataAdapter(com);
            con.Open();
            dataAdapter.Fill(table);
            dataBoat.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void DataBoat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PasswordChange_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword Change = new ChangePassword();
            Change.tex3.Text = tex1.Text;
            Change.ShowDialog();
        }

        private void Tex1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                var document = new Document();
                helveticaBase = BaseFont.CreateFont(@"..\..\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                using (var writer = PdfWriter.GetInstance(document, new FileStream("Certificate.pdf", FileMode.Create)))
                {
                    document.Open();

                    writer.DirectContent.BeginText();
                    writer.DirectContent.SetFontAndSize(helveticaBase, 12f);
                    writer.DirectContent.ShowTextAligned(Element.ALIGN_LEFT, "Сертификат выдан " + tex1.Text , 100, 766, 90);
                    writer.DirectContent.ShowTextAligned(Element.ALIGN_CENTER, "Данный сертификат подтверждает мою возможность создавать pdf файлы", 228, 740, 0);

                    writer.DirectContent.EndText();

                    MessageBox.Show("Сетификат успешно создан");

                    document.Close();
                    writer.Close();

                    Process.Start("Certificate.pdf");
                }
            
           
        }
    }
}