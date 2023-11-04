using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;
using WebSocketSharp;

namespace BP_Data_Manager
{
    public partial class frm_main : Form
    {
        // WordPressDB db;
        WordPressDB_REST db;
        MSG msg;

        public frm_main()
        {
            InitializeComponent();
            msg=new MSG(lst_msg);
            db = new WordPressDB_REST(txt_server.Text, txt_port.Text, txt_Database.Text, txt_Uid.Text, txt_password.Text);
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
           // Display_Data();
        }

        private async void btn_connect_Click(object sender, EventArgs e)
        {
            await  db.Connect("http://simulab.local/wp-json/db/v1");
            if (db.Connected) msg.push("Connected With Database OK");
            else msg.push("Error!!! Not able to connect");
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
           // db.Disconnect();
            msg.push("Database Disconnected");
        }

        private async void btn_read_all_Click(object sender, EventArgs e)
        {
            await db.Read();
            List<bp_data> lst_bp_data = new List<bp_data>();
            dynamic jsonDe = JsonConvert.DeserializeObject(db.str_response);
          
            foreach (var data in jsonDe)
            {
                bp_data bp_ = new bp_data();

                bp_.Record_No=data.id;
                bp_.User_ID =  data.User_ID; 
                bp_.DateTime =data.DateTime;
                bp_.SIS = data.SIS;
                bp_.DIA = data.DIA;
                bp_.PUL = data.PUL;

                lst_bp_data.Add(bp_);   
            }
                Display_Data(lst_bp_data);             
        }

        private async void btn_create_table_Click(object sender, EventArgs e)
        {
            string tbl = "wp_bp2";
            string createTableQuery =
                "CREATE TABLE IF NOT EXISTS "+tbl+"( "+
                "id mediumint(11) NOT NULL AUTO_INCREMENT, "+
                "emp_id varchar(10) NOT NULL, "+
                "DateTime datetime NOT NULL, "+
                "SIS INT(3) unsigned NOT NULL, "+
                "DIA INT(3) unsigned NOT NULL, "+
                "PUL INT(3) unsigned NOT NULL, "+
                "PRIMARY KEY id(id) )";
            await  db.Execute_command_String("http://simulab.local/wp-json/db/v1","create",createTableQuery);
            if (db.str_response=="<Table Created>") msg.push("Table Created");
            else msg.push("Error!!! Unable to create Table");
        }

        private void btn_delete_table_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Table?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
              // db.Delete_Table("tbl_bp_data");
                msg.push("Table Deleted");
            }          
        }

        private void txt_insert_Click(object sender, EventArgs e)
        {
            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("User_ID", txt_user_id.Text.ToString()));
            list.Add(new KeyValuePair<string, string>("DateTime", "2023-10-13 12:02:00"));
            list.Add(new KeyValuePair<string, string>("SIS", txt_sys.Text.ToString()));
            list.Add(new KeyValuePair<string, string>("DIA", txt_dia.Text.ToString()));
            list.Add(new KeyValuePair<string, string>("PUL", txt_pul.Text.ToString()));

            db.Insert_Data("wp_bp2", list);
          //  Display_Data();
        }

        private void dg_display_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void Display_Data(List<bp_data> bp_Datas)
        {          
            if (bp_Datas==null) return;

            dg_display.Rows.Clear();
            dg_display.Rows.Add(bp_Datas.Count);
            for (int i = 0; i < bp_Datas.Count; i++)
            {
                dg_display[0, i].Value=bp_Datas[i].Record_No.ToString();
                dg_display[1, i].Value=bp_Datas[i].User_ID.ToString();
                dg_display[2, i].Value=bp_Datas[i].DateTime.ToString();
                dg_display[3, i].Value=bp_Datas[i].SIS.ToString();
                dg_display[4, i].Value=bp_Datas[i].DIA.ToString();
                dg_display[5, i].Value=bp_Datas[i].PUL.ToString();
            }

            lbl_record_total.Text="Total Record Count="+bp_Datas.Count.ToString();
        }

        private void dg_display_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int c_row = dg_display.CurrentRow.Index-1;

                string Record_ID = dg_display[0, c_row].Value.ToString();

                string User_ID = dg_display[1, c_row].Value.ToString();

                string SIS = dg_display[3, c_row].Value.ToString();
                string DIA = dg_display[4, c_row].Value.ToString();
                string PUL = dg_display[5, c_row].Value.ToString();

                var list = new List<KeyValuePair<string, string>>();
              
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                list.Add(new KeyValuePair<string, string>("id",         Record_ID));
                list.Add(new KeyValuePair<string, string>("User_ID",    User_ID));
                list.Add(new KeyValuePair<string, string>("DateTime",   sqlFormattedDate));
                list.Add(new KeyValuePair<string, string>("SIS",        SIS));
                list.Add(new KeyValuePair<string, string>("DIA",        DIA));
                list.Add(new KeyValuePair<string, string>("PUL",        PUL));

                db.Update_Data("wp_bp2", list);
                //Display_Data();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Record?", "Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int c_row = dg_display.CurrentRow.Index;
                string Record_ID = dg_display[0, c_row].Value.ToString();

                var list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("id", Record_ID));

                await db.Delete_Data("wp_bp2", list);
                //{
                //    messagebox.show("record sucessfully deleted");
                //    display_data();
                //}
                //else
                //{
                //    messagebox.show("error!!!!not able to delete records");
                //}
            }          
        }

     
   
    }
}
