using System;
using System.Windows.Forms;
using NivelAccesDate;
using LibrarieModele;
using InterfataUtilizator;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DotNetOracle
{
    public partial class Form1 : Form
    {
        private const bool SUCCESS = true;

        private IStocareUtilizatori stocareUtilizatori;
        private IStocareActivitati stocareActivitati;

        public Form1()
        {
            InitializeComponent();

            // Initialize storage objects
            InitializeStorage();
        }

        private void InitializeStorage()
        {
            // Initialize storage for Utilizator objects
            stocareUtilizatori = (IStocareUtilizatori)new StocareFactory().GetTipStocare(typeof(Utilizator));
            if (stocareUtilizatori == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii utilizatorilor");
            }

            // Initialize storage for Activitate objects
            stocareActivitati = (IStocareActivitati)new StocareFactory().GetTipStocare(typeof(Activitate));
            if (stocareActivitati == null)
            {
                MessageBox.Show("Eroare la initializare a stocarii activitatilor");
            }
        }

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

            // Remove the ID from the constructor call
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

    private void button2_Click(object sender, EventArgs e)
        {
            try
            {
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
            // Validate input for Activitate
            int idActivitate; // Nu mai este necesar să citim ID-ul de la utilizator
            if (!int.TryParse(textBox9.Text, out idActivitate))
            {
                MessageBox.Show("ID-ul activității trebuie să fie un număr întreg.");
                return null;
            }

            int durataActivitate;
            if (!int.TryParse(textBox12.Text, out durataActivitate))
            {
                MessageBox.Show("Durata activității trebuie să fie un număr întreg.");
                return null;
            }

            return new Activitate(
                textBox10.Text, // Numele activității
                textBox11.Text, // Descrierea activității
                durataActivitate
            );
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load any necessary data or configurations
        }
    }
}