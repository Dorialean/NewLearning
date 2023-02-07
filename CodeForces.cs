using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLearning
{
    public sealed class CodeForces
    {
        public static void LeastCommonDivisor()
        {
            var notesAmount = Console.ReadLine().Split(' ');
            int n = int.Parse(notesAmount[0].ToString());
            int k = int.Parse(notesAmount[1].ToString());
            Console.WriteLine((n / k + 1) * k);
        }
    }
}
