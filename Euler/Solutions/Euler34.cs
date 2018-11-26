using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler34 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 34:

    145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

    Find the sum of all numbers which are equal to the sum of the
    factorial of their digits.

    Note: as 1! = 1 and 2! = 2 are not sums they are not included.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all numbers which are equal to the sum of the factorial of\ntheir digits is {0}"
                    .FormatWith(this.Solve());
            }
        }

        /// <summary>
        /// These type of numbers are referred to as factorions and it’s easy to learn that
        /// only 4 exist: 1, 2, 145 & 40585. The problem description wants us to ignore 1 &
        /// 2 so the answer to this problem should become obvious.
        ///
        /// But, let’s write a program anyway to search for factorions. As usual, when
        /// writing a brute force search algorithm, we must first determine our bounds. The
        /// lower bound is 10 because single digit candidates are to be ignored. The upper
        /// bound we discover as follows (from Wikipedia):
        ///
        /// If n is a natural number of d digits that is a factorion, then 10d − 1 ≤ n ≤ 9!d
        /// and this fails to hold for d ≥ 8. Thus n has 7 digits and the maximum sum of
        /// factorials of digits for a 7 digit number is 9!7 = 2,540,160, which is the upper
        /// bound.
        ///
        /// Afterwards, we learned 50,000 worked just fine.
        /// </summary>
        public double Solve() {
            //pre - calculated factorials from 1 to 9
            List<long> fact = new List<long>() { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };  
            var r = 0; // results accumulator
            var rng = Enumerable.Range(10, 49989);

            foreach (var n in rng) {
                var x = (from d in n.ToString() select fact[d.ToInt()]).Sum();
                if (n == x) {
                    r += n;
                }
            }

            return r;
        }
    }
}
