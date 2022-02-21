using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLearning
{
    internal class CodeWarsExercises
    {
        public int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> res = new List<int>(a);
            foreach (var numA in a)
            {
                if(b.Contains(numA))res.RemoveAll(x => x == numA);
            }
            return res.ToArray();
        }
        public int sumTwoSmallestNumbers(int[] numbers)
        {
            return numbers.OrderBy(i => i).Take(2).Sum();
        }
        public object FirstNonConsecutive(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                if(arr[i] != arr[i+1]-1)
                    return arr[i+1];
            }
            return null;
        }

        public string AreYouPlayingBanjo(string name)
        {
            return name.StartsWith("R") || name.StartsWith("r") ? name + " plays banjo" : name + " does not play banjo";
        }
    }
}
