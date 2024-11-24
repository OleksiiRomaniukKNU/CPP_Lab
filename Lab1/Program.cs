using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Зчитуємо вхідні дані
        string[] input = File.ReadAllText("INPUT.TXT").Split();
        int S = int.Parse(input[0]); // Сума цифр
        int K = int.Parse(input[1]); // Кількість цифр

        // Формуємо найменше число
        string smallest = GetSmallestNumber(S, K);
        
        // Формуємо найбільше число
        string largest = GetLargestNumber(S, K);

        // Записуємо результат у файл
        File.WriteAllText("OUTPUT.TXT", $"{largest} {smallest}");
    }

    static string GetSmallestNumber(int sum, int length)
    {
        char[] digits = new char[length];
        Array.Fill(digits, '0');
        digits[0] = '1'; // Забезпечуємо, щоб число не мало нулів на початку
        sum--;

        for (int i = length - 1; i >= 0 && sum > 0; i--)
        {
            int add = Math.Min(9 - (digits[i] - '0'), sum);
            digits[i] = (char)(digits[i] + add);
            sum -= add;
        }

        return new string(digits);
    }

    static string GetLargestNumber(int sum, int length)
    {
        char[] digits = new char[length];
        for (int i = 0; i < length && sum > 0; i++)
        {
            digits[i] = (char)(Math.Min(9, sum) + '0');
            sum -= digits[i] - '0';
        }

        for (int i = sum; i < length; i++)
        {
            if (digits[i] == '\0')
                digits[i] = '0';
        }

        return new string(digits);
    }
}
