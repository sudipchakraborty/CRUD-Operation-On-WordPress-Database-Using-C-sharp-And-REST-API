using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MySql.Data.MySqlClient;

using System;
using System.Data;
using MySql.Data.MySqlClient;
using BP_Data_Manager;
using Google.Protobuf.Collections;
using System.Data.Common;
using System.Windows.Forms;

namespace Tools
{
    public class WordPressDB
    {
        public string server;
        public string port;
        public string Database;
        public String Uid;
        public String Pwd;

        MySqlConnection connection;
        public bool Connected = false;

        /// <summary>
        /// @brief This is the constructor 
        /// @param None
        /// @return void
        /// </summary> 
        public WordPressDB()
        {

        }

        /// <summary>
        /// @brief This is the constructor with server credentials
        /// @param server=server address
        /// @param port= server port
        /// @param Database= Database name
        /// @param Uid= User ID
        /// @param Pwd= Password
        /// @return void
        /// </summary>
        /// 
        public WordPressDB(string server, string port, string Database, String Uid, String Pwd)
        {
            this.server = server;
            this.port = port;   
            this.Database = Database;
            this.Uid = Uid;
            this.Pwd = Pwd;
        }

        /// <summary>
        /// @brief This function is used to connect with database using credentials from variable
        /// @param server=server address
        /// @param port= server port
        /// @param Database= Database name
        /// @param Uid= User ID
        /// @param Pwd= Password
        /// @return void
        /// </summary>
        public void Connect()
        {
            string connectionString = "Server="+server+";Port="+port+";Database="+Database+";Uid="+Uid+";Pwd="+Pwd+";";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            if (connection.State==ConnectionState.Open)
            {
                Connected= true;
            }
            else
            {
                Connected= false;
            }          
        }

        /// <summary>
        /// @brief This function is used to connect with database
        /// @param server=server address
        /// @param port= server port
        /// @param Database= Database name
        /// @param Uid= User ID
        /// @param Pwd= Password
        /// @return void
        /// </summary>
        public void Connect(string server, string port,string Database, String Uid,String Pwd)
        {
            string connectionString = "Server="+server+";Port="+port+";Database="+Database+";Uid="+Uid+";Pwd="+Pwd+";";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            if (connection.State==ConnectionState.Open)
            {
                Connected= true;
            }
            else
            {
                Connected= false;
            }
        }

        /// <summary>
        /// @brief This function is used to Disconnect from the database
        /// @param void
        /// @return void
        /// </summary>
        public void Disconnect()
        {
           if(Connected)
            {
                connection.Close(); 
                Connected = false;
            }           
        }

        /// <summary>
        /// @brief This function is used to Create Table
        /// @param Query String to create table including table name, column name and type
        /// @return true if created, else false
        /// </summary>
        public bool Create_Table(String createTableQuery)
        {
            if(!Connected) Connect();

            try
            {
                 MySqlCommand command = new MySqlCommand(createTableQuery, connection);
                 command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //throw;
                return false;
            }       
            return true;
        }

        public bool Delete_Table(String Table_Name) 
        {
            if (!Connected) Connect();

            string cmd= "DROP TABLE IF EXISTS "+Table_Name;
            try
            {
                MySqlCommand command = new MySqlCommand(cmd, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //throw;
                return false;
            }
            return true;
        }

        /// <summary>
        /// @brief This function is used to Insert Data into Table
        /// @param Query String to insert data into table
        /// @return true if inserted ok, else false
        /// </summary>
        public bool Insert_Data(String table_name, List<KeyValuePair<string, string>> data)
        {
            if (!Connected) Connect();

            string s1 = "(";
            string s2 = "VALUES (";

            foreach (KeyValuePair<string, string> k in data)
            {
                s1+=k.Key+",";
                s2=s2+"@"+k.Key+",";
            }
            s1=s1.Substring(0, s1.Length-1); s1+=")";
            s2=s2.Substring(0, s2.Length-1); s2+=")";

            string insertQuery = "INSERT INTO " + table_name +" " + s1 +" " + s2;
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            
            foreach (KeyValuePair<string, string> k in data)
            {
                command.Parameters.AddWithValue("@"+k.Key, k.Value);
            }                 
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0) return true;
            else                  return false;            
        }

        /// <summary>
        /// @brief This function is used to Update Data inside the Table
        /// @param table_name Table Name
        /// @param data=command string
        /// @return true if update ok, else false
        /// </summary>
        public bool Update_Data(String table_name, List<KeyValuePair<string, string>> data, string condition)
        {
            string s1="";
            foreach (KeyValuePair<string, string> k in data)
            {
                s1+=k.Key+" =@"+k.Key+",";
            }
            s1=s1.Substring(0, s1.Length-1);

            string insertQuery = "UPDATE " + table_name +" SET " + s1 + " WHERE "+condition;
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            foreach (KeyValuePair<string, string> k in data)
            {
                command.Parameters.AddWithValue("@"+k.Key, k.Value);
            }
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0) return true;
            else return false;
        }

