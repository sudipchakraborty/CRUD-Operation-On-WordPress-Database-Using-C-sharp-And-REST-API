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
using System.Net.Http;
using System.Threading;
using System.Timers;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Tools
{
    public class WordPressDB_REST
    {
        public string server;
        public string port;
        public string Database;
        public String Uid;
        public String Pwd;
        public bool Connected = false;
        public string str_response = "";

        public WordPressDB_REST()
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
        public WordPressDB_REST(string server, string port, string Database, String Uid, String Pwd)
        {
            this.server = server;
            this.port = port;
            this.Database = Database;
            this.Uid = Uid; 
            this.Pwd = Pwd;
        }

        /// <summary>
        /// @brief This function is used to check the existence of the server. it sends a string "connect" to the server.
        /// if the server running, response with "ok" message.
        /// @param apiUrl=API url string
        /// @return void
        /// </summary>
        /// 
        public async Task  Connect(string apiUrl)
        {
            if (Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);
            
            //Create my object
            var query = new
            {
                cmd = @"connect",
                cmd_string = @""
            };

            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read and display the response content
                var content2 = await response.Content.ReadAsStringAsync();
                content2=content2.Trim(new char[] { '\r', '\n', '"' });
                if (content2 =="ok") Connected=true;
                else                Connected=false;
            }
            else
            {
                Connected=false;
            }
        }

        public async Task Execute_command_String(string apiUrl, string command,string cmd_str)
        {
            if (!Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Create my object
            var query = new
            {
                cmd = @command,
                cmd_string = @cmd_str
            };

            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            // Check if the request was successful (HTTP status code 201 indicates success)
            if (response.IsSuccessStatusCode)
            {
                str_response = await response.Content.ReadAsStringAsync();
                str_response=str_response.Trim(new char[] { '\r', '\n', '"' });               
            }
            else
            {
                str_response="Error";
            }
        }

        public void Test_Insert()
        {

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("User_ID", "001"));
            list.Add(new KeyValuePair<string, string>("DateTime", "2023-10-13 12:02:00"));
            list.Add(new KeyValuePair<string, string>("SIS", "120"));
            list.Add(new KeyValuePair<string, string>("DIA", "60"));
            list.Add(new KeyValuePair<string, string>("PUL", "72"));

            Insert_Data("tbl_bp_data", list);

        }

        /// <summary>
        /// @brief This function is used to Insert Data into Table
        /// @param Query String to insert data into table
        /// @return true if inserted ok, else false
        /// </summary>
        public async Task Insert_Data(String table_name, List<KeyValuePair<string, string>> data)
        {
            if (!Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Create my object
            var query = new
            {
                cmd = @"insert",
                cmd_string = @"",
                tbl_name = @table_name,
                User_ID = @data[0].Value,
                DateTime= @data[1].Value,
                SIS = @data[2].Value,
                DIA = @data[3].Value,
                PUL= @data[4].Value
            };

            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync("http://simulab.local/wp-json/db/v1", content);
            // Check if the request was successful (HTTP status code 201 indicates success)
            if (response.IsSuccessStatusCode)
            {
                str_response = await response.Content.ReadAsStringAsync();
                str_response=str_response.Trim(new char[] { '\r', '\n', '"' });
            }
            else
            {
                str_response="Error";
            }
        }

        /// <summary>
        /// @brief This function is used to Insert Data into Table
        /// @param Query String to insert data into table
        /// @return true if inserted ok, else false
        /// </summary>
        public async Task Read()
        {
            if (!Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Create my object
            var query = new
            {
                cmd = @"read",
                cmd_string = @"select * from wp_bp2"             
            };

            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync("http://simulab.local/wp-json/db/v1", content);
            // Check if the request was successful (HTTP status code 201 indicates success)
            if (response.IsSuccessStatusCode)
            {             
                str_response = await response.Content.ReadAsStringAsync();
            }
            else
            {
                str_response="Error";
            }
        }

        public async Task Update_Data(String table_name, List<KeyValuePair<string, string>> data)
        {
            if (!Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Create my object
            var query = new
            {
                cmd = @"update",
                cmd_string = @"",
                tbl_name = @table_name,
                id= @data[0].Value,
                User_ID = @data[1].Value,
                DateTime = @data[2].Value,
                SIS = @data[3].Value,
                DIA = @data[4].Value,
                PUL = @data[5].Value
            };
            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync("http://simulab.local/wp-json/db/v1", content);
            // Check if the request was successful (HTTP status code 201 indicates success)
            if (response.IsSuccessStatusCode)
            {
                str_response = await response.Content.ReadAsStringAsync();
            }
            else
            {
                str_response="Error";
            }   
        }
         
        public async Task Delete_Data(String table_name, List<KeyValuePair<string, string>> data)
        {
            if (!Connected) return;
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Create my object
            var query = new
            {
                cmd = @"delete",
                cmd_string = @"",
                tbl_name = @table_name,
                id = @data[0].Value
            };
            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(query);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync("http://simulab.local/wp-json/db/v1", content);
            // Check if the request was successful (HTTP status code 201 indicates success)
            if (response.IsSuccessStatusCode)
            {
                str_response = await response.Content.ReadAsStringAsync();
            }
            else
            {
                str_response="Error";
            }
        }




         




















        /// <summary>
        /// @brief This function is used to check the existence of the server. it sends a string "connect" to the server.
        /// if the server running, response with "ok" message.
        /// @param apiUrl=API url string
        /// @return void
        /// </summary>
        ///
        public List<bp_data> Get_Data(string table_name, string sql)
        {
            if (!Connected) return null;

























            List<bp_data> lst_bp_data = new List<bp_data>();
            MySqlDataReader reader;

                string query = "SELECT * FROM " +
                                table_name;
                

















                //while (reader.Read())
                //{
                //    bp_data bp_ = new bp_data();

                //    bp_.Record_No= reader.GetInt32("Record_No");
                //    bp_.User_ID = reader.GetString("User_ID");
                //    bp_.DateTime = reader.GetString("DateTime");
                //    bp_.SIS = reader.GetString("SIS");
                //    bp_.DIA = reader.GetString("DIA");
                //    bp_.PUL = reader.GetString("PUL");

                //    lst_bp_data.Add(bp_);
                //}
                //reader.Close();
                //return lst_bp_data;

            return null;

        }




        //string jsonData = "{\"title\":\"New Post\",\"content\":\"This is the content of the new post.\"}";

        //// Create the HTTP content from the JSON data
        //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //// Make the POST request
        //HttpResponseMessage response = await client.PostAsync(apiUrl, content);
        //// Check if the request was successful (HTTP status code 201 indicates success)
        //if (response.IsSuccessStatusCode)
        //{
        //   // Console.WriteLine("Post created successfully.");
        //    string s= await response.Content.ReadAsStringAsync();

        //}
        //else
        //{
        //    string p = "";
        //    string s = ($"Error: {response.StatusCode}");
        //      s = await response.Content.ReadAsStringAsync();
        //}




        //            // Create an HttpClient and set the base address
        //            using (HttpClient client = new HttpClient())
        //            {
        //                // Encode the credentials as base64
        //                string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        //                // Set the Authorization header with Basic authentication
        //                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

        //                // Create the data you want to POST as a JSON string

        //                // Create a C# object
        //                var person = new Person
        //                {
        //                    Sistolic = "120",
        //                    DIA = "80",
        //                    PUL = 72
        //                };
        //                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(person);


        //                //   string jsonData = "{\"title\":\"New Post\",\"content\":\"This is the content of the new post.\"}";

        //                // Create the HTTP content from the JSON data
        //                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //                // Make the POST request
        //                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
        //                // Check if the request was successful (HTTP status code 201 indicates success)
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    Console.WriteLine("Post created successfully.");
        //                    Console.WriteLine(await response.Content.ReadAsStringAsync());
        //                    Console.ReadKey();
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Error: {response.StatusCode}");
        //                    Console.WriteLine(await response.Content.ReadAsStringAsync());
        //                    Console.ReadKey();
        //                }
        //            }
        //        }






















        //string connectionString = "Server=localhost;Port=10017;Database=local;Uid=root;Pwd=root;";
        //connection = new MySqlConnection(connectionString);
        //connection.Open();
        //if (connection.State==ConnectionState.Open)
        //{
        //    Connected= true;
        //}
        //else
        //{
        //    Connected= false;
        //}          
        //     }


        /// <summary>
        /// @brief This function is used to connect with database
        /// @param server=server address
        /// @param port= server port
        /// @param Database= Database name
        /// @param Uid= User ID
        /// @param Pwd= Password
        /// @return void
        /// </summary>
        public void Connect(string server, string port, string Database, String Uid, String Pwd)
        {
            //string connectionString = "Server="+server+";Port="+port+";Database="+Database+";Uid="+Uid+";Pwd="+Pwd+";";
            //connection = new MySqlConnection(connectionString);
            //connection.Open();
            //if (connection.State==ConnectionState.Open)
            //{
            //    Connected= true;
            //}
            //else
            //{
            //    Connected= false;
            //}
        }










        public void Disconnect()
        {
           //if(Connected)
           // {
           //     connection.Close(); 
           //     Connected = false;
           // }           
        }

        public List<bp_data> Get_Data(string sql )
        {
            List<bp_data> lst_bp_data = new List<bp_data>();
          

            //if (Connected)
            //{
            //    string query = "SELECT * FROM bp_data";
            //    MySqlCommand command = new MySqlCommand(query, connection);
            //    MySqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        bp_data bp_ = new bp_data();

            //        bp_.Record_No= reader.GetInt32("Record_No");
            //        bp_.User_ID = reader.GetString("User_ID");
            //        bp_.DateTime = reader.GetString("DateTime");
            //        bp_.SIS = reader.GetString("SIS");
            //        bp_.DIA = reader.GetString("DIA");
            //        bp_.PUL = reader.GetString("PUL");

            //        lst_bp_data.Add(bp_);
            //    }

            //    return lst_bp_data;
            //}

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
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Security.Cryptography;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {





//            // Replace with your WordPress REST API endpoint and authentication details
//            string apiUrl = "http://diwakaracademy.local/wp-json/iot/update";
//            string username = "sudip";
//            string password = "Sudip@123";

//            // Create an HttpClient and set the base address
//            using (HttpClient client = new HttpClient())
//            {
//                // Encode the credentials as base64
//                string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

//                // Set the Authorization header with Basic authentication
//                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

//                // Create the data you want to POST as a JSON string

//                // Create a C# object
//                var person = new Person
//                {
//                    Sistolic = "120",
//                    DIA = "80",
//                    PUL = 72
//                };
//                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(person);


//                //   string jsonData = "{\"title\":\"New Post\",\"content\":\"This is the content of the new post.\"}";

//                // Create the HTTP content from the JSON data
//                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

//                // Make the POST request
//                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
//                // Check if the request was successful (HTTP status code 201 indicates success)
//                if (response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("Post created successfully.");
//                    Console.WriteLine(await response.Content.ReadAsStringAsync());
//                    Console.ReadKey();
//                }
//                else
//                {
//                    Console.WriteLine($"Error: {response.StatusCode}");
//                    Console.WriteLine(await response.Content.ReadAsStringAsync());
//                    Console.ReadKey();
//                }
//            }
//        }


































//        ////////////////////////////////////////

//        //    // WordPress REST API endpoint for updating a post
//        // //   string apiUrl = "http://diwakaracademy.local/wp-json/iot/update";

//        //// Your WordPress post ID
//        //int postId = 1; // Replace with the ID of the post you want to update

//        //// Create an HttpClient instance
//        //using (HttpClient client = new HttpClient())
//        //{
//        //    try
//        //    {
//        //        // Define the updated post data
//        //        //var updatedPost = new
//        //        //{
//        //        //    title = "Updated Post Title",
//        //        //    content = "Updated post content."
//        //        //};

//        //        // Create a C# object
//        //        var person = new Person
//        //        {
//        //            SIS = "120",
//        //            DIA = "80",
//        //            PUL = 72
//        //        };




//        //        // Serialize the updated post data to JSON
//        //        string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(person);

//        //        // Create a StringContent object with JSON data
//        //        var content = new StringContent("?SYS=132&DIA=82&PUL=72", Encoding.UTF8, "application/json");

//        //        // Send a PUT request to update the post
//        //        HttpResponseMessage response = await client.PutAsync(apiUrl, content);

//        //        // Check if the update request was successful
//        //        if (response.IsSuccessStatusCode)
//        //        {
//        //            Console.WriteLine("Post updated successfully.");
//        //        }
//        //        else
//        //        {
//        //            Console.WriteLine("Error: Unable to update post. Status code: " + response.StatusCode);
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        Console.WriteLine("Error: " + ex.Message);
//        //    }
//        //}



//        //Console.ReadKey();
//        //}









//        public class Person
//        {
//            public string Sistolic { get; set; }
//            public string DIA { get; set; }
//            public int PUL { get; set; }
//        }








//        public async Task get_data()
//        {
//            // WordPress REST API endpoint for posts
//            string apiUrl = "http://diwakaracademy.local/wp-json/iot/update"; // "http://diwakaracademy.local/wp-json/university/v1/search";

//            // Create an HttpClient instance
//            using (HttpClient client = new HttpClient())
//            {
//                try
//                {
//                    // Send GET request to the WordPress API
//                    HttpResponseMessage response = await client.GetAsync(apiUrl);

//                    // Check if the request was successful
//                    if (response.IsSuccessStatusCode)
//                    {
//                        // Read and display the response content
//                        string content = await response.Content.ReadAsStringAsync();
//                        Console.WriteLine(content);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Error: Unable to retrieve data. Status code: " + response.StatusCode);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Error: " + ex.Message);
//                }
//            }

//        }











//    }
//}














































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