using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler47 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 47 

    The first two consecutive numbers to have two distinct prime factors are:

        14 = 2 × 7
        15 = 3 × 5

    The first three consecutive numbers to have three distinct prime factors 
    are:

        644 = 2² × 7 × 23
        645 = 3 × 5 × 43
        646 = 2 × 17 × 19.

    Find the first four consecutive integers to have four distinct prime 
    factors each. What is the first of these numbers?

";
            }
        }

        public string Answer {
            get {
                return "The number is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            long x = 210;   // first number with 4 unique prime factors - start here
            int y = 1;
            List<long> nums = new List<long>();

            while (y != 4) {
                x += 1;
                if (x.Factors().ToHashSet().Where(n => n.IsPrime()).Count() == 4) {
                    y += 1;
                    nums.Add(x);
                } else {
                    y = 0;
                    nums.Clear();
                }
            }

            return nums[0];
        }
    }
}
