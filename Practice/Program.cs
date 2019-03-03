using System;
using System.Collections.Generic;
namespace Treehouse.CodeChallenges {
    public static class MathHelpers {
        public static List<int> GetPowersOf2(int UpperLimit) {
            Console.WriteLine("What is the upper limit of the Powers of 2 list you request?");

            var PowersOf2List = new List<int>();

            for (int index = 0; index < UpperLimit + 1; index++) {
                PowersOf2List.Add((int)Math.Pow(2, index));
            }
            return PowersOf2List;
        }
    }
}