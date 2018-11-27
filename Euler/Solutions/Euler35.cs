using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler35 : IEuler {
        public string Problem {
            get {
                return @"
Project Euler Problem 35:

    The number, 197, is called a circular prime because all rotations of the digits:
    197, 971, and 719, are themselves prime.

    There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71,
    73, 79, and 97.

    How many circular primes are there below one million?

";
            }
        }

        public string Answer {
            get {
                return "There are {0} circular primes below 1 million."
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            // all primes less than 1 million
            var primes = from p in Enumerable.Range(1, 999999) where p.IsPrime() select p;
            // resulting list of circular primes
            List<long> L = new List<long>();

            foreach (var prime in primes) {
                if (CheckRotations((from d in prime.ToString().ToList() select d.ToLong()).ToList(), prime)) {
                    L.Add(prime);
                }
            }

            return L.Count;
        }

        /// <summary>
        /// Checks the circular rotations of each prime number for primes
        /// </summary>
        /// <returns>
        /// True if all rotations are also prime, false otherwise
        /// </returns>
        /// <param name='l'>
        /// a list of digits that makes up the prime nunber n
        /// </param>
        /// <param name='n'>
        /// The prime number to check
        /// </param>
        public bool CheckRotations(List<long> l, long n) {
            var k = 0L;

            while (n != k) {
                // as in Lisp car and cdr
                var cdr = l.Skip(1).Take(l.Count - 1).ToList();
                var car = l[0];

                cdr.Add(car);

                k = cdr.JoinAsString().ToLong();

                if (!k.IsPrime()) {
                    return false;
                }

                l = cdr;
            }

            return true;
        }
    }
}
