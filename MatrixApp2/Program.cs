using System;
using MatrixLib;

namespace MatrixApp
{
    class Program
    {
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0 && value <= 10)
                    return value;
                Console.WriteLine("Введите целое число от 1 до 10.");
            }
        }

        static double[,] ReadMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("Строка {0}:", i + 1);
                string line = Console.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Ошибка ввода.");
                    Environment.Exit(1);
                }

                // Используем Split с явным разделителем ' ' и StringSplitOptions
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols && j < parts.Length; j++)
                {
                    if (!double.TryParse(parts[j], out double num))
                    {
                        Console.WriteLine("Некорректное число. Будет использовано 0.");
                        num = 0.0;
                    }
                    matrix[i, j] = num;
                }
            }
            return matrix;
        }

        static void PrintResult(int[] cols, string name)
        {
            Console.WriteLine("\nРезультат для {0} матрицы:", name);
            if (cols.Length == 0)
                Console.WriteLine("Нет столбцов с только положительными элементами.");
            else
                Console.WriteLine("Подходящие столбцы: " + string.Join(", ", cols));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Анализ столбцов матриц (размер до 10x10)\n");

            // Первая матрица
            int r1 = ReadInt("Строки первой матрицы (1-10): ");
            int c1 = ReadInt("Столбцы первой матрицы (1-10): ");
            double[,] m1 = ReadMatrix(r1, c1);

            // Вторая матрица
            int r2 = ReadInt("Строки второй матрицы (1-10): ");
            int c2 = ReadInt("Столбцы второй матрицы (1-10): ");
            double[,] m2 = ReadMatrix(r2, c2);

            // Обработка
            int[] res1 = MatrixHelper.FindPositiveColumns(m1);
            int[] res2 = MatrixHelper.FindPositiveColumns(m2);

            // Вывод
            PrintResult(res1, "первой");
            PrintResult(res2, "второй");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}