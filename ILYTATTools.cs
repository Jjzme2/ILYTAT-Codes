using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    public class Tools
    {
        public static string GenerateNewKey(int lettersPerIteration = 4, int iterations = 5, bool addHyphen = true)
        {
            List<string> iterationKeys = new List<string>();
            string charsInKeyIteration;
            string key = "";

            for (int i = 0; i < iterations; i++)
            {
                iterationKeys.Add(System.Guid.NewGuid().ToString());
                charsInKeyIteration = iterationKeys[i].Remove(lettersPerIteration);
                key += charsInKeyIteration;
                if (addHyphen)
                    if (i < iterations - 1)
                    {
                        key += "-";
                    }
            }
            return key;
        }
    }
}