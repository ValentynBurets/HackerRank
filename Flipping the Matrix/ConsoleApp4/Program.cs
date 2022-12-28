using System;
using System.Collections.Generic;

namespace ConsoleApp4 { 
class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> matrix = new List<List<int>>()
        {
            new List<int>(){ 112, 42, 83, 119 },
            new List<int>(){ 56, 125, 56, 49 },
            new List<int>(){ 15, 78, 101, 43},
            new List<int>(){ 62, 98, 114, 108 }
        };

        //int result = FirstResult.flippingMatrix(matrix);
        int result = SecondResult.flippingMatrix(matrix);

        Console.WriteLine($"{result} is {result == 414} 414");
    }
}
}
