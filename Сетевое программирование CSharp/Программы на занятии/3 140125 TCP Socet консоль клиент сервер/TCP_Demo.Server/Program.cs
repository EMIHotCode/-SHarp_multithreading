using System.Net;
using System.Net.Sockets;
using System.Text;
// IPEndPoint специальный класс который используется чтобы сокет посавить на прослушку
var ip = new IPEndPoint(IPAddress.Any, 65000); // IPAddress.Any - назначается наиболее подходящий сетевой адрес 
var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // создаем сокет со стандартными параметрами
server.Bind(ip); // вызываем метод в который передаем номер порта и ip 
server.Listen(2);  // сколько приложений будет подключаться к серверу

    var client = await server.AcceptAsync();

    var stream = new NetworkStream(client); // 

    var buffer = new byte[1024];
    buffer = Encoding.UTF8.GetBytes("Привет!");
    await stream.WriteAsync(buffer);

    while (true)
    {
        var responseData = new byte[1024];
        var bytes = await stream.ReadAsync(responseData);
        var response = Encoding.UTF8.GetString(responseData, 0, bytes); // получаем строку из байтового массива
        Console.WriteLine(response);
        
        var buffer2 = Encoding.UTF8.GetBytes($"Ваше сообщение {response} получено");;
        await stream.WriteAsync(buffer2);
    }