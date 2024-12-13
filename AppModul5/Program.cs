using System;
class Program
{
    static void Main()
    {
        var (name, surname, age, hasPet, petNum, petNames, colorNum, colorNames) = GetUser();
        DataOutput(name, surname, age, hasPet, petNum, petNames, colorNum, colorNames);
    }

    static (string, string, byte, bool, byte, string[], byte, string[]) GetUser()
    {
        Console.WriteLine("Введите имя пользователя:");
        string name = CheckWord();

        Console.WriteLine("Введите фамилию пользователя:");
        string surname = CheckWord();

        Console.WriteLine("Введите возраст пользователя:");
        byte age = CheckNum();

        bool hasPet = ChoisePet();
        byte petNum = 0;
        string[] petNames = Array.Empty<string>(); // Инициализация пустого массива

        if (hasPet)
        {
            Console.WriteLine("Введите количество питомцев пользователя:");
            petNum = CheckNum();
            petNames = NamesPets(petNum);
        }
        byte colorNum = 0;
        string[] colorNames = Array.Empty<string>();
        Console.WriteLine("Введите количество любимых цветов пользователя:");
        colorNum = CheckNum();
        colorNames = NamesColors(colorNum);


        return (name, surname, age, hasPet, petNum, petNames, colorNum, colorNames);
    }

    static bool ChoisePet()
    {
        Console.WriteLine("Есть ли у пользователя питомец?");
        int top = Console.CursorTop;
        int y = top;

        Console.WriteLine("Да");
        Console.WriteLine("Нет");
        int down = Console.CursorTop;

        Console.CursorSize = 100;
        Console.CursorTop = top;

        ConsoleKey key;
        while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
        {
            if (key == ConsoleKey.UpArrow)
            {
                if (y > top)
                {
                    y--;
                    Console.CursorTop = y;
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                if (y < down - 1)
                {
                    y++;
                    Console.CursorTop = y;
                }
            }
        }

        // Восстанавливаем курсор на нужную строку
        Console.CursorTop = down;

        return y == top; // Возврат true, если выбрано "Да"
    }

    static string[] NamesPets(byte petNum)
    {
        string[] names = new string[petNum];

        for (int i = 0; i < petNum; i++)
        {
            Console.WriteLine($"Введите кличку {i + 1}го питомца:");
            names[i] = CheckWord();
        }

        return names;
    }

    static string[] NamesColors(byte colorNum)
    {
        string[] colors = new string[colorNum];

        for (int i = 0; i < colorNum; i++)
        {
            Console.WriteLine($"Введите название {i + 1}го любимого цвета:");
            colors[i] = CheckWord();
        }

        return colors;
    }

    static byte CheckNum()
    {
        byte result = 0;
        while (true)
        {
            bool flag = byte.TryParse(Console.ReadLine(), out byte number);
        if (flag == false || number > 110)
            {
                Console.WriteLine("Число может быть от 0 до 110 включительно");
            }
            else
            {
                result = number;
                break;
            }
        }
        return result;
    }

    static string CheckWord()
    {
        string result = string.Empty; // Инициализация пустой строки
        while (true)
        {
            Console.WriteLine("Ввод(максимум 20 символов):");
            string word = Console.ReadLine();

            // Проверяем, если слово корректно и длина не превышает 20 символов
            if (string.IsNullOrWhiteSpace(word) || word.Length > 20)
            {
                Console.WriteLine("Слово не должно превышать 20 символов");
            }
            else
            {
                result = word; // Присваиваем значение
                break; // Выход из цикла
            }
        }
        return result;
    }
    static void DataOutput(string name, string surname, byte age, bool hasPet, byte petNum, string[] petNames, byte colorNum, string[] colorNames)
    {
        Console.WriteLine($"Имя: {name}, Фамилия: {surname}, Возраст: {age}");

        if (hasPet)
        {
            Console.WriteLine($"У пользователя {petNum} питомца(цев): {string.Join(", ", petNames)}");
        }
        else
        {
            Console.WriteLine("У пользователя нет питомцев");
        }
        if (colorNum != 0)
        {
            Console.WriteLine($"У пользователя {colorNum} любимых цвета(ов): {string.Join(", ", colorNames)}");
        }
        else
        {
            Console.WriteLine("У пользователя нет любимых цветов");
        }
    }
}