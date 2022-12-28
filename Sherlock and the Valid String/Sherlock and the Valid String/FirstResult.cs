using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_the_Valid_String
{
    public static class FirstResult
    {
        /*
        * Complete the 'isValid' function below.
        *
        * The function is expected to return a STRING.
        * The function accepts STRING s as parameter.
        */

        public static string isValid(string s)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (!letters.TryAdd(item, 1))
                {
                    letters[item]++;
                }
            }

            bool isValid = true;
            int removeItem = 1;
            int quantityOfOneLetter = letters.Values.First();

            foreach (var item in letters.Values)
            {
                if (item > quantityOfOneLetter || item < quantityOfOneLetter)
                {
                    if(removeItem > 0 && (quantityOfOneLetter - 1 == item || quantityOfOneLetter == item - 1) || item - 1 == 0 )
                    {
                        removeItem--;
                        continue;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid ? "YES" : "NO";
        }
    }
}
