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

Console.WriteLine(leetCode.IsValidSudoku(new char[][] {new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.' },
 new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
    new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
    new char[] {'.', '.', '.', '.', '6', '.', '.', '.', '3'},
    new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
    new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
    new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
    new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
    new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}}));
