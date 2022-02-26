using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

LeetCodeExercises.ListNode lNode = new LeetCodeExercises.ListNode();
lNode.val = 1;
lNode.next = new LeetCodeExercises.ListNode(2);

Console.WriteLine(leetCode.IsPalindrome(lNode));







