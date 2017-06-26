using System;

namespace _02_KnightGame
{
    class Startup
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine().Trim());
            var matrix = new int[size, size];
            int knightsRemoved = 0;

            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine().Trim();
                for (int j = 0; j < size; j++)
                {
                    if (input[j] == 'K') matrix[i, j] = 1;
                }
            }

            for (int maxAttacks = 8; maxAttacks > 0; maxAttacks--)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i, j] == 1 && KnightsAttacked(i, j, matrix, size) == maxAttacks)
                        {
                            matrix[i, j] = 0;
                            knightsRemoved++;
                        }
                    }
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        private static int KnightsAttacked(int x, int y, int[,] matrix, int size)
        {
            int count = 0;
            if (IsInMatrix(x + 2, y + 1, size) && matrix[x + 2, y + 1] == 1) count++;
            if (IsInMatrix(x + 1, y + 2, size) && matrix[x + 1, y + 2] == 1) count++;
            if (IsInMatrix(x - 1, y + 2, size) && matrix[x - 1, y + 2] == 1) count++;
            if (IsInMatrix(x - 2, y + 1, size) && matrix[x - 2, y + 1] == 1) count++;
            if (IsInMatrix(x - 2, y - 1, size) && matrix[x - 2, y - 1] == 1) count++;
            if (IsInMatrix(x - 1, y - 2, size) && matrix[x - 1, y - 2] == 1) count++;
            if (IsInMatrix(x + 1, y - 2, size) && matrix[x + 1, y - 2] == 1) count++;
            if (IsInMatrix(x + 2, y - 1, size) && matrix[x + 2, y - 1] == 1) count++;

            return count;
        }

        private static bool IsInMatrix(int x, int y, int size)
        {
            if (0 <= x && x < size && 0 <= y && y < size)
            {
                return true;
            }
            return false;
        }
    }
}