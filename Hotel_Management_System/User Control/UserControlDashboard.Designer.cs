namespace Hotel_Management_System.User_Control
{
    partial class UserControlDashboard
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelClientCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFreeRoom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelRooms = new System.Windows.Forms.Label();
            this.labelReervedCount = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.buttonSearchRoom = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(101)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelClientCount);
            this.panel1.Location = new System.Drawing.Point(64, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 109);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Clients :";
            // 
            // labelClientCount
            // 
            this.labelClientCount.AutoSize = true;
            this.labelClientCount.ForeColor = System.Drawing.Color.White;
            this.labelClientCount.Location = new System.Drawing.Point(126, 61);
            this.labelClientCount.Name = "labelClientCount";
            this.labelClientCount.Size = new System.Drawing.Size(22, 23);
            this.labelClientCount.TabIndex = 0;
            this.labelClientCount.Text = "?";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.labelFreeRoom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(359, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 109);
            this.panel2.TabIndex = 1;
            // 
            // labelFreeRoom
            // 
            this.labelFreeRoom.AutoSize = true;
            this.labelFreeRoom.ForeColor = System.Drawing.Color.White;
            this.labelFreeRoom.Location = new System.Drawing.Point(126, 61);
            this.labelFreeRoom.Name = "labelFreeRoom";
            this.labelFreeRoom.Size = new System.Drawing.Size(22, 23);
            this.labelFreeRoom.TabIndex = 0;
            this.labelFreeRoom.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Free Rooms :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.labelRooms);
            this.panel3.Controls.Add(this.labelReervedCount);
            this.panel3.Location = new System.Drawing.Point(686, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 109);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // labelRooms
            // 
            this.labelRooms.AutoSize = true;
            this.labelRooms.ForeColor = System.Drawing.Color.White;
            this.labelRooms.Location = new System.Drawing.Point(126, 61);
            this.labelRooms.Name = "labelRooms";
            this.labelRooms.Size = new System.Drawing.Size(22, 23);
            this.labelRooms.TabIndex = 0;
            this.labelRooms.Text = "?";
            // 
            // labelReervedCount
            // 
            this.labelReervedCount.AutoSize = true;
            this.labelReervedCount.ForeColor = System.Drawing.Color.White;
            this.labelReervedCount.Location = new System.Drawing.Point(58, 28);
            this.labelReervedCount.Name = "labelReervedCount";
            this.labelReervedCount.Size = new System.Drawing.Size(184, 23);
            this.labelReervedCount.TabIndex = 0;
            this.labelReervedCount.Text = "Reserved Rooms :";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxHotel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.comboBoxHotel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Items.AddRange(new object[] {
            "Tanger",
            "Casablanca",
            "Khouribga",
            "Marrakech",
            "Errachidia",
            "Tetouan",
            "Essaouira",
            "Rabat"});
            this.comboBoxHotel.Location = new System.Drawing.Point(296, 63);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(240, 31);
            this.comboBoxHotel.TabIndex = 9;
            // 
            // buttonSearchRoom
            // 
            this.buttonSearchRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSearchRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(198)))), ((int)(((byte)(218)))));
            this.buttonSearchRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchRoom.FlatAppearance.BorderSize = 0;
            this.buttonSearchRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchRoom.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchRoom.ForeColor = System.Drawing.Color.White;
            this.buttonSearchRoom.Location = new System.Drawing.Point(542, 63);
            this.buttonSearchRoom.Name = "buttonSearchRoom";
            this.buttonSearchRoom.Size = new System.Drawing.Size(123, 34);
            this.buttonSearchRoom.TabIndex = 13;
            this.buttonSearchRoom.Text = "Search";
            this.buttonSearchRoom.UseVisualStyleBackColor = false;
            this.buttonSearchRoom.Click += new System.EventHandler(this.buttonSearchRoom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Hotel_Management_System.Properties.Resources.bed_32;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::Hotel_Management_System.Properties.Resources.bed_32;
            this.pictureBox2.Location = new System.Drawing.Point(0, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::Hotel_Management_System.Properties.Resources.user_2_32;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(63, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // UserControlDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonSearchRoom);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UserControlDashboard";
            this.Size = new System.Drawing.Size(1075, 436);
            this.Load += new System.EventHandler(this.UserControlDashboard_Load);
            this.Leave += new System.EventHandler(this.UserControlDashboard_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelClientCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelFreeRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelRooms;
        private System.Windows.Forms.Label labelReervedCount;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Button buttonSearchRoom;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
