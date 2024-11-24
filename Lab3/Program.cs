using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Зчитуємо вхідний шлях з файлу
        string input = File.ReadAllText("INPUT.TXT").Trim();

        // Використовуємо стек для нейтралізації протилежних рухів
        Stack<char> pathStack = new Stack<char>();

        foreach (char direction in input)
        {
            // Якщо стек не порожній, перевіряємо протилежний напрямок
            if (pathStack.Count > 0)
            {
                char last = pathStack.Peek();
                if ((last == 'N' && direction == 'S') || (last == 'S' && direction == 'N') ||
                    (last == 'E' && direction == 'W') || (last == 'W' && direction == 'E'))
                {
                    // Якщо напрямки протилежні, видаляємо останній елемент
                    pathStack.Pop();
                }
                else
                {
                    // Інакше додаємо поточний напрямок
                    pathStack.Push(direction);
                }
            }
            else
            {
                // Якщо стек порожній, просто додаємо поточний напрямок
                pathStack.Push(direction);
            }
        }

        // Формуємо зворотний шлях, перевертаючи залишкові елементи стеку
        StringBuilder reversePath = new StringBuilder();
        while (pathStack.Count > 0)
        {
            char direction = pathStack.Pop();
            // Додаємо відповідний зворотний напрямок
            switch (direction)
            {
                case 'N':
                    reversePath.Append('S');
                    break;
                case 'S':
                    reversePath.Append('N');
                    break;
                case 'E':
                    reversePath.Append('W');
                    break;
                case 'W':
                    reversePath.Append('E');
                    break;
            }
        }

        // Записуємо результат у файл
        File.WriteAllText("OUTPUT.TXT", reversePath.ToString());
    }
}
