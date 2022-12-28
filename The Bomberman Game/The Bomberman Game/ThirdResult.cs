using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Bomberman_Game
{
    public static class ThirdResult
    {
        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n < 2 || n % 2 == 0)
            {
                return grid;
            }

            int StringQuantity = grid.Count;
            int StringLength = grid[0].Length;

            List<StringBuilder> sbPlantedGrid = grid.Select(x => new StringBuilder(x, StringLength)).ToList();

            List<StringBuilder> sbGrid = new List<StringBuilder>();

            List<StringBuilder> InitialPlantedGrid = new List<StringBuilder>();

            StringBuilder InitialPlanedStringBuilder = new StringBuilder("", StringLength);

            for (int i = 0; i < StringLength; i++)
            {
                InitialPlanedStringBuilder.Append("O");
            }

            string InitialPlanedString = InitialPlanedStringBuilder.ToString();

            for (int i = 0; i < StringQuantity; i++)
            {
                InitialPlantedGrid.Add(new StringBuilder(InitialPlanedString, StringLength));
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
                            if (right >= StringLength - 1)
                            {
                                right = StringLength - 1;
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
                    sbGrid = new List<StringBuilder>(sbPlantedGrid);
                    sbPlantedGrid = new List<StringBuilder>(InitialPlantedGrid);
                }

                burst = !burst;
            }
            return new List<string>(sbPlantedGrid.Select(a => a.ToString()));
        }
    }
}
