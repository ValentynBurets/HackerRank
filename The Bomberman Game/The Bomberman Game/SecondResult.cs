using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Bomberman_Game
{
    public static class SecondResult
    {

        /*
         * Complete the 'bomberMan' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. STRING_ARRAY grid
         */

        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n < 2) {
                return grid; 
            }

            int StringQuantity = grid.Count;
            int StringLength = grid[0].Length;

            List<StringBuilder> sbPlantedGrid = new List<StringBuilder>();

            List<StringBuilder> sbGrid = new List<StringBuilder>();

            StringBuilder planedGrid = new StringBuilder("", StringLength);

            for(int i = 0; i < StringLength; i++)
            {
                planedGrid.Append("O");
            }

            string planedStringGrid = planedGrid.ToString();

            for(int i = 0; i < StringQuantity; i++)
            {
                StringBuilder stringBuilder = new StringBuilder(planedStringGrid, StringLength);

                sbGrid.Add(stringBuilder);
            }

            foreach (var item in grid)
            {
                sbPlantedGrid.Add(new StringBuilder(item, StringLength));
            }


            if (n % 2 == 0)
            {
                return new List<string>(sbGrid.Select(a => a.ToString()));
            }

            bool burst = false;

            string tempString = "";
            int bombIndex = -1;
            int left, right;

            for (int t = 2; t <= n; t++)
            {

                if (burst)
                {
                    for (int sNumber = 0; sNumber < StringQuantity; sNumber++)
                    {
                        tempString = sbGrid[sNumber].ToString();

                        bombIndex = tempString.IndexOf('O');

                        while (bombIndex >= 0)
                        {
                            //(i+-1,j)
                            left = bombIndex - 1;
                            right = bombIndex + 1;
                            if (left < 0)
                            {
                                left = 0;
                            }
                            if (right >= sbPlantedGrid[sNumber].Length - 1)
                            {
                                right = sbPlantedGrid[sNumber].Length - 1;
                            }
                            sbPlantedGrid[sNumber].Replace('O', '.', left, right - (left - 1));

                            //(i,j+-1)
                            int sNumberI = (sNumber - 1) >= 0 ? (sNumber - 1) : 0;
                            for (; sNumberI <= sNumber + 1 && sNumberI <= (StringQuantity - 1); sNumberI++)
                            {
                                sbPlantedGrid[sNumberI].Replace('O', '.', bombIndex, 1);
                            }

                            bombIndex = tempString.IndexOf('O', bombIndex + 1);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < StringQuantity; i++)
                    {
                        sbGrid[i].Clear();
                        sbGrid[i].Append(sbPlantedGrid[i].ToString());
                        sbPlantedGrid[i] = new StringBuilder(planedStringGrid, StringLength);
                    }
                }

                burst = !burst;
            }
            return new List<string>(sbPlantedGrid.Select(a => a.ToString()));
        }
    }
}
