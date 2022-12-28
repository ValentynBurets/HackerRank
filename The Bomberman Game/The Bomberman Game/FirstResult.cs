using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Bomberman_Game
{
    public static class FirstResult
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
            List<StringBuilder> sbPlantedGrid = new List<StringBuilder>();

            List<StringBuilder> sbGrid = new List<StringBuilder>();
            foreach (var item in grid)
            {
                sbGrid.Add(new StringBuilder(item, item.Count()));
                sbPlantedGrid.Add(new StringBuilder(item, item.Count()));
            }

            bool burst = false;

            for (int t = 2; t <= n; t++)
            {

                if (burst)
                {
                    for (int sNumber = 0; sNumber < sbGrid.Count; sNumber++)
                    {
                        for (int chNumber = 0; chNumber < sbGrid[sNumber].Length; chNumber++)
                        {

                            if (sbGrid[sNumber][chNumber].Equals('O'))
                            {

                                //(i+-1,j)
                                int left = chNumber - 1, right = chNumber + 1;
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
                                for (; sNumberI <= sNumber + 1 && sNumberI <= (sbGrid.Count - 1); sNumberI++)
                                {
                                    sbPlantedGrid[sNumberI].Replace('O', '.', chNumber, 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < sbPlantedGrid.Count; i++)
                    {
                        sbGrid[i].Clear();
                        sbGrid[i].Append(sbPlantedGrid[i].ToString());
                        sbPlantedGrid[i].Replace('.', 'O');
                    }
                }

                burst = !burst;
            }
            return new List<string>(sbPlantedGrid.Select(a => a.ToString()));
        }

    }
}
