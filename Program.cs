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

Console.WriteLine(leetCode.BestTeamScore(scores:new int[]{ 4, 5, 6, 5 }, ages:new int[] { 2, 1, 2, 1 }));
