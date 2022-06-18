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
    public partial class UserControlReservation : UserControl
    {


        private string RID = "", No;
        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;

        n.NpgsqlConnection cnx1 = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd1;
        n.NpgsqlDataAdapter ada1;
        DataTable dt1;
        public UserControlReservation()
        {
            InitializeComponent();
        }

        public void FreeRoom()
        {
            
            
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd1 = new n.NpgsqlCommand();
            cmd1.Connection = cnx;
            cmd.CommandText = "SELECT idroom FROM public.reservation WHERE dateout<= CURRENT_DATE";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            DataRow[] rows = dt.Select(null, null, DataViewRowState.CurrentRows);
            if (rows.Length < 1)
                Console.WriteLine("No Data");
            else
            {
                foreach(DataRow row in rows)
                {
                    cmd1.CommandText = "UPDATE public.rooms SET freeroom='YES' WHERE idroom =" + row[0];
                    cmd1.Prepare();
                    cmd1.ExecuteNonQuery();
                }
                
            }
            

        }

        public void ArchiverReservation()
        {


            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd1 = new n.NpgsqlCommand();
            cmd1.Connection = cnx;
            cmd.CommandText = "SELECT * FROM public.reservation WHERE dateout = CURRENT_DATE - INTERVAL '6 months'";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            DataRow[] rows = dt.Select(null, null, DataViewRowState.CurrentRows);
            if (rows.Length < 1)
                Console.WriteLine("No Data");
            else
            {
                foreach (DataRow row in rows)
                {
                    cmd1.CommandText = "INSERT INTO public.archive(idreservation,idclient,datein,dateout,price,idroom) VALUES(@idreservation,@idclient,@datein,@dateout,@price,@idroom);";
                    cmd1.Parameters.AddWithValue("idreservation", row[0]);
                    cmd1.Parameters.AddWithValue("idclient", row[1]);
                    cmd1.Parameters.AddWithValue("datein", row[2]);
                    cmd1.Parameters.AddWithValue("dateout", row[3]);
                    cmd1.Parameters.AddWithValue("price", row[4]);
                    cmd1.Parameters.AddWithValue("idroom", row[5]);
                    cmd1.Prepare();
                    cmd1.ExecuteNonQuery();

                    cmd1.CommandText = "DELETE FROM reservation WHERE idreservation = " + row[0] +";" ;
                    cmd1.Prepare();
                    cmd1.ExecuteNonQuery();
                }

            }


        }

        public void Clear() {
            comboBoxRoomId.SelectedIndex = -1;
            comboBoxRoomType.SelectedIndex = -1;
            textBoxClientId.Clear();
            dateTimePickerIn.Value = DateTime.Now;
            dateTimePickerOut.Value = DateTime.Now; 

        }

        private void UserControlReservation_Load(object sender, EventArgs e)
        {
            cnx.Open();
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT rooms.idroom,rooms.idcat,categories.cat  FROM public.rooms JOIN public.categories ON rooms.idcat = categories.idcat WHERE freeroom='YES'";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            


            comboBoxRoomId.DataSource = dt;
            comboBoxRoomId1.DataSource = dt;
            comboBoxRoomId.DisplayMember = "idroom";
            comboBoxRoomId.ValueMember = "idroom";
            comboBoxRoomId1.DisplayMember = "idroom";
            comboBoxRoomId1.ValueMember = "idroom";

            comboBoxRoomType.DataSource = dt;
            comboBoxRoomType1.DataSource = dt;
            
            comboBoxRoomType.DisplayMember = "cat";
            comboBoxRoomType.ValueMember = "idcat";

            comboBoxRoomType1.DisplayMember = "cat";
            comboBoxRoomType1.ValueMember = "idcat";

            comboBoxRoomId.SelectedIndex = 0;
            comboBoxRoomId1.SelectedIndex = 0;
            comboBoxRoomType.SelectedIndex = 0;
            comboBoxRoomType1.SelectedIndex = 0;

            cnx.Close();
            cnx.Open();
            FreeRoom();
            ArchiverReservation();

        }

        private void UserControlReservation_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();
        }

        private void tabPageAdddReservation_Click(object sender, EventArgs e)
        {
           

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddReservation_Click(object sender, EventArgs e)
        {
            if (textBoxClientId.Text.Trim() == String.Empty || textBoxPrice.Text.Trim() == String.Empty
               || comboBoxRoomId.SelectedIndex == -1 || comboBoxRoomType.SelectedIndex == -1)
                MessageBox.Show("Please fill out all fields", "Require all field", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                cnx1.Open();

                cmd1 = new n.NpgsqlCommand();
                cmd1.Connection = cnx1;
                cmd1.CommandText = "INSERT INTO public.reservation(idclient,datein,dateout,price,idroom) VALUES(@idclient,@datein,@dateout,@price,@idroom)";
                cmd1.Parameters.AddWithValue("idclient", int.Parse(textBoxClientId.Text));
                cmd1.Parameters.AddWithValue("datein", dateTimePickerIn.Value);
                cmd1.Parameters.AddWithValue("dateout", dateTimePickerOut.Value);
                cmd1.Parameters.AddWithValue("price", int.Parse(textBoxPrice.Text));
                cmd1.Parameters.AddWithValue("idroom", int.Parse(comboBoxRoomId.Text));

               
                cmd1.Prepare();
                cmd1.ExecuteNonQuery();

                cmd1.CommandText = "UPDATE public.rooms SET freeroom='NO' WHERE idroom='"+ int.Parse(comboBoxRoomId.Text) + "'";
                cmd1.Prepare();
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Reservation added Succesfuly", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnx1.Close();
                Clear();

            }


        }

        private void tabPageSearchReservation_Enter(object sender, EventArgs e)
        {
            
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT reservation.idreservation, reservation.idroom , reservation.idclient, clients.lnamecl , rooms.idhotel , reservation.datein , reservation.dateout ,rooms.idcat FROM public.reservation JOIN public.rooms ON reservation.idroom = rooms.idroom JOIN public.clients ON reservation.idclient = clients.idclient  ";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewReservation.DataSource = dt;
        }

        private void dataGridViewReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewReservation.Rows[e.RowIndex];
                RID = row.Cells[0].Value.ToString();
                textBoxClientId1.Text = row.Cells[2].Value.ToString();
                comboBoxRoomId1.SelectedItem = row.Cells[1].Value.ToString();
                comboBoxRoomType1.SelectedItem = row.Cells[7].Value.ToString();
                dateTimePickerIn1.Text = row.Cells[5].Value.ToString();
                dateTimePickerOut1.Text = row.Cells[6].Value.ToString();

            }
        }

        private void tabPageArchive_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM public.archive ";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewArchive.DataSource = dt;
        }

        public void Clear1()
        {

            comboBoxRoomId1.SelectedIndex = -1;
            comboBoxRoomType1.SelectedIndex = -1;
            dateTimePickerIn1.Value = DateTime.Now;
            dateTimePickerOut1.Value = DateTime.Now;
            RID = "";

        }
    }
}
