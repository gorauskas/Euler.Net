using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Euler.Sequences;

namespace Euler.Solutions {
    public class Euler46 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 46

    It was proposed by Christian Goldbach that every odd composite number can
    be written as the sum of a prime and twice a square.

    9 = 7 + 2×12
    15 = 7 + 2×22
    21 = 3 + 2×32
    25 = 7 + 2×32
    27 = 19 + 2×22
    33 = 31 + 2×12

    It turns out that the conjecture was false.

    What is the smallest odd composite that cannot be written as the sum of a
    prime and twice a square?

";
            }
        }

        public string Answer {
            get {
                return "The smallest odd composite that cannot be written as the sum of a prime and twice a square is {0}"
                    .FormatWith(this.Solve());
                
            }
        }

        public double Solve() {
            List<long> primes = new LongPrimeSequence().TakeWhile(x => x < 10000).ToList();
            int r = 1;
            bool nf = true;

            while (nf) {
                r += 2;
                int j = 0;
                nf = false;
                while (r >= primes[j]) {
                    if (twiceSquare(r - primes[j])) {
                        nf = true;
                        break;
                    }
                    j++;
                }
            }

            return r;
        }

        private Func<long, bool> twiceSquare = x => (x / 2.0).Sqrt() % 1.0 == 0;
    }
}
