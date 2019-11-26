using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Software_Engin_Project
{
    public partial class BedsideMonitoring : Form
    {
        public static string pulse;
        public static void ThreadProc()
        {
            for (int i = 0; i < 999999; i++)
            {
                
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }
        public BedsideMonitoring()
        {
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
            InitializeComponent();
            if (RunningData.beds[Constants.currentBed].currentPatient == null)
            {
                Namelabel.Text = "No Patient";
                return;
            }
            else
            {

                string FirstName = RunningData.beds[Constants.currentBed].currentPatient.Firstname;
                string LastName = RunningData.beds[Constants.currentBed].currentPatient.LastName;
                Namelabel.Text =   FirstName + LastName;

                string pulse = RunningData.beds[Constants.currentBed].currentPatient.Pulse.ToString("00.00");
                PulseText.Text = pulse;
                string breath = RunningData.beds[Constants.currentBed].currentPatient.Breathing.ToString("00.00");
                BreathingText.Text = breath;
                string temp = RunningData.beds[Constants.currentBed].currentPatient.Temp.ToString("00.00");
                TempText.Text = temp;
                string blood = RunningData.beds[Constants.currentBed].currentPatient.Blood.ToString("00.00");
                Bloodtext.Text = blood;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            BedOverview bed = new BedOverview();

            bed.Show();
        }

        private void BedsideMonitoring_Load(object sender, EventArgs e)
        {
            
        }
           

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BreathingText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }
    }
}
