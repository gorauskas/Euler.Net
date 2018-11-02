using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler18 : IEuler {

        private const string TRIANGLE = @"
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
";

        public string Problem {
            get {
                return @" 
Project Euler Problem 18:

    By starting at the top of the triangle below and moving to adjacent numbers 
    on the row below, the maximum total from top to bottom is 23.

       3
      7 4
     2 4 6
    8 5 9 3

    That is, 3 + 7 + 4 + 9 = 23.

    Find the maximum total from top to bottom of the triangle below:

                  75
                 95 64
                17 47 82
               18 35 87 10
              20 04 82 47 65
             19 01 23 75 03 34
            88 02 77 73 07 63 67
           99 65 04 28 06 16 70 92
          41 41 26 56 83 40 80 70 33
         41 48 72 33 47 32 37 16 94 29
        53 71 44 65 25 43 91 52 97 51 14
       70 11 33 28 77 73 17 78 39 68 17 57
      91 71 52 38 17 14 91 43 58 50 27 29 48
     63 66 04 68 89 53 67 30 73 16 69 87 40 31
    04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

";
            }
        }

        public string Answer {
            get {
                return "The maximum sum travelling from the top of the triangle to the base is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return FindMaxSum(GetTriangle(TRIANGLE));
        }

        /// <summary>
        /// I want to represent the data as a List of List of Int32
        /// so I break the data down by line and then by space and 
        /// convert it to Int32 and return the data structure.
        /// </summary>
        /// <param name="data">The string data to parse</param>
        /// <returns>a list of list of int</returns>
        private IEnumerable<IEnumerable<int>> GetTriangle(string triangle) {
            return triangle
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(' ').Select(num => Int32.Parse(num)));
        }

        /// <summary>
        /// We keep reducing the triangle until there is only one item left
        /// and that's our result.
        /// </summary>
        /// <param name="triangle">the triangle data</param>
        /// <returns>The max sum of the trip from the top</returns>
        private int FindMaxSum(IEnumerable<IEnumerable<int>> triangle) {
            var t = triangle.Select(x => x.ToList()).ToList();

            while (t.Count > 1) {
                ReduceTriangle(ref t);
            }

            return t[0][0];
        }

        /// <summary>
        /// The key strategy of the algorithm is to treat the data from the bottom up.
        /// Here are the steps:
        ///  1. Get the last row of the triangle
        ///  2. Get the next to the last row of the triangle
        ///  3. Loop through the items from step 2 above
        ///  4. Find the 2 adjacent items for the item in step 3 above
        ///  5. Select the largest of the 2 items from step 4 above
        ///  6. Replace the item in step 3 above with the sum of item in step 5 
        ///     and the original item from step 3
        ///  7. Remove the last row from the triangle
        /// This is a form of reduction because the next to the last row will contain
        /// the accumulation of the items values after each iteration of the loop in 
        /// FindMaxSum.
        /// </summary>
        /// <param name="triangle">
        /// The triangle data is passed by ref because I need to change
        /// the thing itself.
        /// </param>
        private void ReduceTriangle(ref List<List<int>> triangle) {
            var lastRow = triangle.Last();

            foreach (var index in Enumerable.Range(0, triangle.Count - 1)) {
                triangle[triangle.FindLastIndex(x => true) - 1][index] +=
                    Math.Max(lastRow.GetRange(index, 2)[0], lastRow.GetRange(index, 2)[1]);
            }

            triangle.Remove(lastRow);
        }
    }
}