        /// <summary>
        /// @brief This function is used to Delete Row from Table
        /// @param table_name Table Name
        /// @param condition=condition to delete row
        /// @return true if delete ok, else false
        /// </summary>
        public bool Delete_Data(String table_name, string condition)
        {        
            string insertQuery = "DELETE FROM " + table_name +" WHERE "+condition;
            MySqlCommand command = new MySqlCommand(insertQuery, connection);      
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0) return true;
            else return false;
        }

        public List<bp_data> Get_Data(string table_name, string sql )
        {
            if(!Connected) Connect();

            List<bp_data> lst_bp_data = new List<bp_data>();
          

            if (Connected)
            {
                string query = "SELECT * FROM " +
                                table_name;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bp_data bp_ = new bp_data();

                    bp_.Record_No= reader.GetInt32("Record_No");
                    bp_.User_ID = reader.GetString("User_ID");
                    bp_.DateTime = reader.GetString("DateTime");
                    bp_.SIS = reader.GetString("SIS");
                    bp_.DIA = reader.GetString("DIA");
                    bp_.PUL = reader.GetString("PUL");

                    lst_bp_data.Add(bp_);
                }
                reader.Close();
                return lst_bp_data;
            }

            return null;
           
        }

        public bool Connect2()
        {
            string connectionString = "Server=localhost;Port=10017;Database=local;Uid=root;Pwd=root;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int postId = reader.GetInt32("ID");
                string postTitle = reader.GetString("post_title");
                string postContent = reader.GetString("post_content");

                //Console.WriteLine($"Post ID: {postId}");
                //Console.WriteLine($"Title: {postTitle}");
                //Console.WriteLine($"Content: {postContent}");
                //Console.WriteLine();
            }

            return true;

        }

        /// <summary>
        /// @brief This function is used to Create  a Test Table
        /// @param None
        /// @return NA
        /// </summary>
        public void Test_Create()
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
            Create_Table(createTableQuery);

        }

         /// <summary>
        /// @brief This function is used to Insert Sample Data into Table
        /// @param Query String to insert data into table
        /// @return true if inserted ok, else false
        /// </summary>

        public void Test_Insert()
        {

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("User_ID",  "001"));
            list.Add(new KeyValuePair<string, string>("DateTime", "2023-10-13 12:02:00"));
            list.Add(new KeyValuePair<string, string>("SIS", "120"));
            list.Add(new KeyValuePair<string, string>("DIA", "60"));
            list.Add(new KeyValuePair<string, string>("PUL", "72"));

            Insert_Data("tbl_bp_data", list);

        }
















    }
}







//class Program
//{
//    static void Main()
//    {
//        string connectionString = "Server=YourServer;Port=YourPort;Database=YourDatabase;Uid=YourUsername;Pwd=YourPassword;";

//        using (MySqlConnection connection = new MySqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();

//                // Query to retrieve data from WordPress database (e.g., posts table)
//                string query = "SELECT ID, post_title, post_content FROM wp_posts WHERE post_type = 'post'";

//                using (MySqlCommand command = new MySqlCommand(query, connection))
//                {
//                    using (MySqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            int postId = reader.GetInt32("ID");
//                            string postTitle = reader.GetString("post_title");
//                            string postContent = reader.GetString("post_content");

//                            Console.WriteLine($"Post ID: {postId}");
//                            Console.WriteLine($"Title: {postTitle}");
//                            Console.WriteLine($"Content: {postContent}");
//                            Console.WriteLine();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }
//}
////////////////////////////////////////////////////////////////////////////////////


//class Program
//{
//    static void Main()
//    {
//        string connectionString = "Server=YourServer;Port=YourPort;Database=YourDatabase;Uid=YourUsername;Pwd=YourPassword;";

//        using (MySqlConnection connection = new MySqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();

//                // Update query
//                string updateQuery = "UPDATE YourTable SET Column1 = @NewValue1, Column2 = @NewValue2 WHERE SomeCondition";

//                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
//                {
//                    // Replace @NewValue1, @NewValue2, and SomeCondition with appropriate values
//                    command.Parameters.AddWithValue("@NewValue1", "NewValue1");
//                    command.Parameters.AddWithValue("@NewValue2", "NewValue2");
//                    command.Parameters.AddWithValue("@SomeCondition", "ConditionValue");

//                    int rowsAffected = command.ExecuteNonQuery();

//                    Console.WriteLine($"Rows affected: {rowsAffected}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }
//}
////////////////////////////////////////////////////////////////////////////////////////