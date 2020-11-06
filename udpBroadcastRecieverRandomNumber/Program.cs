using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace udpBroadcastRecieverRandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // UdpClient 
            // when you are reading broadcast data -> you have to mention specific port no 
            UdpClient udpBroadcastReciever = new UdpClient(7000);
            // what is the IP address of Broadcaster 
            // 255.255.255.255
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Reciever is block until recieved message from Host device");

            try
            {
                while(true)
                {
                    Byte[] rcvdBytes = udpBroadcastReciever.Receive(ref ipEndPoint);
                    // convert byte into Message
                    string strMsg = Encoding.ASCII.GetString(rcvdBytes);
                    Console.WriteLine("The Message coming from Remote Host:" + strMsg);
                    Console.WriteLine("The Remote IP address" + ipEndPoint.Address + "and Port no:" + ipEndPoint.Port);
                    Thread.Sleep(1000);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
