using System;
using System.Collections.Generic;
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
        public string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Nexitt\Desktop\IPKM2005\IPKM2005DB\IPKM2005DB.accdb"; // путь к базе данных
        public OleDbDataReader Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            OleDbConnection connect = new OleDbConnection(connection); // подключаемся к базе данных
            connect.Open(); // открываем базу данных

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect); // создаём запрос
            OleDbDataReader reader = cmd.ExecuteReader(); // получаем данные

            return reader; // возвращаем
        }



        public MainWindow()
        {
            InitializeComponent();
            OleDbDataReader read = Select("SELECT * FROM Users"); // запрашиваем данные
            while (read.Read())
            { // обрабатываем данные
                MessageBox.Show("Код: " + read.GetValue(0) + " Логин: " + read.GetValue(1) + " Пароль: " + read.GetValue(2)); // выводим данные
            }
        }
    }
}
