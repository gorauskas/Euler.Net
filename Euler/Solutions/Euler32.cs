using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler32 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 32:

    We shall say that an n-digit number is pandigital if it makes use of all 
    the digits 1 to n exactly once; for example, the 5-digit number, 15234, 
    is 1 through 5 pandigital.

    The product 7254 is unusual, as the identity, 39 x 186 = 7254, containing 
    multiplicand, multiplier, and product is 1 through 9 pandigital.

    Find the sum of all products whose multiplicand/multiplier/product 
    identity can be written as a 1 through 9 pandigital.

    HINT: Some products can be obtained in more than one way so be sure to 
    only include it once in your sum.

";
            }
        }

        public string Answer {
            get {
                return "The sum of all products whose multiplicand/multiplier/product\nidentity can be written as a 1 through 9 pandigital is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            HashSet<int> p = new HashSet<int>();  //guarantees uniqueness of items

            foreach (var i in 2.To(100)) {
                int start = 1234;

                if (i > 9) {
                    start = 123;
                }

                foreach (var j in start.To(10000 / i + 1)) {
                    string s = (i.ToString() + j.ToString() + (i * j).ToString());
                    if (s.ToLong().IsPanDigital()) {
                        p.Add(i * j);
                    }
                }
            }

            return p.Sum();
        }
    }
}
