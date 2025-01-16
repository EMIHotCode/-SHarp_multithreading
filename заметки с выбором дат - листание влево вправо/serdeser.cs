using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_ezhednevnik2
{
    internal class serdeser
    {
        private static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "your_notes.json");

        public static void Serialize<T>(T data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        public static T Deserialize<T>()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            else
            {
            
                File.Create(filePath).Close();
                return default(T);
            }
        }
    }
}
