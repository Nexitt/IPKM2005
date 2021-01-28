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

            OleDbDataAdapter da = new OleDbDataAdapter("select Valve_numbers.Number from Valve_numbers", con);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);

            DataSet ds = new DataSet();
            da.Fill(ds, "Valve_numbers");

            MainGrid.ItemsSource = ds.Tables["Valve_numbers"].DefaultView;
            con.Close();

        }
    }
}
