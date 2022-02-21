using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLearning
{
    internal class LeetCodeExercises
    {
        //Решением было создание подмножества для каждого элемента nums,а потом добавление этого нового подмножества в результат.
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>() { new List<int>() };
            foreach (var num in nums)
            {
                List<List<int>> newSubsets = new List<List<int>>();
                foreach (var curr in res)
                {
                    newSubsets.Add(new List<int>(curr) { num });
                }
                foreach (List<int> curr in newSubsets)
                {
                    res.Add(curr);
                }
            }
            return res;
        }
        
        //Нужно было использовать HashTable , где ключ - цифра, значение - её повторения в массиве
        public int MajorityElement(int[] nums)
        {
            Hashtable map = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                if(!map.ContainsKey(nums[i]))map.Add(nums[i], CountNums(nums[i],nums));
            }
            int max = 0;
            foreach (var n in map.Values)
            {
                if ((int)n > max) max = (int)n;
            }
            foreach (var item in map.Keys)
            {
                if ((int)map[item] == max) return (int)item;
            }
            return 0;

            int CountNums(int n, int[] nums) => nums.Where(x => x == n).Count();
        }

        

    }
}

