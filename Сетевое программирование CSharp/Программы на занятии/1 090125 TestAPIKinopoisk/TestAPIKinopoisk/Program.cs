using System.Text.Json;
using TestAPIKinopoisk;

var http = new HttpClient();  // Для отправки HTTP-запросов в .NET применяется класс HttpClient 
http.DefaultRequestHeaders.Add("X-API-KEY", "D8XPZ1P-ZJX4KHD-HY5TXHW-ZXNV21X"); // API сервис нуждается в дополнительной информации без которой не выполняется запрос

var response = await http.GetAsync("https://api.kinopoisk.dev/v1.4/movie/random"); // получаем ответ от запроса 

if (response.IsSuccessStatusCode)
{
    var json = await response.Content.ReadAsStringAsync();
    var result = JsonSerializer.Deserialize<KinopoiskRoot>(json); // воспользоваться дессиреализацией для возврата данных
    if (result.Name == null)
        Console.WriteLine("NoName");
    else
    Console.WriteLine(result.Name);
    //Console.WriteLine(result.Genres[0].Name);
}

/*
if (response.StatusCode == HttpStatusCode.Unauthorized)
{
    Console.WriteLine("Неавторизован");
    var str = await response.Content.ReadAsStreamAsync();
    Console.WriteLine(str);
}
*/
// Console.WriteLine(response.StatusCode.ToString());