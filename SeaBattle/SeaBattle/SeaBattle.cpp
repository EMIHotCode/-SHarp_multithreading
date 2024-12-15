//#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <cstring>
#include <cstdio>
#include <windows.h>
#include <math.h>
#include <ctime>
#include <fstream>

using namespace std;

const int N = 10;  // определяет размер поля

void set_rand_ships(int map[N][N], int size_ship, int num_ships)
{
    int x, y;      // координаты первичного квадата корабля откуда он будет расти
    int dir = 0;  // генерация случайного направления роста корабля в 4 разные стороны
    int count_ship = 0;
    int count_tact = 0;// предохранительный счетчик от зацикливания программы

    // генерация кораблей (расстановка на поле ) наращивание из одной точки, если чтото мешает отменяем процедуру и повторяем заново

    while (count_ship < num_ships)
    {
        count_tact++;
        if (count_tact > 1000) // если предохранительный счетчик отработал 1000 раз и не смог завершится то принудительно прерываем
        {
            break;
        }
        // первичная позиция 
        y = rand() % N;
        x = rand() % N;

        int temp_x = x;
        int temp_y = y;

        bool setting_is_possible = 1; // возможность постановки корабля - по умолчанию true

        // генерация направления 
        dir = rand() % 4;

        // проверка возможности постановки корабля 
        for (int i = 0; i < size_ship; i++)
        {
            if (x < 0 || y < 0 || x >= N || y >= N)
            {
                setting_is_possible = 0;  // невозможно поставить корабль
                break;
            }

            if (map[x][y] == 1 ||  // проверка чтобы корабли не накладывались друг на друга (все ячейки вокруг выбраной ячейки)
                map[x][y + 1] == 1 ||
                map[x][y - 1] == 1 ||
                map[x + 1][y] == 1 ||
                map[x + 1][y + 1] == 1 ||
                map[x + 1][y - 1] == 1 ||
                map[x - 1][y] == 1 ||
                map[x - 1][y + 1] == 1 ||
                map[x - 1][y - 1] == 1)
            {
                setting_is_possible = 0;
                break;
            }

            switch (dir)
            {
            case 0:
                x++;
                break;
            case 1:
                y++;
                break;
            case 2:
                x--;
                break;
            case 3:
                y--;
                break;
            }
        }

        // если есть возможность поставить корабль ставим
        if (setting_is_possible)
        {
            x = temp_x;
            y = temp_y;

            for (int i = 0; i < size_ship; i++)  // 5 это количество палуб корабля
            {
                switch (dir)  // выбралось направление dir куда будет расти корабль
                {
                case 0:
                    map[x][y] = 1;   // расти корабль будет вправо по координате х
                    x++;
                    break;

                case 1:
                    map[x][y] = 1;   // расти корабль будет вверх по координате y
                    y++;
                    break;

                case 2:
                    map[x][y] = 1;   // расти корабль будет влево по координате х
                    x--;
                    break;

                case 3:
                    map[x][y] = 1;
                    y--;
                    break;
                }
            }
            count_ship++;
        }
    }
}

void map_show(int map[N][N], int mask[N][N])  // вывод игрового поля на экран с туманом невидимости кораблей
{
    // прорисовка сетки координат поля по горизонтали
    cout << ' ';
    for (int i = 0; i < N; i++)
    {
        cout << i;
    }
    cout << endl;


    // прорисовка матрицы на экран
    for (int i = 0; i < N; i++)
    {
        cout << i; // прорисовка сетки координат поля по вертикали
        for (int j = 0; j < N; j++)
        {
            if (mask[j][i] == 1)
            {
                if (map[j][i] == 1)
                {
                    cout << 'X';
                }
                else
                {
                    cout << map[j][i];
                }
            }
            else
            {
                cout << '~';  // вывод тумана
            }


        }
        cout << endl;
    }
}


int main()
{
    setlocale(LC_ALL, "Rus");


    while (true)
    {
        int map[N][N] = { 0 };
        int mask[N][N] = { 0 };

        set_rand_ships(map, 4, 1);
        set_rand_ships(map, 3, 2);
        set_rand_ships(map, 2, 3);
        set_rand_ships(map, 1, 4);



        int x = 0, y = 0;

        while (true) // 
        {
            map_show(map, mask);
            cout << "Введите координаты цели: " << endl;

            cin >> x;
            cin >> y;

            if (map[x][y] == 1)
            {
                cout << "Попал" << endl;
                mask[x][y] = 1;
            }
            else
                cout << "Промах" << endl;

            Sleep(1000);
            system("cls");
        }

        _getch();
        system("cls");
    }

    system("pause");
    return 0;
}

//     while (true)    // реализация игры 
//     {
//         cout << "Введите координаты цели: " << endl;

//         cin >> x;
//         cin >> y;

//         if (map[x][y] == 1)
//         {
//             cout << "Попал" << endl;
//             map[x][y] = '-';


//                 bool ship_detect = false; 
//                 for (int i=0; i<N; i++)     //  определение наличия кораблей на поле
//                 {
//                     for (int j=0; j<N; j++)
//                     {
//                         if (map[j][i] == 1)
//                         {
//                             ship_detect = true;
//                             break;      // чтобы не проверять все ячейки массива на наличие кораблей, а хотябы наличие одного корабля вызывать true; break;
//                         }
//                     }
//                 if (ship_detect == true)
//                 {
//                     break;
//                 }
//                 }
//                 if (ship_detect == false)
//                 {
//                     cout << "Вы победили!!!" << endl;
//                     break;
//                 }


//         }
//         else
//         {
//             cout << "Промах" << endl;
//         }
//     }


// }