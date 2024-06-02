using InterfataUtilizator;
using LibrarieModele;
using NivelAccesDate;
using Oracle.DataAccess.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DotNetOracle
{
    public partial class Form2 : Form
    {
        private const bool SUCCESS = true;

        private IStocareUtilizatori stocareUtilizatori;
        private IStocareActivitati stocareActivitati;
        private IStocareJurnalActivitati stocareJurnal;
        private IStocareObiectiveUtilizator stocareObiective;
        public Form2()
        {
            InitializeComponent();
            InitializeStorage();
        }

        private void InitializeStorage()
        {
            stocareUtilizatori = (IStocareUtilizatori)new StocareFactory().GetTipStocare(typeof(Utilizator));
            if (stocareUtilizatori == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii utilizatorilor");
            }

            stocareActivitati = (IStocareActivitati)new StocareFactory().GetTipStocare(typeof(Activitate));
            if (stocareActivitati == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii activitatilor");
            }

            stocareObiective = (IStocareObiectiveUtilizator)new StocareFactory().GetTipStocare(typeof(ObiectiveUtilizator));
            if (stocareObiective == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii obiectivelor");
            }

            stocareJurnal = (IStocareJurnalActivitati)new StocareFactory().GetTipStocare(typeof(JurnalActivitate));
            if (stocareJurnal == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii jurnalului de activitati");
            }
        }
        // de la utilizator
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input for Utilizator
                Utilizator utilizator = ValidateUtilizatorInput();
                if (utilizator == null)
                    return;

                // Add the Utilizator object to storage
                bool result = stocareUtilizatori.AddUtilizator(utilizator);
                if (result == SUCCESS)
                {
                    MessageBox.Show("Utilizator adaugat");
                }
                else
                {
                    MessageBox.Show("Eroare la adaugare utilizator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie: " + ex.Message);
            }
        }

        private Utilizator ValidateUtilizatorInput()
        {
            // Validate input for Utilizator
            DateTime? dateOfBirth = null;
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                if (!DateTime.TryParseExact(textBox4.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    MessageBox.Show("Data de nastere invalida. Va rugam introduceti o data valida in formatul dd/MM/yyyy.");
                    return null;
                }
                dateOfBirth = dob;
            }

            return new Utilizator(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox5.Text,
                dateOfBirth,
                string.IsNullOrEmpty(textBox6.Text) ? (int?)null : Convert.ToInt32(textBox6.Text),
                string.IsNullOrEmpty(textBox7.Text) ? (int?)null : Convert.ToInt32(textBox7.Text)
            );
        }



        // DE SCOS ID ACTIVITATE
        // de la activitate
    private void button2_Click(object sender, EventArgs e)
        {
            try{
                // Validate input for Activitate
                Activitate activitate = ValidateActivitateInput();
                if (activitate == null)
                    return;

                // Add the Activitate object to storage
                bool result = stocareActivitati.AddActivitate(activitate);
                if (result == SUCCESS)
                {
                    MessageBox.Show("Activitate adaugată.");
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea activității.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie: " + ex.Message);
            }
        }

        private Activitate ValidateActivitateInput()
        {
            int durataActivitate;
            if (!int.TryParse(textBox12.Text, out durataActivitate) || durataActivitate <= 0)
            {
                MessageBox.Show("Durata activității trebuie să fie un număr întreg pozitiv.");
                return null;
            }

            return new Activitate(
                textBox10.Text, // Numele activității
                textBox11.Text, // Descrierea activității
                durataActivitate
            );
        }


        // de la obiective utilizator
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input for ObiectivUtilizator
                ObiectiveUtilizator obiectiv = ValidateObiectivInput();
                if (obiectiv == null)
                    return;

                // Add the ObiectivUtilizator object to storage
                bool result = stocareObiective.AddObiectivUtilizator(obiectiv);
                if (result == SUCCESS)
                {
                    MessageBox.Show("Obiectiv adăugat.");
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea obiectivului.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie: " + ex.Message);
            }
        }

        private ObiectiveUtilizator ValidateObiectivInput()
        {
            // Validează inputul pentru ObiectivUtilizator
            int idUtilizator;
            if (!int.TryParse(textBox9.Text, out idUtilizator))
            {
                MessageBox.Show("Id-ul utilizatorului trebuie să fie un număr întreg pozitiv.");
                return null;
            }

            DateTime? dataStart = null;
            DateTime? dataEnd = null;
            if (!string.IsNullOrEmpty(textBox14.Text))
            {
                if (!DateTime.TryParseExact(textBox14.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime start))
                {
                    MessageBox.Show("Data de start invalidă. Vă rugăm introduceți o dată validă în formatul dd/MM/yyyy.");
                    return null;
                }
                dataStart = start;
            }
            if (!string.IsNullOrEmpty(textBox15.Text))
            {
                if (!DateTime.TryParseExact(textBox15.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime end))
                {
                    MessageBox.Show("Data de sfârșit invalidă. Vă rugăm introduceți o dată validă în formatul dd/MM/yyyy.");
                    return null;
                }
                dataEnd = end;
            }
            return new ObiectiveUtilizator(
                idUtilizator, // Setează id-ul utilizatorului curent
                textBox8.Text, // tipObiectiv
                textBox13.Text, // descriere
                dataStart,
                dataEnd
            );
        }
       

        // de la jurnal activitati
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input for JurnalActivitate
                JurnalActivitate jurnal = ValidateJurnalInput();
                if (jurnal == null)
                    return;

                // Add the JurnalActivitate object to storage
                bool result = stocareJurnal.AddJurnalActivitate(jurnal);
                if (result == SUCCESS)
                {
                    MessageBox.Show("Jurnal adăugat.");
                }
                else
                {
                    MessageBox.Show("Eroare la adăugarea jurnalului.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptie: " + ex.Message);
            }
        }

        private JurnalActivitate ValidateJurnalInput()
        {
            DateTime? data = null;
            if (!string.IsNullOrEmpty(textBox16.Text))
            {
                if (!DateTime.TryParseExact(textBox16.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataParsed))
                {
                    MessageBox.Show("Data invalidă. Vă rugăm introduceți o dată validă în formatul dd/MM/yyyy.");
                    return null;
                }
                data = dataParsed;
            }

            int durataActivitate;
            if (!int.TryParse(textBox17.Text, out durataActivitate) || durataActivitate <= 0)
            {
                MessageBox.Show("Durata activității trebuie să fie un număr întreg pozitiv.");
                return null;
            }

            decimal distanta;
            if (!decimal.TryParse(textBox18.Text, out distanta) || distanta <= 0)
            {
                MessageBox.Show("Distanța trebuie să fie un număr pozitiv.");
                return null;
            }

            int caloriiArse;
            if (!int.TryParse(textBox19.Text, out caloriiArse) || caloriiArse <= 0)
            {
                MessageBox.Show("Caloriile arse trebuie să fie un număr întreg pozitiv.");
                return null;
            }

            string email = textBox20.Text;

            return new JurnalActivitate
            {
                Data = data.Value,
                DurataActivitate = durataActivitate,
                Distanta = distanta,
                CaloriiArse = caloriiArse,
                Email = email,
                Bonus = JurnalActivitate.CalculateBonus(caloriiArse) // Calculăm bonusul aici
            };
        }
      

        private void button5_Click(object sender, EventArgs e)
        {
            string email = textBox21.Text;

            if (!string.IsNullOrEmpty(email))
            {
                // Create an instance of AdministrareUtilizatori
                AdministrareUtilizatori adminUtilizatori = new AdministrareUtilizatori();

                // Call the method on the instance
                bool deleted = adminUtilizatori.DeleteUtilizatorByEmail(email);

                if (deleted)
                {
                    MessageBox.Show("Utilizatorul a fost șters cu succes!");
                }
                else
                {
                    MessageBox.Show("Nu s-a putut efectua ștergerea utilizatorului.");
                }
            }
            else
            {
                MessageBox.Show("Introduceți un email valid pentru ștergere.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                string numeActivitate = textBox22.Text;

                if (!string.IsNullOrEmpty(numeActivitate))
                {
                    // Creăm o instanță a clasei AdministrareActivitati
                    AdministrareActivitati adminActivitati = new AdministrareActivitati();

                    // Apelăm metoda pentru ștergere
                    bool deleted = adminActivitati.DeleteActivitateByNume(numeActivitate);

                    if (deleted)
                    {
                        MessageBox.Show("Activitatea a fost ștearsă cu succes!");
                    }
                    else
                    {
                        MessageBox.Show("Nu s-a putut efectua ștergerea activității.");
                    }
                }
                else
                {
                    MessageBox.Show("Introduceți un nume de activitate valid pentru ștergere.");
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string tipObiectiv = textBox23.Text;

            if (!string.IsNullOrEmpty(tipObiectiv))
            {
                // Creăm o instanță a clasei AdministrareObiectiveUtilizator
                AdministrareObiectiveUtilizator adminObiective = new AdministrareObiectiveUtilizator();

                // Apelăm metoda pentru ștergere
                bool deleted = adminObiective.DeleteObiectivByTip(tipObiectiv);

                if (deleted)
                {
                    MessageBox.Show("Obiectivul a fost șters cu succes!");
                }
                else
                {
                    MessageBox.Show("Nu s-a putut efectua ștergerea obiectivului.");
                }
            }
            else
            {
                MessageBox.Show("Introduceți un tip de obiectiv valid pentru ștergere.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
{
    string userName = textBox24.Text; // Assume you have a TextBox named textBoxSearch for entering the user's name

    if (string.IsNullOrEmpty(userName))
    {
        MessageBox.Show("Please enter a user name to search.");
        return;
    }

    string connectionString = "Data Source=localhost:1521;User Id=system;Password=admin;"; // Replace with your actual connection string

    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        string query = "SELECT * FROM Utilizatori WHERE Nume = :Nume"; // Adjust query based on your table schema
        using (OracleCommand command = new OracleCommand(query, connection))
        {
            command.Parameters.Add(new OracleParameter("Nume", userName));

            try
            {
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow userRow = dataTable.Rows[0];

                    // Assuming you have columns Nume, Prenume, Email, etc.
                    string nume = userRow["Nume"].ToString();
                    string prenume = userRow["Prenume"].ToString();
                    string email = userRow["Email"].ToString();
                    string inaltime = userRow["Inaltime"].ToString();
                    DateTime dataNasterii = Convert.ToDateTime(userRow["DataNasterii"]);
                    string numarKG = userRow["NumarKG"].ToString();
                    string indexMasaMusculara = userRow["IndexMasaMusculara"].ToString();
                    // Add other columns as needed

                    // Pass data to Form3
                    Form3 form3 = new Form3(nume, prenume, email, inaltime, dataNasterii, numarKG, indexMasaMusculara); // Adjust constructor as needed
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }
    }
}

        private void button9_Click(object sender, EventArgs e)
        {
            string userFirstName = textBox25.Text; // Assume you have a TextBox named textBoxSearch for entering the user's first name

            if (string.IsNullOrEmpty(userFirstName))
            {
                MessageBox.Show("Please enter a user first name to search.");
                return;
            }

            string connectionString = "Data Source=localhost:1521;User Id=system;Password=admin;"; // Replace with your actual connection string

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = "SELECT * FROM Utilizatori WHERE Prenume = :Prenume"; // Adjust query based on your table schema
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("Prenume", userFirstName));

                    try
                    {
                        connection.Open();
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            DataRow userRow = dataTable.Rows[0];

                            // Assuming you have columns Nume, Prenume, Email, etc.
                            string nume = userRow["Nume"].ToString();
                            string prenume = userRow["Prenume"].ToString();
                            string email = userRow["Email"].ToString();
                            string inaltime = userRow["Inaltime"].ToString();
                            DateTime dataNasterii = Convert.ToDateTime(userRow["DataNasterii"]);
                            string numarKG = userRow["NumarKG"].ToString();
                            string indexMasaMusculara = userRow["IndexMasaMusculara"].ToString();
                            // Add other columns as needed

                            // Pass data to Form3
                            Form3 form3 = new Form3(nume, prenume, email, inaltime, dataNasterii, numarKG, indexMasaMusculara); // Adjust constructor as needed
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving data: " + ex.Message);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string dateOfBirthText = textBox26.Text; // Assume you have a TextBox named textBoxDateOfBirth for entering the user's date of birth
            DateTime userDateOfBirth;

            if (!DateTime.TryParse(dateOfBirthText, out userDateOfBirth))
            {
                MessageBox.Show("Invalid date format. Please enter date in dd/MM/yyyy format.");
                return;
            }

            string connectionString = "Data Source=localhost:1521;User Id=system;Password=admin;"; // Replace with your actual connection string

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string query = "SELECT * FROM Utilizatori WHERE DataNasterii = :DataNasterii"; // Adjust query based on your table schema
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("DataNasterii", userDateOfBirth));

                    try
                    {
                        connection.Open();
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            DataRow userRow = dataTable.Rows[0];

                            // Assuming you have columns Nume, Prenume, Email, etc.
                            string nume = userRow["Nume"].ToString();
                            string prenume = userRow["Prenume"].ToString();
                            string email = userRow["Email"].ToString();
                            string inaltime = userRow["Inaltime"].ToString();
                            DateTime dataNasterii = Convert.ToDateTime(userRow["DataNasterii"]);
                            string numarKG = userRow["NumarKG"].ToString();
                            string indexMasaMusculara = userRow["IndexMasaMusculara"].ToString();
                            // Add other columns as needed

                            // Pass data to Form3
                            Form3 form3 = new Form3(nume, prenume, email, inaltime, dataNasterii, numarKG, indexMasaMusculara); // Adjust constructor as needed
                            form3.Show();
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving data: " + ex.Message);
                    }
                }
            }
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            FormAfisare formAfisare = new FormAfisare();
            formAfisare.Show();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // Load any necessary data or configurations
        }

        





        /*  private void textBox3_Validating(object sender, CancelEventArgs e)
          {
              string email = textBox3.Text.Trim();
              Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

              if (!regex.IsMatch(email))
              {
                  errorProvider1.SetError(textBox3, "Adresa de email nu este validă.");
                  e.Cancel = true;
                  Console.WriteLine("Adresa de email introdusă este: " + email);

              }
              else
              {
                  errorProvider1.SetError(textBox3, "");
                  e.Cancel = false;
              }*/
    }

}
