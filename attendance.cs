using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;

namespace TimeTracker
{
    public partial class attendance : Form
    {
        public static string connectionString = "Server=localhost;Database=timetracker;User ID=root;Password=;";
        MySqlConnection connection = new MySqlConnection(connectionString);
        public attendance()
        {
            InitializeComponent();
            textBox86.Text = "https://" + GetWiFiIPAddress();
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            
            connection.Open();
            try
            {   
                Console.WriteLine("Connection successful!");

                string query = "SELECT student_id, name, college, time_in, time_out FROM attendance_info";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
        public static string GetWiFiIPAddress()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && ni.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
            return null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox86.Text = "https://" + GetWiFiIPAddress();
        }
    }
}
