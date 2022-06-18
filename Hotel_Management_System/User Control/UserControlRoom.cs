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
    public partial class UserControlRoom : UserControl
    {

        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;

        private string ID = "";

        public void Clear()
        {
            comboBoxHotel.SelectedIndex = -1;
        }
        public UserControlRoom()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearchRoom_Click(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex == -1)
                MessageBox.Show("Please fill out all fields", "Require all field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dt = new DataTable();
                cmd = new n.NpgsqlCommand();
                cmd.Connection = cnx;
               // cmd.CommandText = "SELECT * FROM public.clients";
               // ada = new n.NpgsqlDataAdapter(cmd);
               // ada.Fill(dt);
               // dataGridViewUser.DataSource = dt;
               if(comboBoxHotel.Text == "Tanger")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 1;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Casablanca")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 2;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Khouribga")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 3;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Marrakech")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 4;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Errachidia")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 5;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }else if (comboBoxHotel.Text == "Tetouan")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 6;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Essaouira")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 7;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
                else if (comboBoxHotel.Text == "Rabat")
                {
                    cmd.CommandText = "SELECT idroom, phoneroom, categories.cat, hotels.namehotel , freeroom FROM public.rooms JOIN public.hotels ON rooms.idhotel = hotels.idhotel JOIN public.categories ON rooms.idcat = categories.idcat  WHERE rooms.idhotel = 8;";
                    ada = new n.NpgsqlDataAdapter(cmd);
                    ada.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                }
            }


        }

        private void UserControlRoom_Load(object sender, EventArgs e)
        {
            cnx.Open();
        }

        private void dataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPageHotel_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * from public.hotels";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewHotels.DataSource = dt;

        }

        private void tabPagecat_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * from public.categories";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewCat.DataSource = dt;
        }
    }
}
