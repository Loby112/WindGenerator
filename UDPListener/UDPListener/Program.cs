using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WindGeneratorLib;

namespace UDPListener {
    internal class Program {
        static void Main(string[] args) {
            using (UdpClient socket = new UdpClient()){

                string url = "https://windrestapi20220608211201.azurewebsites.net/api/Wind";

                socket.Client.Bind(new IPEndPoint(IPAddress.Any, 6010));

                using (HttpClient client = new HttpClient()){

                
                    IPEndPoint clientEndPoint = null;

                    while (true){
                        byte[] data = socket.Receive(ref clientEndPoint);

                        string message = Encoding.UTF8.GetString(data);

                        WindData windObject = JsonSerializer.Deserialize<WindData>(message);

                        HttpContent content = new StringContent(message, Encoding.UTF8, "text/json");

                        client.PostAsync(url, content);
                        Console.WriteLine("Direction " + windObject.Direction);
                        Console.WriteLine("Speed " + windObject.Speed);

                    }
                }
            }
        }
    }
}
