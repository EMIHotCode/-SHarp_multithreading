using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_ezhednevnik2
{
    public class Zametka
    {
        public Zametka(string named, string desc, DateTime dataz)
        {
            name = named;
            description = desc;
            data = dataz;
        }

        public string name;
        public string description;
        public DateTime data;
    }
}
