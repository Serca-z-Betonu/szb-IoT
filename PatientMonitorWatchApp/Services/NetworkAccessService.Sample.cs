using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Tizen.Network.Connection;
using WebSocketSharp;
namespace PatientMonitorWatchApp.Services
{
    public partial class NetworkAccessService

    {
        private static string serverAddress = "ws://192.168.137.190:8088";
        WebSocket webSocket = new WebSocket(serverAddress);
        //webSocket += webSocket_OnMessage;
        /// <summary>
        /// This is a sample to demonstrate how to check the network state and connect to the internet on a watch
        /// More details about making web requests in .NET Core see
        /// https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
        /// </summary>
        public static void webSocket_OnMessage(object viewer, MessageEventArgs a) //function for server to respond
        {
            Console.WriteLine("Recived from the server " + a.Data);
        }
        public async Task SendWebRequestSampleAsync()
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            if (connection.Type == ConnectionType.Disconnected)
            {
                // TODO: There is no available connectivity as now
                return;
            }

            HttpClientHandler handler = null;
            HttpClient client = null;

            try
            {
                handler = new HttpClientHandler();

                // When a watch has a Bluetooth connection to a phone, a proxy to access the internet through the phone is served by default
                if (connection.Type == ConnectionType.Ethernet)
                {
                    var proxy = ConnectionManager.GetProxy(AddressFamily.IPv4);
                    handler.Proxy = new WebProxy(proxy, true);
                }

                client = new HttpClient(handler);
                var response = await client.GetStringAsync(new Uri("http://192.168.0.23:8000/"));

                // TODO: Insert code to process the response from a web server
                Logger.Info($"response: {response}");
            }
            finally
            {
                client?.Dispose();
                handler?.Dispose();
            }
        }

        public void PostData(Dictionary<string, string> data)
        {
            webSocket.Connect();
            webSocket.OnOpen += (sender, e) => {
                Logger.Info("DUPA123");
            };
            webSocket.Send(JsonConvert.SerializeObject(data));
            Logger.Info(JsonConvert.SerializeObject(data));
        }
        public void initConnection()
        {
            webSocket.OnMessage += webSocket_OnMessage;
        }
    }
}
