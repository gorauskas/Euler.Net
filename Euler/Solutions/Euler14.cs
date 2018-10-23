using System.Collections.Generic;
using System.Linq;

using Euler.Sequences;

namespace Euler.Solutions {
    public class Euler14 : IEuler {

        private readonly IDictionary<long, int> _cache = new Dictionary<long, int>();

        public string Problem {
            get {
                return @"
Project Euler Problem 14:

    The following iterative sequence is defined for the n of positive 
    integers:

    n -> n/2      (n is even)
    n -> 3n + 1   (n is odd)

    Using the rule above and starting with 13, we generate the following 
    sequence:

    13  40  20  10  5  16  8  4  2  1
    
    It can be seen that this sequence (starting at 13 and finishing at 1) 
    contains 10 terms. Although it has not been proved yet (Collatz Problem), 
    it is thought that all starting numbers finish at 1.

    Which starting number, under one million, produces the longest chain?

";
            }
        }

        public string Answer {
            get {
                return "The starting number that produces the longest chain is {0}"
                    .FormatWith(this.Solve());
            }
        }

        public double Solve() {
            return 2.To(999999)
                .Select(y => new { Key = y, Len = CalcLen(y) })
                .OrderByDescending(z => z.Len)
                .First()
                .Key;
        }


        private long CalcLen(long n) {
            var uncachedSeq = GetCollatzSequence(n);

            if (uncachedSeq.Any()) {
                AddToCache(uncachedSeq);
            }

            return _cache[n];
        }

        private void AddToCache(IEnumerable<long> uncachedSequence) {
            var lastIn = uncachedSequence.Last();
            var lenAdd = 0;
            var collatzSeqLen = uncachedSequence.Count();

            if (lastIn != 1) {
                var next = CollatzSequence.CollatzEnumerator.CalculateNext(lastIn);
                lenAdd = _cache[next];
            }

            uncachedSequence
                .Select((x, y) => new { Key = x, Value = collatzSeqLen - y + lenAdd })
                .ForEach(z => _cache.Add(z.Key, z.Value));
        }

        private IEnumerable<long> GetCollatzSequence(long n) {
            return CollatzSequence.NewSequence(n).TakeWhile(x => !_cache.ContainsKey(x));
        }
    }
}
