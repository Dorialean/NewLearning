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

        //Представить в виде Char массива , складывать умножая на кол-во букв в алфавите.
        public int TitleToNumber(string columnTitle)
        {
            const int ASCII_USELESS_NUMS = 64;
            char[] columnCharTitle = columnTitle.ToCharArray();
            int sum = 0;
            int i = columnCharTitle.Length - 1;
            foreach (char ch in columnCharTitle)
            {
                sum += (ch - ASCII_USELESS_NUMS) * (int)Math.Pow(26, i);
                i--;
            }
            return sum;
        }
        //Поиск перебором с двух сторон
        public int[] TwoSum(int[] nums, int target)
        {
            int[] indexRes = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums.Length-1; j > 0 ; j--)
                {
                    if (i == j) continue;
                    if (nums[i] + nums[j] == target) 
                    {
                        indexRes[0] = i;
                        indexRes[1] = j;
                        return indexRes;
                    }
                }
            }
            return indexRes;
        }

        //Очередь для прохождения по графу, dict для результата.
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        
        public Node CloneGraph(Node node)
        {
            Queue<Node> q = new Queue<Node>();
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();

            if (node == null)
            {
                return null;
            }

            q.Enqueue(node);
            dict.Add(node, new Node(node.val));

            while (q.Count > 0)
            {
                Node cur = q.Dequeue();

                foreach (var nei in cur.neighbors)
                {
                    if (!dict.ContainsKey(nei))
                    {
                        dict.Add(nei, new Node(nei.val));
                        q.Enqueue(nei);
                    }

                    dict[cur].neighbors.Add(dict[nei]);
                }
            }

            return dict[node];
        }
    }
}

