using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using n = Npgsql;

namespace Hotel_Management_System.User_Control
{
    public partial class UserControlDashboard : UserControl
    {
        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;
        public UserControlDashboard()
        {
            InitializeComponent();
        }

        public void FreeRooms(int idhotel)
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT COUNT(*) FROM public.rooms WHERE freeroom='YES' AND idhotel ="+idhotel+";";
            string result = cmd.ExecuteScalar().ToString();
            labelFreeRoom.Text = result;
        }

        public void ReservedRooms(int idhotel)
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT COUNT(*) FROM public.rooms WHERE freeroom='NO' AND idhotel =" + idhotel + ";";
            var firstColumn = cmd.ExecuteScalar();

                string result = firstColumn.ToString();
                Console.WriteLine(result);
            labelRooms.Text = result;

        }
        public void FreeRooms1()
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT COUNT(*) FROM public.rooms WHERE freeroom='YES';";
            string result = cmd.ExecuteScalar().ToString();
            labelFreeRoom.Text = result;
        }

        public void ReservedRooms1()
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT COUNT(*) FROM public.rooms WHERE freeroom='NO';";
            string result = cmd.ExecuteScalar().ToString();
            labelRooms.Text = result;
        }

        public void Clients()
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT COUNT(*) FROM public.clients";
            string result = cmd.ExecuteScalar().ToString();
            labelClientCount.Text = result;
        }

        private void UserControlDashboard_Load(object sender, EventArgs e)
        {
            cnx.Open();
            FreeRooms1();
            ReservedRooms1();
            Clients();
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSearchRoom_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.Text == "Tanger")
            {
                ReservedRooms(1);
                FreeRooms(1);
                
                Clients();
            }
            else if (comboBoxHotel.Text == "Casablanca")
            {
                FreeRooms(2);
                ReservedRooms(2);
                Clients();

            }
            else if (comboBoxHotel.Text == "Khouribga")
            {
                FreeRooms(3);
                ReservedRooms(3);
                Clients();

            }
            else if (comboBoxHotel.Text == "Marrakech")
            {
                FreeRooms(4);
                ReservedRooms(4);
                Clients();

            }
            else if (comboBoxHotel.Text == "Errachidia")
            {
                FreeRooms(5);
                ReservedRooms(5);
                Clients();

            }
            else if (comboBoxHotel.Text == "Tetouan")
            {
                FreeRooms(6);
                ReservedRooms(6);
                Clients();

            }
            else if (comboBoxHotel.Text == "Essaouira")
            {
                FreeRooms(7);
                ReservedRooms(7);
                Clients();

            }
            else if (comboBoxHotel.Text == "Rabat")
                FreeRooms(8);
                ReservedRooms(8);
                Clients();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControlDashboard_Leave(object sender, EventArgs e)
        {
            FreeRooms1();
            ReservedRooms1();
            Clients();
        }
    }
    }

