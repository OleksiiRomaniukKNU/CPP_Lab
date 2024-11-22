using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Читаємо вхідні дані
        var input = File.ReadAllText("INPUT.TXT").Split();
        int S = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        // Знаходимо мінімальне число
        string minNumber = GetMinNumber(S, K);

        // Знаходимо максимальне число
        string maxNumber = GetMaxNumber(S, K);

        // Записуємо результати у вихідний файл
        File.WriteAllText("OUTPUT.TXT", $"{minNumber} {maxNumber}");
    }

    static string GetMinNumber(int sum, int digits)
    {
        char[] result = new char[digits];
        Array.Fill(result, '0');

        // Мінімальне число починається з 1 (немає лідуючих нулів)
        result[0] = '1';
        sum--;

        for (int i = digits - 1; i >= 0 && sum > 0; i--)
        {
            int add = Math.Min(9, sum);
            result[i] += (char)add;
            sum -= add;
        }

        return new string(result);
    }

    static string GetMaxNumber(int sum, int digits)
    {
        char[] result = new char[digits];
        for (int i = 0; i < digits && sum > 0; i++)
        {
            int add = Math.Min(9, sum);
            result[i] = (char)('0' + add);
            sum -= add;
        }

        for (int i = 0; i < digits; i++)
        {
            if (result[i] == '\0')
                result[i] = '0';
        }

        return new string(result);
    }
}
