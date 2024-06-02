using Oracle.DataAccess.Client;

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class FormAfisare : Form
    {
        public FormAfisare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetrieveUtilizatoriData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetrieveActivitatiData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RetrieveJurnalActivitatiData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RetrieveObiectiveUtilizatorData();
        }

        private void RetrieveUtilizatoriData()
        {
            string query = "SELECT * FROM Utilizatori";
            RetrieveData(query);
        }

        private void RetrieveActivitatiData()
        {
            string query = "SELECT * FROM Activitati";
            RetrieveData(query);
        }

        private void RetrieveJurnalActivitatiData()
        {
            string query = "SELECT * FROM JurnalActivitati";
            RetrieveData(query);
        }

        private void RetrieveObiectiveUtilizatorData()
        {
            string query = "SELECT * FROM ObiectiveUtilizator";
            RetrieveData(query);
        }

        private void RetrieveData(string query)
        {
            string connectionString = "Data Source=localhost:1521;User Id=system;Password=admin;"; // Replace with your actual connection string

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving data: " + ex.Message);
                    }
                }
            }
        }
    }
}
