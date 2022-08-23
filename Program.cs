using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

//LeetCodeExercises.ListNode list3 = new(6);
//LeetCodeExercises.ListNode list2 = new(2,list3);
//LeetCodeExercises.ListNode list1 = new(1,list2);


//LeetCodeExercises.ListNode list6 = new(5);
//LeetCodeExercises.ListNode list5 = new(3, list6);
//LeetCodeExercises.ListNode list4 = new(1, list5);


//LeetCodeExercises.ListNode list8 = new(7);
//LeetCodeExercises.ListNode list7 = new(2, list8);


foreach (var index in leetCode.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word","good","best","good" }))
{
    Console.WriteLine(index);
}
foreach (var index in leetCode.FindSubstring("foobarfoobar", new string[] { "foo", "bar" }))
{
    Console.WriteLine(index);
}










