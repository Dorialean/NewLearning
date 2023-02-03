using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using System.Text;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

foreach (var item in leetCode.PlusOne(new int[] { 9, 9 }))
{
    Console.WriteLine(item);
}


