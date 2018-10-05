using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Euler.Sequences {

    public abstract class PrimeSequence<T> : IEnumerable<T> {

        protected abstract IEnumerable<T> Sequence { get; }

        public IEnumerator<T> GetEnumerator() {
            return Sequence.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }

    public class IntPrimeSequence : PrimeSequence<int> {

        private readonly IEnumerable<int> seq;

        public IntPrimeSequence() {
            seq = 2.ToMax().Where(x => x.IsPrime());
        }

        protected override IEnumerable<int> Sequence {
            get { return seq; }
        }

    }

    public class LongPrimeSequence : PrimeSequence<long> {

        private readonly IEnumerable<long> seq;

        public LongPrimeSequence() {
            seq = ((long)2).ToMax().Where(x => x.IsPrime());
        }

        protected override IEnumerable<long> Sequence {
            get { return seq; }
        }

    }

}
