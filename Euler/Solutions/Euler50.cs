using Euler.Sequences;
using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler50 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 50

    The prime 41, can be written as the sum of six consecutive primes:

        41 = 2 + 3 + 5 + 7 + 11 + 13

    This is the longest sum of consecutive primes that adds to a prime below
    one-hundred.

    The longest sum of consecutive primes below one-thousand that adds to a
    prime, contains 21 terms, and is equal to 953.

    Which prime, below one-million, can be written as the sum of the most
    consecutive primes?

";
            }
        }

        public string Answer {
            get {
                return "The prime number is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            // prime list below 1 million
            var pl = new IntPrimeSequence().TakeWhile(x => x < 1000000).ToList();

            foreach (var ub in Enumerable.Range(1, 546).Reverse()) {  // upper bound
                int lb = 0;                                           // lower bound
                var s = pl.Skip(lb).Take(lb + ub).Sum();
                while (s < 1000000) {
                    if (s.IsPrime()) {
                        return s;
                    }

                    lb += 1;
                    s = pl.Skip(lb).Take(lb + ub).Sum();
                }
            }

            return 0;
        }

    }

}
