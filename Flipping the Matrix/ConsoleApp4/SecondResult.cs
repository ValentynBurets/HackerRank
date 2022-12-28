using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class SecondResult
    {
        public static int flippingMatrix(List<List<int>> matrix)
        {
            int n = matrix.Count / 2;

            int m = matrix.Count - 1;

            int s = 0;

            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    s += Max(new int[]{ matrix[i][j], matrix[i][m - j], matrix[m - i][j], matrix[m - i][m - j]});
                }
            }

            return s;
        }

        public static T MaxBy<T>(this IEnumerable<T> items) where T : IComparable<T>
        {
            return items.Aggregate((a, b) => a.CompareTo(b) > 0 ? a : b);
        }

        public static int Max(this IEnumerable<int> items)
        {
            return items.Aggregate((a, b) => a.CompareTo(b) > 0 ? a : b);
        }
    }
}
