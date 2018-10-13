using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Solutions {

    public class Euler9 : IEuler {

        public string Problem {
            get {
                return @"
Project Euler Problem 9:

   A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

    a^2 + b^2 = c^2

   For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

   There exists exactly one Pythagorean triplet for which a + b + c = 1000.
   Find the product abc.

";
            }
        }

        public string Answer {
            get {
                return "The pythagorean triplet whose sum equals 1000 has a product of: {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var t = new List<int>();

            for (int a = 1; a < 1000; a++) {
                for (int b = a + 1; b < 1000; b++) {
                    for (int c = b + 1; c < 1000; c++) {
                        if ((a + b + c == 1000) && (a.Sqr() + b.Sqr() == c.Sqr())) {
                            t.AddRange(new int[] { a, b, c });
                            break;
                        }
                    }
                }
            }

            return t.Product();
        }

    }

}
