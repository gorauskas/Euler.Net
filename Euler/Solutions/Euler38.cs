using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace Euler.Solutions {
    public class Euler38 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 38:

    Take the number 192 and multiply it by each of 1, 2, and 3:

        192 * 1 = 192
        192 * 2 = 384
        192 * 3 = 576

    By concatenating each product we get the 1 to 9 pandigital, 192384576. We 
    will call 192384576 the concatenated product of 192 and (1,2,3)
    The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, 
    and 5, giving the pandigital, 918273645, which is the concatenated product 
    of 9 and (1,2,3,4,5).

    What is the largest 1 to 9 pandigital 9-digit number that can be formed as 
    the concatenated product of an integer with (1,2, ... , n) where n > 1?

";
            }
        }

        public string Answer {
            get {
                return "The largest 1 to 9 pandigital 9-digit number is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            List<BigInteger> lbi = new List<BigInteger>();

            foreach (int n in Enumerable.Range(1, 9999)) {
                foreach (int m in Enumerable.Range(1, 9)) {
                    BigInteger bi = ConcatenatedProduct(n, m);

                    if (bi.IsPanDigital()) {
                        lbi.Add(bi);
                    }
                }
            }

            return lbi.Max().ToString().ToLong();
        }

        private BigInteger ConcatenatedProduct(int n, int m) {
            List<string> ls = new List<string>();

            foreach (var i in Enumerable.Range(1, m + 1)) {
                ls.Add((n * i).ToString());
            }

            return ls.JoinAsString().ToBigInteger();
        }
    }
}
