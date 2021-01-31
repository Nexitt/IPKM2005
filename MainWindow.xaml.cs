using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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


namespace VesselApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\IPKM2005\VesselApp\IPKM2005DB.accdb");
            con.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Valve_numbers Запрос]", con);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "[Valve_numbers Запрос]");

            MainGrid.ItemsSource = ds.Tables["[Valve_numbers Запрос]"].DefaultView;
            con.Close();

            /*List<MainInfo> mainInfo = new List<MainInfo>();
            MainGrid.ItemsSource = mainInfo;*/


        }

        /*public class MainInfo
        {
            public int Id { get; set; }

            public string Number { get; set; }

            public ComboBox Status { get; set; }

            public string Product_name { get; set; }
            
            public string Type { get; set; }

            public string Vessel_name { get; set; }

            public string Reg_number { get; set; }

            public DateTime Plan_date { get; set; }

            public DateTime Fact_date { get; set; }

        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
