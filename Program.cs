using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

LeetCodeExercises.ListNode list3 = new(6);
LeetCodeExercises.ListNode list2 = new(2,list3);
LeetCodeExercises.ListNode list1 = new(1,list2);


LeetCodeExercises.ListNode list6 = new(5);
LeetCodeExercises.ListNode list5 = new(3, list6);
LeetCodeExercises.ListNode list4 = new(1, list5);


LeetCodeExercises.ListNode list8 = new(7);
LeetCodeExercises.ListNode list7 = new(2, list8);


var lists = new List<LeetCodeExercises.ListNode>()
{
    list1,
    list4,
    list7
};

leetCode.MergeKLists(lists.ToArray());
leetCode.MergeKLists(Array.Empty<LeetCodeExercises.ListNode>());
leetCode.MergeKLists(new LeetCodeExercises.ListNode[2] { null, list7 });







