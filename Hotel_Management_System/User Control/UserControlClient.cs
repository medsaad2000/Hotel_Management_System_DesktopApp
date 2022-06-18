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
    public partial class UserControlClient : UserControl
    {
        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;

        private string ID = "";
        public UserControlClient()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxAddress.Clear();
            textBoxCity.Clear();
            textBoxZipCode.Clear();
            textBoxEmail.Clear();
            textBoxPhone.Clear();
        }
        public void Clear1()
        {
            textBoxFirstName1.Clear();
            textBoxLastName1.Clear();
            textBoxAddress1.Clear();
            textBoxCity1.Clear();
            textBoxZipCode1.Clear();
            textBoxEmail1.Clear();
            textBoxPhone1.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPageAddClient_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Trim() == String.Empty || textBoxLastName.Text.Trim() == String.Empty ||
                textBoxAddress.Text.Trim() == String.Empty || textBoxCity.Text.Trim() == String.Empty ||
                textBoxZipCode.Text.Trim() == String.Empty || textBoxEmail.Text.Trim() == String.Empty ||
                textBoxPhone.Text.Trim() == String.Empty)
                MessageBox.Show("Please fill out all fields", "Require all field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                cmd = new n.NpgsqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO public.clients(fnamecl,lnamecl,addresscl,citycl,zipcl,emailcl,phonecl) VALUES(@fname,@lname,@addresscl,@citycl,@zipcl,@emailcl,@phonecl)";
                cmd.Parameters.AddWithValue("fname", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("lname", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("addresscl", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("citycl", textBoxCity.Text);
                cmd.Parameters.AddWithValue("zipcl", int.Parse(textBoxZipCode.Text));
                cmd.Parameters.AddWithValue("emailcl", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("phonecl", textBoxPhone.Text);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Client added Succesfuly", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear();

            }
        }

        private void UserControlClient_Load(object sender, EventArgs e)
        {
            cnx.Open();
        }

        private void tabPageAddClient_Leave(object sender, EventArgs e)
        {
            Clear();
            Clear1();

        }

        private void tabPageSearchClient_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPageSearchClient_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM public.clients";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewUser.DataSource = dt;
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewUser.Rows[e.RowIndex];
                ID = row.Cells[0].Value.ToString();
                textBoxFirstName1.Text = row.Cells[1].Value.ToString();
                textBoxLastName1.Text = row.Cells[2].Value.ToString();
                textBoxAddress1.Text = row.Cells[3].Value.ToString();
                textBoxCity1.Text = row.Cells[4].Value.ToString();
                textBoxZipCode1.Text = row.Cells[5].Value.ToString();
                textBoxEmail1.Text = row.Cells[6].Value.ToString();
                textBoxPhone1.Text = row.Cells[7].Value.ToString();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                if (textBoxFirstName1.Text.Trim() == String.Empty || textBoxLastName1.Text.Trim() == String.Empty ||
                    textBoxAddress1.Text.Trim() == String.Empty || textBoxCity1.Text.Trim() == String.Empty ||
                    textBoxZipCode1.Text.Trim() == String.Empty || textBoxEmail1.Text.Trim() == String.Empty ||
                    textBoxPhone1.Text.Trim() == String.Empty)
                    MessageBox.Show("Please fill out all fields .", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    cmd = new n.NpgsqlCommand();
                    cmd.Connection = cnx;
                    cmd.CommandText = "UPDATE public.clients SET fnamecl = @fname , lnamecl = @lname," +
                        "addresscl = @addresscl ,citycl=@citycl,zipcl = @zipcl,emailcl=@emailcl ,phonecl = @phonecl  WHERE idclient = " + ID + ";";
                    cmd.Parameters.AddWithValue("fname", textBoxFirstName1.Text);
                    cmd.Parameters.AddWithValue("lname", textBoxLastName1.Text);
                    cmd.Parameters.AddWithValue("addresscl", textBoxAddress1.Text);
                    cmd.Parameters.AddWithValue("citycl", textBoxCity1.Text);
                    cmd.Parameters.AddWithValue("zipcl", int.Parse(textBoxZipCode1.Text));
                    cmd.Parameters.AddWithValue("emailcl", textBoxEmail1.Text);
                    cmd.Parameters.AddWithValue("phonecl", textBoxPhone.Text);

                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Client updated", "Client updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear1();
                }
            }
            else
            {
                MessageBox.Show("Please select user from the table", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                if (textBoxFirstName.Text.Trim() == String.Empty || textBoxLastName.Text.Trim() == String.Empty ||
                    textBoxAddress.Text.Trim() == String.Empty || textBoxCity.Text.Trim() == String.Empty ||
                    textBoxZipCode.Text.Trim() == String.Empty || textBoxEmail.Text.Trim() == String.Empty ||
                    textBoxPhone.Text.Trim() == String.Empty)
                    MessageBox.Show("Please fill out all fields .", "Require All fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult result = MessageBox.Show("Are you want to delete this user ", "User delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult.Yes == result)
                    {
                        cmd = new n.NpgsqlCommand();
                        cmd.Connection = cnx;
                        cmd.CommandText = "DELETE FROM public.clients WHERE userid = " + ID + ";";

                        cmd.Prepare();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Client deleted", "Client deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Clear1();
                    }
                }
            }
        }

        private void tabPageUpdateAndDeleteClient_Leave(object sender, EventArgs e)
        {
            Clear1();
        }
    }
}
