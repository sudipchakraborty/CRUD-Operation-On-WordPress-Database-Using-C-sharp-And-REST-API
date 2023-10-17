using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

using Tools;

using WebSocketSharp;

namespace BP_Data_Manager
{
    public partial class frm_main : Form
    {
        WordPressDB db;
        MSG msg;

        public frm_main()
        {
            InitializeComponent();
            msg=new MSG(lst_msg);
            db = new WordPressDB(txt_server.Text, txt_port.Text, txt_Database.Text, txt_Uid.Text, txt_password.Text);
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
          db.Connect();
          msg.push("Connected With Database OK");            
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            db.Disconnect();
            msg.push("Database Disconnected");
        }

        private void btn_read_all_Click(object sender, EventArgs e)
        {
            Display_Data();
        }

        private void btn_create_table_Click(object sender, EventArgs e)
        {
            string createTableQuery =
                "CREATE TABLE IF NOT EXISTS" +
                " tbl_BP_Data " +
                "(" +
                    "Record_No INT AUTO_INCREMENT PRIMARY KEY, " +
                    "User_ID VARCHAR(10) NOT NULL, " +
                    "DateTime datetime NOT NULL, " +
                    "SIS INT(3) unsigned NOT NULL, " +
                    "DIA int(3) unsigned NOT NULL, " +
                    "PUL int(3) unsigned NOT NULL" +
                ")";
             db.Create_Table(createTableQuery);
        }

        private void btn_delete_table_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Table?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                db.Delete_Table("tbl_bp_data");
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

            db.Insert_Data("tbl_bp_data", list);
            Display_Data();
        }

        private void dg_display_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private void Display_Data()
        {
            List<bp_data> bp_Datas;
            bp_Datas= db.Get_Data("tbl_BP_Data", "jgjghj");
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

                list.Add(new KeyValuePair<string, string>("User_ID", User_ID));

                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                list.Add(new KeyValuePair<string, string>("DateTime", sqlFormattedDate));
                list.Add(new KeyValuePair<string, string>("SIS", SIS));
                list.Add(new KeyValuePair<string, string>("DIA", DIA));
                list.Add(new KeyValuePair<string, string>("PUL", PUL));

                db.Update_Data("tbl_bp_data", list, "Record_No="+Record_ID);
                Display_Data();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Record?", "Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int c_row = dg_display.CurrentRow.Index;
                string Record_ID = dg_display[0, c_row].Value.ToString();
                
                if( db.Delete_Data("tbl_bp_data", "Record_No="+Record_ID))
                {
                    MessageBox.Show("Record Sucessfully Deleted");
                    Display_Data();
                }
                else
                {
                    MessageBox.Show("Error!!!!Not able to Delete Records");
                }              
            }          
        }
 
    }
}
