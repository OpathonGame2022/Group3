using System.Net;
using System.Net.Sockets;
using System.Text;

public class GetSocket
{
    private const int port = 80;
    private const string ipv6_addr = "854d:0477:1ee6:8743::";

    private static Socket ConnectSocket()
    {
        IPAddress ip = IPAddress.Parse(ipv6_addr);
        IPEndPoint ipeh = new IPEndPoint(ip, port);
        Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(ipeh);
        if(socket.Connected)
        {
            Console.Error.WriteLine("Error connecting!");
        }

        return socket;
    }

    private static string sendAndReceive(string encoding)
    {
        Byte[] byteSent = Encoding.ASCII.GetBytes(encoding);
        Byte[] byteReceived = new byte[256];

        using(Socket s = ConnectSocket())
        {
            if (s == null) return ("Connection failed!");
            s.Send(byteSent);
            s.Receive(byteReceived);
        }
        return Encoding.ASCII.GetString(byteReceived);
    }
    public static void Main()
    {
        // to be changed to allow for customized inputs
        string encoding = "f57dtEG7NUGRJi9D8nJsV8qRXsBTiEAikjRZy+bpxT7GBtfIavkt1ogl9hpRBWZyFFXlDy9eu8sz0i3NrRFzAlhKyuqjR3Cltn8hrvh0e+rRMy+SBk5mSqfaZBm9prfiFYUqmuMNJPu8gT5WwmrJm4kAHVymoditkDq7VFVpJq75sBxVlr8TmcY9VpsobeNB/7xCuX8Q9RhYRlKiuj+1pVmwUYGSU3C5t+FyHtM/pbg=";
        Console.WriteLine(sendAndReceive(encoding));
        
    }
}