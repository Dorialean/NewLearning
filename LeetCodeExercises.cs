using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
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

        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i]) i--;
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i]) j--;
                swap(nums, i, j);
            }
            reverse(nums, i + 1);
        }

        private void reverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                swap(nums, i, j);
                i++; j--;
            }
        }

        private void swap(int[] nums, int i, int j)
        {
            int t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode dummy = new();
            ListNode pre = dummy;

            while (l1 != null || l2 != null || carry == 1)
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                carry = sum < 10 ? 0 : 1;
                pre.next = new ListNode(sum % 10);
                pre = pre.next;

                if (l1 != null)l1 = l1.next;
                if (l2 != null)l2 = l2.next;                
            }
            return dummy.next;
        }

        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s == String.Empty) return 0;

            HashSet<char> set = new HashSet<char>();
            int currentMax = 0, i = 0, j = 0;

            while (j < s.Length)
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    currentMax = Math.Max(currentMax, j - i);
                }
                else set.Remove(s[i++]);

            return currentMax;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] allNums = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(allNums, 0);
            nums2.CopyTo(allNums, nums1.Length);
            Array.Sort(allNums);
            if(allNums.Length % 2 == 0)
                return Convert.ToDouble(((allNums[allNums.Length / 2 - 1] + allNums[allNums.Length / 2]))) / 2;
            else return allNums[Convert.ToInt32(Math.Floor(Convert.ToDecimal(allNums.Length / 2)))];
        }

        public class KthLargest
        {            
            private SortedList<int, int> minHeap;
            int k;
            private int size;

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                minHeap = new SortedList<int, int>();
                foreach (int n in nums) Add(n);
            }

            public int Add(int val)
            {
                if(minHeap.ContainsKey(val))minHeap[val]++;
                else minHeap.Add(val,1);
                size++;
                if (size > k)
                {
                    var minKV = minHeap.Values[0];
                    if(minKV == 1)minHeap.RemoveAt(0);
                    else minHeap[minHeap.Keys[0]]--;
                    size--;
                }
                minHeap.First();
                return minHeap.Keys[0];
            }
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)|| s.Length <= 1)
                return s;
            int length = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int evenLength = PalindromeLength(s, i, i + 1);
                int oddLength = PalindromeLength(s, i, i);
                int currentLength = Math.Max(evenLength, oddLength);

                if (currentLength > length)
                {
                    length = currentLength;
                    start = i - (length - 1) / 2;
                }
            }

            return s.Substring(start, length);
        }

        private int PalindromeLength(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        public int MyAtoi(string str)
        {
            if (str == null || str == string.Empty)
                return 0;

            int res = 0,
                sign = 1;
            bool findSign = false,
                 findDigit = false;

            foreach (var c in str)
                if (!findSign && !findDigit && (c == '+' || c == '-'))
                {
                    findSign = true;
                    sign = c == '+' ? 1 : -1;
                }
                else if (c >= '0' && c <= '9')
                {
                    findDigit = true;

                    if (res == 0 && c == '0')
                        continue;
                    else if (res > Int32.MaxValue / 10 || (res == Int32.MaxValue / 10 && c - '0' > Int32.MaxValue % 10))
                        return sign == 1 ? Int32.MaxValue : Int32.MinValue;
                    else
                        res = res * 10 + (c - '0');
                }
                else if (c != ' ' || ((findDigit || findSign) && c == ' ') || (findDigit && c == '.'))
                    break;

            return res * sign;
        }

        public string ConvertS(string s, int numRows)
        {
            if (numRows == 1) return s;

            string result = "";

            for (int currentLine = 0; currentLine < numRows; currentLine++)
            {
                bool isFirstOrLastLine = currentLine == 0 || currentLine == numRows - 1 ? true : false;
                int index = currentLine;

                while (index < s.Length)
                {
                    if (isFirstOrLastLine)
                    {
                        result += s[index];
                        index += 2 * (numRows - 1);
                    }
                    else
                    {
                        result += s[index];
                        index += 2 * (numRows - currentLine - 1);
                        if (index >= s.Length) continue;
                        result += s[index];
                        index += 2 * currentLine;
                    }
                }
            }
            return result;
        }
        public int RomanToInt(string s)
        {
            int res = GetRomNum(s[s.Length-1]);
            for (int i = s.Length-1; i >= 1; i--)
            {
                if(GetRomNum(s[i-1]) >= GetRomNum(s[i]))
                    res += GetRomNum(s[i-1]);
                else
                    res -= GetRomNum(s[i-1]);
            }
            return res;
        }

        private int GetRomNum(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;                    
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        public int Reverse(int x)
        {
            string res = x >= 0 ? string.Concat(x.ToString().Reverse().TakeWhile(char.IsNumber)) : "-" + string.Concat(x.ToString().Reverse().TakeWhile(char.IsNumber));
            try{return Convert.ToInt32(res);}
            catch (Exception){ return 0; }
        }
        public bool IsMatch(string s, string p)
        {
            if (p.Length == 0) 
                return s.Length == 0;
            bool first_match = (!(s.Length == 0) && (p[0] == s[0] || p[0] == '.'));

            if (p.Length >= 2 && p[1] == '*')
                return IsMatch(s, p.Substring(2)) || (first_match && IsMatch(s.Substring(1), p));
            else
                return first_match && IsMatch(s.Substring(1), p.Substring(1));
        }

        public int MaxArea(int[] height)
        {
            int maxSize = 0, leftPointer = 0, rightPointer = height.Length - 1;
            while(leftPointer != rightPointer)
            {
                maxSize = (rightPointer - leftPointer) * Math.Min(height[leftPointer], height[rightPointer]) > maxSize 
                    ? (rightPointer - leftPointer) * Math.Min(height[leftPointer], height[rightPointer]) : maxSize;
                if (height[leftPointer] > height[rightPointer])
                    rightPointer--;
                else
                    leftPointer++;
            }
            return maxSize;
        }

        public string ValidationResult(string s)
        {
            string res = String.Empty;
            int north = s.Count(x => x.Equals('N')),
                south = s.Count(x => x.Equals('S')),
                west = s.Count(x => x.Equals('W')),
                east = s.Count(x => x.Equals('E'));
            int verticalD = north - south;
            int horizontalR = west - east;
            res = CreateNorS(verticalD) + CreateWorE(horizontalR);
            var something = res.OrderBy(x => x).ToList();
            return string.Concat(something).Trim();
        }
        private string CreateNorS(int x) 
        {
            string res = string.Empty;
            if(x > 0)
                for (int i = 0; i < x; i++)
                {
                    res += 'N';
                }
            else
                for (int i = 0; i < Math.Abs(x); i++)
                {
                    res += 'S';
                }
            return res;
        }

        private string CreateWorE(int x) 
        {
            string res = string.Empty;
            if (x > 0)
                for (int i = 0; i < x; i++)
                {
                    res += 'W';
                }
            else
                for (int i = 0; i < Math.Abs(x); i++)
                {
                    res += 'E';
                }
            return res;
        }

        private int Candy(int[] ratings)
        {
            int[] res = new int[ratings.Length];

            //Each child must have at least one candy
            Array.Fill(res, 1);

            //Children with a higher rating get more candies than their neighbors.
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    res[i] = res[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    res[i] = Math.Max(res[i], res[i + 1] + 1);
            }

            return res.Sum();
        }

        public int LongestConsecutive(int[] nums)
        {
            //Dummy check
            if (nums.Length <= 0)
                return 0;

            int longestSeqence = 1;
            int usedSequence = 1;

            //Getting rid of repeated nums
            nums = nums.Select(x => x).Distinct().ToArray();
            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    usedSequence++;
                }
                else
                {
                    usedSequence = 1;
                }

                if (usedSequence > longestSeqence)
                {
                    longestSeqence = usedSequence;
                }
            }
            return longestSeqence;
        }

        public IList<int> RightSideView(TreeNode root)
        {
            if(root == null)
                return new List<int>();

            List<int> res = new();
            Queue<TreeNode> q = new();
            q.Enqueue(root);

            while(q.Count > 0)
            {
                int count = q.Count;

                while(count > 0)
                {
                    TreeNode cur = q.Dequeue();

                    if (count == 1)
                        res.Add(cur.val);

                    if(cur.left != null)
                        q.Enqueue(cur.left);

                    if (cur.right != null)
                        q.Enqueue(cur.right);

                    count--;
                }
            }

            return res;
        }

        public bool IsAnagram(string s, string t) => string.Concat(s.OrderBy(c => c)) == string.Concat(t.OrderBy(c => c));

        
        public int UniquePaths(int m, int n)
        {
            int[,] matrix = new int[m,n];
            matrix = FillWithOnes(matrix);

            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                for (int j = 1; j <= matrix.GetLength(1) - 1; j++)
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];

            return matrix[m - 1, n - 1];
        }

        private int[,] FillWithOnes(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            matrix[0, 0] = 1;
            if (m > 1)
                for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
                    matrix[i, 0] = 1;
            if (n > 1)
                for (int i = 1; i <= matrix.GetLength(1) - 1; i++)
                    matrix[0, i] = 1;

            return matrix;
        }

        public string IntToRoman(int num)
        {
            string[] M = new string[] { "", "M", "MM", "MMM" };
            string[] C = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] X = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] I = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var prefix = string.Empty;
            var start = string.Empty;

            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs[i].Length; j++)
                {
                    start += strs[i][j];
                    if (strs.All(s => s.StartsWith(start)))
                    {
                        prefix = start;
                    }
                }
            }
            return prefix;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            int prevOuter = 0;

            Array.Sort(nums);
            for (int i = nums.Length - 1; i > 1; i--)
            {
                if (i != nums.Length - 1 && nums[i] == prevOuter)
                {
                    continue;
                }
                int remain = 0 - nums[i];
                prevOuter = nums[i];
                int prevInner = 0;

                for (int j = i - 1; j > 0; j--)
                {
                    if (j != i - 1 && nums[j] == prevInner)
                    {
                        continue;
                    }
                    int last = remain - nums[j];
                    prevInner = nums[j];
                    int exist = Array.BinarySearch<int>(nums, 0, j, last);
                    if (exist >= 0)
                    {
                        res.Add(new List<int>() { nums[i], nums[j], last });
                    }
                }
            }
            return res;
        }


        Dictionary<char, char[]> phoneNumberToLetters = new()
        {
            { '2', new char[] { 'a', 'b', 'c' } },
            { '3', new char[] { 'd', 'e', 'f' } },
            { '4', new char[] { 'g', 'h', 'i' } },
            { '5', new char[] { 'j', 'k', 'l' } },
            { '6', new char[] { 'm', 'n', 'o' } },
            { '7', new char[] { 'p', 'q', 'r', 's' } },
            { '8', new char[] { 't', 'u', 'v' } },
            { '9', new char[] { 'w', 'x', 'y', 'z' } },
        };
        IList<string> letterCombinations = new List<string>();


        public IList<string> LetterCombinations(string digits)
        {
            if (digits == string.Empty || digits == null)
                return new List<string>();

            DFS(digits, 0, new StringBuilder());
            return letterCombinations;
        }

        private void DFS(string d, int i, StringBuilder cur)
        {
            foreach (var c in phoneNumberToLetters[d[i]])
            {
                cur.Append(c);

                if(d.Length - 1 == i)
                {
                    letterCombinations.Add(cur.ToString());
                }
                else
                {
                    DFS(d, i + 1, cur);
                }

                cur.Remove(cur.Length-1, 1);
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            List<ListNode> list = new List<ListNode>();

            var node = head;

            while (node != null)
            {
                list.Add(node);
                node = node.next;
            }

            if (n == list.Count)
                return list.Count > 1 ? list[1] : null;

            list[list.Count - 1 - n].next = list[list.Count - n].next;

            return head;
        }

        public bool IsValid(string s)
        {
            Stack<char> brackets = new();

            foreach (var bracket in s)
            {
                if (bracket == '(')
                    brackets.Push(')');
                else if (bracket == '[')
                    brackets.Push(']');
                else if (bracket == '{')
                    brackets.Push('}');
                else if (brackets.Count == 0 || brackets.Pop() != bracket)
                    return false;
            }

            return brackets.Count == 0;
        }

        //Не корректное, но рабочее решение
        /*public ListNode MergeTwoLists(ListNode list1, ListNode list2)
          {
              ListNode leftCursor = list1;
              ListNode rightCursor = list2;
              List<int> result = new();

              if (leftCursor == null && rightCursor == null)
                  return null;
              else if (leftCursor == null)
                  return list2;
              else if (rightCursor == null)
                  return list1;

              while (leftCursor != null)
              {
                  result.Add(leftCursor.val);
                  leftCursor = leftCursor.next;
              }

              while (rightCursor != null)
              {
                  result.Add(rightCursor.val);
                  rightCursor = rightCursor.next;
              }
              var resultArray = result.ToArray();
              Array.Sort(resultArray);
              ListNode res = new(resultArray[0]);
              ListNode resHead = res;
              foreach (var n in resultArray.Skip(1).ToArray())
              {
                  res.next = new(n);
                  res = res.next;
              }

              return resHead;
          }
        */

        //Корректное решение
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            ListNode d = new ListNode(),
                     cur = d;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }

                cur = cur.next;
            }

            if (l1 != null)
                cur.next = l1;

            if (l2 != null)
                cur.next = l2;

            return d.next;
        }

        public int RemoveDuplicates(int[] nums)
        {
            int placePointer = 0;

            for (int checkPointer = 0; checkPointer < nums.Length; checkPointer++)
            {
                nums[placePointer++] = nums[checkPointer];
                while (checkPointer < nums.Length - 1 && nums[checkPointer] == nums[checkPointer + 1])
                    checkPointer++;
            }
            return placePointer;
        }


        const char leftBracer = '(';
        const char rightBracer = ')';

        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = new List<string>();
            DFS(n, n, new StringBuilder(), res);
            return res;

            void DFS(int openBracers, int closeBracers, StringBuilder sb, IList<string> res)
            {
                if (openBracers == 0 && closeBracers == 0)
                {
                    res.Add(sb.ToString());
                }
                else
                {
                    if (openBracers > 0)
                    {
                        sb.Append(leftBracer);
                        DFS(openBracers - 1, closeBracers, sb, res);
                        sb.Length--;
                    }

                    if (closeBracers > openBracers)
                    {
                        sb.Append(rightBracer);
                        DFS(openBracers, closeBracers - 1, sb, res);
                        sb.Length--;
                    }
                }
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0 || !IsAnyNodesLeft(lists))
                return null;

            //For Completing DummyTest if there was an null in start 'lists' array
            ListNode[] withoutNullLists = lists.Where(x => x != null).Select(x => x).ToArray();
            ListNode minValCurs = new(withoutNullLists.Select(x => x.val).Min());
            ListNode res = minValCurs;


            while (IsAnyNodesLeft(withoutNullLists))
            {
                //picking index of the lowest element
                int i = Array.IndexOf(withoutNullLists, withoutNullLists.MinBy(lNode => lNode?.val));
                minValCurs.next = new(TakeOneAndGoNext(ref withoutNullLists[i]));
                minValCurs = minValCurs.next;
            }

            return res.next;

            //Taking listnode value and moving this value forward
            int TakeOneAndGoNext(ref ListNode listNode)
            {
                int res = listNode.val;
                listNode = listNode.next;
                return res;
            }

            bool IsAnyNodesLeft(ListNode[] arrayNodes)
            {
                if (arrayNodes.All(x => x == null))
                    return false;
                return true;
            }
        }

        public int StrStr(string haystack, string needle) => haystack.IndexOf(needle);

        public IList<int> FindSubstring(string s, string[] words)
        {
            var permutations = Permutations(words);
            IList<int> indicies = new List<int>();

            foreach (var p in permutations)
            {
                string currStr = string.Join("", p);
                int index = s.IndexOf(currStr);
                int i = 0;
                while (s.Length > 0 && i < s.Length)
                {
                    index = s.IndexOf(currStr, i++);
                    if (index != -1)
                        indicies.Add(index);
                }
                i = 0;
                
            }

            return indicies.Distinct().ToList();

            static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
            {
                if (fromInd + 1 == values.Length)
                    yield return values;
                else
                {
                    foreach (var v in Permutations(values, fromInd + 1))
                        yield return v;

                    for (var i = fromInd + 1; i < values.Length; i++)
                    {
                        SwapValues(values, fromInd, i);
                        foreach (var v in Permutations(values, fromInd + 1))
                            yield return v;
                        SwapValues(values, fromInd, i);
                    }
                }
            }

            static void SwapValues<T>(T[] values, int pos1, int pos2)
            {
                if (pos1 != pos2)
                {
                    T tmp = values[pos1];
                    values[pos1] = values[pos2];
                    values[pos2] = tmp;
                }
            }
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            foreach (char ch in ransomNote)
            {
                if (!magazine.Contains(ch) || magazine.Count(c => c == ch) < ransomNote.Count(c => c == ch))
                    return false;
            }
            return true;
        }

        public int SearchRotated(int[] nums, int target) => Array.IndexOf(nums, target);

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) 
                return null;
            if (head.next == null) 
                return head;

            ListNode res = head;
            ListNode curr = head;
            ListNode next = head.next;

            while (curr != null && next != null)
            {
                int tmp = curr.val;
                curr.val = next.val;
                next.val = tmp;
                curr = next.next;
                next = curr?.next;
            }

            return res;
        }

        public int[] SearchRange(int[] nums, int target) => new int[] { Array.IndexOf(nums, target), Array.LastIndexOf(nums, target)};

        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return left;
        }

        public bool CanJump(int[] nums)
        {
            int goal = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                {
                    goal = i;
                }
            }
            return goal == 0;
        }

        public bool IsValidSudoku(char[][] board)
        {
            
            for (int i = 0; i < board.Length; i++)
            {
                if (!IsValidSudokuLine(board[i]))
                {
                    return false;
                }
                char[] sudokuColumn = new char[board.Length];
                for (int j = 0; j < board.Length; j++)
                {
                    sudokuColumn[j] = board[j][i];
                }
                if (!IsValidSudokuLine(sudokuColumn))
                {
                    return false;
                }
            }

            for (int i = 0; i < board.Length; i += 3)
            {
                for (int j = 0; j < board.Length; j += 3)
                {
                    List<char> sudokuChunk = new();
                    for (int k = 0; k < 3; k++)
                    {
                        sudokuChunk.AddRange(board[i + k][j..(j + 3)]);
                    }
                    if (!IsValidSudokuLine(sudokuChunk.ToArray()))
                    {
                        return false;
                    }
                }
            }

            return true;

            static bool IsValidSudokuLine(char[] line)
            {
                const char EMPTY_CELL_CONTAINER = '.';

                if (line.All(c => c.Equals(EMPTY_CELL_CONTAINER)))
                {
                    return true;
                }

                var lineWithoutEmptyCells = line.Select(c => c).Where(c => !c.Equals(EMPTY_CELL_CONTAINER)).ToArray();
                if (lineWithoutEmptyCells.Length != lineWithoutEmptyCells.ToHashSet().Count)
                {
                    return false;
                }
                return true;
            }
        }

        public int FirstMissingPositive(int[] nums)
        {
            Array.Sort(nums);
            int minVal = nums.Where(x => x >= 0).Min();
            int minValIndex = 0;
            bool isDoneQueue = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == minVal)
                {
                    minValIndex = i;
                    break;
                }
            }
            while (isDoneQueue)
            {
                if (minValIndex + 1 == nums.Length)
                {
                    break;
                }
                if (nums[minValIndex + 1] == minVal + 1)
                {
                    minValIndex++;
                    minVal++;
                }
                else
                    isDoneQueue = false;
            }
            return minVal + 1;
        }

        public int MaxIceCream(int[] costs, int coins)
        {
            if (costs.All(iceCreamCost => iceCreamCost > coins))
                return 0;

            int iceCreamsAmount = 0;
            int maxCost = costs.Max() + 1;
            while (coins > 0)
            {
                int minCost = costs.Min();
                if (minCost == maxCost)
                    break;
                int indexOfMin = Array.IndexOf<int>(costs, minCost);
                coins -= minCost;
                if (coins < 0)
                    break;

                costs[indexOfMin] = maxCost;
                iceCreamsAmount++;

                if (!costs.Any(c => c != maxCost))
                    break;
            }
            return iceCreamsAmount;
        }
    }
}

