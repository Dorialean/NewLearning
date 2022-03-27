using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

LeetCodeExercises.ListNode l3 = new LeetCodeExercises.ListNode(3);
LeetCodeExercises.ListNode l2 = new LeetCodeExercises.ListNode(4, l3);
LeetCodeExercises.ListNode l1 = new LeetCodeExercises.ListNode(2, l2);

LeetCodeExercises.ListNode l6 = new LeetCodeExercises.ListNode(4);
LeetCodeExercises.ListNode l5 = new LeetCodeExercises.ListNode(6, l6);
LeetCodeExercises.ListNode l4 = new LeetCodeExercises.ListNode(5, l5);

Console.WriteLine(leetCode.AddTwoNumbers(l1,l4));








