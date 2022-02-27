using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

LeetCodeExercises.TreeNode bottomNode5 = new LeetCodeExercises.TreeNode(5);
LeetCodeExercises.TreeNode bottomNode3 = new LeetCodeExercises.TreeNode(3);
LeetCodeExercises.TreeNode bottomNode9 = new LeetCodeExercises.TreeNode(9);
LeetCodeExercises.TreeNode middleNode3 = new LeetCodeExercises.TreeNode(3,bottomNode5,bottomNode3);
LeetCodeExercises.TreeNode middleNode2 = new LeetCodeExercises.TreeNode(3, null, bottomNode9);
LeetCodeExercises.TreeNode upperNode1 = new LeetCodeExercises.TreeNode(1, middleNode3,middleNode2);
Console.WriteLine(leetCode.WidthOfBinaryTree(upperNode1));







