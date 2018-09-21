using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Sequences {
    public class FibonacciSequence : IEnumerable<int> {
        private readonly IEnumerable<int> _sequence;

        private FibonacciSequence() {
            _sequence = 0.ToMax().Select(x => x.CalcFiboTerm());
        }

        public static IEnumerable<int> NewSequence() {
            return new FibonacciSequence();
        }

        public IEnumerator<int> GetEnumerator() {
            return _sequence.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    internal static class FiboSeqExtensions {
        public static int CalcFiboTerm(this int i) {
            if (i == 0) return 0;
            if (i == 1) return 1;
            return CalcFiboTerm(i - 1) + CalcFiboTerm(i - 2);
        }
    }
}
