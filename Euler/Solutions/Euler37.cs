using System;
using System.Collections.Generic;
using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {
    public class Euler37 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 37:

    The number 3797 has an interesting property. Being prime itself, it is
    possible to continuously remove digits from left to right, and remain prime
    at each stage: 3797, 797, 97, and 7. Similarly we can work from right to
    left: 3797, 379, 37, and 3.

    Find the sum of the only eleven primes that are both truncatable from left
    to right and right to left.

    NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

";
            }
        }

        public string Answer {
            get {
                return "The sum of the only eleven primes that are both truncatable left\nand right is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            List<long> L = new List<long>();
            // single digit number we don't care for
            var primes = new LongPrimeSequence().Where(x => x > 10).GetEnumerator(); 
            primes.MoveNext();      // prime the pump (pun intended)                                                      

            while (L.Count < 11) {  // by the problem we only care about the first 11
                if (IsTruncatable(primes.Current)) {
                    L.Add(primes.Current);
                }

                primes.MoveNext();
            }

            return L.Sum();
        }

        private bool IsTruncatable(long n) {
            long m = n;
            while (m > 0) {          // truncate right - divide by 10
                if (!m.IsPrime()) {
                    return false;
                }

                m /= 10;
            }

            long k = 10;             // truncate left - mod by 10, 100, 1000, n
            for (int x = 0; x < n.ToString().Length; x++) {
                if (!(n % k).IsPrime()) {
                    return false;
                }

                k *= 10;
            }

            return true;
        }
    }
}
