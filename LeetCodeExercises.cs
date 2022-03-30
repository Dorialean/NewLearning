﻿using System;
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
                if (!map.ContainsKey(nums[i])) map.Add(nums[i], CountNums(nums[i], nums));
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
                for (int j = nums.Length - 1; j > 0; j--)
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

        public bool IsPalindrome(int x)
        {
            char[] str = x.ToString().ToCharArray();
            int i = str.Length - 1;
            foreach (var ch in str)
            {
                if (ch != str[i]) return false;
                i--;
            }
            return true;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        //Перевернуть половину списка, при помощи "быстрого" и "медленного" курсора
        public bool IsPalindrome(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;//Этот курсор дойдёт до конца, когда
                slow = slow.next;     //Этот дойдёт до половины
            }

            ListNode prev = null;
            while (slow != null)
            {
                ListNode tmp = slow.next;
                slow.next = prev;
                prev = slow;
                slow = tmp;
            }//Переворот половины списка

            ListNode left = head;
            ListNode right = prev;
            while (right != null)
            {
                if (left.val != right.val) return false;
                left = left.next;
                right = right.next;
            }
            return true;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        //BFS , причём левый сын = 2p+1, правый = 2p+2
        public int WidthOfBinaryTree(TreeNode root)
        {
            Queue<(int, TreeNode)>? queue = new Queue<(int, TreeNode)>();
            queue.Enqueue((0, root));
            int max = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                (int p, TreeNode n) = queue.Peek();
                int left = p, right = p;
                while (count-- > 0)
                {
                    (p, n) = queue.Dequeue();
                    if (p < left) left = p;
                    if (p > right) right = p;
                    if (n.left != null) queue.Enqueue((2 * p + 1, n.left));
                    if (n.right != null) queue.Enqueue((2 * p + 2, n.right));
                }
                max = Math.Max(max, right - left + 1);
            }
            return max;
        }

        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int lightest = 0;
            int heaviest = people.Length - 1;

            int boats = 0;
            while (lightest < people.Length - 1 && heaviest >= lightest)
            {
                if (people[lightest] + people[heaviest] <= limit)
                    lightest++;
                boats++;
                heaviest--;
            }
            return boats;
        }

        public int TwoCitySchedCost(int[][] costs)
        {
            int a = costs.Length / 2;
            int b = a;
            int total = 0;

            foreach (var cost in costs.OrderByDescending(c => Math.Abs(c[0] - c[1])))
            {
                if (a == 0) total += cost[1];
                else if (b == 0) total += cost[0];
                else if (cost[0] < cost[1]) { total += cost[0]; a--; }
                else { total += cost[1]; b--; }
            }

            return total;
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Contains(target)) return Array.BinarySearch(nums, target);
            return -1;
        }

        public int FindDuplicate(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (var n in nums)
            {
                if (!result.Contains(n)) result.Add(n);
                else return n;
            }
            return -1;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            foreach (var dim in matrix)
            {
                if (dim.Contains(target)) return true;
            }
            return false;
        }
    }
}

