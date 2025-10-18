using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public static class MatrixHelper
    {
        public static bool IsColumnPositive(double[] column)
        {
            if (column == null || column.Length == 0)
                return false;

            foreach (double x in column)
                if (x <= 0)
                    return false;

            return true;
        }

        public static int[] FindPositiveColumns(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            var list = new System.Collections.Generic.List<int>();

            for (int j = 0; j < cols; j++)
            {
                double[] col = new double[rows];
                for (int i = 0; i < rows; i++)
                    col[i] = matrix[i, j];

                if (IsColumnPositive(col))
                    list.Add(j + 1); // нумерация с 1
            }

            return list.ToArray();
        }
    }
}