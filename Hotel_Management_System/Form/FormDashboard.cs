using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class FormDashboard : Form
    {

        public String Username;

        public FormDashboard()
        {
            InitializeComponent();
        }


        public void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelUsername.Text = Username;
            userControlDashboard1.Show();

        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to Logout ?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                timer1.Stop();
                this.Close();
            }



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            MovePanel(buttonDashboard);
            userControlSetting1.Hide();
            userControlClient1.Hide();
            userControlRoom1.Hide();
            userControlBill1.Hide();
            userControlReservation1.Hide();
            userControlReservation1.Visible = false;
            userControlDashboard1.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            MovePanel(buttonClient);
            userControlDashboard1.Hide();
            userControlRoom1.Hide();
            userControlSetting1.Hide();
            userControlBill1.Hide();
            userControlReservation1.Hide();
            userControlClient1.Clear();
            userControlClient1.Show();
            

        }

        private void buttonRoom_Click(object sender, EventArgs e)
        {
            MovePanel(buttonRoom);
            userControlSetting1.Hide();
            userControlClient1.Hide();
            userControlReservation1.Hide();
            userControlDashboard1.Hide();
            userControlBill1.Hide();
            userControlRoom1.Clear();
            userControlRoom1.Show();
        }

        private void buttonReservation_Click(object sender, EventArgs e)
        {
            MovePanel(buttonReservation);
            userControlSetting1.Hide();
            userControlClient1.Hide();
            userControlRoom1.Hide();
            userControlBill1.Hide();
            userControlDashboard1.Hide();
            userControlReservation1.Clear();
            userControlReservation1.Show();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            MovePanel(buttonSetting);
            userControlRoom1.Hide();
            userControlClient1.Hide();
            userControlBill1.Hide();
            userControlReservation1.Hide();
            userControlDashboard1.Hide();
            userControlSetting1.Clear();
            userControlSetting1.Show();
            

        }

        private void buttonFacture_Click(object sender, EventArgs e)
        {
            MovePanel(buttonFacture);
            userControlRoom1.Hide();
            userControlClient1.Hide();
            userControlReservation1.Hide();
            userControlDashboard1.Hide();
            userControlSetting1.Hide();
            userControlBill1.Clear();
            userControlBill1.Show();

        }
    }
}
