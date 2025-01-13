/*
 * Пример взят с сайта https://habr.com/ru/sandbox/44535/
 * используется сайт Погоды с открытым кодом https://www.meteoservice.ru/weather/overview/nizhniy-novgorod
 */
using System.Net;
using System.Text.RegularExpressions;

var http = new HttpClient();  // Для отправки HTTP-запросов в .NET применяется класс HttpClient 
var response = await http.GetAsync("https://www.meteoservice.ru/weather/overview/nizhniy-novgorod"); // получаем ответ от запроса 

if (response.IsSuccessStatusCode)
{
    var httpText = await response.Content.ReadAsStringAsync();
    string town = new Regex("(?:<meta.*?name=\"keywords\".*?)(.*?)(?:\\/>)").Match(httpText).Groups[0].Value;
    string temperature = new Regex("(<span.*?class=\"value\">)(.*?)(<\\/span>)").Match(httpText).Groups[0].Value;

    string[] wordsTown = town.Split(',');
    string[] wordsTemprature = temperature.Split('<', '>');
    
    town = wordsTown[2];
    temperature = wordsTemprature[2];
    Console.WriteLine($"\n\nВаш город: {town}");
    Console.WriteLine($"Температура за окном: {temperature}С");
}
