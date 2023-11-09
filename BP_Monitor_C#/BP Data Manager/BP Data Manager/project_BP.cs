using BP_Data_Manager;
using MySqlX.XDevAPI.Relational;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_Data_Manager
{
    public class project_BP
    {
        public string route = "http://simulab.local/wp-json/bp/v1";
        public string table = "wp_bp2";
        public string Read_All = "select * from wp_bp2";

        public project_BP()
        {   
            
        }

        public bp_data Get_Create_Table_obj()
        {
            string createTableQuery =
              "CREATE TABLE IF NOT EXISTS "+table+"( "+
              "id mediumint(11) NOT NULL AUTO_INCREMENT, "+
              "User_ID varchar(10) NOT NULL, "+
              "DateTime datetime NOT NULL, "+
              "SIS INT(3) unsigned NOT NULL, "+
              "DIA INT(3) unsigned NOT NULL, "+
              "PUL INT(3) unsigned NOT NULL, "+
              "PRIMARY KEY id(id) )";

            bp_data bp_Data = new bp_data();
            bp_Data.cmd="create";
            bp_Data.cmd_string=createTableQuery;
            return bp_Data;
        }

        public bp_data Get_Connect_obj()
        {
            bp_data bp_Data = new bp_data();
            bp_Data.cmd="connect";
            return bp_Data;
        }

        public bp_data Get_Insert_String(string id, string dt, string sys, string dia, string pul)
        {    
            
            bp_data bp_Data = new bp_data();

            bp_Data.cmd="insert";
            bp_Data.cmd_string="";
            bp_Data.tbl_name=table;
            bp_Data.User_ID=id;
            bp_Data.DateTime=dt;
            bp_Data.SIS=sys;
            bp_Data.DIA=dia;
            bp_Data.PUL=pul;

            return bp_Data;
        }


        public bp_data Get_Read_obj()
        {
            bp_data bp_Data = new bp_data();
            bp_Data.cmd="read";
            return bp_Data;
        }

        public bp_data Get_Delete_row_obj(string id)
        {
            bp_data bp_Data = new bp_data();
            bp_Data.cmd="delete_row";
            bp_Data.tbl_name=table;
            bp_Data.id=id;

            return bp_Data;
        }

        public bp_data Get_Delete_table_obj()
        {
            bp_data bp_Data = new bp_data();
            bp_Data.cmd="delete_table";
            bp_Data.tbl_name=table;

            return bp_Data;
        }




        public object Get_Update_data(DataGridView dg)
        {
            int c_row = dg.CurrentRow.Index-1;

            string Record_ID = dg[0, c_row].Value.ToString();
            string User_ID = dg[1, c_row].Value.ToString();
            string SIS = dg[3, c_row].Value.ToString();
            string DIA = dg[4, c_row].Value.ToString();
            string PUL = dg[5, c_row].Value.ToString();

            bp_data bp_Data = new bp_data();

            bp_Data.cmd="insert";
            bp_Data.cmd_string="";
            bp_Data.tbl_name=table;
            bp_Data.id=Record_ID;
            bp_Data.User_ID=User_ID;

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            bp_Data.DateTime=sqlFormattedDate;

            bp_Data.SIS=SIS;
            bp_Data.DIA=DIA;
            bp_Data.PUL=PUL;

            return bp_Data;
        }


        public void Fill_DataGrid(String data_string, DataGridView dg)
        {
            dynamic jsonDe = JsonConvert.DeserializeObject(data_string);
            int i = 0;
            dg.Rows.Clear();

            foreach (var data in jsonDe)
            {
                dg.Rows.Add();
                dg[0, i].Value=data.id;
                dg[1, i].Value= data.User_ID;
                dg[2, i].Value=data.DateTime;
                dg[3, i].Value=data.SIS;
                dg[4, i].Value=data.DIA;
                dg[5, i].Value=data.PUL;
                i++;
            }
        }



    }
}
