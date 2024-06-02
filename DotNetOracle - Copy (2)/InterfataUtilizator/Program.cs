using DotNetOracle;

using System;
using System.Windows.Forms;

namespace InterfataUtilizator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CustomApplicationContext());
        }
    }

    public class CustomApplicationContext : ApplicationContext
    {
        private Form2 form2;
        private FormAfisare formAfisare;

        public CustomApplicationContext()
        {
            form2 = new Form2();
            form2.FormClosed += OnForm2Closed;
            form2.Show();
        }

        private void OnForm2Closed(object sender, FormClosedEventArgs e)
        {
            formAfisare = new FormAfisare();
            formAfisare.FormClosed += OnFormAfisareClosed;
            formAfisare.Show();
        }

        private void OnFormAfisareClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }
    }
}
