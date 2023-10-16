namespace BP_Data_Manager
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_sys = new System.Windows.Forms.TextBox();
            this.txt_insert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtn_using_rest_api = new System.Windows.Forms.RadioButton();
            this.rbtn_using_sql = new System.Windows.Forms.RadioButton();
            this.txt_dia = new System.Windows.Forms.TextBox();
            this.txt_pul = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_user_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dg_display = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_Uid = new System.Windows.Forms.TextBox();
            this.txt_Database = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lst_msg = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_read_all = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_record_total = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_delete_table = new System.Windows.Forms.Button();
            this.btn_create_table = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_display)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_sys
            // 
            this.txt_sys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sys.Location = new System.Drawing.Point(125, 48);
            this.txt_sys.Name = "txt_sys";
            this.txt_sys.Size = new System.Drawing.Size(66, 30);
            this.txt_sys.TabIndex = 0;
            this.txt_sys.Text = "120";
            // 
            // txt_insert
            // 
            this.txt_insert.ForeColor = System.Drawing.Color.Black;
            this.txt_insert.Location = new System.Drawing.Point(361, 19);
            this.txt_insert.Name = "txt_insert";
            this.txt_insert.Size = new System.Drawing.Size(66, 66);
            this.txt_insert.TabIndex = 1;
            this.txt_insert.Text = "INSERT";
            this.txt_insert.UseVisualStyleBackColor = true;
            this.txt_insert.Click += new System.EventHandler(this.txt_insert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(343, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "BP Monitor Data Manager";
            // 
            // rbtn_using_rest_api
            // 
            this.rbtn_using_rest_api.AutoSize = true;
            this.rbtn_using_rest_api.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtn_using_rest_api.Location = new System.Drawing.Point(30, 214);
            this.rbtn_using_rest_api.Name = "rbtn_using_rest_api";
            this.rbtn_using_rest_api.Size = new System.Drawing.Size(116, 19);
            this.rbtn_using_rest_api.TabIndex = 3;
            this.rbtn_using_rest_api.TabStop = true;
            this.rbtn_using_rest_api.Text = "Using REST API";
            this.rbtn_using_rest_api.UseVisualStyleBackColor = true;
            // 
            // rbtn_using_sql
            // 
            this.rbtn_using_sql.AutoSize = true;
            this.rbtn_using_sql.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtn_using_sql.Location = new System.Drawing.Point(30, 192);
            this.rbtn_using_sql.Name = "rbtn_using_sql";
            this.rbtn_using_sql.Size = new System.Drawing.Size(87, 19);
            this.rbtn_using_sql.TabIndex = 4;
            this.rbtn_using_sql.TabStop = true;
            this.rbtn_using_sql.Text = "Using SQL";
            this.rbtn_using_sql.UseVisualStyleBackColor = true;
            // 
            // txt_dia
            // 
            this.txt_dia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dia.Location = new System.Drawing.Point(197, 48);
            this.txt_dia.Name = "txt_dia";
            this.txt_dia.Size = new System.Drawing.Size(66, 30);
            this.txt_dia.TabIndex = 5;
            this.txt_dia.Text = "80";
            // 
            // txt_pul
            // 
            this.txt_pul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pul.Location = new System.Drawing.Point(269, 48);
            this.txt_pul.Name = "txt_pul";
            this.txt_pul.Size = new System.Drawing.Size(66, 30);
            this.txt_pul.TabIndex = 7;
            this.txt_pul.Text = "72";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_insert);
            this.groupBox1.Controls.Add(this.txt_pul);
            this.groupBox1.Controls.Add(this.txt_user_id);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_sys);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_dia);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 96);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Current Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(286, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "PUL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(215, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "DIA";
            // 
            // txt_user_id
            // 
            this.txt_user_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user_id.Location = new System.Drawing.Point(53, 48);
            this.txt_user_id.Name = "txt_user_id";
            this.txt_user_id.Size = new System.Drawing.Size(66, 30);
            this.txt_user_id.TabIndex = 0;
            this.txt_user_id.Text = "U001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(56, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(137, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "SYS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dg_display);
            this.groupBox2.Location = new System.Drawing.Point(470, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 363);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History";
            // 
            // dg_display
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_display.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_display.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_display.Location = new System.Drawing.Point(6, 19);
            this.dg_display.Name = "dg_display";
            this.dg_display.RowHeadersWidth = 51;
            this.dg_display.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_display.Size = new System.Drawing.Size(613, 330);
            this.dg_display.TabIndex = 0;
            this.dg_display.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_display_KeyDown);
            this.dg_display.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dg_display_PreviewKeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_disconnect);
            this.groupBox3.Controls.Add(this.btn_connect);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_password);
            this.groupBox3.Controls.Add(this.txt_Uid);
            this.groupBox3.Controls.Add(this.txt_Database);
            this.groupBox3.Controls.Add(this.txt_port);
            this.groupBox3.Controls.Add(this.txt_server);
            this.groupBox3.Controls.Add(this.rbtn_using_sql);
            this.groupBox3.Controls.Add(this.rbtn_using_rest_api);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 237);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DataBase";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.ForeColor = System.Drawing.Color.Maroon;
            this.btn_disconnect.Location = new System.Drawing.Point(102, 157);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(73, 29);
            this.btn_disconnect.TabIndex = 8;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.ForeColor = System.Drawing.Color.Black;
            this.btn_connect.Location = new System.Drawing.Point(22, 157);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(74, 29);
            this.btn_connect.TabIndex = 7;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "User ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "DATABASE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "PORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "SERVER";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(84, 128);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(71, 20);
            this.txt_password.TabIndex = 5;
            this.txt_password.Text = "root";
            // 
            // txt_Uid
            // 
            this.txt_Uid.Location = new System.Drawing.Point(84, 102);
            this.txt_Uid.Name = "txt_Uid";
            this.txt_Uid.Size = new System.Drawing.Size(71, 20);
            this.txt_Uid.TabIndex = 5;
            this.txt_Uid.Text = "root";
            // 
            // txt_Database
            // 
            this.txt_Database.Location = new System.Drawing.Point(84, 76);
            this.txt_Database.Name = "txt_Database";
            this.txt_Database.Size = new System.Drawing.Size(71, 20);
            this.txt_Database.TabIndex = 5;
            this.txt_Database.Text = "local";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(84, 50);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(71, 20);
            this.txt_port.TabIndex = 5;
            this.txt_port.Text = "10017";
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(84, 24);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(71, 20);
            this.txt_server.TabIndex = 5;
            this.txt_server.Text = "localhost";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lst_msg);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(12, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(446, 209);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message";
            // 
            // lst_msg
            // 
            this.lst_msg.BackColor = System.Drawing.Color.Black;
            this.lst_msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_msg.ForeColor = System.Drawing.Color.White;
            this.lst_msg.FormattingEnabled = true;
            this.lst_msg.ItemHeight = 20;
            this.lst_msg.Location = new System.Drawing.Point(6, 22);
            this.lst_msg.Name = "lst_msg";
            this.lst_msg.Size = new System.Drawing.Size(421, 160);
            this.lst_msg.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(207, 317);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 96);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(7, 71);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(52, 19);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "SYS";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 19);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Date";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "User ID";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(185, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 34);
            this.button3.TabIndex = 1;
            this.button3.Text = "SEARCH";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btn_read_all
            // 
            this.btn_read_all.ForeColor = System.Drawing.Color.Black;
            this.btn_read_all.Location = new System.Drawing.Point(7, 26);
            this.btn_read_all.Name = "btn_read_all";
            this.btn_read_all.Size = new System.Drawing.Size(94, 42);
            this.btn_read_all.TabIndex = 13;
            this.btn_read_all.Text = "READ";
            this.btn_read_all.UseVisualStyleBackColor = true;
            this.btn_read_all.Click += new System.EventHandler(this.btn_read_all_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBox1);
            this.groupBox6.Location = new System.Drawing.Point(471, 440);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(629, 187);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "GRAPH VIEW";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(10, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 139);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(945, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 25);
            this.button1.TabIndex = 14;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1035, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbl_record_total
            // 
            this.lbl_record_total.AutoSize = true;
            this.lbl_record_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_record_total.ForeColor = System.Drawing.Color.Black;
            this.lbl_record_total.Location = new System.Drawing.Point(737, 41);
            this.lbl_record_total.Name = "lbl_record_total";
            this.lbl_record_total.Size = new System.Drawing.Size(142, 20);
            this.lbl_record_total.TabIndex = 15;
            this.lbl_record_total.Text = "Total Record=123";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_delete_table);
            this.groupBox7.Controls.Add(this.btn_create_table);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(208, 176);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(91, 135);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TABLE";
            // 
            // btn_delete_table
            // 
            this.btn_delete_table.ForeColor = System.Drawing.Color.Black;
            this.btn_delete_table.Location = new System.Drawing.Point(6, 76);
            this.btn_delete_table.Name = "btn_delete_table";
            this.btn_delete_table.Size = new System.Drawing.Size(73, 42);
            this.btn_delete_table.TabIndex = 0;
            this.btn_delete_table.Text = "DELETE";
            this.btn_delete_table.UseVisualStyleBackColor = true;
            this.btn_delete_table.Click += new System.EventHandler(this.btn_delete_table_Click);
            // 
            // btn_create_table
            // 
            this.btn_create_table.ForeColor = System.Drawing.Color.Black;
            this.btn_create_table.Location = new System.Drawing.Point(6, 27);
            this.btn_create_table.Name = "btn_create_table";
            this.btn_create_table.Size = new System.Drawing.Size(73, 43);
            this.btn_create_table.TabIndex = 0;
            this.btn_create_table.Text = "CREATE";
            this.btn_create_table.UseVisualStyleBackColor = true;
            this.btn_create_table.Click += new System.EventHandler(this.btn_create_table_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_read_all);
            this.groupBox8.Controls.Add(this.btn_delete);
            this.groupBox8.ForeColor = System.Drawing.Color.White;
            this.groupBox8.Location = new System.Drawing.Point(305, 176);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(112, 135);
            this.groupBox8.TabIndex = 17;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "RECORD";
            // 
            // btn_delete
            // 
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(7, 79);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(94, 39);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.button5_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Record No";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "User ID";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 75;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DateTime";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "SIS";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 75;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DIA";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 75;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PUL";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 75;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1118, 640);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.lbl_record_total);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_display)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_sys;
        private System.Windows.Forms.Button txt_insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtn_using_rest_api;
        private System.Windows.Forms.RadioButton rbtn_using_sql;
        private System.Windows.Forms.TextBox txt_dia;
        private System.Windows.Forms.TextBox txt_pul;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_Database;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lst_msg;
        private System.Windows.Forms.TextBox txt_user_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.DataGridView dg_display;
        private System.Windows.Forms.Button btn_read_all;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_record_total;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Uid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_delete_table;
        private System.Windows.Forms.Button btn_create_table;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

