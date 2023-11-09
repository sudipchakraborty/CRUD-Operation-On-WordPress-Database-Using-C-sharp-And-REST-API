using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        project_BP bp;  
        WordPressDB_REST db;
        MSG msg;
        

        public frm_main()
        {
            InitializeComponent();
            msg=new MSG(lst_msg);
            bp=  new project_BP();
            db = new WordPressDB_REST(global.server, global.port, global.Database, global.user_ID, global.password,bp.route);         
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
           
        }

        private async void btn_connect_Click(object sender, EventArgs e)
        {
            await db.send(bp.Get_Connect_obj());
            if(db.str_response=="ok")
            {
                db.Connected=true;
                msg.push("Connected With Database OK");
            }        
            else msg.push("Error!!! Not connected. check server is running..");
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            msg.push("Database Disconnected");
        }

        private async void btn_create_table_Click(object sender, EventArgs e)
        {
            await db.send(bp.Get_Create_Table_obj());
            if (db.str_response=="<Table Created>") msg.push("Table Created");
            else msg.push("Error!!! Unable to create Table");
        }

        private async void btn_delete_table_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Table?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await db.send(bp.Get_Delete_table_obj());
                if (db.str_response=="[]") msg.push("Table Deleted");
                else msg.push("Unable to Delete Table");
            }
        }

        private async void txt_insert_Click(object sender, EventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
           
            bp_data b = bp.Get_Insert_String(txt_user_id.Text, sqlFormattedDate, txt_sys.Text, txt_dia.Text, txt_pul.Text);
            await db.send(b);
            if (db.str_response=="Failed to Insert data")
            {
                msg.push("Failed to Insert data");
                return;
            }
            else
            {
                await db.send(bp.Get_Read_obj());
                bp.Fill_DataGrid(db.str_response, dg_display);
                dg_display.ClearSelection();
                dg_display.Rows[dg_display.RowCount - 2].Selected = true;
                dg_display.CurrentCell = dg_display.Rows[dg_display.RowCount - 2].Cells[0];
                lbl_record_total.Text="Total Record Count="+dg_display.Rows.Count.ToString();
            }
        }

        private async void btn_read_all_Click(object sender, EventArgs e)
        {
            Check_Connection();
            if (db.Connected)
            {
                await db.send(bp.Get_Read_obj());
                bp.Fill_DataGrid(db.str_response, dg_display);
                lbl_record_total.Text="Total Record Count="+dg_display.Rows.Count.ToString();
            }
        }

        private async void dg_display_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                object b = bp.Get_Update_data(dg_display);
                await  db.send(b);
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
                await db.send(bp.Get_Delete_row_obj(Record_ID));
                /////////////////////////////////
                await db.send(bp.Get_Read_obj());
                bp.Fill_DataGrid(db.str_response, dg_display);
                lbl_record_total.Text="Total Record Count="+dg_display.Rows.Count.ToString();

            }          
        }

        public async void Check_Connection()
        {
            if (!db.Connected)
            {
                await db.send(bp.Get_Connect_obj());
                if (db.str_response=="ok")
                {
                    db.Connected=true;
                    msg.push("Connected With Database OK");
                }
                else msg.push("Error!!! Not connected. check server is running..");
            }
        }

       
    }
}
