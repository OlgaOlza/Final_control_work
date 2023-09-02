﻿// Задание: Написать программу, которая из имеющегося массива строк,
// формирует массив из строк, длина которых меньше или равна 3 символа.
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.
// Примеры:
// ["hello", "2", "world", ":-)"] -> ["2",":-)"]
// ["1234", "1567", "-2", "computer science"] -> ["-2"]
// ["Russia", "Denmark", "Kazan"] -> []


// Метод проверки ввода.
string UserText(string text, string message)
{
    Console.WriteLine(message);
    while (string.IsNullOrWhiteSpace(text = Console.ReadLine()))
    {
        Console.WriteLine($"Строка не должна быть пустой!\n{message}");
    }
    return text;
}

// Метод удаления лишних пробелов.
string ExtraSpaceRemover(string text)
{
    while (text[0] == ' ') text = text.Remove(0, 1);
    while (text[text.Length - 1] == ' ') text = text.Remove(text.Length - 1, 1);
    for (int i = 1; i < text.Length - 1; i++)
    {
        while (text[i] == ' ' && text[i - 1] == ' ') text = text.Remove(i - 1, 1);
    }
    return text;
}

// Метод определения размера будущего массива.
int StringArraySizer(string text)
{
    int size = 1;
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] == ' ')
        {
            size++;
        }
    }
    return size;
}

// Метод записи значений в массив.
string[] StringArrayMaker(string text, int size)
{
    int count = default;
    string[] array = new string[size];
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] != ' ')
        {
            array[count] += text[i];
        }
        else count++;
    }
    return array;
}

// Метод вывода на экран всего массива.
void StringArrayPrinter(string[] text)
{
    Console.Write("\n[");
    for (int i = 0; i < text.Length; i++)
    {
        if (i < text.Length - 1) Console.Write($"\"{text[i]}\",");
        else Console.Write($"\"{text[i]}\"");
    }
    Console.Write("]");
}

// Метод вывода нужных элементов массива.
void CroppedStringArrayPrinter(string[] text)
{
    int count = default;
    Console.Write("[");
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i].Length < 4)
        {
            count++;
            Console.Write($"\"{text[i]}\",");
        }
    }
    if (count > 0)
    {
        (int, int) CursorPosition = Console.GetCursorPosition();
        Console.SetCursorPosition(CursorPosition.Item1 - 1, CursorPosition.Item2);
    }
    Console.WriteLine("]");
}
{
    Console.Clear();

    string userText = String.Empty;

// Запрос ввода от пользователя и удаление лишних пробелов.
    userText = UserText(userText, "Введите текст:");
    userText = ExtraSpaceRemover(userText);
// Определение размера будущего массива.
    int arraySize = StringArraySizer(userText);
// Создание, запись и печать массива.
    string[] stringArray = StringArrayMaker(userText, arraySize);
    StringArrayPrinter(stringArray);
    Console.Write(" -> ");
    CroppedStringArrayPrinter(stringArray);
}