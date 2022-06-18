using DGVPrinterHelper;
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
    public partial class UserControlBill : UserControl
    {

        static string strConnString = "server=localhost;port=5432;user id=postgres;password=saad;database=Hotel_Management_System";
        //NpgsqlConnection db;
        n.NpgsqlConnection cnx = new n.NpgsqlConnection(strConnString);
        n.NpgsqlCommand cmd;
        n.NpgsqlDataAdapter ada;
        DataTable dt;
        private int total;

        private string ID = "";
        private int priceroom;
        public UserControlBill()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBoxBreakfast.Clear();
            textBoxLaunch.Clear();
            textBoxDinner.Clear();
            textGymPrice.Clear();
            textBoxIdReservation.Clear();

        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxBreakfast.Text.Trim() == String.Empty || textBoxLaunch.Text.Trim() == String.Empty ||
               textBoxDinner.Text.Trim() == String.Empty || textGymPrice.Text.Trim() == String.Empty ||
               textBoxIdReservation.Text.Trim() == String.Empty)
                MessageBox.Show("Please fill out all fields", "Require all field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                cmd = new n.NpgsqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO public.bills(idreservation,breakfastprice,gymprice,dinnerprice,launchprice,total) VALUES(@idreservation,@breakfastprice,@gymprice,@dinnerprice,@launchprice,@total)";
                cmd.Parameters.AddWithValue("idreservation", int.Parse(textBoxIdReservation.Text));
                cmd.Parameters.AddWithValue("breakfastprice", int.Parse(textBoxBreakfast.Text));
                cmd.Parameters.AddWithValue("gymprice", int.Parse(textGymPrice.Text));
                cmd.Parameters.AddWithValue("dinnerprice", int.Parse(textBoxDinner.Text));
                cmd.Parameters.AddWithValue("launchprice", int.Parse(textBoxLaunch.Text));
                cmd.Parameters.AddWithValue("total", int.Parse(textBoxLaunch.Text)+ int.Parse(textBoxBreakfast.Text) + int.Parse(textGymPrice.Text) + int.Parse(textBoxDinner.Text) + this.priceroom);


                cmd.Prepare();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Bill added Succesfuly", "Bill added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear();

            }
        }

        private void buttonGetReservation_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT idreservation , price  FROM public.reservation WHERE idreservation = "+textBoxIdReservation.Text+";";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                labelTotal.Text = row["price"].ToString();
                this.priceroom = int.Parse(row["price"].ToString());
            }

        }

        private void UserControlBill_Load(object sender, EventArgs e)
        {
            cnx.Open();
        }

        private void dataGridViewBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPageSearchBill_Enter(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM public.bills";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewBill.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd = new n.NpgsqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT idbill, bills.idreservation , breakfastprice ,gymprice, dinnerprice, launchprice, total , reservation.price  FROM public.bills JOIN public.reservation ON bills.idreservation = reservation.idreservation WHERE idbill="+textBoxBill.Text+";";
            ada = new n.NpgsqlDataAdapter(cmd);
            ada.Fill(dt);
            dataGridViewPrint.DataSource = dt;
            this.total = int.Parse(dt.Rows[0][7].ToString());
            
            
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "YAS HOTEL BILL";
            printer.SubTitle = string.Format(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            printer.PrinterName = "Total Price: " + this.total.ToString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.HeaderCellAlignment = StringAlignment.Near;
            
            printer.Footer = "Total Price: " + this.total.ToString()+" DH";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridViewPrint);


            //total = 0;
            //guna2DataGridView1.Rows.Clear();
            //labelTotalAmount.Text = "" + total + " DHS";
        }

        private void dataGridViewPrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
