using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using WindGeneratorLib;

namespace UDPBroadcast {
    internal class Program {
        static void Main(string[] args) {
            using (UdpClient socket = new UdpClient()){
                while (true){
                    WindData testData = new WindData();
                    testData.Direction = testData.NextDirection();
                    testData.Speed = testData.NextSpeed();


                    string serializedData = JsonSerializer.Serialize(testData);

                    byte[] data = Encoding.UTF8.GetBytes(serializedData);

                    socket.Send(data, data.Length, "255.255.255.255", 6010);

                    Console.WriteLine(serializedData);
                    
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
