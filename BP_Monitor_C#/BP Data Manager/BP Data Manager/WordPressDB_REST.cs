using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Tools
{
    public class WordPressDB_REST
    {
        public string server;
        public string port;
        public string Database;
        public String Uid;
        public String Pwd;
        public String route;
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
        public WordPressDB_REST(string server, string port, string Database, String Uid, String Pwd, string route)
        {
            this.server = server;
            this.port = port;
            this.Database = Database;
            this.Uid = Uid;
            this.Pwd = Pwd;
            this.route = route;
        }

        /// <summary>
        /// @brief This asynchronous function is used to send the Data to the server and read the response from the server
        /// @param data = json structured to send
        /// @return the server response is stored inside the  "str_response" string veriable 
        /// </summary>
        public async Task send(object data)
        {
            HttpClient client = new HttpClient();
            string base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Uid}:{Pwd}"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Auth);

            //Tranform it to Json object
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            // Create the HTTP content from the JSON data
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            HttpResponseMessage response = await client.PostAsync(route, content);
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

    }//class
}//ns
     