using System.Net.Http;
using System.Windows;

namespace WebAPI_Demo.Desktop;


public partial class App : Application
{
    public static readonly HttpClient HttpClient = new HttpClient();
}