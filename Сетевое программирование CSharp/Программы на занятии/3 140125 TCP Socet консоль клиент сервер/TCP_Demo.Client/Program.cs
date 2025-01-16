using System.Net;
using System.Net.Sockets;
using System.Text;

var ip = IPAddress.Parse("127.0.0.1");
var port = 65000;

var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
await server.ConnectAsync(ip, port);

var stream = new NetworkStream(server);

while (true)
{
    var responseData = new byte[1024];
    var bytes = await stream.ReadAsync(responseData);
    var response = Encoding.UTF8.GetString(responseData, 0, bytes);
    Console.WriteLine(response);
    
    var text2 = Console.ReadLine();
    var buffer2 = Encoding.UTF8.GetBytes(text2);
    await stream.WriteAsync(buffer2);
}


