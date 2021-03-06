﻿using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler21 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 21:

    Let d(n) be defined as the sum of proper divisors of n (numbers less than n
    which divide evenly into n).

    If d(a) = b and d(b) = a, n a  b, then a and b are an amicable pair and
    each of a and b are called amicable numbers.

    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55
    and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71
    and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.

";
            }
        }


        public string Answer {
            get {
                return "The sum of all the amicable numbers under 10000 is: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            // SumOfDivisors() is the d(n) function
            return 0.To(10000 - 1)
                .Where(x => x == x.SumOfDivisors().SumOfDivisors() && x != x.SumOfDivisors())
                .Sum();
        }
    }
}
