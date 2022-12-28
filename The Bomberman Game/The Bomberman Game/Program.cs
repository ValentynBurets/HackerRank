using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace The_Bomberman_Game
{
    class Solution
    {
        public static void Main(string[] args)
        {
            List<string> grid = new List<string>() { ".......", "...O...", "....O..", ".......", "OO.....", "OO....." };

            List<string> grid2 = new List<string>() { ".......", "...O.O.", "....O..", "..O....", "OO...OO", "OO.O..." };

            List<string> grid3 = new List<string>() { 
                ".......", "000.0.0", 
                "...O.O.", "00.....",
                "....O..", "00....0",
                "..O....", ".......",
                "OO...OO", ".......",
                "OO.O...", "......."
            };

            //List<string> res = FirstResult.bomberMan(3, grid2);
            //List<string> res = SecondResult.bomberMan(3, grid2);
            List<string> res = ThirdResult.bomberMan(3, grid2);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}




