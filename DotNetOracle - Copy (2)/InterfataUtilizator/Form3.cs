using Oracle.DataAccess.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetOracle
{
    public partial class Form3 : Form
    {

        private string nume;
        private string prenume;
        private string email;
        private string inaltime;
        private DateTime? dataNasterii;
        private string numarKG;
        private string indexMasaMusculara;

        public Form3(string nume, string prenume, string email, string inaltime, DateTime? dataNasterii, string numarKG, string indexMasaMusculara)
        {
            InitializeComponent();

            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.inaltime = inaltime;
            this.dataNasterii = dataNasterii;
            this.numarKG = numarKG;
            this.indexMasaMusculara = indexMasaMusculara;

            // Populate the form fields with the user data
            textBox1.Text = nume;
            textBox2.Text = prenume;
            textBox3.Text = email;
            textBox4.Text = inaltime;
            if (dataNasterii.HasValue)
            {
                textBox5.Text = dataNasterii.Value.ToString("dd/MM/yyyy");
            }
            textBox6.Text = numarKG;
            textBox7.Text = indexMasaMusculara;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string updatedNume = textBox1.Text;
            string updatedPrenume = textBox2.Text;
            string updatedEmail = textBox3.Text;
            string updatedInaltime = textBox4.Text;
            DateTime? updatedDataNasterii;

            // Parse the date input from the TextBox
            if (!DateTime.TryParseExact(textBox5.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime temp))
            {
                MessageBox.Show("Data de nastere invalida. Va rugam introduceti o data valida in formatul dd/MM/yyyy.");
                return;
            }
            updatedDataNasterii = temp;

            string updatedNumarKG = textBox6.Text;
            string updatedIndexMasaMusculara = textBox7.Text;

            string connectionString = "Data Source=localhost:1521;User Id=system;Password=admin;"; // Replace with your actual connection string

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = @"UPDATE Utilizatori 
                         SET Nume = :Nume, Prenume = :Prenume, Email = :Email, Inaltime = :Inaltime, 
                             DataNasterii = :DataNasterii, NumarKG = :NumarKG, IndexMasaMusculara = :IndexMasaMusculara 
                         WHERE Nume = :OldNume"; // Adjust query based on your table schema

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Nume", updatedNume));
                    command.Parameters.Add(new OracleParameter("Prenume", updatedPrenume));
                    command.Parameters.Add(new OracleParameter("Email", updatedEmail));
                    command.Parameters.Add(new OracleParameter("Inaltime", updatedInaltime));
                    command.Parameters.Add(new OracleParameter("DataNasterii", updatedDataNasterii));
                    command.Parameters.Add(new OracleParameter("NumarKG", updatedNumarKG));
                    command.Parameters.Add(new OracleParameter("IndexMasaMusculara", updatedIndexMasaMusculara));
                    command.Parameters.Add(new OracleParameter("OldNume", nume)); // Original name to find the correct record

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Update failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating data: " + ex.Message);
                    }
                }
            }
        }

    }
}
