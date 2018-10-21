using System;
using System.Collections;
using System.Collections.Generic;

namespace Euler.Sequences {
    public class CollatzSequence : IEnumerable<long> {

        private readonly long _start;

        private CollatzSequence(long start) {
            this._start = start;
        }

        public static CollatzSequence NewSequence(long start) {
            return new CollatzSequence(start);
        }

        public ulong Count {
            get {
                var enumerator = new CollatzEnumerator(_start);
                ulong count = 0;

                while (enumerator.MoveNext())
                    count++;

                return count;
            }
        }

        public IEnumerator<long> GetEnumerator() {
            return new CollatzEnumerator(_start);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public class CollatzEnumerator : IEnumerator<long> {

            private long _current;
            private bool _yieldFirst = true;

            public CollatzEnumerator(long start) {
                _current = start;
            }

            public void Dispose() { }

            public long Current {
                get { return _current; }
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            public bool MoveNext() {
                if (_yieldFirst) {
                    _yieldFirst = false;
                    return true;
                }

                if (_current == 1)
                    return false;

                UpdateCurrent();

                return true;
            }

            private void UpdateCurrent() {
                _current = CalculateNext(_current);
            }

            internal static long CalculateNext(long l) {
                return l.IsEven() ? l / 2 : l * 3 + 1;
            }

            public void Reset() {
                throw new NotSupportedException();
            }
        }
    }
}
