using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Solutions {
    public class Euler53 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 53

    There are exactly ten ways of selecting three from five, 12345:

        123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

                                           5
    In combinatorics, we use the notation,  C = 10.
                                             3

    In general,

        n         n!
         C  = ----------   where r <= n, n! = n*(n−1)*...*3*2*1, and 0! = 1.
          r    r!(n−r)!

                                                              23
    It is not until n = 23, that a value exceeds one-million:   C   = 1144066.
                                                                 10

                                                  n
    How many, not necessarily distinct, values of  C , for 1 <= n <= 100,
                                                    r

    are greater than one-million?

";
            }
        }

        public string Answer {
            get {
                return "There are {0} values greater than one million."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            int res = 0;
            const int ul = 1000000; // upper limit
            const int ll = 100;     // lower limit

            int[,] pt = new int[ll + 1, ll / 2 + 1]; // pascal triangle

            for (int n = 0; n <= ll; n++) {
                pt[n, 0] = 1;
            }

            for (int n = 1; n <= ll; n++) {
                for (int r = 1; r <= n / 2; r++) {
                    pt[n, r] = pt[n - 1, r] + pt[n - 1, r - 1];
                    if (r == n / 2 && n % 2 == 0) {
                        pt[n, r] += pt[n - 1, r - 1];
                    }

                    if (pt[n, r] > ul) {
                        pt[n, r] = ul;
                        res += n - 2 * r + 1;
                        break;
                    }
                }
            }

            return res;
        }
    }
}
