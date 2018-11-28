using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler36 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 36:

    The decimal number, 585 = 1001001001v2 (binary), is palindromic in both
    bases.

    Find the sum of all numbers, less than one million, which are palindromic
    in base 10 and base 2.

    (Please note that the palindromic number, in either base, may not include
    leading zeros.)

";
            }
        }

        public string Answer {
            get {
                return "The sum of all palindromic numbers in base 10 and 2 is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            List<long> L = new List<long>();

            foreach (var num in Enumerable.Range(1, 999999)) {
                if (num.ToString() == num.ToString().Reverse().JoinAsString()) {
                    if (Convert.ToString(num, 2) == Convert.ToString(num, 2).Reverse().JoinAsString()) {
                        L.Add(num);
                    }
                }
            }

            return L.Sum();
        }
    }
}
