using NewLearning;
using System.Linq;
using System.Text.RegularExpressions;

Algorithms algorithms = new Algorithms();
LeetCodeExercises leetCode = new LeetCodeExercises();
CodeWarsExercises codeWars = new CodeWarsExercises();

LeetCodeExercises.Node nd = new LeetCodeExercises.Node(1);
nd.neighbors.Add(new LeetCodeExercises.Node(2));
nd.neighbors.Add(new LeetCodeExercises.Node(3));
nd.neighbors[1].neighbors.Add(new LeetCodeExercises.Node(4));

var resNode = leetCode.CloneGraph(nd);







