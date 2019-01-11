using Euler.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions {
    public class Euler60 : IEuler {

        private List<int> primes;

        public Euler60() {
            primes = new IntPrimeSequence().TakeWhile(x => x < 10000).ToList();
        }

        public string Problem {
            get {
                return @"
Project Euler Problem 60

    The primes 3, 7, 109, and 673, are quite remarkable. By taking any two
    primes and concatenating them in any order the result will always be
    prime. For example, taking 7 and 109, both 7109 and 1097 are prime. The sum
    of these four primes, 792, represents the lowest sum for a set of four
    primes with this property.

    Find the lowest sum for a set of five primes for which any two primes
    concatenate to produce another prime.

";
            }
        }

        public string Answer {
            get {
                return "The lowest sum for a set of five primes is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            int res = int.MaxValue;
            HashSet<int>[] pairs = new HashSet<int>[primes.Count()];

            for (int a = 1; a < primes.Count(); a++) {
                if (primes[a] * 5 >= res) {
                    break;
                }

                if (pairs[a] == null) {
                    pairs[a] = MakePairs(a);
                }

                SortedSet<int> testSet = new SortedSet<int>(pairs[a]);

                for (int b = a + 1; b < primes.Count(); b++) {
                    if (primes[a] + primes[b] * 4 >= res) {
                        break;
                    }

                    if (!testSet.Contains(primes[b])) {
                        continue;
                    }

                    if (pairs[b] == null) {
                        pairs[b] = MakePairs(b);
                    }

                    SortedSet<int> tempA = new SortedSet<int>(testSet);
                    testSet.IntersectWith(pairs[b]);

                    if (testSet.Count == 0) {
                        testSet = tempA;
                        continue;
                    }

                    for (int c = b + 1; c < primes.Count(); c++) {
                        if (primes[a] + primes[b] + primes[c] * 3 >= res) {
                            break;
                        }

                        if (!testSet.Contains(primes[c])) {
                            continue;
                        }

                        if (pairs[c] == null) {
                            pairs[c] = MakePairs(c);
                        }

                        SortedSet<int> tempB = new SortedSet<int>(testSet);
                        testSet.IntersectWith(pairs[c]);

                        if (testSet.Count == 0) {
                            testSet = tempB;
                            continue;
                        }

                        for (int d = c + 1; d < primes.Count(); d++) {
                            if (primes[a] + primes[b] + primes[c] + primes[d] * 2 >= res) {
                                break;
                            }

                            if (!testSet.Contains(primes[d])) {
                                continue;
                            }

                            if (pairs[d] == null) {
                                pairs[d] = MakePairs(d);
                            }

                            SortedSet<int> tempC = new SortedSet<int>(testSet);
                            testSet.IntersectWith(pairs[d]);

                            if (testSet.Count == 0) {
                                testSet = tempC;
                                continue;
                            }

                            int e = testSet.Min;

                            if (primes[a] + primes[b] + primes[c] + primes[d] + e < res) {
                                res = primes[a] + primes[b] + primes[c] + primes[d] + e;
                            }

                            testSet = tempC;
                        }

                        testSet = tempB;
                    }

                    testSet = tempA;
                }
            }

            return res;
        }

        private HashSet<int> MakePairs(int a) {
            HashSet<int> pairs = new HashSet<int>();

            for (int b = a + 1; b < primes.Count(); b++) {
                if (primes[a].Concat(primes[b]).IsPrime() && 
                    primes[b].Concat(primes[a]).IsPrime()) {

                    pairs.Add(primes[b]);
                }
            }

            return pairs;
        }
    }
}
