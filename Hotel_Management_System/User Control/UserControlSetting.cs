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
    public partial class UserControlSetting : UserControl
    {

        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;

        private string ID = "";

        public UserControlSetting()
        {
            InitializeComponent();
            
        }

        public void Clear()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            tabControlUser.SelectedTab = tabPageAddUser; 
        }
        public void Clear1()
        {
            textBoxUsername1.Clear();
            textBoxPassword1.Clear();
            ID = "";
        }

        private void tabPageAddUser_Click(object sender, EventArgs e)
        {
                
        }

        private void tabControlUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(ID != "")
            {
                if (textBoxUsername1.Text.Trim() == string.Empty || textBoxPassword1.Text.Trim() == string.Empty)
                    MessageBox.Show("Please fill out all fields .", "Require All fields",MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    cmd = new n.NpgsqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "UPDATE public.users SET username = @usernamee , userpassword = @passwordd WHERE userid = "+ID+";";
                    cmd.Parameters.AddWithValue("usernamee", textBoxUsername1.Text);
                    cmd.Parameters.AddWithValue("passwordd", textBoxPassword1.Text);

                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User updated", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear1();
                }
            }
            else
            {
                MessageBox.Show("Please select user from the table", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControlUser_Leave(object sender, EventArgs e)
        {

        }

        private void tabPageAddUser_Leave(object sender, EventArgs e)
        {
            Clear();

        }

        private void tabPageSearchUser_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM public.users";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewUser.DataSource = dt;
        }

        private void tabPageSearchUser_Leave(object sender, EventArgs e)
        {
            textBoxSearchUsename.Clear();
        }

        private void tabPageUpdateAndDeleteUser_Leave(object sender, EventArgs e)
        {
            Clear1();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Trim() == String.Empty || textBoxPassword.Text.Trim() == String.Empty)
                MessageBox.Show("Please fill out all fields", "Require all field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                cmd = new n.NpgsqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO public.users(username,userpassword) VALUES(@usernamee,@passwordd)";
                cmd.Parameters.AddWithValue("usernamee", textBoxUsername.Text);
                cmd.Parameters.AddWithValue("passwordd", textBoxPassword.Text);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                MessageBox.Show("User added", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear();

            }
        }

        private void UserControlSetting_Load(object sender, EventArgs e)
        {
            cnx.Open();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                if (textBoxUsername1.Text.Trim() == string.Empty || textBoxPassword1.Text.Trim() == string.Empty)
                    MessageBox.Show("Please fill out all fields .", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult result = MessageBox.Show("Are you want to delete this user ", "User delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult.Yes == result)
                    {
                        cmd = new n.NpgsqlCommand();
                        cmd.Connection = cnx;
                        cmd.CommandText = "DELETE FROM public.users WHERE userid = " + ID + ";";
                        cmd.Parameters.AddWithValue("usernamee", textBoxUsername1.Text);
                        cmd.Parameters.AddWithValue("passwordd", textBoxPassword1.Text);

                        cmd.Prepare();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("User deleted", "User deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Clear1();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select user from the table", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewUser.Rows[e.RowIndex];
                ID = row.Cells[0].Value.ToString();
                textBoxUsername1.Text = row.Cells[1].Value.ToString();
                textBoxPassword1.Text = row.Cells[2].Value.ToString();
            }
        }

        private void textBoxSearchUsename_TextChanged(object sender, EventArgs e)
        {
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            

            cmd.CommandText = "SELECT * FROM public.users WHERE username LIKE '%"+textBoxSearchUsename.Text+"%'";

            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewUser.DataSource = dt;


        }
    }
}
