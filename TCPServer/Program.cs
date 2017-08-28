using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {

            startServerAsync();
            Console.ReadKey();
        }

        static void startServerAsync()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAddress = IPAddress.Parse("192.168.0.3");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);
            serverSocket.Bind(ipEndPoint);//绑定ip和端口号
            serverSocket.Listen(0);//开始监听端口号

            //Socket clientSocket = serverSocket.Accept();//接收一个客户端链接
            serverSocket.BeginAccept(AcceptCallBack, serverSocket);


        }

        static Message msg = new Message();

        static void AcceptCallBack(IAsyncResult ar)
        {
            Socket serverSocket = ar.AsyncState as Socket;
            Socket clientSocket = serverSocket.EndAccept(ar);

            //向客户端发送一条信息
            string msgStr = "Hello client!你好...";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msgStr);
            clientSocket.Send(data);


            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, clientSocket);

            serverSocket.BeginAccept(AcceptCallBack, serverSocket);
        }

        static byte[] dataBuffer = new byte[1024];
        static void ReceiveCallBack(IAsyncResult ar)
        {
            Socket clientSocket = null;//= ar.AsyncState as Socket;
            try
            {
                clientSocket = ar.AsyncState as Socket;
                int count = clientSocket.EndReceive(ar);
                if (count == 0)
                {
                    clientSocket.Close();
                    return;
                }
                msg.AddCount(count);
                //string msgStr = Encoding.UTF8.GetString(dataBuffer, 0, count);
                //Console.WriteLine("从客户端接收到数据：" + msgStr);

                //clientSocket.BeginReceive(dataBuffer, 0, 1024, SocketFlags.None, ReceiveCallBack, clientSocket);
                clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, clientSocket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (clientSocket != null)
                {
                    clientSocket.Close();
                }
            }
            finally
            {

            }
        }

        void startServerSync()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAddress = IPAddress.Parse("192.168.0.4");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);
            serverSocket.Bind(ipEndPoint);//绑定ip和端口号
            serverSocket.Listen(0);//开始监听端口号
            Socket clientSocket = serverSocket.Accept();//接收一个客户端链接

            //向客户端发送一条信息
            string msg = "Hello client!你好...";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);

            //接收客户端的一条信息
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine(msgReceive);

            clientSocket.Close();
            serverSocket.Close();

            Console.ReadLine();
        }
    }
}
