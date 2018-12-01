using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace Euler.Solutions {
    public class Euler39 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 39:

    If p is the perimeter of a right angle triangle with integral length sides, 
    {a,b,c}, there are exactly three solutions for p = 120.

        {20,48,52}, {24,45,51}, {30,40,50}

    For which value of p ≤ 1000, is the number of solutions maximised?

";
            }
        }

        public string Answer {
            get {
                return "The number of solutions is maximized for {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            long result = 0, resultSolutions = 0;

            for (long p = 2; p <= 1000; p += 2) {
                int numberOfSolutions = 0;
                for (long a = 2; a < (p / 3); a++) {
                    if (p * (p - 2 * a) % (2 * (p - a)) == 0) {
                        numberOfSolutions++;
                    }
                }
                if (numberOfSolutions > resultSolutions) {
                    resultSolutions = numberOfSolutions;
                    result = p;
                }
            }

            return result;
        }
    }
}
