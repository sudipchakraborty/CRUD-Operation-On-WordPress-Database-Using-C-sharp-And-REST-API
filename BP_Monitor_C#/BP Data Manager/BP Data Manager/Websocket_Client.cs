using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;

// install WebSocketSharp-NonPreRelease by sta, swiftyspiffy (cole)

namespace Tools
{
    public class Websocket_Client
    {
        WebSocket ws;

    public Websocket_Client()
    {

    }

    public bool open(string url="ws://localhost:8088")
    {
        ws = new WebSocket(url);
        ws.OnMessage +=ws_OnMessage;
        ws.Connect();       
        return true;   
    }

    private void ws_OnMessage(object sender, MessageEventArgs e)
    {
       string s="Received from Server"+e.Data;
    }

    public void close()
    {
        if(ws!= null)
        {
            ws.Close();
        }
    }

    public void send(string message)
    {
        try
        {
            if(ws != null)
            {
                ws.Send(message);
            } 
        }
        catch(Exception ex)
        {
            string s= ex.ToString();
        }
    }

















    }
}
