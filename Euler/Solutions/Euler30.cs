using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler30 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 30:

    Surprisingly there are only three numbers that can be written as the sum 
    of fourth powers of their digits:

        1634 = 1^4 + 6^4 + 3^4 + 4^4
        8208 = 8^4 + 2^4 + 0^4 + 8^4
        9474 = 9^4 + 4^4 + 7^4 + 4^4

    As 1 = 1^4 is not a sum it is not included.

    The sum of these numbers is 1634 + 8208 + 9474 = 19316.

    Find the sum of all the numbers that can be written as the sum of fifth 
    powers of their digits.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all the numbers that can be written as the sum of fifth\npowers of their digits is {0}"
                    .FormatWith(this.Solve());
            }
        }

        // Find the bounds: Start at 2 because 1 is not a sum
        // 9^5 * 6 = 354294 = upper bound or the highest sum of 5th powers 
        //   So we can cover 6 digit numbers up to that far and no further.
        //   With 7 digit numbers, the highest value is 413343,  So we only 
        //   need to loop from 2 to 354294
        // Create a list of int
        // Split each num into a char
        // Raise each digit to the 5th power and sum them
        // Does the result equals the initial number
        // sum the result
        public double Solve() {
            return 2.To(354294)
                .Where(x => x == x.ToString()
                    .Select(y => (int)Math.Pow(int.Parse(y.ToString()), 5))
                    .Sum())
                .Sum();
        }
    }
}
