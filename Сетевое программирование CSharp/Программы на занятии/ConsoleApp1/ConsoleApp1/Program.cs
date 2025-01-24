Random rnd = new Random();

string[] names =
{
    "Ефремов Михаил Иванович",
    "Астахов Артем Сергеевич",
    "Казанцев Кирилл Александрович",
    "Колдин Иван Александрович",
    "Кривошта Татьяна Юрьевна",
    "Курманаев Сергей Петрович",
    "Меркин Артем Валерьевич",
    "Старинин Андрей Николаевич",
    "Тарановский Дмитрий Андреевич",
    "Тумоякова Светлана Андреевна",
    "Усманов Владимир Рустамович",
    "Царевская Элина Роальдовна",
    "Чугайнов Андрей Алексеевич",
    "Макаренко Дмитрий Михайлович"
};
names = names.OrderBy(s => rnd.Next()).ToArray();

int commandNum = 1;
int num = 0;
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"\nКомманда {commandNum}");
    while (num < 3)
    {
        if (i + num < names.Length)
        {
            Console.WriteLine(names[i+num]);
        }
        num++;
    }
    i+= 2;
    num = 0;
    commandNum++;
}
Console.WriteLine("\n\n\n");