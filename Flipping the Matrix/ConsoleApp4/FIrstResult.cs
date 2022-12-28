using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class FirstResult
    {
        /*
  * Complete the 'flippingMatrix' function below.
  *
  * The function is expected to return an INTEGER.
  * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
  */

        public static int flippingMatrix(List<List<int>> matrix)
        {
            int n = matrix.Count / 2;


            for (int i = 0; i < 2 * n; i++)
            {
                int leftRowSum = 0;
                int rightRowSum = 0;

                for (int j = 0; j < n; j++)
                {
                    leftRowSum += matrix[i][j];
                    rightRowSum += matrix[i][(2 * n - 1) - j];
                }
                if (leftRowSum < rightRowSum)
                {
                    matrix[i].Reverse();
                }
            }

            for (int i = 0; i < 2 * n; i++)
            {
                int topSum = 0;
                int bottomSum = 0;

                for (int j = 0; j < n; j++)
                {
                    topSum += matrix[j][i];
                    bottomSum += matrix[(2 * n - 1) - j][i];
                }

                if (topSum < bottomSum)
                {
                    int tempValue;
                    int index = 1;
                    int N = matrix.Count;

                    for (int j = 0; j < N / 2; j++)
                    {
                        tempValue = matrix[j][index];
                        matrix[j][index] = matrix[N - 1 - i][index];
                        matrix[N - 1 - i][index] = tempValue;
                    }
                }
            }

            int Sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Sum += matrix[i][j];
                }
            }

            return Sum;
        }
    }
}
