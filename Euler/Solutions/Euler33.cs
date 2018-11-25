using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler33 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 33:

    The fraction 49/98 is a curious fraction, as an inexperienced mathematician
    in attempting to simplify it may incorrectly believe that 49/98 = 4/8,
    which is correct, is obtained by cancelling the 9s.

    We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

    There are exactly four non-trivial examples of this type of fraction, less
    than one in value, and containing two digits in the numerator and
    denominator.

    If the product of these four fractions is given in its lowest common terms,
    find the value of the denominator.

";
            }
        }

        public string Answer {
            get {
                return "The value of the denominator is: {0}".FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var d = 1.0;

            foreach (var i in Enumerable.Range(1, 9)) {
                foreach (var j in Enumerable.Range(1, i)) {
                    foreach (var k in Enumerable.Range(1, j)) {
                        var ki = k * 10 + i;
                        var ij = (float)(i * 10 + j);

                        if (k * ij == ki * j) {
                            d *= ij / ki;
                        }
                    }
                }
            }

            return d;
        }
    }
}
