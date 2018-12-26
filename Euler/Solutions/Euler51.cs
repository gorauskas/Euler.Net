using Euler.Sequences;
using System;
using System.Linq;

namespace Euler.Solutions {
    public class Euler51 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 51

    By replacing the 1st digit of the 2-digit number *3, it turns out that six
    of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.

    By replacing the 3rd and 4th digits of 56**3 with the same digit, this
    5-digit number is the first example having seven primes among the ten
    generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663,
    56773, and 56993. Consequently 56003, being the first member of this
    family, is the smallest prime with this property.

    Find the smallest prime which, by replacing part of the number (not
    necessarily adjacent digits) with the same digit, is part of an eight prime
    value family.

";
            }
        }

        public string Answer {
            get {
                return "The smallest prime which is part of an eight prime value\nfamily is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            var primes = new IntPrimeSequence().SkipWhile(x => x <= 99999).TakeWhile(x => x <= 1000000).ToList();

            foreach (var prime in primes) {
                string s = prime.ToString();

                for (int x = 0; x < s.Length; x++) {
                    char c = s[x];
                    int count = 0;

                    for (int y = 0; y < 10; y++) {
                        int i = int.Parse(s.Replace(c, char.Parse(y.ToString())));

                        if (i.IsPrime() && i > 100000) {
                            count++;
                        }
                    }

                    if (count > 7) {
                        return int.Parse(s);
                    }
                }
            }

            return 0;
        }
    }
}
