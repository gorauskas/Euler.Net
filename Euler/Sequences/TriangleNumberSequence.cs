using System;
using System.Collections;
using System.Collections.Generic;

namespace Euler.Sequences {
    public class TriangleNumberSequence : IEnumerable<int> {

        private TriangleNumberSequence() { }

        public static IEnumerable<int> NewSequence() {
            return new TriangleNumberSequence();
        }

        public IEnumerator<int> GetEnumerator() {
            return new TriangleNumberEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public class TriangleNumberEnumerator : IEnumerator<int> {
            private int _count = 0;
            private int _current = 0;
            private int _last = 0;

            public void Dispose() { }

            public int Current {
                get { return _current; }
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            public bool MoveNext() {
                _last = _current;
                _count++;
                _current = _last + _count;

                return true;
            }

            public void Reset() {
                throw new NotSupportedException();
            }
        }
    }
}
