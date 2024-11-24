using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Зчитуємо вхідні дані
        string[] input = File.ReadAllLines("INPUT.TXT");

        // Кількість стареньких
        int N = int.Parse(input[0]);

        // Рівні балакучості
        int[] chatterLevels = input[1].Split().Select(int.Parse).ToArray();

        // Сортуємо рівні балакучості для оптимального розбиття
        Array.Sort(chatterLevels);

        // Змінна для мінімальної балакучості
        int minChatterLevel = int.MaxValue;

        // Перевіряємо різницю між кожними двома сусідніми елементами після сортування
        for (int i = 0; i < N - 1; i++)
        {
            int difference = chatterLevels[i + 1] - chatterLevels[i];
            minChatterLevel = Math.Min(minChatterLevel, difference);
        }

        // Записуємо результат у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", minChatterLevel.ToString());
    }
}
