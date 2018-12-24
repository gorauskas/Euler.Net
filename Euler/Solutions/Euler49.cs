using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions {
    public class Euler49 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 49 

    The arithmetic sequence, 1487, 4817, 8147, in which each of the terms 
    increases by 3330, is unusual in two ways: (i) each of the three terms are 
    prime, and, (ii) each of the 4-digit numbers are permutations of one 
    another.

    There are no arithmetic sequences made up of three 1-, 2-, or 3-digit 
    primes, exhibiting this property, but there is one other 4-digit increasing 
    sequence.

    What 12-digit number do you form by concatenating the three terms in this 
    sequence?

";
            }
        }

        public string Answer {
            get {
                return "The 12-digit number is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            long x = 0, y = 0, z = 0;
            string str = "";

            foreach (var item in Enumerable.Range(1000, 9999)) {
                x = item;
                y = x + 3330;
                z = y + 3330;

                if (x.IsPrime() && y.IsPrime() && z.IsPrime()) {
                    if (y.ToString().Sorted() == x.ToString().Sorted() &&
                        z.ToString().Sorted() == x.ToString().Sorted()) {

                        str = String.Concat(x.ToString(), y.ToString(), z.ToString());

                    }
                }
            }

            return Double.Parse(str);
        }

    }

}
